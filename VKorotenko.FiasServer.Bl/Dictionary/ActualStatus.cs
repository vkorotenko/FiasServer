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
    [Serializable]
    public class ActualStatus
    {
        public const string Root = "ActualStatuses";
        public const string Start = "AS_ACTSTAT_";
        [XmlAttribute(AttributeName = "ACTSTATID")]
        public byte ActstatId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}
