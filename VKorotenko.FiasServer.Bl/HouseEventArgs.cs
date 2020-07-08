#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 7:34

#endregion

using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Аргументы для обработки дома
    /// </summary>
    public class HouseEventArgs
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <param name="count">Количество уже обработанных</param>
        public HouseEventArgs(House item, long count)
        {
            Item = item;
            Count = count;
        }
        /// <summary>
        /// Документ
        /// </summary>
        public House Item { get; set; }
        /// <summary>
        /// Количество уже обработанных
        /// </summary>
        public long Count { get; set; }
    }
}