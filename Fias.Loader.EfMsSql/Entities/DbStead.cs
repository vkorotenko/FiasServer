using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Stead
    /// </summary>
    [Table(Stead.Table)]
    public class DbStead
    {

        #region Поля
        /// <summary>
        /// STEADGUID
        /// </summary>
        [Column(SteadTags.STEADGUID)]
        public Guid STEADGUID { get; set; }
        /// <summary>
        /// NUMBER
        /// </summary>
        [Column(SteadTags.NUMBER), MaxLength(500)]
        public string Number { get; set; }
        /// <summary>
        /// REGIONCODE
        /// </summary>
        [Column(SteadTags.REGIONCODE)]
        public int RegionCode { get; set; }
        /// <summary>
        /// POSTALCODE
        /// </summary>
        [Column(SteadTags.POSTALCODE)]
        public int? PostalCode { get; set; }
        /// <summary>
        /// IFNSFL
        /// </summary>
        [Column(SteadTags.IFNSFL)]
        public int? IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [Column(SteadTags.TERRIFNSFL)]
        public int? TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [Column(SteadTags.IFNSUL)]
        public int? IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [Column(SteadTags.TERRIFNSUL)]
        public int? TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [Column(SteadTags.OKATO)]
        public long? OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [Column(SteadTags.OKTMO)]
        public long? OKTMO { get; set; }
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [Column(SteadTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }
        /// <summary>
        /// PARENTGUID
        /// </summary>
        [Column(SteadTags.PARENTGUID)]
        public Guid? PARENTGUID { get; set; }
        /// <summary>
        /// STEADID
        /// </summary>

        [Column(SteadTags.STEADID),Key]
        public Guid STEADID { get; set; }
        /// <summary>
        /// PREVID
        /// </summary>
        [Column(SteadTags.PREVID)]
        
        public Guid? PREVID { get; set; }
        /// <summary>
        /// NEXTID
        /// </summary>
        [Column(SteadTags.NEXTID)]
        public Guid? NEXTID { get; set; }
        /// <summary>
        /// OPERSTATUS
        /// </summary>
        [Column(SteadTags.OPERSTATUS)]
        public long OPERSTATUS { get; set; }
        /// <summary>
        /// STARTDATE
        /// </summary>
        [Column(SteadTags.STARTDATE)]
        
        public DateTime STARTDATE { get; set; }
        /// <summary>
        /// ENDDATE
        /// </summary>
        [Column(SteadTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }
        /// <summary>
        /// NORMDOC
        /// </summary>

        [Column(SteadTags.NORMDOC)]
        public Guid? NORMDOC { get; set; }
        /// <summary>
        /// LIVESTATUS
        /// </summary>
        [Column(SteadTags.LIVESTATUS)]
        public byte LIVESTATUS { get; set; }
        /// <summary>
        /// CADNUM
        /// </summary>
        [Column(SteadTags.CADNUM), MaxLength(100)]
        public string CADNUM { get; set; }
        /// <summary>
        /// DIVTYPE
        /// </summary>
        [Column(SteadTags.DIVTYPE)]
        public int DIVTYPE { get; set; }
        #endregion
    }
}
