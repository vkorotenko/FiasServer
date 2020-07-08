#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:21
#endregion

using System.ComponentModel.DataAnnotations;

namespace VKorotenko.FiasServer.Bl.Data
{
    /// <summary>
    /// Номер строения
    /// </summary>
    public class BuildNum
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public short Id { get; set; }
        /// <summary>
        /// Номер строения
        /// </summary>
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
