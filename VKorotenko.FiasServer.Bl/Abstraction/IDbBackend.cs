#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 9:05
#endregion

using System;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace VKorotenko.FiasServer.Bl.Abstraction
{
    public interface IDbBackend
    {
        void Init(string connectionString);
        #region Словари
        void Insert(ActualStatus[] status);
        void Insert(AddressObjectType[] types);
        void Insert(CenterStatus[] types);
        void Insert(CurrentStatus[] types);
        void Insert(EstateStatus[] types);
        void Insert(FlatType[] types);
        void Insert(NormativeDocumentType[] types);
        void Insert(OperationStatus[] types);
        void Insert(RoomType[] types);
        void Insert(StructureStatus[] types); 
        #endregion

        #region Данные
        IRepository<AddressObject,Guid> AddressRepository { get; }
        IRepository<NormativeDocument,Guid> NormativeDocument { get; }
        #endregion
    }
}
