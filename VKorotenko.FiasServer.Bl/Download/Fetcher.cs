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

        public static async Task<DownloadFileInfo> GetLatestAsync()
        {
            using var client = new WebClient();
            var data = await client.DownloadStringTaskAsync(LastUrl);
            var fileInfo = JsonConvert.DeserializeObject<DownloadFileInfo>(data);
            return fileInfo;
        }
        public static async Task<DownloadFileInfo[]> GetAllAsync()
        {
            using var client = new WebClient();
            var data = await client.DownloadStringTaskAsync(AllUrl);
            var fileInfo = JsonConvert.DeserializeObject<DownloadFileInfo[]>(data);
            return fileInfo;
        }
        public static void GetXmlDelta(DownloadFileInfo fi, string file)
        {
            var rcl = new RenewableClient(file, fi.FiasDeltaXmlUrl);
            rcl.Download();
        }
    }
}
