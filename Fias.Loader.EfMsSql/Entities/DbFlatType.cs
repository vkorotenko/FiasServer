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
    [Table("FLATTYPE")]
    public class DbFlatType
    {
     
        [Column( "FLTYPEID"),Key]
        public byte FltypeId { get; set; }
        [Column( "NAME"),MaxLength(20)]
        public string Name { get; set; }
        [Column( "SHORTNAME"), MaxLength(20)]
        public string ShortName { get; set; }
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