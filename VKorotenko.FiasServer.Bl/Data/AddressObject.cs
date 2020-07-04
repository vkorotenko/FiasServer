#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  28.06.2020 14:11
#endregion


using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;
using VKorotenko.FiasServer.Bl.PureData;

namespace VKorotenko.FiasServer.Bl.Data
{
    /// <summary>
    /// Объект  ФИАС
    /// </summary>
    public class AddressObject
    {


        #region Поля
        /// <summary>
        /// Глобальный идентификатор в системе AOGUID
        /// </summary>
        [XmlAttribute(AddressTag.AOGUID)]
        public Guid AoGuid { get; set; }
        /// <summary>
        /// Формальное имя FORMALNAME
        /// </summary>
        [XmlAttribute(AddressTag.FORMALNAME), MaxLength(120)]
        public string FormalName { get; set; }
        /// <summary>
        /// REGIONCODE
        /// </summary>
        [XmlAttribute(AddressTag.REGIONCODE)]
        public short RegionCode { get; set; }
        /// <summary>
        /// AUTOCODE
        /// </summary>
        [XmlAttribute(AddressTag.AUTOCODE)]
        public int AutoCode { get; set; }
        /// <summary>
        /// AREACODE
        /// </summary>
        [XmlAttribute(AddressTag.AREACODE)]
        public int AreaCode { get; set; }
        /// <summary>
        /// CITYCODE
        /// </summary>
        [XmlAttribute(AddressTag.CITYCODE)]
        public int CityCode { get; set; }
        /// <summary>
        /// CTARCODE
        /// </summary>
        [XmlAttribute(AddressTag.CTARCODE)]
        public int CtarCode { get; set; }
        /// <summary>
        /// PLACECODE
        /// </summary>
        [XmlAttribute(AddressTag.PLACECODE)]
        public int PlaceCode { get; set; }
        /// <summary>
        /// PLANCODE
        /// </summary>
        [XmlAttribute(AddressTag.PLANCODE)]
        public int PlanCode { get; set; }
        /// <summary>
        /// STREETCODE
        /// </summary>
        [XmlAttribute(AddressTag.STREETCODE)]
        public int StreetCode { get; set; }
        /// <summary>
        /// EXTRCODE
        /// </summary>
        [XmlAttribute(AddressTag.EXTRCODE)]
        public int ExtrCode { get; set; }
        /// <summary>
        /// SEXTCODE
        /// </summary>

        [XmlAttribute(AddressTag.SEXTCODE)]
        public int SextCode { get; set; }
        /// <summary>
        /// OFFNAME
        /// </summary>
        [XmlAttribute(AddressTag.OFFNAME), MaxLength(120)]
        public string OffName { get; set; }
        /// <summary>
        /// POSTALCODE
        /// </summary>

        [XmlAttribute(AddressTag.POSTALCODE)]
        public int? PostalCode { get; set; }
        /// <summary>
        /// IFNSFL
        /// </summary>
        [XmlAttribute(AddressTag.IFNSFL)]
        public int? IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [XmlAttribute(AddressTag.TERRIFNSFL)]
        public int? TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [XmlAttribute(AddressTag.IFNSUL)]
        public int? IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [XmlAttribute(AddressTag.TERRIFNSUL)]
        public int? TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [XmlAttribute(AddressTag.OKATO)]
        public long? OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [XmlAttribute(AddressTag.OKTMO)]
        public long? OKTMO { get; set; }
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [XmlAttribute(AddressTag.UPDATEDATE)]
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// SHORTNAME
        /// </summary>
        [XmlAttribute(AddressTag.SHORTNAME), MaxLength(200)]
        public string SHORTNAME { get; set; }
        /// <summary>
        /// SHORTNAMEID
        /// </summary>
        [XmlAttribute(AddressTag.SHORTNAMEID)]
        public int SHORTNAMEID { get; set; }
        /// <summary>
        /// AOLEVEL
        /// </summary>
        [XmlAttribute(AddressTag.AOLEVEL)]
        public short AoLevel { get; set; }
        /// <summary>
        /// PARENTGUID
        /// </summary>

        [XmlAttribute(AddressTag.PARENTGUID)]
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// AOID
        /// </summary>
        [XmlAttribute(AddressTag.AOID)]
        public Guid AoId { get; set; }
        /// <summary>
        /// PREVID
        /// </summary>

        [XmlAttribute(AddressTag.PREVID)]
        public Guid? PrevId { get; set; }
        /// <summary>
        /// NEXTID
        /// </summary>
        [XmlAttribute(AddressTag.NEXTID)]
        public Guid? NextId { get; set; }
        /// <summary>
        /// CODE
        /// </summary>
        [XmlAttribute(AddressTag.CODE)]
        public long? Code { get; set; }
        /// <summary>
        /// PLAINCODE
        /// </summary>
        [XmlAttribute(AddressTag.PLAINCODE)]
        public long? PlainCode { get; set; }
        /// <summary>
        /// ACTSTATUS
        /// </summary>
        [XmlAttribute(AddressTag.ACTSTATUS)]
        public short ActStatus { get; set; }
        /// <summary>
        /// CENTSTATUS
        /// </summary>
        [XmlAttribute(AddressTag.CENTSTATUS)]
        public short CentStatus { get; set; }
        /// <summary>
        /// OPERSTATUS
        /// </summary>
        [XmlAttribute(AddressTag.OPERSTATUS)]
        public byte OperStatus { get; set; }
        /// <summary>
        /// CURRSTATUS
        /// </summary>
        [XmlAttribute(AddressTag.CURRSTATUS)]
        public byte CurrStatus { get; set; }
        /// <summary>
        /// STARTDATE
        /// </summary>
        [XmlAttribute(AddressTag.STARTDATE)]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// ENDDATE
        /// </summary>
        [XmlAttribute(AddressTag.ENDDATE)]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// NORMDOC
        /// </summary>
        [XmlAttribute(AddressTag.NORMDOC)]
        public Guid? NORMDOC { get; set; }
        /// <summary>
        /// LIVESTATUS
        /// </summary>
        [XmlAttribute(AddressTag.LIVESTATUS)]
        public short LiveStatus { get; set; }
        /// <summary>
        /// DIVTYPE
        /// </summary>
        [XmlAttribute(AddressTag.DIVTYPE)]
        public int DivType { get; set; }

        #endregion
    }
}
