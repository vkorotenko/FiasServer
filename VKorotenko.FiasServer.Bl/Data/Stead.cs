#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.07.2020 20:51
#endregion


using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Data
{
    public class Stead
    {
        #region Служебные константы
        public const string Root = "Steads";
        public const string Start = "AS_STEAD_";
        public const string Table = "STEAD";
        public const string ContainerTag = "Stead";
        #endregion
        #region Поля
        [XmlAttribute(SteadTags.STEADGUID)]
        public Guid STEADGUID { get; set; }
        [XmlAttribute(SteadTags.NUMBER), MaxLength(120)]
        public string Number { get; set; }
        [XmlAttribute(SteadTags.REGIONCODE)]
        public int RegionCode { get; set; }
        [XmlAttribute(SteadTags.POSTALCODE)]
        public string PostalCode { get; set; }
        [XmlAttribute(SteadTags.IFNSFL)]
        public string IFNSFL { get; set; }
        [XmlAttribute(SteadTags.TERRIFNSFL)]
        public string TERRIFNSFL { get; set; }
        [XmlAttribute(SteadTags.IFNSUL)]
        public string IFNSUL { get; set; }
        [XmlAttribute(SteadTags.TERRIFNSUL)]
        public string TERRIFNSUL { get; set; }
        [XmlAttribute(SteadTags.OKATO)]
        public string OKATO { get; set; }
        [XmlAttribute(SteadTags.OKTMO)]
        public string OKTMO { get; set; }

        [XmlAttribute(SteadTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }
        [XmlAttribute(SteadTags.PARENTGUID)]
        public string PARENTGUID { get; set; }
        [XmlAttribute(SteadTags.STEADID)]
        public Guid STEADID { get; set; }
        [XmlAttribute(SteadTags.PREVID)]
        public string PREVID { get; set; }
        [XmlAttribute(SteadTags.NEXTID)]
        public string NEXTID { get; set; }
        [XmlAttribute(SteadTags.OPERSTATUS)]
        public long OPERSTATUS { get; set; }
        [XmlAttribute(SteadTags.STARTDATE)]
        public DateTime STARTDATE { get; set; }
        [XmlAttribute(SteadTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }

        [XmlAttribute(SteadTags.NORMDOC)]
        public string NORMDOC { get; set; }
        [XmlAttribute(SteadTags.LIVESTATUS)]
        public byte LIVESTATUS { get; set; }
        [XmlAttribute(SteadTags.CADNUM), MaxLength(100)]
        public string CADNUM { get; set; }
        [XmlAttribute(SteadTags.DIVTYPE)]
        public int DIVTYPE { get; set; } 
        #endregion
        public Stead() { }

        public Stead(string xml)
        {
            LoadXml(xml);
        }
        public void LoadXml(string source)
        {
            var serializer = new XmlSerializer(GetType());
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(source));
            var obj = serializer.Deserialize(ms);
            foreach (var p in obj.GetType().GetProperties())
            {
                var p2 = GetType().GetProperty(p.Name);
                if (p2 != null && p2.CanWrite) p2.SetValue(this, p.GetValue(obj, null), null);
            }
        }
    }
}
