#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.07.2020 12:32
#endregion

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Data
{
    /// <summary>
    /// Объект дома
    /// </summary>
    public class House
    {
        #region Служебные константы
        /// <summary>
        /// Корневой элемент в файле
        /// </summary>
        public const string Root = "Houses";
        /// <summary>
        /// Название файла в архиве
        /// </summary>
        public const string Start = "AS_HOUSE_";
        /// <summary>
        /// Таблица в БД
        /// </summary>
        public const string Table = "HOUSE";
        /// <summary>
        /// Тэг в документе
        /// </summary>
        public const string ContainerTag = "House";
        #endregion

        #region Поля
        /// <summary>
        /// IFNSFL
        /// </summary>
        [XmlAttribute(HouseTags.IFNSFL)]
        public string IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [XmlAttribute(HouseTags.TERRIFNSFL)]
        public string TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [XmlAttribute(HouseTags.IFNSUL)]
        public string IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [XmlAttribute(HouseTags.TERRIFNSUL)]
        public string TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [XmlAttribute(HouseTags.OKATO)]
        public string OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [XmlAttribute(HouseTags.OKTMO)]
        public string OKTMO { get; set; }
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [XmlAttribute(HouseTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }
        /// <summary>
        /// ESTSTATUS
        /// </summary>
        [XmlAttribute(HouseTags.ESTSTATUS)]
        public short ESTSTATUS { get; set; }
        /// <summary>
        /// STRUCNUM
        /// </summary>
        [XmlAttribute(HouseTags.STRUCNUM)]
        public string STRUCNUM { get; set; }
        /// <summary>
        /// STRSTATUS
        /// </summary>
        [XmlAttribute(HouseTags.STRSTATUS)]
        public string STRSTATUS { get; set; }
        /// <summary>
        /// HOUSEID
        /// </summary>
        [XmlAttribute(HouseTags.HOUSEID)]
        public Guid HOUSEID { get; set; }
        /// <summary>
        /// HOUSEGUID
        /// </summary>
        [XmlAttribute(HouseTags.HOUSEGUID)]
        public Guid HOUSEGUID { get; set; }
        /// <summary>
        /// AOGUID
        /// </summary>
        [XmlAttribute(HouseTags.AOGUID)]
        public Guid AOGUID { get; set; }

        /// <summary>
        /// STARTDATE
        /// </summary>
        [XmlAttribute(HouseTags.STARTDATE)]
        public DateTime STARTDATE { get; set; }
        /// <summary>
        /// ENDDATE
        /// </summary>
        [XmlAttribute(HouseTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }
        /// <summary>
        /// STATSTATUS
        /// </summary>
        [XmlAttribute(HouseTags.STATSTATUS)]
        public long STATSTATUS { get; set; }
        /// <summary>
        /// NORMDOC
        /// </summary>
        [XmlAttribute(HouseTags.NORMDOC)]
        public string NORMDOC { get; set; }

        /// <summary>
        /// COUNTER
        /// </summary>
        [XmlAttribute(HouseTags.COUNTER)]
        public short COUNTER { get; set; }

        /// <summary>
        /// CADNUM
        /// </summary>
        [XmlAttribute(HouseTags.CADNUM)]
        public string CADNUM { get; set; }
        /// <summary>
        /// DIVTYPE
        /// </summary>
        [XmlAttribute(HouseTags.DIVTYPE)]
        public byte DIVTYPE { get; set; }

        /// <summary>
        /// POSTALCODE
        /// </summary>
        [XmlAttribute(HouseTags.POSTALCODE)]
        public string POSTALCODE { get; set; }

        /// <summary>
        /// REGIONCODE
        /// </summary>
        [XmlAttribute(HouseTags.REGIONCODE)]
        public string REGIONCODE { get; set; }

        /// <summary>
        /// HOUSENUM
        /// </summary>
        [XmlAttribute(HouseTags.HOUSENUM)]
        public string HOUSENUM { get; set; }
        /// <summary>
        /// Индекс названия дома
        /// </summary>
        public int? HOUSENUM_IX { get; set; }
        /// <summary>
        /// BUILDNUM
        /// </summary>
        [XmlAttribute(HouseTags.BUILDNUM)]
        public string BUILDNUM { get; set; }
        /// <summary>
        /// Индекс строения
        /// </summary>
        public short? BUILDNUM_IX { get; set; }
        #endregion
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public House() { }
        /// <summary>
        /// Конструктор на основе XML
        /// </summary>
        /// <param name="xml"></param>
        public House(string xml)
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
