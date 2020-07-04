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
    /// <summary>
    /// Таблица центра
    /// </summary>
    [Table("CENTERST")]
    public class DbCenterStatus
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Column( "CENTERSTID"),Key]
        public byte CenterstId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column( "NAME"), MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Получение из XML
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
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