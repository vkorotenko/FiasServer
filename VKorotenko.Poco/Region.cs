#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 8:56

#endregion

using System;
using System.Text.Json.Serialization;

namespace VKorotenko.Poco
{
    /// <summary>
    /// Регион для выбора
    /// </summary>
    public class Region
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Название региона
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Край, область и т.д.
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// Название для ЧПУ
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Идентификатор региона
        /// </summary>
        [JsonIgnore]
        public Guid Guid { get; set; }
    }
}