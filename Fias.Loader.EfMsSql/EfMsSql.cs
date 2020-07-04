#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 10:09
#endregion

using Fias.Loader.EfMsSql.Entities;
using Fias.Loader.EfMsSql.Repositories;
using System;
using System.Linq;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql
{
    public class EfMsSql : IDbBackend
    {
        private DataContext _ctx;
        public void Init(string connectionString)
        {
            _ctx = new DataContext(connectionString);
            AddressRepository = new AddressRepository(_ctx);
            NormativeDocument = new NormativeDocumentRepository(_ctx);
            Steads = new SteadRepository(_ctx);
        }

        #region Словари
        public void Insert(ActualStatus[] status)
        {
            _ctx.ActualStatuses.BulkMerge(status.Select(DbActualStatus.Get));
        }

        public void Insert(AddressObjectType[] types)
        {
            var unique = types.Select(a => a)
                .GroupBy(a => a.KodTSt)
                .Select(g => g.First()).ToList();
            _ctx.AddressObjectTypes.BulkMerge(unique.Select(DbAddressObjectType.Get),
                options => options.ColumnPrimaryKeyExpression = c => c.KodTSt);
        }

        public void Insert(CenterStatus[] types)
        {
            _ctx.CenterStatuses.BulkMerge(types.Select(DbCenterStatus.Get));
        }

        public void Insert(CurrentStatus[] types)
        {
            _ctx.CurrentStatuses.BulkMerge(types.Select(DbCurrentStatus.Get));
        }

        public void Insert(EstateStatus[] types)
        {
            _ctx.EstateStatuses.BulkMerge(types.Select(DbEstateStatus.Get));
        }

        public void Insert(FlatType[] types)
        {
            _ctx.FlatTypes.BulkMerge(types.Select(DbFlatType.Get));
        }

        public void Insert(NormativeDocumentType[] types)
        {
            _ctx.NormativeDocumentTypes.BulkMerge(types.Select(DbNormativeDocumentType.Get));
        }

        public void Insert(OperationStatus[] types)
        {
            _ctx.OperationStatuses.BulkMerge(types.Select(DbOperationStatus.Get));
        }

        public void Insert(RoomType[] types)
        {
            _ctx.RoomTypes.BulkMerge(types.Select(DbRoomType.Get));

        }

        public void Insert(StructureStatus[] types)
        {
            _ctx.StructureStatuses.BulkMerge(types.Select(DbStructureStatus.Get));
        } 
        #endregion

        public IRepository<AddressObject, Guid> AddressRepository { get; private set; }
        public IRepository<NormativeDocument, Guid> NormativeDocument { get; private set; }
        public IRepository<Stead, Guid> Steads { get; private set; }
    }
}
