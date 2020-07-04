#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:08

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Тип помещения
    /// </summary>
    [Table("FLATTYPE")]
    public class DbFlatType
    {
        /// <summary>
        /// ключ
        /// </summary>
        [Column("FLTYPEID"), Key]
        public byte FltypeId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column("NAME"), MaxLength(20)]
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
        public static DbFlatType Get(FlatType arg)
        {
            return new DbFlatType()
            {
                FltypeId = arg.FltypeId,
                Name = arg.Name,
                ShortName = arg.ShortName
            };
        }
    }
}