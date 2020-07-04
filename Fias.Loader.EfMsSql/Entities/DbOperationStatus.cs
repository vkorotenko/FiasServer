#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:16

#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Операционный статус
    /// </summary>
    [Table("OPERSTAT")]
    public class DbOperationStatus
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Column("OPERSTATID"), Key]
        public byte OperstatId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column("NAME"), MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Получение из XML
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static DbOperationStatus Get(OperationStatus arg)
        {
            return new DbOperationStatus()
            {
                OperstatId = arg.OperstatId,
                Name = arg.Name
            };
        }
    }
}