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
    [Serializable]
    public class EstateStatus
    {
        
        public const string Root = "EstateStatuses";
        public const string Start = "AS_ESTSTAT_";
        [XmlAttribute(AttributeName = "ESTSTATID")]
        public byte EststatId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "SHORTNAME")]
        public string ShortName { get; set; }
    }
}