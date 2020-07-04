#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.06.2020 21:53

#endregion

using System.Diagnostics;

namespace VKorotenko.FiasServer.Bl.Loggers
{
    /// <summary>
    /// логгер с выводом в консоль отладки
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Вывод в отладку
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="args">Параметры форматирования</param>
        public void LogMessage(string message, params object[] args)
        {
            Debug.WriteLine(message, args);
        }
    }
}