#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.07.2020 7:14
#endregion

using Fias.Loader.EfMsSql.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Repositories
{
    /// <summary>
    /// Репозиторий SteadRepository
    /// </summary>
    public class SteadRepository : IRepository<Stead, Guid>
    {
        private readonly DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx">Контекст БД</param>
        public SteadRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="item"></param>
        public void Add(Stead item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавление списка элементов
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<Stead> items)
        {
            try
            {
                _ctx.Steads.BulkMerge(items.Select(n => n.Get()), o => o.ColumnPrimaryKeyExpression = c => c.STEADID);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stead> All()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Получение по первичному ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Stead Get(Guid key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Получение по LINQ функции
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<Stead> Where(Func<Stead, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
