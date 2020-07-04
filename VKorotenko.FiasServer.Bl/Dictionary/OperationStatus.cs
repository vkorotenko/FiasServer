#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:10

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Операционный статус
    /// </summary>
    [Serializable]
    public class OperationStatus
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "OperationStatuses";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_OPERSTAT_";
        /// <summary>
        /// Идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "OPERSTATID")]
        public byte OperstatId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}