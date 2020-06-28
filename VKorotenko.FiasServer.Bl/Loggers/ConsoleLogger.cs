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
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}