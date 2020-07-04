#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 11:50
#endregion

using Fias.Loader.EfMsSql.Entities;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.Extensions;

namespace Fias.Loader.EfMsSql.Extensions
{
    public static class ConvertExtension
    {
        public static DbAddressObject Get(this AddressObject a)
        {
            return new DbAddressObject
            {
                AoGuid = a.AoGuid,
                ActStatus = a.ActStatus,
                AoId = a.AoId,
                AoLevel = a.AoLevel,
                AreaCode = a.AreaCode,
                AutoCode = a.AutoCode,
                CentStatus = a.CentStatus,
                CityCode = a.CityCode,
                Code = a.Code,
                CtarCode = a.CtarCode,
                UpdateDate = a.UpdateDate,
                CurrStatus = a.CurrStatus,
                IFNSUL = a.IFNSUL,
                FormalName = a.FormalName,
                PlanCode = a.PlanCode,
                StreetCode = a.StreetCode,
                OffName = a.OffName,
                RegionCode = a.RegionCode,
                StartDate = a.StartDate,
                PlaceCode = a.PlaceCode,
                EndDate = a.EndDate,
                LiveStatus = a.LiveStatus,
                SextCode = a.SextCode,
                ExtrCode = a.ExtrCode,
                OperStatus = a.OperStatus,
                DivType = a.DivType,
                NORMDOC = a.NORMDOC,
                PostalCode = a.PostalCode,
                ParentGuid = a.ParentGuid,
                NextId = a.NextId,
                PrevId = a.PrevId,
                PlainCode = a.PlainCode,
                OKTMO = a.OKTMO,
                OKATO = a.OKATO,
                IFNSFL = a.IFNSFL,
                TERRIFNSFL = a.TERRIFNSFL,
                SHORTNAMEID = a.SHORTNAMEID,
                TERRIFNSUL = a.TERRIFNSUL
            };
        }

        public static DbNormativeDocument Get(this NormativeDocument d)
        {
            if (d.DocNum?.Length > 200) 
#pragma warning disable 642
                ; // ловим превышение длины
#pragma warning restore 642
            return  new DbNormativeDocument
            {
                DocDate = d.DocDate.ToNullDateTime(),
                DocImgId = d.DocImgId.ToNullGuid(),
                DocName = d.DocName,
                DocNum = d.DocNum,
                DocType = d.DocNum.ToNullShort(),
                NormDocId = d.NormDocId
            };
        }

        public static DbStead Get(this Stead s)
        {
            if (s.Number?.Length > 120)
#pragma warning disable 642
                ; // ловим превышение длины
#pragma warning restore 642
            return new DbStead
            {
                STEADID = s.STEADID,
                IFNSUL = s.IFNSUL.ToNullInt(),
                OKATO = s.OKATO.ToNullLong(),
                RegionCode = s.RegionCode,
                PostalCode = s.PostalCode.ToNullInt(),
                NORMDOC = s.NORMDOC.ToNullGuid(),
                OKTMO = s.OKTMO.ToNullLong(),
                TERRIFNSUL = s.TERRIFNSUL.ToNullInt(),
                IFNSFL = s.IFNSFL.ToNullInt(),
                TERRIFNSFL = s.TERRIFNSFL.ToNullInt(),
                STEADGUID = s.STEADGUID,
                CADNUM = s.CADNUM,
                DIVTYPE = s.DIVTYPE,
                ENDDATE = s.ENDDATE,
                LIVESTATUS = s.LIVESTATUS,
                NEXTID = s.NEXTID.ToNullGuid(),
                Number = s.Number,
                OPERSTATUS = s.OPERSTATUS,
                PARENTGUID = s.PARENTGUID.ToNullGuid(),
                PREVID = s.PREVID.ToNullGuid(),
                STARTDATE = s.STARTDATE,
                UPDATEDATE = s.UPDATEDATE
            };
        }
    }
}
