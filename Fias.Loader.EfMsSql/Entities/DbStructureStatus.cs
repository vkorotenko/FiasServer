#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:24

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// STRSTAT
    /// </summary>
    [Table("STRSTAT")]

    public class DbStructureStatus
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Column("STRSTATID"),Key]
        public byte StrstatId { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        [Column("NAME"),MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// Сокращение
        /// </summary>
        [Column("SHORTNAME"),MaxLength(20)]
        public string ShortName { get; set; }
        /// <summary>
        /// получение из XML
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static DbStructureStatus Get(StructureStatus arg)
        {
            return new DbStructureStatus()
            {
                StrstatId = arg.StrstatId,
                Name = arg.Name,
                ShortName = arg.ShortName
            };
        }
    }
}