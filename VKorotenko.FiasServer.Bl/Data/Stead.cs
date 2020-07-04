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
    /// <summary>
    /// Stead
    /// </summary>
    public class Stead
    {
        #region Служебные константы
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "Steads";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_STEAD_";
        /// <summary>
        /// Таблица
        /// </summary>
        public const string Table = "STEAD";
        /// <summary>
        /// Тэг элемента
        /// </summary>
        public const string ContainerTag = "Stead";
        #endregion
        #region Поля
        /// <summary>
        /// STEADGUID
        /// </summary>
        [XmlAttribute(SteadTags.STEADGUID)]
        public Guid STEADGUID { get; set; }
        /// <summary>
        /// NUMBER
        /// </summary>
        [XmlAttribute(SteadTags.NUMBER), MaxLength(120)]
        public string Number { get; set; }
        /// <summary>
        /// REGIONCODE
        /// </summary>
        [XmlAttribute(SteadTags.REGIONCODE)]
        public int RegionCode { get; set; }
        /// <summary>
        /// POSTALCODE
        /// </summary>
        [XmlAttribute(SteadTags.POSTALCODE)]
        public string PostalCode { get; set; }
        /// <summary>
        /// IFNSFL
        /// </summary>
        [XmlAttribute(SteadTags.IFNSFL)]
        public string IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [XmlAttribute(SteadTags.TERRIFNSFL)]
        public string TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [XmlAttribute(SteadTags.IFNSUL)]
        public string IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [XmlAttribute(SteadTags.TERRIFNSUL)]
        public string TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [XmlAttribute(SteadTags.OKATO)]
        public string OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [XmlAttribute(SteadTags.OKTMO)]
        public string OKTMO { get; set; }
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [XmlAttribute(SteadTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }
        /// <summary>
        /// PARENTGUID
        /// </summary>
        [XmlAttribute(SteadTags.PARENTGUID)]
        public string PARENTGUID { get; set; }
        /// <summary>
        /// STEADID
        /// </summary>
        [XmlAttribute(SteadTags.STEADID)]
        public Guid STEADID { get; set; }
        /// <summary>
        /// PREVID
        /// </summary>
        [XmlAttribute(SteadTags.PREVID)]
        public string PREVID { get; set; }
        /// <summary>
        /// NEXTID
        /// </summary>
        [XmlAttribute(SteadTags.NEXTID)]
        public string NEXTID { get; set; }
        /// <summary>
        /// OPERSTATUS
        /// </summary>
        [XmlAttribute(SteadTags.OPERSTATUS)]
        public long OPERSTATUS { get; set; }
        /// <summary>
        /// STARTDATE
        /// </summary>
        [XmlAttribute(SteadTags.STARTDATE)]
        public DateTime STARTDATE { get; set; }
        /// <summary>
        /// ENDDATE
        /// </summary>
        [XmlAttribute(SteadTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }
        /// <summary>
        /// NORMDOC
        /// </summary>
        [XmlAttribute(SteadTags.NORMDOC)]
        public string NORMDOC { get; set; }
        /// <summary>
        /// LIVESTATUS
        /// </summary>
        [XmlAttribute(SteadTags.LIVESTATUS)]
        public byte LIVESTATUS { get; set; }
        /// <summary>
        /// CADNUM
        /// </summary>
        [XmlAttribute(SteadTags.CADNUM), MaxLength(100)]
        public string CADNUM { get; set; }
        /// <summary>
        /// DIVTYPE
        /// </summary>
        [XmlAttribute(SteadTags.DIVTYPE)]
        public int DIVTYPE { get; set; } 
        #endregion
        /// <summary>
        /// Конструктор
        /// </summary>
        public Stead() { }
        /// <summary>
        /// Конструктор с разбором XML
        /// </summary>
        /// <param name="xml"></param>
        public Stead(string xml)
        {
            LoadXml(xml);
        }
        private void LoadXml(string source)
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
