﻿#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 9:16
#endregion

using Fias.Loader.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VKorotenko.FiasServer.Bl;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.Dictionary;
using VKorotenko.Poco;

namespace Fias.Loader
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppConfig _appConfig;
        private IDbBackend _back;
        private List<AddressObjectType> _socr;
        private List<AddressObject> _address;
        private DateTime _start = DateTime.Now;
        public async Task Run()
        {
            await Task.Delay(0);
            Loader(_appConfig.DbBack);
            if (_back != null)
            {
                _back.Init(_appConfig.FiasConnection);
                var config = new Config()
                {
                    FullPath = _appConfig.FullPath
                };
                var proc = new FileProcessor(config);
                proc.Run();
                _logger.LogInformation("Start import dictionary");
                _back.Insert(proc.Result.AddressObjectTypes);
                _socr = new List<AddressObjectType>(proc.Result.AddressObjectTypes);
                _back.Insert(proc.Result.FlatTypes);
                _back.Insert(proc.Result.NormativeDocumentTypes);
                _back.Insert(proc.Result.RoomTypes);
                _back.Insert(proc.Result.ActualStatuses);
                _back.Insert(proc.Result.CenterStatuses);
                _back.Insert(proc.Result.CurrentStatuses);
                _back.Insert(proc.Result.EstateStatuses);
                _back.Insert(proc.Result.OperationStatuses);
                _back.Insert(proc.Result.StructureStatuses);
                _logger.LogInformation("End import dictionary");

                _logger.LogInformation(DateTime.Now + " Start Address");
                var address = new AddressProcessor(config);
                _address = new List<AddressObject>();
                address.Complete += Address_Complete;
                address.AddressParsed += Address_AddressParsed;
                address.Run();
            }
        }

        private void Address_AddressParsed(object sender, AddressProcessorEventArgs args)
        {
            _address.Add(args.Address);
            if (_address.Count % 10000 == 0)
            {
                ProcessAddress();
                var now = DateTime.Now;
                Console.WriteLine($"{(now - _start).TotalSeconds:N1} \tProcess: {(args.Count + 1):N0}");
                //_logger.LogInformation($"Process: {args.Count}");
            }
        }

        private void ProcessAddress()
        {
            foreach (var a in _address)
            {
                a.SHORTNAMEID = _socr.First(x => x.ScName == a.SHORTNAME).KodTSt;
            }
            _back.AddressRepository.AddRange(_address);
            _address.Clear();
        }

        private void Address_Complete(object sender, EventArgs args)
        {
            ProcessAddress();
            _logger.LogInformation(DateTime.Now + " End Address");
        }

        public App(ILogger<App> logger, IOptions<AppConfig> appSettings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appConfig = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }
        private void Loader(string assemblyFile)
        {
            Type[] types = null;

            try
            {
                var asm = Assembly.LoadFrom(assemblyFile);
                types = asm.GetTypes();
            }
            catch (Exception ex)
            {
                var msg = $"Unable to load add-in assembly: {Path.GetFileNameWithoutExtension(assemblyFile)}";
                Debug.WriteLine(ex.Message);
                return;
            }

            foreach (var type in types)
            {
                var typeList = type.FindInterfaces(InterfaceFilter, typeof(IDbBackend));
                if (typeList.Length <= 0) continue;
                var ai = Activator.CreateInstance(type) as IDbBackend;
                _back = ai;
            }
        }

        private static bool InterfaceFilter(Type m, object criteria)
        {
            return m.ToString() == criteria.ToString();
        }
    }
}