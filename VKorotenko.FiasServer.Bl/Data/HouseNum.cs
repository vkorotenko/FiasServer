#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 8:59

#endregion

using System.ComponentModel.DataAnnotations;

namespace VKorotenko.FiasServer.Bl.Data
{
    /// <summary>
    /// Номер дома
    /// </summary>
    public class HouseNum
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }
    }
}