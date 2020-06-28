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
    [Table("STRSTAT")]

    public class DbStructureStatus
    {

        [Column("STRSTATID"),Key]
        public byte StrstatId { get; set; }
        [Column("NAME"),MaxLength(20)]
        public string Name { get; set; }
        [Column("SHORTNAME"),MaxLength(20)]
        public string ShortName { get; set; }
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