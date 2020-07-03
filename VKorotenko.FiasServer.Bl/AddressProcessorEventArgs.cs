#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 11:08

#endregion

using System;
using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Аргументы обработки Адреса
    /// </summary>
    public class AddressProcessorEventArgs : EventArgs
    {
        /// <summary>
        /// Аргументы обработки Адреса
        /// </summary>
        /// <param name="address">Обработанный адрес</param>
        /// <param name="count">Количество обработанных адресов</param>
        public AddressProcessorEventArgs(AddressObject address, long count)
        {
            Address = address;
            Count = count;
        }
        /// <summary>
        /// Количество обработанных адресов
        /// </summary>
        public long Count { get; private set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public AddressObject Address { get; private set; }
    }
}