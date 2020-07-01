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

namespace VKorotenko.FiasServer.Bl.PureData
{

    public sealed class AddressTag{
        #region Константы

        public const string AOGUID = "AOGUID";
        public const string FORMALNAME = "FORMALNAME";
        public const string REGIONCODE = "REGIONCODE";
        public const string AUTOCODE = "AUTOCODE";
        public const string AREACODE = "AREACODE";
        public const string CITYCODE = "CITYCODE";
        public const string CTARCODE = "CTARCODE";
        public const string PLACECODE = "PLACECODE";
        public const string PLANCODE = "PLANCODE";
        public const string STREETCODE = "STREETCODE";
        public const string EXTRCODE = "EXTRCODE";
        public const string SEXTCODE = "SEXTCODE";
        public const string OFFNAME = "OFFNAME";
        public const string POSTALCODE = "POSTALCODE";
        public const string IFNSFL = "IFNSFL";
        public const string TERRIFNSFL = "TERRIFNSFL";
        public const string IFNSUL = "IFNSUL";
        public const string TERRIFNSUL = "TERRIFNSUL";
        public const string OKATO = "OKATO";
        public const string OKTMO = "OKTMO";
        public const string UPDATEDATE = "UPDATEDATE";
        public const string SHORTNAME = "SHORTNAME";
        public const string SHORTNAMEID = "SHORTNAMEID";
        public const string AOLEVEL = "AOLEVEL";
        public const string PARENTGUID = "PARENTGUID";
        public const string AOID = "AOID";
        public const string PREVID = "PREVID";
        public const string NEXTID = "NEXTID";
        public const string CODE = "CODE";
        public const string PLAINCODE = "PLAINCODE";
        public const string ACTSTATUS = "ACTSTATUS";
        public const string CENTSTATUS = "CENTSTATUS";
        public const string OPERSTATUS = "OPERSTATUS";
        public const string CURRSTATUS = "CURRSTATUS";
        public const string STARTDATE = "STARTDATE";
        public const string ENDDATE = "ENDDATE";
        public const string NORMDOC = "NORMDOC";
        public const string LIVESTATUS = "LIVESTATUS";
        public const string DIVTYPE = "DIVTYPE";

        #endregion
    }
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
                Code = TryGetLong(a.Code),
                CtarCode = a.CtarCode,
                CurrStatus =  TryConv( a.CurrStatus),
                DivType = a.DivType,
                EndDate = a.EndDate,
                ExtrCode = a.ExtrCode,
                FormalName = a.FormalName,
                IFNSFL = TryGetInt(a.IFNSFL),
                IFNSUL = TryGetInt(a.IFNSUL),
                LiveStatus = a.LiveStatus,
                NORMDOC = TryGetGuid(a.NORMDOC),
                NextId = TryGetGuid(a.NextId),
                OKATO =  TryGetLong(a.OKATO),
                OKTMO = TryGetLong(a.OKTMO),
                OffName = a.OffName,
                OperStatus = a.OperStatus,
                ParentGuid = TryGetGuid(a.ParentGuid),
                PlaceCode = a.PlaceCode,
                PlainCode = TryGetLong(a.PlainCode),
                PlanCode = a.PlanCode,
                PostalCode = TryGetInt(a.PostalCode),
                PrevId = TryGetGuid(a.PrevId),
                RegionCode = a.RegionCode,
                SHORTNAME = a.SHORTNAME,
                SextCode = a.SextCode,
                StartDate = a.StartDate,
                StreetCode = a.StreetCode,
                TERRIFNSFL = TryGetInt(a.TERRIFNSFL),
                TERRIFNSUL = TryGetInt(a.TERRIFNSUL),
                UpdateDate = a.UpdateDate
            };

            return r;

        }

        private static byte TryConv(string conv)
        {
            byte r = 0;
            if (byte.TryParse(conv, out var n)) r = n;
            return r;
        } 
        private static long? TryGetLong(string aCode)
        {
            long? r = null;
            if (long.TryParse(aCode, out var n)) r = n;
            return r;
        }
        private static int? TryGetInt(string aCode)
        {
            int? r = null;
            if (int.TryParse(aCode, out var n)) r = n;
            return r;
        }
        private static Guid? TryGetGuid(string aCode)
        {
            Guid? r = null;
            if (Guid.TryParse(aCode, out var n)) r = n;
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
