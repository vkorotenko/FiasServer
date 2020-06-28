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
    [Table("SOCRBASE")]
    public class  DbAddressObjectType
    {
        [Column( "KOD_T_ST"),Key]
        public Int16 KodTSt { get; set; }
        [Column( "SOCRNAME"), MaxLength(50)]
        public string SocrName { get; set; }
        [Column( "SCNAME"), MaxLength(10)]
        public string ScName { get; set; }
        [Column( "LEVEL")]
        public Int16 Level { get; set; }

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