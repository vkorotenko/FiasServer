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
    [Serializable]
    public class CurrentStatus
    {
        public const string Root = "CurrentStatuses";
        public const string Start = "AS_CURENTST_";
        [XmlAttribute(AttributeName = "CURENTSTID")]
        public byte CurentstId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}