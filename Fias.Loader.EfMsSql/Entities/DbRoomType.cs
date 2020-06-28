#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:20

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("ROOMTYPE")]
    public class DbRoomType
    {
        [Column("RMTYPEID"), Key]
        public byte RmtypeId { get; set; }
        [Column("NAME"), MaxLength(20)]
        public string Name { get; set; }
        [Column("SHORTNAME"), MaxLength(20)]
        public string ShortName { get; set; }

        public static DbRoomType Get(RoomType arg)
        {
            return new DbRoomType()
            {
                RmtypeId = arg.RmtypeId,
                Name = arg.Name,
                ShortName = arg.ShortName
            };
        }
    }
}