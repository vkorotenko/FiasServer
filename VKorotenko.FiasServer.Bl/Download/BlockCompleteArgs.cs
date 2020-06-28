#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 20:44

#endregion

using System;

namespace VKorotenko.FiasServer.Bl.Download
{
    /// <summary>
    /// Параметры скачанного блока
    /// </summary>
    public class BlockCompleteArgs : EventArgs
    {
        /// <summary>
        /// Общая длина скачанного куска файла.
        /// </summary>
        public long Received { get; set; }
        /// <summary>
        /// Размер блока при скачивании.
        /// </summary>
        public long BlockSize { get; set; }
        /// <summary>
        /// Параметры скачанного блока.
        /// </summary>
        /// <param name="received">Общая длина скачанного куска файла.</param>
        /// <param name="blockSize">Размер блока при скачивании.</param>
        public BlockCompleteArgs(long received, long blockSize)
        {
            BlockSize = blockSize;
            Received = received;
        }
    }
}