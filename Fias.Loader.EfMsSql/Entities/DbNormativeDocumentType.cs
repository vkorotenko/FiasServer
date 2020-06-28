#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:13

#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    [Table("NDOCTYPE")]
    public class DbNormativeDocumentType
    {
        [Column( "NDTYPEID"),Key]
        public Int16 NdtypeId { get; set; }
        [Column( "NAME"),MaxLength(250)]
        public string Name { get; set; }
        public static DbNormativeDocumentType Get(NormativeDocumentType arg)
        {
            return new DbNormativeDocumentType()
            {
                NdtypeId = arg.NdtypeId,
                Name = arg.Name
            };
        }
    }
}