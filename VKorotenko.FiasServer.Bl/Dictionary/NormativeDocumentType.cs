#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:09

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    [Serializable]
    public class NormativeDocumentType
    {

        public const string Root = "NormativeDocumentTypes";
        public const string Start = "AS_NDOCTYPE_";
        [XmlAttribute(AttributeName = "NDTYPEID")]
        public Int16 NdtypeId { get; set; }
        [XmlAttribute(AttributeName = "NAME")]
        public string Name { get; set; }
    }
}