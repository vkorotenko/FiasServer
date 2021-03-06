﻿#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 22:27
#endregion

using System;
using System.IO.Compression;
using System.Xml.Serialization;
using VKorotenko.FiasServer.Bl.Dictionary;
using VKorotenko.FiasServer.Bl.Loggers;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Обработчик словарей. 
    /// </summary>
    public class FileProcessor
    {
        private readonly string _fullPath;
        private readonly ILogger _logger = new DebugLogger();
        /// <summary>
        /// Результаты обработки словарей
        /// </summary>
        public readonly DictResult Result = new DictResult();
        /// <summary>
        /// Обработчик словарей
        /// </summary>
        /// <param name="fiasZipPath">Полный путь к архиву ФИАС</param>
        /// <param name="logger"></param>
        public FileProcessor(string fiasZipPath, ILogger logger = null)
        {
            _fullPath = fiasZipPath;
            if (logger != null) _logger = logger;
        }
        /// <summary>
        /// Запуск обработки
        /// </summary>
        public void Run()
        {
            using var archive = ZipFile.OpenRead(_fullPath);
            FillInDictionaries(archive);
           
        }
        private void FillInDictionaries(ZipArchive archive)
        {
            _logger.LogMessage($"Start fill in dictionary: {DateTime.Now}");
            foreach (var entry in archive.Entries)
            {
                if (entry.FullName.StartsWith(ActualStatus.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(ActualStatus[]), new XmlRootAttribute(ActualStatus.Root));
                    Result.ActualStatuses = (ActualStatus[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(AddressObjectType.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter =
                        new XmlSerializer(typeof(AddressObjectType[]), new XmlRootAttribute(AddressObjectType.Root));
                    Result.AddressObjectTypes = (AddressObjectType[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(CenterStatus.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(CenterStatus[]), new XmlRootAttribute(CenterStatus.Root));
                    Result.CenterStatuses = (CenterStatus[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(CurrentStatus.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(CurrentStatus[]), new XmlRootAttribute(CurrentStatus.Root));
                    Result.CurrentStatuses = (CurrentStatus[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(EstateStatus.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(EstateStatus[]), new XmlRootAttribute(EstateStatus.Root));
                    Result.EstateStatuses = (EstateStatus[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(FlatType.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(FlatType[]), new XmlRootAttribute(FlatType.Root));
                    Result.FlatTypes = (FlatType[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(NormativeDocumentType.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(NormativeDocumentType[]),
                        new XmlRootAttribute(NormativeDocumentType.Root));
                    Result.NormativeDocumentTypes = (NormativeDocumentType[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(OperationStatus.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(OperationStatus[]), new XmlRootAttribute(OperationStatus.Root));
                    Result.OperationStatuses = (OperationStatus[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(RoomType.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(RoomType[]), new XmlRootAttribute(RoomType.Root));
                    Result.RoomTypes = (RoomType[])formatter.Deserialize(str);
                }

                if (entry.FullName.StartsWith(StructureStatus.Start, StringComparison.OrdinalIgnoreCase))
                {
                    var str = entry.Open();
                    var formatter = new XmlSerializer(typeof(StructureStatus[]), new XmlRootAttribute(StructureStatus.Root));
                    Result.StructureStatuses = (StructureStatus[])formatter.Deserialize(str);
                }
            }
            _logger.LogMessage($"End fill in dictionary: {DateTime.Now}");
        }
    }
}
