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
    public class NormativeDocumentRepository : IRepository<NormativeDocument, Guid>
    {
        private readonly DataContext _ctx;
        public NormativeDocumentRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(NormativeDocument item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<NormativeDocument> items)
        {
            _ctx.NormativeDocuments.BulkMerge(items.Select(n => n.Get()), o => o.ColumnPrimaryKeyExpression = c => c.NormDocId);
        }

        public NormativeDocument Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NormativeDocument> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NormativeDocument> Where(Func<NormativeDocument, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
