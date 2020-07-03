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
    [Serializable]
    [XmlType(ContainerTag)]
    public class XmlAddressObject
    {
        public XmlAddressObject() { }

        public XmlAddressObject(string xml)
        {
            LoadXml(xml);
        }

        #region Служебные константы
        public const string Root = "AddressObjects";
        public const string Start = "AS_ADDROBJ_";
        public const string Table = "ADDROBJ";
        public const string ContainerTag = "Object";
        #endregion
        

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
        public string PostalCode { get; set; }
        [XmlAttribute(AddressTag.IFNSFL)]
        public string IFNSFL { get; set; }

        [XmlAttribute(AddressTag.TERRIFNSFL)]
        public string TERRIFNSFL { get; set; }

        [XmlAttribute(AddressTag.IFNSUL)]
        public string IFNSUL { get; set; }

        [XmlAttribute(AddressTag.TERRIFNSUL)]
        public string TERRIFNSUL { get; set; }

        [XmlAttribute(AddressTag.OKATO)]
        public string OKATO { get; set; }

        [XmlAttribute(AddressTag.OKTMO)]
        public string OKTMO { get; set; }

        [XmlAttribute(AddressTag.UPDATEDATE)]
        public DateTime UpdateDate { get; set; }

        [XmlAttribute(AddressTag.SHORTNAME), MaxLength(200)]
        public string SHORTNAME { get; set; }

        [XmlAttribute(AddressTag.SHORTNAMEID)]
        public int SHORTNAMEID { get; set; }

        [XmlAttribute(AddressTag.AOLEVEL)]
        public short AoLevel { get; set; }


        [XmlAttribute(AddressTag.PARENTGUID)]
        public string ParentGuid { get; set; }

        [XmlAttribute(AddressTag.AOID)]
        public Guid AoId { get; set; }


        [XmlAttribute(AddressTag.PREVID)]
        public string PrevId { get; set; }

        [XmlAttribute(AddressTag.NEXTID)]
        public string NextId { get; set; }

        [XmlAttribute(AddressTag.CODE)]
        public string Code { get; set; }

        [XmlAttribute(AddressTag.PLAINCODE)]
        public string PlainCode { get; set; }


        [XmlAttribute(AddressTag.ACTSTATUS)]
        public short ActStatus { get; set; }

        [XmlAttribute(AddressTag.CENTSTATUS)]
        public short CentStatus { get; set; }

        [XmlAttribute(AddressTag.OPERSTATUS)]
        public byte OperStatus { get; set; }

        [XmlAttribute(AddressTag.CURRSTATUS)]
        public string CurrStatus { get; set; }

        [XmlAttribute(AddressTag.STARTDATE)]
        public DateTime StartDate { get; set; }
        [XmlAttribute(AddressTag.ENDDATE)]
        public DateTime EndDate { get; set; }

        [XmlAttribute(AddressTag.NORMDOC)]
        public string NORMDOC { get; set; }

        [XmlAttribute(AddressTag.LIVESTATUS)]
        public short LiveStatus { get; set; }

        [XmlAttribute(AddressTag.DIVTYPE)]
        public int DivType { get; set; }

        #endregion


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
        
        public void LoadXml(string source)
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
