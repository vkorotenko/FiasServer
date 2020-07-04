#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 21:03
#endregion


using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Статус  актуальности
    /// </summary>
    [Serializable]
    public class ActualStatus
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "ActualStatuses";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_ACTSTAT_";
        /// <summary>
        /// ACTSTATID
        /// </summary>
        [XmlAttribute(AttributeName = "ACTSTATID")]
        public byte ActstatId { get; set; }
        /// <summary>
        /// NAME
        /// </summary>
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}
