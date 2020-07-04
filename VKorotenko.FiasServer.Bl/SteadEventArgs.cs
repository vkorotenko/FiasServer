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
    public class SteadEventArgs
    {
        public SteadEventArgs(Stead doc, long count)
        {
            Document = doc;
            Count = count;
        }

        public Stead Document { get; set; }
        public long Count { get; set; }
    }
}