#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.08.2020 11:22
#endregion

using System;
using System.Threading.Tasks;
using FiasServer.Models;
using VKorotenko.FiasServer.Bl.Download;

namespace FiasServer.Services
{
    public class AdminInfoService
    {
        public SystemInfoModel Model { get; set; }

        public AdminInfoService()
        {
            var model = new SystemInfoModel()
            {
                LastDownload = new DateTime(1977, 02, 16),
                DataDir = @"c:\temp",
            };
            Model = model;
            FetchData().Wait();
        }

        private async Task FetchData()
        {
            var data = await Fetcher.GetAllAsync();
            Model.FilesInfo = data;
        }
    }
}