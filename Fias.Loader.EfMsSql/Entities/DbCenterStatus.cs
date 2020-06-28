#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 14:22

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("CENTERST")]
    public class DbCenterStatus
    {
        [Column( "CENTERSTID"),Key]
        public byte CenterstId { get; set; }
        [Column( "NAME"), MaxLength(100)]
        public string Name { get; set; }

        public static DbCenterStatus Get(CenterStatus arg)
        {
            return  new DbCenterStatus()
            {
                CenterstId = arg.CenterstId,
                Name = arg.Name
            };
        }
    }
}