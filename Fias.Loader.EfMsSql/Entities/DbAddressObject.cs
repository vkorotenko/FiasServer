#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 10:11
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.PureData;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("ADDROBJ")]
    public class DbAddressObject
    {
        #region Поля
        [Column(AddressTag.AOGUID)]
        public Guid AoGuid { get; set; }
        [Column(AddressTag.FORMALNAME), MaxLength(120)]
        public string FormalName { get; set; }
        [Column(AddressTag.REGIONCODE)]
        public short RegionCode { get; set; }
        [Column(AddressTag.AUTOCODE)]
        public int AutoCode { get; set; }
        [Column(AddressTag.AREACODE)]
        public int AreaCode { get; set; }
        [Column(AddressTag.CITYCODE)]
        public int CityCode { get; set; }

        [Column(AddressTag.CTARCODE)]
        public int CtarCode { get; set; }
        [Column(AddressTag.PLACECODE)]
        public int PlaceCode { get; set; }
        [Column(AddressTag.PLANCODE)]
        public int PlanCode { get; set; }

        [Column(AddressTag.STREETCODE)]
        public int StreetCode { get; set; }

        [Column(AddressTag.EXTRCODE)]
        public int ExtrCode { get; set; }
        [Column(AddressTag.SEXTCODE)]
        public int SextCode { get; set; }

        [Column(AddressTag.OFFNAME), MaxLength(120)]
        public string OffName { get; set; }
        
        [Column(AddressTag.POSTALCODE)]
        public int? PostalCode { get; set; }

        [Column(AddressTag.IFNSFL)]
        public int? IFNSFL { get; set; }

        [Column(AddressTag.TERRIFNSFL)]
        public int? TERRIFNSFL { get; set; }

        [Column(AddressTag.IFNSUL)]
        public int? IFNSUL { get; set; }

        [Column(AddressTag.TERRIFNSUL)]
        public int? TERRIFNSUL { get; set; }

        [Column(AddressTag.OKATO)]
        public long? OKATO { get; set; }

        [Column(AddressTag.OKTMO)]
        public long? OKTMO { get; set; }

        [Column(AddressTag.UPDATEDATE)]
        public DateTime UpdateDate { get; set; }
        [Column(AddressTag.SHORTNAMEID)]
        public int SHORTNAMEID { get; set; }

        [Column(AddressTag.AOLEVEL)]
        public short AoLevel { get; set; }
        [Column(AddressTag.PARENTGUID)]
        public Guid? ParentGuid { get; set; }

        [Column(AddressTag.AOID),Key]
        public Guid AoId { get; set; }


        [Column(AddressTag.PREVID)]
        public Guid? PrevId { get; set; }

        [Column(AddressTag.NEXTID)]
        public Guid? NextId { get; set; }

        [Column(AddressTag.CODE)]
        public long? Code { get; set; }

        [Column(AddressTag.PLAINCODE)]
        public long? PlainCode { get; set; }


        [Column(AddressTag.ACTSTATUS)]
        public short ActStatus { get; set; }

        [Column(AddressTag.CENTSTATUS)]
        public short CentStatus { get; set; }

        [Column(AddressTag.OPERSTATUS)]
        public byte OperStatus { get; set; }

        [Column(AddressTag.CURRSTATUS)]
        public byte CurrStatus { get; set; }

        [Column(AddressTag.STARTDATE)]
        public DateTime StartDate { get; set; }
        [Column(AddressTag.ENDDATE)]
        public DateTime EndDate { get; set; }

        [Column(AddressTag.NORMDOC)]
        public Guid? NORMDOC { get; set; }

        [Column(AddressTag.LIVESTATUS)]
        public short LiveStatus { get; set; }

        [Column(AddressTag.DIVTYPE)]
        public int DivType { get; set; }

        #endregion
    }
}
