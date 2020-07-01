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
    public class AddressRepository : IRepository<AddressObject, Guid>
    {
        private DataContext _ctx;
        public AddressRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public void Add(AddressObject item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<AddressObject> items)
        {
            _ctx.AddressObjects.BulkMerge(items.Select(addressObject => addressObject.Get()));
        }

        public AddressObject Get(Guid key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressObject> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressObject> Where(Func<AddressObject, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
