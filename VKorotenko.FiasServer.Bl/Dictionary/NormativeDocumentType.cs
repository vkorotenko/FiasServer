#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:09

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Тип нормативного документа
    /// </summary>
    [Serializable]
    public class NormativeDocumentType
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "NormativeDocumentTypes";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_NDOCTYPE_";
        /// <summary>
        /// Идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "NDTYPEID")]
        public short NdtypeId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}