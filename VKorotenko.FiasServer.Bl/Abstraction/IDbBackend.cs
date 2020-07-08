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

#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
    /// <summary>
    /// Интерфейс для бэкенда ДБ. Базовая реализация см. в <see cref="Fias.Loader.EfMsSql"/>
    /// </summary>
    public interface IDbBackend
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
    {
        /// <summary>
        /// Инициализация модуля
        /// </summary>
        /// <param name="connectionString">Строка соединения для данного модуля</param>
        void Init(string connectionString);
        #region Словари
        /// <summary>
        /// Словарь статусов актуальности
        /// </summary>
        /// <param name="status"></param>
        void Insert(ActualStatus[] status);
        /// <summary>
        /// Типы адресных объектов
        /// </summary>
        /// <param name="types"></param>
        void Insert(AddressObjectType[] types);
        /// <summary>
        /// Статус центра
        /// </summary>
        /// <param name="types"></param>
        void Insert(CenterStatus[] types);
        /// <summary>
        /// Текущий статус
        /// </summary>
        /// <param name="types"></param>
        void Insert(CurrentStatus[] types);
        /// <summary>
        /// EstateStatus
        /// </summary>
        /// <param name="types"></param>
        void Insert(EstateStatus[] types);
        /// <summary>
        /// Тип помещения
        /// </summary>
        /// <param name="types"></param>
        void Insert(FlatType[] types);
        /// <summary>
        /// Тип нормативного документа
        /// </summary>
        /// <param name="types"></param>
        void Insert(NormativeDocumentType[] types);
        /// <summary>
        /// Операционный статус
        /// </summary>
        /// <param name="types"></param>
        void Insert(OperationStatus[] types);
        /// <summary>
        /// Тип комнаты
        /// </summary>
        /// <param name="types"></param>
        void Insert(RoomType[] types);
        /// <summary>
        /// Тип структуры
        /// </summary>
        /// <param name="types"></param>
        void Insert(StructureStatus[] types);
        #endregion

        #region Данные
        /// <summary>
        /// Адресные объекты
        /// </summary>
        IRepository<AddressObject, Guid> AddressRepository { get; }
        /// <summary>
        /// Нормативные документы
        /// </summary>
        IRepository<NormativeDocument, Guid> NormativeDocument { get; }
        /// <summary>
        /// Stead
        /// </summary>
        IRepository<Stead, Guid> Steads { get; }
        /// <summary>
        /// Дома
        /// </summary>
        IRepository<House,Guid> Houses { get; }
        /// <summary>
        /// Номера строений
        /// </summary>
        IRepository<BuildNum,short> BuildNumbers { get; }
        /// <summary>
        /// Номера домов
        /// </summary>
        IRepository<HouseNum, int> HouseNumbers { get; }
        #endregion
    }
}
