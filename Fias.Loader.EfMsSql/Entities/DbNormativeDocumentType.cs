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
    /// <summary>
    /// Тип нормативного документа
    /// </summary>
    [Table("NDOCTYPE")]
    public class DbNormativeDocumentType
    {
        /// <summary>
        /// Ключ
        /// </summary>
        [Column( "NDTYPEID"),Key]
        public short NdtypeId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column( "NAME"),MaxLength(250)]
        public string Name { get; set; }
        /// <summary>
        /// Получение из XML
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
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