#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:03

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// ESTSTAT
    /// </summary>
    [Table("ESTSTAT")]
    public class DbEstateStatus
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Column("ESTSTATID"),Key]
        public byte EststatId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column( "NAME"),MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// Сокращение
        /// </summary>
        [Column("SHORTNAME"), MaxLength(20)]
        public string ShortName { get; set; }
        /// <summary>
        /// Получение из XML
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static DbEstateStatus Get(EstateStatus arg)
        {
            return new DbEstateStatus()
            {
                EststatId = arg.EststatId,
                Name = arg.Name,
                ShortName = arg.ShortName
            };
        }
    }
}