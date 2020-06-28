#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.06.2020 22:11

#endregion

namespace VKorotenko.FiasServer.Bl.Loggers
{
    public interface ILogger
    {
        void LogMessage(string message, params object[] args);
    }
}