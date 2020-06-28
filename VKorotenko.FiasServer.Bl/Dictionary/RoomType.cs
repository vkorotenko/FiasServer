#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:15

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    [Serializable]
    public class RoomType
    {

        public const string Root = "RoomTypes";
        public const string Start = "AS_ROOMTYPE_";
        [XmlAttribute(AttributeName = "RMTYPEID")]
        public byte RmtypeId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "SHORTNAME")]
        public string ShortName { get; set; }
    }
}