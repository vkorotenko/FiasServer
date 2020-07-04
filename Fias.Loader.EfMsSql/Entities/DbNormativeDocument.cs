#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  03.07.2020 7:44
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Data;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Нормативный документ
    /// </summary>
    [Table(NormativeDocument.Table)]
    public class DbNormativeDocument
    {
        #region Свойства
        /// <summary>
        /// Ключ
        /// </summary>
        [Column(NormativeDocumentTags.NORMDOCID),Key]
        public Guid NormDocId { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Column(NormativeDocumentTags.DOCNAME)]
        public string DocName { get; set; }
        /// <summary>
        /// Дата
        /// </summary>
        [Column(NormativeDocumentTags.DOCDATE)]
        public DateTime? DocDate { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        [Column(NormativeDocumentTags.DOCNUM),MaxLength(200)]
        public string DocNum { get; set; }
        /// <summary>
        /// Тип документа
        /// </summary>
        [Column(NormativeDocumentTags.DOCTYPE)]
        public short? DocType { get; set; }
        /// <summary>
        /// Изображение
        /// </summary>
        [Column(NormativeDocumentTags.DOCIMGID)]
        public Guid? DocImgId { get; set; }

        #endregion
    }
}
