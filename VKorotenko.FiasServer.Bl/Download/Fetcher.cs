#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 12:19
#endregion

using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKorotenko.FiasServer.Bl.Download
{
    /// <summary>
    /// Получение информации об актуальных пакетах
    /// </summary>
    public class Fetcher
    {
        /// <summary>
        /// Адрес полного пакета
        /// </summary>
        public const string AllUrl = "http://fias.nalog.ru/WebServices/Public/GetAllDownloadFileInfo";
        /// <summary>
        /// Адрес последнего обновления.
        /// </summary>
        public const string LastUrl = "http://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";
        /// <summary>
        /// Получение последней версии для скачивания
        /// </summary>
        /// <returns></returns>
        public static async Task<DownloadFileInfo> GetLatestAsync()
        {
            using var client = new WebClient();
            var data = await client.DownloadStringTaskAsync(LastUrl);
            var fileInfo = JsonConvert.DeserializeObject<DownloadFileInfo>(data);
            return fileInfo;
        }
        /// <summary>
        /// Получение информации о всех скачиваниях
        /// </summary>
        /// <returns>Информация о скачиваемых файлах</returns>
        public static async Task<DownloadFileInfo[]> GetAllAsync()
        {
            using var client = new WebClient();
            var data = await client.DownloadStringTaskAsync(AllUrl);
            var fileInfo = JsonConvert.DeserializeObject<DownloadFileInfo[]>(data);
            return fileInfo;
        }
        /// <summary>
        /// Скачивание файла с информации о файлах
        /// </summary>
        /// <param name="fi">Информация о скачивании</param>
        /// <param name="file">Куда сохранять</param>
        public static void GetXmlDelta(DownloadFileInfo fi, string file)
        {
            var rcl = new RenewableClient(file, fi.FiasDeltaXmlUrl);
            rcl.Download();
        }
    }
}
