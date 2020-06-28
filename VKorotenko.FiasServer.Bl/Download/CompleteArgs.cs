#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 19:03

#endregion

using System;

namespace VKorotenko.FiasServer.Bl.Download
{
    /// <summary>
    /// Скачивание завершено
    /// </summary>
    public class CompleteArgs : EventArgs
    {
        /// <summary>
        /// Скачивание завершено.
        /// </summary>
        /// <param name="path">Путь к скачанному файлу</param>
        /// <param name="url">URL скачанного файла</param>
        /// <param name="date">Время завершения.</param>
        public CompleteArgs(string path, string url, DateTime date)
        {
            Date = date;
            Url = url;
            Path = path;
        }
        /// <summary>
        /// Время завершения
        /// </summary>
        public DateTime Date { get; private set; }
        /// <summary>
        /// Url скачанного файла
        /// </summary>
        public string Url { get; private set; }
        /// <summary>
        /// Путь к скачанному файлу
        /// </summary>
        public string Path { get; private set; }
    }
}