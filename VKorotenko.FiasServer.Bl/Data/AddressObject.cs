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
    public class AddressObject
    {

        
        #region Поля
        [XmlAttribute(AddressTag.AOGUID)]
        public Guid AoGuid { get; set; }
        [XmlAttribute(AddressTag.FORMALNAME), MaxLength(120)]
        public string FormalName { get; set; }
        [XmlAttribute(AddressTag.REGIONCODE)]
        public short RegionCode { get; set; }
        [XmlAttribute(AddressTag.AUTOCODE)]
        public int AutoCode { get; set; }
        [XmlAttribute(AddressTag.AREACODE)]
        public int AreaCode { get; set; }
        [XmlAttribute(AddressTag.CITYCODE)]
        public int CityCode { get; set; }

        [XmlAttribute(AddressTag.CTARCODE)]
        public int CtarCode { get; set; }
        [XmlAttribute(AddressTag.PLACECODE)]
        public int PlaceCode { get; set; }
        [XmlAttribute(AddressTag.PLANCODE)]
        public int PlanCode { get; set; }

        [XmlAttribute(AddressTag.STREETCODE)]
        public int StreetCode { get; set; }

        [XmlAttribute(AddressTag.EXTRCODE)]
        public int ExtrCode { get; set; }


        [XmlAttribute(AddressTag.SEXTCODE)]
        public int SextCode { get; set; }

        [XmlAttribute(AddressTag.OFFNAME), MaxLength(120)]
        public string OffName { get; set; }


        [XmlAttribute(AddressTag.POSTALCODE)]
        public int? PostalCode { get; set; }

        [XmlAttribute(AddressTag.IFNSFL)]
        public int? IFNSFL { get; set; }

        [XmlAttribute(AddressTag.TERRIFNSFL)]
        public int? TERRIFNSFL { get; set; }

        [XmlAttribute(AddressTag.IFNSUL)]
        public int? IFNSUL { get; set; }

        [XmlAttribute(AddressTag.TERRIFNSUL)]
        public int? TERRIFNSUL { get; set; }

        [XmlAttribute(AddressTag.OKATO)]
        public long? OKATO { get; set; }

        [XmlAttribute(AddressTag.OKTMO)]
        public long? OKTMO { get; set; }

        [XmlAttribute(AddressTag.UPDATEDATE)]
        public DateTime UpdateDate { get; set; }

        [XmlAttribute(AddressTag.SHORTNAME), MaxLength(200)]
        public string SHORTNAME { get; set; }

        [XmlAttribute(AddressTag.SHORTNAMEID)]
        public int SHORTNAMEID { get; set; }

        [XmlAttribute(AddressTag.AOLEVEL)]
        public short AoLevel { get; set; }


        [XmlAttribute(AddressTag.PARENTGUID)]
        public Guid? ParentGuid { get; set; }

        [XmlAttribute(AddressTag.AOID)]
        public Guid AoId { get; set; }


        [XmlAttribute(AddressTag.PREVID)]
        public Guid? PrevId { get; set; }

        [XmlAttribute(AddressTag.NEXTID)]
        public Guid? NextId { get; set; }

        [XmlAttribute(AddressTag.CODE)]
        public long? Code { get; set; }

        [XmlAttribute(AddressTag.PLAINCODE)]
        public long? PlainCode { get; set; }


        [XmlAttribute(AddressTag.ACTSTATUS)]
        public short ActStatus { get; set; }

        [XmlAttribute(AddressTag.CENTSTATUS)]
        public short CentStatus { get; set; }

        [XmlAttribute(AddressTag.OPERSTATUS)]
        public byte OperStatus { get; set; }

        [XmlAttribute(AddressTag.CURRSTATUS)]
        public byte CurrStatus { get; set; }

        [XmlAttribute(AddressTag.STARTDATE)]
        public DateTime StartDate { get; set; }
        [XmlAttribute(AddressTag.ENDDATE)]
        public DateTime EndDate { get; set; }

        [XmlAttribute(AddressTag.NORMDOC)]
        public Guid? NORMDOC { get; set; }

        [XmlAttribute(AddressTag.LIVESTATUS)]
        public short LiveStatus { get; set; }

        [XmlAttribute(AddressTag.DIVTYPE)]
        public int DivType { get; set; }

        #endregion
    }
}
