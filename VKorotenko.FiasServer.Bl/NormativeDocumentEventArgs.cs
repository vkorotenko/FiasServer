#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.07.2020 22:51

#endregion

using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Аргумент для парсинга документа
    /// </summary>
    public class NormativeDocumentEventArgs
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="doc">Документ</param>
        /// <param name="count">Общее количество обработанных элементов</param>
        public NormativeDocumentEventArgs(NormativeDocument doc, long count)
        {
            Document = doc;
            Count = count;
        }
        /// <summary>
        /// Документ
        /// </summary>
        public NormativeDocument Document { get; set; }
        /// <summary>
        /// Общее количество обработанных элементов
        /// </summary>
        public long Count { get; set; }
    }
}