#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.06.2020 21:53

#endregion

namespace VKorotenko.FiasServer.Bl.Loggers
{
    public class NullLogger : ILogger
    {
        public void LogMessage(string message, params object[] args)
        {
            return;
        }
    }
}