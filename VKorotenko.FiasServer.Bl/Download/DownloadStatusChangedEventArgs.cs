#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.07.2020 10:47

#endregion

using System;

namespace VKorotenko.FiasServer.Bl.Download
{
    /// <summary>
    /// Аргумент изменения статуса скачивания
    /// </summary>
    public class DownloadStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="canResume">Можно ли возобновить скачивание</param>
        public DownloadStatusChangedEventArgs(bool canResume)
        {
            ResumeSupported = canResume;
        }
        /// <summary>
        /// Можно ли возобновить
        /// </summary>
        public bool ResumeSupported { get; }
    }
}