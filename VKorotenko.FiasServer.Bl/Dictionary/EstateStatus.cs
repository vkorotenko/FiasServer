#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:05

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Estate
    /// </summary>
    [Serializable]
    public class EstateStatus
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "EstateStatuses";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_ESTSTAT_";
        /// <summary>
        /// Идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "ESTSTATID")]
        public byte EststatId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
        /// <summary>
        /// Сокращение
        /// </summary>
        [XmlAttribute(AttributeName = "SHORTNAME")]
        public string ShortName { get; set; }
    }
}