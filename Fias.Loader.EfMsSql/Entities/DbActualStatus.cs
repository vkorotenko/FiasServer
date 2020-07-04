using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Таблица статусов актуальности
    /// </summary>
    [Table("ACTSTAT")]
    public class DbActualStatus
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Column("ACTSTATID"), Key]
        public byte ActstatId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column("NAME"),MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Получение элемента из XML
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static DbActualStatus Get(ActualStatus st)
        {
            return new DbActualStatus()
            {
                ActstatId = st.ActstatId,
                Name = st.Name
            };
        }
    }
}
