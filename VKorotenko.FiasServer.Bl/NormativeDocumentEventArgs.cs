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
    public class NormativeDocumentEventArgs
    {
        public NormativeDocumentEventArgs(NormativeDocument doc, long count)
        {
            Document = doc;
            Count = count;
        }

        public NormativeDocument Document { get; set; }
        public long Count { get; set; }
    }
}