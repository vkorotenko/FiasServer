#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.06.2020 21:52

#endregion

using System;

namespace VKorotenko.FiasServer.Bl.Loggers
{
    /// <summary>
    /// Логгер с выводом на консоль
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Вывод на консоль
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="args">Объекты форматирования</param>
        public void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}