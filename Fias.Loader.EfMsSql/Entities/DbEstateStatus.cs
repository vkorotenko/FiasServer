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
    [Table("ESTSTAT")]
    public class DbEstateStatus
    {
        [Column("ESTSTATID"),Key]
        public byte EststatId { get; set; }
        [Column( "NAME"),MaxLength(20)]
        public string Name { get; set; }
        [Column("SHORTNAME"), MaxLength(20)]
        public string ShortName { get; set; }
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