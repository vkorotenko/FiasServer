#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.07.2020 8:02
#endregion

using System;

namespace VKorotenko.FiasServer.Bl.Extensions
{
    /// <summary>
    /// Методы для обработки XML
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Парсинг строки с датой 
        /// </summary>
        /// <param name="src">Источник</param>
        /// <returns></returns>
        public static DateTime? ToNullDateTime(this string src)
        {
            if (DateTime.TryParse(src, out var n)) return n;
            return null;
        }
        /// <summary>
        /// Обнуляемый Guid
        /// </summary>
        /// <param name="src">Источник</param>
        /// <returns></returns>
        public static Guid? ToNullGuid(this string src)
        {
            if (Guid.TryParse(src, out var n)) return n;
            return null;
        }
        /// <summary>
        /// Обнуляемый short
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static short? ToNullShort(this string src)
        {
            if (short.TryParse(src, out var n)) return n;
            return null;
        }
        /// <summary>
        /// Попытка обработать статус, 0 если пустая строка
        /// </summary>
        /// <param name="conv">Источник</param>
        /// <returns></returns>
        public static byte GetCurStatus(this string conv)
        {
            return byte.TryParse(conv, out var n) ? n : (byte) 0;
        }
        /// <summary>
        /// Обнуляемое целое
        /// </summary>
        /// <param name="val">Источник</param>
        /// <returns></returns>
        public static int? ToNullInt(this string val)
        {
            if (int.TryParse(val, out var n)) return n;
            return null;
        }
        /// <summary>
        /// Обнуляемый long
        /// </summary>
        /// <param name="val">Источник</param>
        /// <returns></returns>
        public static long? ToNullLong(this string val)
        {
            if (long.TryParse(val, out var n)) return n;
            return null;
        }
    }
}
