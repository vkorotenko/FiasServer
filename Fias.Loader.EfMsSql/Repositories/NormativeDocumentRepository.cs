#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.07.2020 7:41
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
    /// Нормативные документы
    /// </summary>
    public class NormativeDocumentRepository : IRepository<NormativeDocument, Guid>
    {
        private readonly DataContext _ctx;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="ctx">Контекст ДБ</param>
        public NormativeDocumentRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="item">элемент</param>
        public void Add(NormativeDocument item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Добавление нескольких элементов
        /// </summary>
        /// <param name="items">Список элементов</param>
        public void AddRange(IEnumerable<NormativeDocument> items)
        {
            _ctx.NormativeDocuments.BulkMerge(items.Select(n => n.Get()), o => o.ColumnPrimaryKeyExpression = c => c.NormDocId);
        }
        /// <summary>
        /// Получение по первичному ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns></returns>
        public NormativeDocument Get(Guid key)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Все элементы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NormativeDocument> All()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Получение по LINQ выражению
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<NormativeDocument> Where(Func<NormativeDocument, bool> query)
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
