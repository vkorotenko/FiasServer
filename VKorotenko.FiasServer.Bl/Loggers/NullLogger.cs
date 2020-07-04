#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.06.2020 21:53

#endregion

namespace VKorotenko.FiasServer.Bl.Loggers
{
    /// <summary>
    /// Ничего не делающий логгер
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// Ничего
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="args">аргументы</param>
        public void LogMessage(string message, params object[] args)
        {
            return;
        }
    }
}