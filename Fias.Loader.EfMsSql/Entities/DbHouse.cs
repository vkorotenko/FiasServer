#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 11:02
#endregion

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("HOUSE")]
    public class DbHouse
    {
        #region Поля
        /// <summary>
        /// IFNSFL
        /// </summary>
        [Column(HouseTags.IFNSFL)]
        public short? IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [Column(HouseTags.TERRIFNSFL)]
        public short? TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [Column(HouseTags.IFNSUL)]
        public short? IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [Column(HouseTags.TERRIFNSUL)]
        public short? TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [Column(HouseTags.OKATO)]
        public long? OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [Column(HouseTags.OKTMO)]
        public long? OKTMO { get; set; }
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [Column(HouseTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }
        /// <summary>
        /// ESTSTATUS
        /// </summary>
        [Column(HouseTags.ESTSTATUS)]
        public short ESTSTATUS { get; set; }
        /// <summary>
        /// STRUCNUM
        /// </summary>
        [Column(HouseTags.STRUCNUM),MaxLength(10)]
        public string STRUCNUM { get; set; }
        /// <summary>
        /// STRSTATUS
        /// </summary>
        [Column(HouseTags.STRSTATUS)]
        public byte? STRSTATUS { get; set; }
        /// <summary>
        /// HOUSEID
        /// </summary>
        [Column(HouseTags.HOUSEID),Key]
        public Guid HOUSEID { get; set; }
        /// <summary>
        /// HOUSEGUID
        /// </summary>
        [Column(HouseTags.HOUSEGUID)]
        public Guid HOUSEGUID { get; set; }
        /// <summary>
        /// AOGUID
        /// </summary>
        [Column(HouseTags.AOGUID)]
        public Guid AOGUID { get; set; }

        /// <summary>
        /// STARTDATE
        /// </summary>
        [Column(HouseTags.STARTDATE)]
        public DateTime STARTDATE { get; set; }
        /// <summary>
        /// ENDDATE
        /// </summary>
        [Column(HouseTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }
        /// <summary>
        /// STATSTATUS
        /// </summary>
        [Column(HouseTags.STATSTATUS)]
        public long STATSTATUS { get; set; }
        /// <summary>
        /// NORMDOC
        /// </summary>
        [Column(HouseTags.NORMDOC)]
        public Guid? NORMDOC { get; set; }

        /// <summary>
        /// COUNTER
        /// </summary>
        [Column(HouseTags.COUNTER)]
        public short COUNTER { get; set; }

        /// <summary>
        /// CADNUM
        /// </summary>
        [Column(HouseTags.CADNUM),MaxLength(100)]
        public string CADNUM { get; set; }
        /// <summary>
        /// DIVTYPE
        /// </summary>
        [Column(HouseTags.DIVTYPE)]
        public byte DIVTYPE { get; set; }

        /// <summary>
        /// POSTALCODE
        /// </summary>
        [Column(HouseTags.POSTALCODE)]
        public int? POSTALCODE { get; set; }

        /// <summary>
        /// REGIONCODE
        /// </summary>
        [Column(HouseTags.REGIONCODE)]
        public short? REGIONCODE { get; set; }

        
        /// <summary>
        /// Индекс названия дома
        /// </summary>
        [Column(HouseTags.HOUSENUM_IX)]
        public int? HOUSENUM_IX { get; set; }
        
        /// <summary>
        /// Индекс строения
        /// </summary>
        [Column(HouseTags.BUILDNUM_IX)]
        public short? BUILDNUM_IX { get; set; }
        #endregion
    }
}
