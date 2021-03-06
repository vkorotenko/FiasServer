﻿#region License
// Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// email: koroten@ya.ru
// skype:vladimir-korotenko 
// https://vkorotenko.ru
// Создано:  19.08.2019 14:38
#endregion

using System;
using System.Text.Json.Serialization;

namespace VKorotenko.Poco
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Регион к которому принадлежит город
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Имя города
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public long Lon { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public long Lat { get; set; }

        /// <summary>
        /// Название для ЧПУ
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Префикс образования, например район или область
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonIgnore]
        public Guid Guid { get; set; }
        /// <summary>
        /// Вышестоящий объект, используется для вывода иерархии
        /// </summary>
        public string Parent { get; set; }
    }
}


