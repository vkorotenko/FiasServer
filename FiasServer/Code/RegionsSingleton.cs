#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  20.07.2020 16:06

#endregion

using System;
using System.Diagnostics;
using System.IO;
using FiasServer.Models;
using Newtonsoft.Json;

namespace FiasServer.Code
{
    /// <summary>
    /// Синглтон для регионов.
    /// </summary>
    public class RegionsSingleton
    {
        private const string Filename = "regions.json";
        private RegionsSingleton()
        {
            try
            {
                var data = File.ReadAllText(Filename);
                Items = JsonConvert.DeserializeObject<Region[]>(data);
            }
            catch (Exception e)
            {
                Items = Array.Empty<Region>();
                Debug.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// Инстанс
        /// </summary>
        public static RegionsSingleton Instance { get; } = new RegionsSingleton();
        /// <summary>
        /// Список регионов
        /// </summary>
        public Region[] Items { get; }
    }
}