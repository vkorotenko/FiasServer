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
    /// <summary>
    /// Бэкенд EF core MSSQL
    /// </summary>
    public class EfMsSql : IDbBackend
    {
        private DataContext _ctx;
        /// <summary>
        /// Инициализация БД
        /// </summary>
        /// <param name="connectionString"></param>
        public void Init(string connectionString)
        {
            _ctx = new DataContext(connectionString);
            AddressRepository = new AddressRepository(_ctx);
            NormativeDocument = new NormativeDocumentRepository(_ctx);
            Steads = new SteadRepository(_ctx);
            Houses = new HouseRepository(_ctx);
            BuildNumbers= new BuildNumbersRepository(_ctx);
            HouseNumbers = new HouseNumbersRepository(_ctx);
            Rooms = new RoomRepository(_ctx);
        }

        #region Словари
        /// <summary>
        /// Вставка статусов актуальности
        /// </summary>
        /// <param name="status"></param>
        public void Insert(ActualStatus[] status)
        {
            _ctx.ActualStatuses.BulkMerge(status.Select(DbActualStatus.Get));
        }
        /// <summary>
        /// Вставка типов адресных обьектов
        /// </summary>
        /// <param name="types"></param>
        public void Insert(AddressObjectType[] types)
        {
            var unique = types.Select(a => a)
                .GroupBy(a => a.KodTSt)
                .Select(g => g.First()).ToList();
            _ctx.AddressObjectTypes.BulkMerge(unique.Select(DbAddressObjectType.Get),
                options => options.ColumnPrimaryKeyExpression = c => c.KodTSt);
        }
        /// <summary>
        /// Вставка статусов центра
        /// </summary>
        /// <param name="types"></param>
        public void Insert(CenterStatus[] types)
        {
            _ctx.CenterStatuses.BulkMerge(types.Select(DbCenterStatus.Get));
        }
        /// <summary>
        /// Вставка статуса актуальности
        /// </summary>
        /// <param name="types"></param>
        public void Insert(CurrentStatus[] types)
        {
            _ctx.CurrentStatuses.BulkMerge(types.Select(DbCurrentStatus.Get));
        }
        /// <summary>
        /// Вставка Estate
        /// </summary>
        /// <param name="types"></param>
        public void Insert(EstateStatus[] types)
        {
            _ctx.EstateStatuses.BulkMerge(types.Select(DbEstateStatus.Get));
        }
        /// <summary>
        /// Вставка типов помещений
        /// </summary>
        /// <param name="types"></param>
        public void Insert(FlatType[] types)
        {
            _ctx.FlatTypes.BulkMerge(types.Select(DbFlatType.Get));
        }
        /// <summary>
        /// вставка типов нормативных документов
        /// </summary>
        /// <param name="types"></param>
        public void Insert(NormativeDocumentType[] types)
        {
            _ctx.NormativeDocumentTypes.BulkMerge(types.Select(DbNormativeDocumentType.Get));
        }
        /// <summary>
        /// Вставка операционных типов
        /// </summary>
        /// <param name="types"></param>
        public void Insert(OperationStatus[] types)
        {
            _ctx.OperationStatuses.BulkMerge(types.Select(DbOperationStatus.Get));
        }
        /// <summary>
        /// Вставка типа комнаты
        /// </summary>
        /// <param name="types"></param>
        public void Insert(RoomType[] types)
        {
            _ctx.RoomTypes.BulkMerge(types.Select(DbRoomType.Get));

        }
        /// <summary>
        /// Вставка структурных кодов
        /// </summary>
        /// <param name="types"></param>
        public void Insert(StructureStatus[] types)
        {
            _ctx.StructureStatuses.BulkMerge(types.Select(DbStructureStatus.Get));
        } 
        #endregion
        /// <summary>
        /// Репозиторий адресных объектов
        /// </summary>
        public IRepository<AddressObject, Guid> AddressRepository { get; private set; }
        /// <summary>
        /// Репозиторий нормативных документов
        /// </summary>
        public IRepository<NormativeDocument, Guid> NormativeDocument { get; private set; }
        /// <summary>
        /// Репозиторий Stead
        /// </summary>
        public IRepository<Stead, Guid> Steads { get; private set; }
        /// <summary>
        /// Дома
        /// </summary>
        public IRepository<House, Guid> Houses { get; private set; }
        /// <summary>
        /// Номера строений
        /// </summary>
        public IRepository<BuildNum, short> BuildNumbers { get; private set; }
        /// <summary>
        /// Номера домов
        /// </summary>
        public IRepository<HouseNum, int> HouseNumbers { get; private set; }
        /// <summary>
        /// Комнаты
        /// </summary>
        public IRepository<Room, Guid> Rooms { get; private set; }
    }
}
