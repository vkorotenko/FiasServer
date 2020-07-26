#region License
// Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// email: koroten@ya.ru
// skype:vladimir-korotenko 
// https://vkorotenko.ru
// Создано:  19.08.2019 20:45
#endregion

using System.ComponentModel.DataAnnotations;

namespace FiasServer.Models
{
    /// <summary>
    /// Контейнер для страны
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ISO код страны
        /// </summary>
        [MaxLength(2)]
        public string Alpha2 { get; set; }
        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 3х символьный ISO код страны
        /// </summary>
        [MaxLength(3)]
        public string Alpha3 { get; set; }
    }
}