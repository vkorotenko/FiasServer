#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.07.2020 6:26
#endregion


using System.Text;
using System.Xml;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Общие утилиты для кода
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Перебирает атрибуты и формирует элемент.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static string GetXmlForElement(XmlReader reader)
        {
            var xml = new StringBuilder();
            xml.Append($"<{reader.Name} ");
            while (reader.MoveToNextAttribute())
            {
                var quoted = reader.Value.Replace("\"", "&quot;")
                    .Replace("'", "&apos;")
                    .Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("&", "&amp;");
                xml.Append($"{reader.Name}=\"{quoted}\" ");
            }
            xml.Append(" />");
            var result = xml.ToString();
            return result;
        }
    }
}
