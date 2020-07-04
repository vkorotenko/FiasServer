#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 14:12

#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VKorotenko.FiasServer.Bl.Dictionary;

namespace Fias.Loader.EfMsSql.Entities
{
    /// <summary>
    /// Таблица сокращений
    /// </summary>
    [Table("SOCRBASE")]
    public class  DbAddressObjectType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Column( "KOD_T_ST"),Key]
        public short KodTSt { get; set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        [Column( "SOCRNAME"), MaxLength(50)]
        public string SocrName { get; set; }
        /// <summary>
        /// Сокращенное имя
        /// </summary>
        [Column( "SCNAME"), MaxLength(10)]
        public string ScName { get; set; }
        /// <summary>
        /// Уровень объекта
        /// </summary>
        [Column( "LEVEL")]
        public Int16 Level { get; set; }
        /// <summary>
        /// Получение из XML объекта
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DbAddressObjectType Get(AddressObjectType type)
        {
            return  new DbAddressObjectType()
            {
                KodTSt = type.KodTSt,
                Level = type.Level,
                ScName = type.ScName,
                SocrName = type.SocrName
            };
        }
    }
}