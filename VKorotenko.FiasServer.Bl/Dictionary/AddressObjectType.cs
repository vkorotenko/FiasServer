#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:17

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    [Serializable]
    public class AddressObjectType
    {

        public const string Root = "AddressObjectTypes";
        public const string Start = "AS_SOCRBASE_";

        [XmlAttribute(AttributeName = "KOD_T_ST")]
        public short KodTSt { get; set; }
        [XmlAttribute(AttributeName = "SOCRNAME")]
        public string SocrName { get; set; }
        [XmlAttribute(AttributeName = "SCNAME")]
        public string ScName { get; set; }
        [XmlAttribute(AttributeName = "LEVEL")]
        public short Level { get; set; }

        public override bool Equals(object obj)
        {
            var q = obj as AddressObjectType;
            if (q == null) return false;
            return this.KodTSt == q.KodTSt;
        }
    }
}