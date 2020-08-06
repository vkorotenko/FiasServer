#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.08.2020 9:51

#endregion

using System;
using VKorotenko.FiasServer.Bl.Download;

namespace FiasServer.Models
{
    public class SystemInfoModel
    {
        public DateTime LastDownload { get; set; }
        public string DataDir { get; set; }
        public DownloadFileInfo[] FilesInfo { get; set; }
    }
}