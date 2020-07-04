#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 9:40
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
    /// Репозиторий адресов
    /// </summary>
    public class AddressRepository : IRepository<AddressObject, Guid>
    {
        private DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx">контекст ДБ</param>
        public AddressRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="item"></param>
        public void Add(AddressObject item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Пакетное добавление
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<AddressObject> items)
        {
            _ctx.AddressObjects.BulkMerge(items.Select(addressObject => addressObject.Get()));
        }
        /// <summary>
        /// Получение по ключу
        /// </summary>
        /// <param name="key">Первичный ключ</param>
        /// <returns></returns>
        public AddressObject Get(Guid key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddressObject> All()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Запрос по функции
        /// </summary>
        /// <param name="query">LINQ функция для фильтрации</param>
        /// <returns></returns>
        public IEnumerable<AddressObject> Where(Func<AddressObject, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
