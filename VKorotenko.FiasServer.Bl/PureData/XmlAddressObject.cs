#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 19:46
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.Extensions;

namespace VKorotenko.FiasServer.Bl.PureData
{
    /// <summary>
    /// Адресный обьект
    /// </summary>
    [Serializable]
    [XmlType(ContainerTag)]
    public class XmlAddressObject
    {
        /// <summary>
        /// Конструктор для сериализации
        /// </summary>
        public XmlAddressObject() { }
        /// <summary>
        /// Конструктор для десириализации
        /// </summary>
        /// <param name="xml"></param>
        public XmlAddressObject(string xml)
        {
            LoadXml(xml);
        }

        #region Служебные константы
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "AddressObjects";
        /// <summary>
        /// Имя файла
        /// </summary>
        public const string Start = "AS_ADDROBJ_";
        /// <summary>
        /// Таблица
        /// </summary>
        public const string Table = "ADDROBJ";
        /// <summary>
        /// Тэг элемента
        /// </summary>
        public const string ContainerTag = "Object";
        #endregion


        #region Поля
        /// <summary>
        /// AOGUID
        /// </summary>
        [XmlAttribute(AddressTag.AOGUID)]
        public Guid AoGuid { get; set; }
        /// <summary>
        /// FORMALNAME
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
        public string PostalCode { get; set; }
        /// <summary>
        /// IFNSFL
        /// </summary>
        [XmlAttribute(AddressTag.IFNSFL)]
        public string IFNSFL { get; set; }
        /// <summary>
        /// TERRIFNSFL
        /// </summary>
        [XmlAttribute(AddressTag.TERRIFNSFL)]
        public string TERRIFNSFL { get; set; }
        /// <summary>
        /// IFNSUL
        /// </summary>
        [XmlAttribute(AddressTag.IFNSUL)]
        public string IFNSUL { get; set; }
        /// <summary>
        /// TERRIFNSUL
        /// </summary>
        [XmlAttribute(AddressTag.TERRIFNSUL)]
        public string TERRIFNSUL { get; set; }
        /// <summary>
        /// OKATO
        /// </summary>
        [XmlAttribute(AddressTag.OKATO)]
        public string OKATO { get; set; }
        /// <summary>
        /// OKTMO
        /// </summary>
        [XmlAttribute(AddressTag.OKTMO)]
        public string OKTMO { get; set; }
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
        public string ParentGuid { get; set; }
        /// <summary>
        /// AOID
        /// </summary>
        [XmlAttribute(AddressTag.AOID)]
        public Guid AoId { get; set; }
        /// <summary>
        /// PREVID
        /// </summary>

        [XmlAttribute(AddressTag.PREVID)]
        public string PrevId { get; set; }
        /// <summary>
        /// NEXTID
        /// </summary>
        [XmlAttribute(AddressTag.NEXTID)]
        public string NextId { get; set; }
        /// <summary>
        /// CODE
        /// </summary>
        [XmlAttribute(AddressTag.CODE)]
        public string Code { get; set; }
        /// <summary>
        /// PLAINCODE
        /// </summary>
        [XmlAttribute(AddressTag.PLAINCODE)]
        public string PlainCode { get; set; }
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
        public string CurrStatus { get; set; }
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
        public string NORMDOC { get; set; }
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

        /// <summary>
        /// Получение из XML
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static AddressObject Get(XmlAddressObject a)
        {
            var r = new AddressObject()
            {
                ActStatus = a.ActStatus,
                AoGuid = a.AoGuid,
                AoId = a.AoId,
                AoLevel = a.AoLevel,
                AreaCode = a.AreaCode,
                AutoCode = a.AutoCode,
                CentStatus = a.CentStatus,
                CityCode = a.CityCode,
                Code = a.Code.ToNullLong(),
                CtarCode = a.CtarCode,
                CurrStatus =  a.CurrStatus.GetCurStatus(),
                DivType = a.DivType,
                EndDate = a.EndDate,
                ExtrCode = a.ExtrCode,
                FormalName = a.FormalName,
                IFNSFL = a.IFNSFL.ToNullInt(),
                IFNSUL = a.IFNSUL.ToNullInt(),
                LiveStatus = a.LiveStatus,
                NORMDOC = a.NORMDOC.ToNullGuid(),
                NextId = a.NextId.ToNullGuid(),
                OKATO =  a.OKATO.ToNullLong(),
                OKTMO = a.OKTMO.ToNullLong(),
                OffName = a.OffName,
                OperStatus = a.OperStatus,
                ParentGuid = a.ParentGuid.ToNullGuid(),
                PlaceCode = a.PlaceCode,
                PlainCode = a.PlainCode.ToNullLong(),
                PlanCode = a.PlanCode,
                PostalCode = a.PostalCode.ToNullInt(),
                PrevId = a.PrevId.ToNullGuid(),
                RegionCode = a.RegionCode,
                SHORTNAME = a.SHORTNAME,
                SextCode = a.SextCode,
                StartDate = a.StartDate,
                StreetCode = a.StreetCode,
                TERRIFNSFL = a.TERRIFNSFL.ToNullInt(),
                TERRIFNSUL = a.TERRIFNSUL.ToNullInt(),
                UpdateDate = a.UpdateDate
            };

            return r;

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
