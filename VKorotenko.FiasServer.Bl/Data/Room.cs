#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  11.07.2020 11:19
#endregion


using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Data
{
    /// <summary>
    /// Комната
    /// </summary>
    public class Room
    {
        #region Конструкторы
        /// <summary>
        /// Дефолтный конструктор
        /// </summary>
        public Room() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="xml">Десириализуемый</param>
        public Room(string xml)
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
        #endregion
        #region Служебные константы
        /// <summary>
        /// Корневой элемент в файле
        /// </summary>
        public const string Root = "Rooms";
        /// <summary>
        /// Название файла в архиве
        /// </summary>
        public const string Start = "AS_ROOM_";
        /// <summary>
        /// Таблица в БД
        /// </summary>
        public const string Table = "ROOM";
        /// <summary>
        /// Тэг в документе
        /// </summary>
        public const string ContainerTag = "Room";
        #endregion

        #region Поля
        #region ROOMGUID
        /// <summary>
        /// ROOMGUID
        /// </summary>
        [XmlAttribute(RoomTags.ROOMGUID)]
        public Guid ROOMGUID { get; set; }
        #endregion
        #region FLATNUMBER
        /// <summary>
        /// FLATNUMBER
        /// </summary>
        [MaxLength(50), XmlAttribute(RoomTags.FLATNUMBER)]
        public string FLATNUMBER { get; set; }
        #endregion
        #region FLATTYPE
        /// <summary>
        /// FLATTYPE
        /// </summary>
        [XmlAttribute(RoomTags.FLATTYPE)]
        public int FLATTYPE { get; set; }


        #endregion
        #region ROOMNUMBER
        /// <summary>
        /// ROOMNUMBER
        /// </summary>
        [MaxLength(50), XmlAttribute(RoomTags.ROOMNUMBER)]
        public string ROOMNUMBER { get; set; }

        #endregion
        #region ROOMTYPE
        /// <summary>
        /// ROOMTYPE
        /// </summary>
        [XmlAttribute(RoomTags.ROOMTYPE)]
        public string ROOMTYPE { get; set; }

        #endregion
        #region REGIONCODE
        /// <summary>
        /// REGIONCODE
        /// </summary>
        [XmlAttribute(RoomTags.REGIONCODE)]
        public short REGIONCODE { get; set; }


        #endregion
        #region POSTALCODE
        /// <summary>
        /// POSTALCODE
        /// </summary>
        [XmlAttribute(RoomTags.POSTALCODE)]
        public string POSTALCODE { get; set; }


        #endregion
        #region UPDATEDATE
        /// <summary>
        /// UPDATEDATE
        /// </summary>
        [XmlAttribute(RoomTags.UPDATEDATE)]
        public DateTime UPDATEDATE { get; set; }

        #endregion
        #region HOUSEGUID
        /// <summary>
        /// HOUSEGUID
        /// </summary>
        [XmlAttribute(RoomTags.HOUSEGUID)]
        public Guid HOUSEGUID { get; set; }


        #endregion
        #region ROOMID
        /// <summary>
        /// ROOMID
        /// </summary>
        [XmlAttribute(RoomTags.ROOMID)]
        public Guid ROOMID { get; set; }

        #endregion
        #region PREVID
        /// <summary>
        /// PREVID
        /// </summary>
        [XmlAttribute(RoomTags.PREVID)]
        public string PREVID { get; set; }

        #endregion
        #region NEXTID
        /// <summary>
        /// NEXTID
        /// </summary>
        [XmlAttribute(RoomTags.NEXTID)]
        public string NEXTID { get; set; }


        #endregion
        #region STARTDATE
        /// <summary>
        /// STARTDATE
        /// </summary>
        [XmlAttribute(RoomTags.STARTDATE)]
        public DateTime STARTDATE { get; set; }


        #endregion
        #region ENDDATE
        /// <summary>
        /// ENDDATE
        /// </summary>
        [XmlAttribute(RoomTags.ENDDATE)]
        public DateTime ENDDATE { get; set; }


        #endregion
        #region LIVESTATUS
        /// <summary>
        /// LIVESTATUS
        /// </summary>
        [XmlAttribute(RoomTags.LIVESTATUS)]
        public string LIVESTATUS { get; set; }

        #endregion
        #region NORMDOC
        /// <summary>
        /// NORMDOC
        /// </summary>
        [XmlAttribute(RoomTags.NORMDOC)]
        public string NORMDOC { get; set; }

        #endregion
        #region OPERSTATUS
        /// <summary>
        /// OPERSTATUS
        /// </summary>
        [XmlAttribute(RoomTags.OPERSTATUS)]
        public long OPERSTATUS { get; set; }


        #endregion
        #region CADNUM
        /// <summary>
        /// CADNUM
        /// </summary>
        [XmlAttribute(RoomTags.CADNUM),MaxLength(100)]
        public string CADNUM { get; set; }

        #endregion
        #region ROOMCADNUM
        /// <summary>
        /// ROOMCADNUM
        /// </summary>
        [XmlAttribute(RoomTags.ROOMCADNUM),MaxLength(100)]
        public string ROOMCADNUM { get; set; }

        #endregion
        #endregion
    }
}