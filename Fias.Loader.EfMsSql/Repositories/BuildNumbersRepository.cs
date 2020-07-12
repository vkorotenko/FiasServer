#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:05

#endregion

using Fias.Loader.EfMsSql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;
using Z.BulkOperations;

namespace Fias.Loader.EfMsSql.Repositories
{
    /// <summary>
    /// Репозиторий строений
    /// </summary>
    public class BuildNumbersRepository : IRepository<BuildNum, short>
    {
        private readonly DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx"></param>
        public BuildNumbersRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public void Add(BuildNum item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавление элементов
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<BuildNum> items)
        {
            var list = items.Select(item => new DbBuildNum() { Name = item.Name });
            _ctx.BuildNums.BulkInsert(list, options =>
            {
                options.ColumnPrimaryKeyExpression = c => c.Name;
                options.CaseSensitive = CaseSensitiveType.Sensitive;
            });
        }
        /// <summary>
        /// Получаем элемент по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BuildNum Get(short key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BuildNum> All()
        {
            var list = _ctx.BuildNums.Select(buildNum => new BuildNum() { Id = buildNum.Id, Name = buildNum.Name.Trim() }).ToList();
            return list;
        }
        /// <summary>
        /// Запрос по выражению
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<BuildNum> Where(Func<BuildNum, bool> query)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Усечение таблицы
        /// </summary>
        public void Truncate()
        {
            var truncate = "TRUNCATE TABLE HOUSE_BUILDNUM";
            var reset = "DBCC CHECKIDENT ('HOUSE_BUILDNUM', RESEED, 0);";
            _ctx.Database.ExecuteSqlRaw(truncate);
            _ctx.Database.ExecuteSqlRaw(reset);
        }
    }
}