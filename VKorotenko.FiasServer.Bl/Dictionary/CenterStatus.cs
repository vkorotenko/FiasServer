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
    [Serializable]
    public class CenterStatus
    {
        public const string Root = "CenterStatuses";
        public const string Start = "AS_CENTERST_";
        [XmlAttribute(AttributeName = "CENTERSTID")]
        public byte CenterstId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}