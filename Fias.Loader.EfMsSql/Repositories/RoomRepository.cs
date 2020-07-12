#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:05

#endregion

using Fias.Loader.EfMsSql.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Repositories
{
    /// <summary>
    /// Репозиторий комнат
    /// </summary>
    public class RoomRepository : IRepository<Room, Guid>
    {
        private readonly DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx"></param>
        public RoomRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="item"></param>
        public void Add(Room item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавить элементы
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<Room> items)
        {
            try
            {
                _ctx.Rooms.BulkInsert(items.Select(n => n.Get()), o => o.ColumnPrimaryKeyExpression = c => c.ROOMID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Получить по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Room Get(Guid key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Room> All()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Запрос по выражению
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Room> Where(Func<Room, bool> query)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Усечение таблицы
        /// </summary>
        public void Truncate()
        {
            const string truncate = "TRUNCATE TABLE ROOM";
            _ctx.Database.ExecuteSqlRaw(truncate);
        }
    }
}