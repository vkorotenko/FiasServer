#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  11.07.2020 20:03
#endregion


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Класс комнаты
    /// </summary>
    [Table(Room.Table)]
    public class DbRoom
    {
        #region Поля
        #region ROOMGUID
        /// <summary>
        /// ROOMGUID
        /// </summary>
        [Column(RoomTags.ROOMGUID)]
        public Guid ROOMGUID { get; set; }
        #endregion
        #region FLATNUMBER
        /// <summary>
        /// FLATNUMBER
        /// </summary>
        [MaxLength(50), Column(RoomTags.FLATNUMBER)]
        public string FLATNUMBER { get; set; }
        #endregion
        #region FLATTYPE
        /// <summary>
        /// FLATTYPE
        /// </summary>
        [Column(RoomTags.FLATTYPE)]
        public int FLATTYPE { get; set; }


        #endregion
        #region ROOMNUMBER
        /// <summary>
        /// ROOMNUMBER
        /// </summary>
        [MaxLength(50), Column(RoomTags.ROOMNUMBER)]
        public string ROOMNUMBER { get; set; }

        #endregion
        #region ROOMTYPE
        /// <summary>
        /// ROOMTYPE
        /// </summary>
        [Column(RoomTags.ROOMTYPE)]
        public int? ROOMTYPE { get; set; }

        #endregion
        #region REGIONCODE
        /// <summary>
        /// REGIONCODE
        /// </summary>
        [Column(RoomTags.REGIONCODE)]
        public int REGIONCODE { get; set; }


        #endregion

        #region POSTALCODE
        /// <summary>
        /// POSTALCODE
        /// </summary>
        [Column(RoomTags.POSTALCODE)]
        public int? POSTALCODE { get; set; }


        #endregion
        #region UPDATEDATE
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [Column(RoomTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }

        #endregion
        #region HOUSEGUID
        /// <summary>
        /// HOUSEGUID
        /// </summary>
        [Column(RoomTags.HOUSEGUID)]
        public Guid HOUSEGUID { get; set; }


        #endregion
        #region ROOMID
        /// <summary>
        /// ROOMID
        /// </summary>
        [Column(RoomTags.ROOMID),Key]
        public Guid ROOMID { get; set; }

        #endregion
        #region PREVID
        /// <summary>
        /// PREVID
        /// </summary>
        [Column(RoomTags.PREVID)]
        public Guid? PREVID { get; set; }

        #endregion
        #region NEXTID
        /// <summary>
        /// NEXTID
        /// </summary>
        [Column(RoomTags.NEXTID)]
        public Guid? NEXTID { get; set; }


        #endregion
        #region STARTDATE
        /// <summary>
        /// STARTDATE
        /// </summary>
        [Column(RoomTags.STARTDATE)]
        public DateTime STARTDATE { get; set; }


        #endregion
        #region ENDDATE
        /// <summary>
        /// ENDDATE
        /// </summary>
        [Column(RoomTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }


        #endregion
        #region LIVESTATUS
        /// <summary>
        /// LIVESTATUS
        /// </summary>
        [Column(RoomTags.LIVESTATUS)]
        public byte LIVESTATUS { get; set; }

        #endregion
        #region NORMDOC
        /// <summary>
        /// NORMDOC
        /// </summary>
        [Column(RoomTags.NORMDOC)]
        public Guid? NORMDOC { get; set; }

        #endregion
        #region OPERSTATUS
        /// <summary>
        /// OPERSTATUS
        /// </summary>
        [Column(RoomTags.OPERSTATUS)]
        public long OPERSTATUS { get; set; }


        #endregion
        #region CADNUM
        /// <summary>
        /// CADNUM
        /// </summary>
        [Column(RoomTags.CADNUM), MaxLength(100)]
        public string CADNUM { get; set; }

        #endregion
        #region ROOMCADNUM
        /// <summary>
        /// ROOMCADNUM
        /// </summary>
        [Column(RoomTags.ROOMCADNUM), MaxLength(100)]
        public string ROOMCADNUM { get; set; }

        #endregion
        #endregion
    }
}
