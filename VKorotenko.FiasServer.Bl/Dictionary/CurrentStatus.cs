#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 21:57

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Текущий статус актуальности
    /// </summary>
    [Serializable]
    public class CurrentStatus
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "CurrentStatuses";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_CURENTST_";
        /// <summary>
        /// Идентификатор
        /// </summary>
        [XmlAttribute(AttributeName = "CURENTSTID")]
        public byte CurentstId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}