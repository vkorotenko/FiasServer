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
    /// <summary>
    /// Таблица адресных обьектов
    /// </summary>
    [Table("ADDROBJ")]
    public class DbAddressObject
    {
        #region Поля
        /// <summary>
        /// AOGUID
        /// </summary>
        [Column(AddressTag.AOGUID)]
        public Guid AoGuid { get; set; }
        /// <summary>
        /// FORMALNAME
        /// </summary>
        [Column(AddressTag.FORMALNAME), MaxLength(120)]
        public string FormalName { get; set; }
        /// <summary>
        /// REGIONCODE
        /// </summary>
        [Column(AddressTag.REGIONCODE)]
        public short RegionCode { get; set; }
        /// <summary>
        /// AUTOCODE
        /// </summary>
        [Column(AddressTag.AUTOCODE)]
        public int AutoCode { get; set; }
        /// <summary>
        /// AREACODE
        /// </summary>
        [Column(AddressTag.AREACODE)]
        public int AreaCode { get; set; }
        /// <summary>
        /// CITYCODE
        /// </summary>
        [Column(AddressTag.CITYCODE)]
        public int CityCode { get; set; }
        /// <summary>
        /// CTARCODE
        /// </summary>
        [Column(AddressTag.CTARCODE)]
        public int CtarCode { get; set; }
        /// <summary>
        /// PLACECODE
        /// </summary>
        [Column(AddressTag.PLACECODE)]
        public int PlaceCode { get; set; }
        /// <summary>
        /// PLANCODE
        /// </summary>
        [Column(AddressTag.PLANCODE)]
        public int PlanCode { get; set; }
        /// <summary>
        /// STREETCODE
        /// </summary>
        [Column(AddressTag.STREETCODE)]
        public int StreetCode { get; set; }
        /// <summary>
        /// EXTRCODE
        /// </summary>
        [Column(AddressTag.EXTRCODE)]
        public int ExtrCode { get; set; }
        /// <summary>
        /// SEXTCODE
        /// </summary>
        [Column(AddressTag.SEXTCODE)]
        public int SextCode { get; set; }
        /// <summary>
        /// OFFNAME
        /// </summary>
        [Column(AddressTag.OFFNAME), MaxLength(120)]
        public string OffName { get; set; }
        /// <summary>
        /// POSTALCODE
        /// </summary>
        [Column(AddressTag.POSTALCODE)]
        public int? PostalCode { get; set; }
        /// <summary>
        /// IFNSFL
        /// </summary>
        [Column(AddressTag.IFNSFL)]
        public int? IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [Column(AddressTag.TERRIFNSFL)]
        public int? TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [Column(AddressTag.IFNSUL)]
        public int? IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [Column(AddressTag.TERRIFNSUL)]
        public int? TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [Column(AddressTag.OKATO)]
        public long? OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [Column(AddressTag.OKTMO)]
        public long? OKTMO { get; set; }
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [Column(AddressTag.UPDATEDATE)]
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// SHORTNAMEID
        /// </summary>
        [Column(AddressTag.SHORTNAMEID)]
        public int SHORTNAMEID { get; set; }
        /// <summary>
        /// AOLEVEL
        /// </summary>
        [Column(AddressTag.AOLEVEL)]
        public short AoLevel { get; set; }
        /// <summary>
        /// PARENTGUID
        /// </summary>
        [Column(AddressTag.PARENTGUID)]
        public Guid? ParentGuid { get; set; }
        /// <summary>
        /// AOID
        /// </summary>
        [Column(AddressTag.AOID),Key]
        public Guid AoId { get; set; }
        /// <summary>
        /// PREVID
        /// </summary>

        [Column(AddressTag.PREVID)]
        public Guid? PrevId { get; set; }
        /// <summary>
        /// NEXTID
        /// </summary>
        [Column(AddressTag.NEXTID)]
        public Guid? NextId { get; set; }
        /// <summary>
        /// CODE
        /// </summary>
        [Column(AddressTag.CODE)]
        public long? Code { get; set; }
        /// <summary>
        /// PLAINCODE
        /// </summary>
        [Column(AddressTag.PLAINCODE)]
        public long? PlainCode { get; set; }
        /// <summary>
        /// ACTSTATUS
        /// </summary>

        [Column(AddressTag.ACTSTATUS)]
        public short ActStatus { get; set; }
        /// <summary>
        /// CENTSTATUS
        /// </summary>
        [Column(AddressTag.CENTSTATUS)]
        public short CentStatus { get; set; }
        /// <summary>
        /// OPERSTATUS
        /// </summary>
        [Column(AddressTag.OPERSTATUS)]
        public byte OperStatus { get; set; }
        /// <summary>
        /// CURRSTATUS
        /// </summary>
        [Column(AddressTag.CURRSTATUS)]
        public byte CurrStatus { get; set; }
        /// <summary>
        /// STARTDATE
        /// </summary>
        [Column(AddressTag.STARTDATE)]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// ENDDATE
        /// </summary>
        [Column(AddressTag.ENDDATE)]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// NORMDOC
        /// </summary>
        [Column(AddressTag.NORMDOC)]
        public Guid? NORMDOC { get; set; }
        /// <summary>
        /// LIVESTATUS
        /// </summary>

        [Column(AddressTag.LIVESTATUS)]
        public short LiveStatus { get; set; }
        /// <summary>
        /// DIVTYPE
        /// </summary>
        [Column(AddressTag.DIVTYPE)]
        public int DivType { get; set; }

        #endregion
    }
}
