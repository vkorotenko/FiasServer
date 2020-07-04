#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.06.2020 22:11

#endregion

namespace VKorotenko.FiasServer.Bl.Loggers
{
    /// <summary>
    /// Интерфейс логгера
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Вывод сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="args">параметры</param>
        void LogMessage(string message, params object[] args);
    }
}