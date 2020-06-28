using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("ACTSTAT")]
    public class DbActualStatus
    {
        [Column("ACTSTATID"), Key]
        public byte ActstatId { get; set; }
        [Column("NAME"),MaxLength(100)]
        public string Name { get; set; }

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
