#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 14:56

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Таблица актуального статуса
    /// </summary>
    [Table("CURENTST")]
    public class DbCurrentStatus
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Column("CURENTSTID"),Key]
        public byte CurentstId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column( "NAME"),MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Получение из XML объекта
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static DbCurrentStatus Get(CurrentStatus arg)
        {
            return  new DbCurrentStatus()
            {
                CurentstId = arg.CurentstId,
                Name =  arg.Name
            };
        }
    }
}