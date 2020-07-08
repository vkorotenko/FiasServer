#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:03
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Fias.Loader.EfMsSql.Entities;
using Microsoft.EntityFrameworkCore;
using VKorotenko.FiasServer.Bl.Abstraction;
using VKorotenko.FiasServer.Bl.Data;
using Z.BulkOperations;

namespace Fias.Loader.EfMsSql.Repositories
{
    /// <summary>
    /// Словарь для номеров дома.
    /// </summary>
    public class HouseNumbersRepository : IRepository<HouseNum, int>
    {
        private DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx"></param>
        public HouseNumbersRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        public void Add(HouseNum item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавление массива элементов
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<HouseNum> items)
        {
            var list = items.Select(item => new DbHouseNum() { Id = item.Id, Name = item.Name });
            _ctx.HouseNums.BulkMerge(list, o =>
            {
                o.ColumnPrimaryKeyExpression = c => c.Id;
                o.BatchSize = 1000;
                o.CaseSensitive = CaseSensitiveType.Sensitive;
            });
        }
        /// <summary>
        /// Получение по индексу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public HouseNum Get(int key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HouseNum> All()
        {
            var list = _ctx.HouseNums.Select(houseNum => new HouseNum() { Id = houseNum.Id, Name = houseNum.Name.Trim() }).ToList();
            return list;
        }
        /// <summary>
        /// Поиск по выражению
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<HouseNum> Where(Func<HouseNum, bool> query)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Обрезание таблицы
        /// </summary>
        public void Truncate()
        {
            var truncate = "TRUNCATE TABLE HOUSE_HOUSENUM";
            var reset = "DBCC CHECKIDENT ('HOUSE_HOUSENUM', RESEED, 0)";
            _ctx.Database.ExecuteSqlRaw(truncate);
            _ctx.Database.ExecuteSqlRaw(reset);
        }
    }
}
