#region License
// Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// email: koroten@ya.ru
// skype:vladimir-korotenko 
// https://vkorotenko.ru
// Создано:  08.09.2019 10:25
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FiasServer.Models;
using Newtonsoft.Json;

namespace FiasServer.Code
{
    /// <summary>
    /// Класс для отдачи списка городов.
    /// </summary>
    public class CitiesSingleton
    {
        private const string Filename = "cityes.json";
        private const string Moscow = "Москва";
        private const string StPetersburg = "Санкт-Петербург";
        private CitiesSingleton()
        {
            try
            {
                var data = File.ReadAllText(Filename);
                var items = JsonConvert.DeserializeObject<City[]>(data);
                var cities = new List<City>();


                var moscow = items.First(x => x.Name == Moscow);
                var st = items.First(x => x.Name == StPetersburg);

                cities.Add(moscow);
                cities.Add(st);
                cities.AddRange(items);
                Items = cities.Distinct().ToArray();
            }
            catch (Exception e)
            {
                Items = Array.Empty<City>();
                Debug.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// Инстанс синглтона
        /// </summary>
        public static CitiesSingleton Instance { get; } = new CitiesSingleton();
        /// <summary>
        /// Список городов
        /// </summary>
        public City[] Items { get; }
    }
}
