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
    /// Аргумент изменение процесса скачивания
    /// </summary>
    public class DownloadProgressChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="totalReceived">Всего принято</param>
        /// <param name="fileSize">Размер файла</param>
        /// <param name="currentSpeed">Текущая скорость</param>
        public DownloadProgressChangedEventArgs(long totalReceived, long fileSize, long currentSpeed)
        {
            BytesReceived = totalReceived;
            TotalBytesToReceive = fileSize;
            CurrentSpeed = currentSpeed;
        }
        /// <summary>
        /// Байт принято
        /// </summary>
        public long BytesReceived { get; }
        /// <summary>
        /// Всего для приема
        /// </summary>
        public long TotalBytesToReceive { get; }
        /// <summary>
        /// Процент скачивания
        /// </summary>
        public float ProgressPercentage => BytesReceived / (float) TotalBytesToReceive * 100;
        /// <summary>
        /// Текущая скорость
        /// </summary>
        public float CurrentSpeed { get; } // in bytes
        /// <summary>
        /// Оставщееся время
        /// </summary>
        public TimeSpan TimeLeft
        {
            get
            {
                var bytesRemainingtoBeReceived = TotalBytesToReceive - BytesReceived;
                return TimeSpan.FromSeconds(bytesRemainingtoBeReceived / CurrentSpeed);
            }
        }
    }
}