#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 21:42

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Центральный статус
    /// </summary>
    [Serializable]
    public class CenterStatus
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "CenterStatuses";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_CENTERST_";
        /// <summary>
        /// Идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "CENTERSTID")]
        public byte CenterstId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}