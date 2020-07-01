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
    public class AddressProcessorEventArgs : EventArgs
    {
        public AddressProcessorEventArgs(AddressObject address, long count)
        {
            Address = address;
            Count = count;
        }

        public long Count { get; private set; }
        public AddressObject Address { get; private set; }
    }
}