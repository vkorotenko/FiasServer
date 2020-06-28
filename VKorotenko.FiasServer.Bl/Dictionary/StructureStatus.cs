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
    [Serializable]
    public class StructureStatus
    {

        public const string Root = "StructureStatuses";
        public const string Start = "AS_STRSTAT_";
        [XmlAttribute(AttributeName = "STRSTATID")]
        public byte StrstatId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "SHORTNAME")]
        public string ShortName { get; set; }
    }
}