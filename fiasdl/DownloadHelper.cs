﻿#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.06.2020 10:06
#endregion

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VKorotenko.FiasServer.Bl;
using VKorotenko.FiasServer.Bl.Download;
using VKorotenko.FiasServer.Bl.Loggers;

namespace FiasDl
{
    /// <summary>
    /// Вспомогательный класс для закачки данных
    /// </summary>
    public class DownloadHelper
    {
        /// <summary>
        /// Показать список версий
        /// </summary>
        public bool IsListVersions { get; set; }
        /// <summary>
        /// Скачивать XML версию
        /// </summary>
        public bool IsXml { get; set; }
        /// <summary>
        /// Версия файла
        /// </summary>
        public int Version { get; set; } = -1;
        /// <summary>
        /// Список доступных версий
        /// </summary>
        public DownloadFileInfo[] VersionInfo { get; set; }
        /// <summary>
        /// Базовая директория для скачивания
        /// </summary>
        public string BaseDir { get; set; } = "fias";
        /// <summary>
        /// Скачивать ли полную версию
        /// </summary>
        public bool IsFull { get; set; }
        /// <summary>
        /// Конфигурационный файл
        /// </summary>
        public string Config { get; set; }
        /// <summary>
        /// Есть ли конфигурационный файл
        /// </summary>
        public bool HasConfig { get; set; }
        /// <summary>
        /// Запуск скачивания
        /// </summary>
        /// <returns></returns>
        public int Run()
        {
            if (IsListVersions)
            {
                ListVersions().Wait();
                foreach (var info in VersionInfo) Console.WriteLine($"{info.VersionId}\t{info.TextVersion}");
                return 0;
            }
            ListVersions().Wait();
            
            var df = Version == -1 ? VersionInfo.First() : VersionInfo.First(x => x.VersionId == Version);
            Version = df.VersionId;
            if (HasConfig)
            {
                if (!File.Exists(Config)) throw new ArgumentException($"No config file: {Config}");
                var cfg = VKorotenko.Poco.Config.Load(Config);
                var proc = new FileProcessor(cfg.FullPath);
                proc.Run();
                return 1;

            }
            var fileName = IsFull ? "full_" : "delta_";

            if (IsXml)
            {
                fileName += "xml.zip";
            }
            else
            {
                fileName += "dbf.zip";
            }
            var dirPath = Path.Combine(BaseDir, Version.ToString());
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            var url = "";
            if (IsXml && IsFull) url = df.FiasCompleteXmlUrl;
            else if (IsXml && !IsFull) url = df.FiasDeltaXmlUrl;
            else if (!IsXml && !IsFull) url = df.FiasDeltaDbfUrl;
            else if (!IsXml && IsFull) url = df.FiasCompleteDbfUrl;
            else throw new ArgumentException("Wrong combination of file");
            
            var client = new Download(new DebugLogger());
            Console.WriteLine();
            Console.Clear();
            var left = Console.CursorLeft;
            var top = Console.WindowTop;
            client.ProgressChanged += (s, e) =>
            {
                Console.SetCursorPosition(left,top);
                Console.WriteLine($"Downloaded: {e.BytesReceived:N0} bytes. Percent: {e.ProgressPercentage:N0} %");
            };
            client.DownloadFile(url, Path.Combine(dirPath,fileName));
            return 0;
        }

        private async Task ListVersions()
        {
            var data = await Fetcher.GetAllAsync();
            VersionInfo = data;
        }
    }
}