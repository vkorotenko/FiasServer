#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:05

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Fias.Loader.EfMsSql.Entities;
using Fias.Loader.EfMsSql.Extensions;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Repositories
{
    /// <summary>
    /// Репозиторий домов
    /// </summary>
    public class HouseRepository : IRepository<House, Guid>
    {
        private readonly DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx"></param>
        public HouseRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="item"></param>
        public void Add(House item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавить элементы
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<House> items)
        {
            try
            {
                _ctx.Houses.BulkMerge(items.Select(n => n.Get()), o => o.ColumnPrimaryKeyExpression = c => c.HOUSEID);
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
        public House Get(Guid key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<House> All()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Запрос по выражению
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<House> Where(Func<House, bool> query)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Усечение таблицы
        /// </summary>
        public void Truncate()
        {
            throw new NotImplementedException();
        }
    }
}