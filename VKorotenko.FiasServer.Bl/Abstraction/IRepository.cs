#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 8:08
#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VKorotenko.FiasServer.Bl.Abstraction
{


    // TODO: Переписать позже на IQueryable http://www.k-press.ru/cs/2008/3/IQueryable/IQueryable.asp
    public interface IRepository< TEntity, in TKey> where TEntity : class
    {
        void Add(TEntity item);
        void AddRange(IEnumerable<TEntity> items);
        TEntity Get(TKey key);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Where(Func<TEntity, bool> query);
    }
}
