#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.07.2020 6:55

#endregion

using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Аргументы для <see cref="Stead"/>
    /// </summary>
    public class SteadEventArgs
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="doc">Документ</param>
        /// <param name="count">Количество уже обработанных</param>
        public SteadEventArgs(Stead doc, long count)
        {
            Document = doc;
            Count = count;
        }
        /// <summary>
        /// Документ
        /// </summary>
        public Stead Document { get; set; }
        /// <summary>
        /// Количество уже обработанных
        /// </summary>
        public long Count { get; set; }
    }
}