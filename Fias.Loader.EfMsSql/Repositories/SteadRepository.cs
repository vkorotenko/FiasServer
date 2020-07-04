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
    public class SteadRepository : IRepository<Stead, Guid>
    {
        private readonly DataContext _ctx;
        public SteadRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(Stead item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Stead> items)
        {
            try
            {
                _ctx.Steads.BulkMerge(items.Select(n => n.Get()), o => o.ColumnPrimaryKeyExpression = c => c.STEADID);
            }
            catch (Exception e)
            {
                foreach (var stead in items)
                {
                    try
                    {
                        _ctx.Steads.Add(stead.Get());
                        _ctx.SaveChanges();
                    }
                    catch (Exception ie)
                    {
                        ;
                    }
                }


                throw e;
            }
            
        }

        public IEnumerable<Stead> All()
        {
            throw new NotImplementedException();
        }

        public Stead Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stead> Where(Func<Stead, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
