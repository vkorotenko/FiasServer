#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:22
#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("HOUSE_BUILDNUM")]
    public class DbBuildNum
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key,Column("ID")]
        public short Id { get; set; }
        /// <summary>
        /// Номер строения
        /// </summary>
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
