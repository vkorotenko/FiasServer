#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:10

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    [Serializable]
    public class OperationStatus
    {

        public const string Root = "OperationStatuses";
        public const string Start = "AS_OPERSTAT_";
        [XmlAttribute(AttributeName = "OPERSTATID")]
        public byte OperstatId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}