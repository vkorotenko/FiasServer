#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 8:08
#endregion

using System;
using System.Collections.Generic;

namespace VKorotenko.FiasServer.Bl.Abstraction
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>

    // TODO: Переписать позже на IQueryable http://www.k-press.ru/cs/2008/3/IQueryable/IQueryable.asp
    public interface IRepository< TEntity, in TKey> where TEntity : class
    {
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        void Add(TEntity item);
        /// <summary>
        /// Пакетная вставка элементов
        /// </summary>
        /// <param name="items">Элементы</param>
        void AddRange(IEnumerable<TEntity> items);
        /// <summary>
        /// Получение по первичному ключу
        /// </summary>
        /// <param name="key">Первичный ключ</param>
        /// <returns></returns>
        TEntity Get(TKey key);
        /// <summary>
        /// Все элементы в репозитории.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> All();
        /// <summary>
        /// Поиск по функции. 
        /// </summary>
        /// <param name="query">Поисковая функция, например: x=>x.Id == id </param>
        /// <returns></returns>
        IEnumerable<TEntity> Where(Func<TEntity, bool> query);
    }
}
