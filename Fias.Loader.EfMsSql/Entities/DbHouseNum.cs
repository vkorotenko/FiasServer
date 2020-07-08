#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  05.07.2020 10:13
#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Номер дома
    /// </summary>
    [Table("HOUSE_HOUSENUM")]
    public class DbHouseNum
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key,Column("ID")]
        public int Id { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        [MaxLength(20),Column("Name")]
        public string Name { get; set; }
    }
}
