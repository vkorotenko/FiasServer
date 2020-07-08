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
    /// <summary>
    /// Приложение для ввода данных из архива.
    /// </summary>
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppConfig _appConfig;
        private IDbBackend _back;
        private List<AddressObjectType> _socr;
        private List<AddressObject> _address;
        private List<NormativeDocument> _normDocs;
        private HashSet<Guid> _normDocIds;
        private List<House> _houses;
        private HashSet<HouseNum> _houseNums;
        private HashSet<string> _houseNumsNames;
        private List<BuildNum> _buildNum;
        private List<string> _buildNumNames;
        private readonly DateTime _start = DateTime.Now;
        private HashSet<Stead> _stead;
        private HashSet<Guid> _steadIds;
        private const string HouseNumFile = "housenum.csv";
        private const string BuildNumFile = "builnum.csv";

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
                        case Stead.Start:
                            await ProcessStead();
                            break;
                        case House.Start:
                            await ProcessHouse();
                            break;
                        default:
                            _logger.LogError("Пустой список таблиц для обработки.");
                            return;
                    }
                }
            }
        }

        #region Обработка домов

        private async Task ProcessHouse()
        {
            _houses = new List<House>();
            _buildNumNames = new List<string>();
            _houseNumsNames = new HashSet<string>();
            if (File.Exists(HouseNumFile) && File.Exists(BuildNumFile))
            {
                _buildNumNames.AddRange(File.ReadAllLines(BuildNumFile));
                var houses = File.ReadAllLines(HouseNumFile);
                foreach (var house in houses)
                {
                    _houseNumsNames.Add(house);
                }
                HouseComplete(this, new EventArgs());
            }
            else
            {
                _logger.LogInformation(DateTime.Now + " Start House dict");
                var proc = new HouseProcessor(_appConfig.FullPath);
                proc.Complete += HouseComplete;
                proc.ItemParsed += OnHouseParsed;
                Console.WriteLine();
                await proc.RunDictionary();
            }
        }
        private void OnHouseParsed(object sender, HouseEventArgs args)
        {
            _houses.Add(args.Item);
            if (_houses.Count % 10000 != 0) return;
            InsertHouse();
            var now = DateTime.Now;
            var top = Console.CursorTop;
            Console.SetCursorPosition(0, top - 1);
            Console.WriteLine($"{(now - _start).TotalSeconds:N1} s. Process: {(args.Count + 1):N0}");
        }
        private void HouseComplete(object sender, EventArgs args)
        {
            InsertHouse();

            var builds = _buildNumNames.Select(name => new BuildNum { Name = name });
            _back.BuildNumbers.Truncate();
            
            _back.BuildNumbers.AddRange(builds);

            File.WriteAllLines(BuildNumFile, _buildNumNames);
            File.WriteAllLines(HouseNumFile, _houseNumsNames.ToArray());
            var i = 1;
            var houses = _houseNumsNames.Select(name => new HouseNum() { Id = i++, Name = name }).ToList();
            _back.HouseNumbers.Truncate();
            try
            {
                _back.HouseNumbers.AddRange(houses);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }




            _logger.LogInformation(DateTime.Now + " End House dict");

            _logger.LogInformation(DateTime.Now + " Start House ");
            _buildNumNames.Clear();
            _houseNumsNames.Clear();

            _buildNum = _back.BuildNumbers.All().ToList();
            _houseNums = _back.HouseNumbers.All().ToHashSet();

            _houses = new List<House>();
            var proc = new HouseProcessor(_appConfig.FullPath);
            proc.Complete += HouseFullComplete;
            proc.ItemParsed += OnHouseFullParsed;
            Console.WriteLine();
            proc.Run().Wait();
        }

        private void OnHouseFullParsed(object sender, HouseEventArgs args)
        {
            _houses.Add(args.Item);
            if (_houses.Count % 10000 != 0) return;
            InsertFullHouse();
            var now = DateTime.Now;
            var top = Console.CursorTop;
            Console.SetCursorPosition(0, top - 1);
            Console.WriteLine($"{(now - _start).TotalSeconds:N1} s. Process: {(args.Count + 1):N0}");
        }

        private void InsertFullHouse()
        {
            foreach (var house in _houses)
            {
                if (!string.IsNullOrWhiteSpace(house.HOUSENUM))
                {
                    var nn = _houseNums.FirstOrDefault(x => x.Name == house.HOUSENUM.Trim().Replace("&quot;","\""));
                    if (nn != null)
                        house.HOUSENUM_IX = nn.Id;
                    else
                        Debug.WriteLine(house.HOUSENUM);
                }
                if (!string.IsNullOrWhiteSpace(house.BUILDNUM))
                {
                    var nn = _buildNum.First(x => x.Name == house.BUILDNUM.Trim().Replace("&quot;", "\""));
                    if (nn != null)
                        house.BUILDNUM_IX = nn.Id;
                    else
                        Debug.WriteLine(house.BUILDNUM);
                }
            }
            _back.Houses.AddRange(_houses);
            _houses.Clear();
        }

        private void HouseFullComplete(object sender, EventArgs args)
        {
            InsertFullHouse();
            _logger.LogInformation(DateTime.Now + " End House");
            _buildNum.Clear();
            _houseNums.Clear();
        }

        private void InsertHouse()
        {
            foreach (var house in _houses)
            {
                var hn = house.HOUSENUM;
                if (!string.IsNullOrWhiteSpace(hn) && !_houseNumsNames.Contains(hn))
                {
                    _houseNumsNames.Add(hn);
                }

                var bn = house.BUILDNUM;
                if (!string.IsNullOrWhiteSpace(bn) && !_buildNumNames.Contains(bn))
                {
                    _buildNumNames.Add(bn);
                }
            }
            _houses.Clear();
        }

        #endregion
        #region Stead
        private async Task ProcessStead()
        {
            _logger.LogInformation(DateTime.Now + " Start Stead");
            var proc = new SteadProcessor(_appConfig.FullPath);
            _stead = new HashSet<Stead>();
            _steadIds = new HashSet<Guid>();
            proc.Complete += SteadComplete;
            proc.SteadParsed += OnSteadParsed;
            Console.WriteLine();
            await proc.Run();
        }
        private void OnSteadParsed(object sender, SteadEventArgs args)
        {
            if (!_steadIds.Contains(args.Document.STEADID))
            {
                _steadIds.Add(args.Document.STEADID);
                _stead.Add(args.Document);
            }
            if (_stead.Count % 10000 != 0) return;
            InsertStead();
            var now = DateTime.Now;
            var top = Console.CursorTop;
            Console.SetCursorPosition(0, top - 1);
            Console.WriteLine($"{(now - _start).TotalSeconds:N1} s. Process: {(args.Count + 1):N0}");
        }
        private void SteadComplete(object sender, EventArgs args)
        {
            InsertStead();
            _steadIds.Clear();
            _logger.LogInformation(DateTime.Now + " End Stead");
        }
        private void InsertStead()
        {
            _back.Steads.AddRange(_stead);
            _stead.Clear();
        }
        #endregion
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
            _normDocIds.Clear();
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
