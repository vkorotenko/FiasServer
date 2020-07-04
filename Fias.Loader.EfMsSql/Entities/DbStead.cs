using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table(Stead.Table)]
    public class DbStead
    {

        #region Поля
        [Column(SteadTags.STEADGUID)]
        public Guid STEADGUID { get; set; }
        [Column(SteadTags.NUMBER), MaxLength(500)]
        public string Number { get; set; }
        [Column(SteadTags.REGIONCODE)]
        public int RegionCode { get; set; }
        [Column(SteadTags.POSTALCODE)]
        public int? PostalCode { get; set; }
        [Column(SteadTags.IFNSFL)]
        public int? IFNSFL { get; set; }
        [Column(SteadTags.TERRIFNSFL)]
        public int? TERRIFNSFL { get; set; }
        [Column(SteadTags.IFNSUL)]
        public int? IFNSUL { get; set; }
        [Column(SteadTags.TERRIFNSUL)]
        public int? TERRIFNSUL { get; set; }
        [Column(SteadTags.OKATO)]
        public long? OKATO { get; set; }
        [Column(SteadTags.OKTMO)]
        public long? OKTMO { get; set; }

        [Column(SteadTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }
        [Column(SteadTags.PARENTGUID)]
        public Guid? PARENTGUID { get; set; }
        
        
        [Column(SteadTags.STEADID),Key]
        public Guid STEADID { get; set; }
        [Column(SteadTags.PREVID)]
        
        public Guid? PREVID { get; set; }
        [Column(SteadTags.NEXTID)]
        public Guid? NEXTID { get; set; }
        [Column(SteadTags.OPERSTATUS)]
        public long OPERSTATUS { get; set; }
        [Column(SteadTags.STARTDATE)]
        
        public DateTime STARTDATE { get; set; }
        [Column(SteadTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }

        [Column(SteadTags.NORMDOC)]
        public Guid? NORMDOC { get; set; }
        [Column(SteadTags.LIVESTATUS)]
        public byte LIVESTATUS { get; set; }
        [Column(SteadTags.CADNUM), MaxLength(100)]
        public string CADNUM { get; set; }
        [Column(SteadTags.DIVTYPE)]
        public int DIVTYPE { get; set; }
        #endregion
    }
}
