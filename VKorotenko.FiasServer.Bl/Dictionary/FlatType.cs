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
    [Serializable]
    public class FlatType
    {

        public const string Root = "FlatTypes";
        public const string Start = "AS_FLATTYPE_";
        [XmlAttribute(AttributeName = "FLTYPEID")]
        public byte FltypeId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "SHORTNAME")]
        public string ShortName { get; set; }
    }
}