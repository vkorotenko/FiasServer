#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:22

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Структурный тип
    /// </summary>
    [Serializable]
    public class StructureStatus
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "StructureStatuses";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_STRSTAT_";
        /// <summary>
        /// идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "STRSTATID")]
        public byte StrstatId { get; set; }
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