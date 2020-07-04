#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:06

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Тип помещения
    /// </summary>
    [Serializable]
    public class FlatType
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "FlatTypes";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_FLATTYPE_";
        /// <summary>
        /// Идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "FLTYPEID")]
        public byte FltypeId { get; set; }
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