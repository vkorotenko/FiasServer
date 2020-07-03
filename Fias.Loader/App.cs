#region License
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
using VKorotenko.FiasServer.Bl.PureData;

namespace Fias.Loader
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppConfig _appConfig;
        private IDbBackend _back;
        private List<AddressObjectType> _socr;
        private List<AddressObject> _address;
        private List<NormativeDocument> _normDocs;
        private HashSet<Guid> _normDocIds;
        private readonly DateTime _start = DateTime.Now;

        /// <summary>
        /// Конструктор приложения 
        /// </summary>
        /// <param name="logger">Экземпляр логгера</param>
        /// <param name="appSettings">Настройки приложения</param>
        public App(ILogger<App> logger, IOptions<AppConfig> appSettings)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appConfig = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }
        /// <summary>
        /// Запуск обработки данных.
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            await Task.Delay(0);
            Loader(_appConfig.DbBack);
            if (_back != null)
            {
                _back.Init(_appConfig.FiasConnection);

                ProcessDictionary();

                foreach (var table in _appConfig.ProcessTables)
                {
                    switch (table)
                    {
                        case XmlAddressObject.Start:
                            ProcessAddress();
                            break;
                        case NormativeDocument.Start:
                            await ProcessNormativeDocument();
                            break;
                        default:
                            _logger.LogError("Пустой список таблиц для обработки.");
                            return;
                    }
                }



            }
        }
        #region Обработка нормативных документов
        private async Task ProcessNormativeDocument()
        {
            _logger.LogInformation(DateTime.Now + " Start NormativeDocument");
            var proc = new NormativeDocumentProcessor(_appConfig.FullPath);
            _normDocs = new List<NormativeDocument>();
            _normDocIds = new HashSet<Guid>();
            proc.Complete += DocumentComplete;
            proc.DocumentParsed += OnDocumentParsed;
            Console.WriteLine();
            await proc.Run();
        }

        private void OnDocumentParsed(object sender, NormativeDocumentEventArgs args)
        {
            if (!_normDocIds.Contains(args.Document.NormDocId))
            {
                _normDocIds.Add(args.Document.NormDocId);
                _normDocs.Add(args.Document);
            }
            if (_normDocs.Count % 10000 != 0) return;
            InsertDocument();
            var now = DateTime.Now;
            var top = Console.CursorTop;
            Console.SetCursorPosition(0, top - 1);
            Console.WriteLine($"{(now - _start).TotalSeconds:N1} s. Process: {(args.Count + 1):N0}");
        }

        private void DocumentComplete(object sender, EventArgs args)
        {
            InsertDocument();
            _logger.LogInformation(DateTime.Now + " End Document");
        }

        private void InsertDocument()
        {
            _back.NormativeDocument.AddRange(_normDocs);
            _normDocs.Clear();
        }

        #endregion

        private void ProcessDictionary()
        {
            var proc = new FileProcessor(_appConfig.FullPath);
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
        }

        #region Обработка адресов 
        private void ProcessAddress()
        {
            _logger.LogInformation(DateTime.Now + " Start Address");
            var address = new AddressProcessor(_appConfig.FullPath);
            _address = new List<AddressObject>();
            address.Complete += AddressComplete;
            address.AddressParsed += AddressAddressParsed;
            Console.WriteLine();
            address.Run();
        }
        private void AddressAddressParsed(object sender, AddressProcessorEventArgs args)
        {
            _address.Add(args.Address);
            if (_address.Count % 10000 != 0) return;
            InsertAddress();
            var now = DateTime.Now;
            var top = Console.CursorTop;
            Console.SetCursorPosition(0, top - 1);
            Console.WriteLine($"{(now - _start).TotalSeconds:N1} s. \tProcess: {(args.Count + 1):N0}");
        }

        private void InsertAddress()
        {
            foreach (var a in _address) a.SHORTNAMEID = _socr.First(x => x.ScName == a.SHORTNAME).KodTSt;
            _back.AddressRepository.AddRange(_address);
            _address.Clear();
        }

        private void AddressComplete(object sender, EventArgs args)
        {
            InsertAddress();
            _logger.LogInformation(DateTime.Now + " End Address");
        }
        #endregion
        #region Служебные методы для подгрузки плагина бвижка БД
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
        #endregion
    }
}
