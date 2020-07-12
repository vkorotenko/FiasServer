#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  11.07.2020 15:19

#endregion

using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Аргументы для обработки комнаты
    /// </summary>
    public class RoomEventArgs
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <param name="count">Количество уже обработанных</param>
        public RoomEventArgs(Room item, long count)
        {
            Item = item;
            Count = count;
        }
        /// <summary>
        /// Документ
        /// </summary>
        public Room Item { get; set; }
        /// <summary>
        /// Количество уже обработанных
        /// </summary>
        public long Count { get; set; }
    }
}