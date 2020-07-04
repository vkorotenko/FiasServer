#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 22:17

#endregion

using System;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Dictionary
{
    /// <summary>
    /// Тип сокращений адресного объекта
    /// </summary>
    [Serializable]
    public class AddressObjectType
    {
        /// <summary>
        /// Корневой элемент
        /// </summary>
        public const string Root = "AddressObjectTypes";
        /// <summary>
        /// Название файла
        /// </summary>
        public const string Start = "AS_SOCRBASE_";
        /// <summary>
        /// Ключ сокращения
        /// </summary>
        [XmlAttribute(AttributeName = "KOD_T_ST")]
        public short KodTSt { get; set; }
        /// <summary>
        /// Полное сокращение
        /// </summary>
        [XmlAttribute(AttributeName = "SOCRNAME")]
        public string SocrName { get; set; }
        /// <summary>
        /// Аббревиатура
        /// </summary>
        [XmlAttribute(AttributeName = "SCNAME")]
        public string ScName { get; set; }
        /// <summary>
        /// Зона в системе
        /// </summary>
        [XmlAttribute(AttributeName = "LEVEL")]
        public short Level { get; set; }

    }
}