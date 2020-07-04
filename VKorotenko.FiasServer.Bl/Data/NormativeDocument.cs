#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.07.2020 20:03
#endregion

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace VKorotenko.FiasServer.Bl.Data
{
    /// <summary>
    /// Класс нормативного документа
    /// </summary>
    public class NormativeDocument
    {
        #region Служебные константы
        /// <summary>
        /// Корневой элемент в файле
        /// </summary>
        public const string Root = "NormativeDocumentes";
        /// <summary>
        /// Название файла в архиве
        /// </summary>
        public const string Start = "AS_NORMDOC_";
        /// <summary>
        /// Таблица в БД
        /// </summary>
        public const string Table = "NORMDOC";
        /// <summary>
        /// Тэг в документе
        /// </summary>
        public const string ContainerTag = "NormativeDocument";
        #endregion

        #region Свойства
        /// <summary>
        /// NORMDOCID
        /// </summary>
        [XmlAttribute(NormativeDocumentTags.NORMDOCID)]
        public Guid NormDocId { get; set; }
        /// <summary>
        /// DOCNAME
        /// </summary>
        [XmlAttribute(NormativeDocumentTags.DOCNAME)]
        public string DocName { get; set; }
        /// <summary>
        /// DOCDATE
        /// </summary>
        [XmlAttribute(NormativeDocumentTags.DOCDATE)]
        public string DocDate { get; set; }
        /// <summary>
        /// DOCNUM
        /// </summary>
        [XmlAttribute(NormativeDocumentTags.DOCNUM)]
        public string DocNum { get; set; }
        /// <summary>
        /// DOCTYPE
        /// </summary>
        [XmlAttribute(NormativeDocumentTags.DOCTYPE)]
        public string DocType { get; set; }
        /// <summary>
        /// DOCIMGID
        /// </summary>
        [XmlAttribute(NormativeDocumentTags.DOCIMGID)]
        public string DocImgId { get; set; }

        #endregion
        /// <summary>
        /// Загрузка XML
        /// </summary>
        /// <param name="xml"></param>
        public NormativeDocument(string xml)
        {
            LoadXml(xml);
        }
        /// <summary>
        /// Конструктор для сериализации
        /// </summary>
        public NormativeDocument() { }
        /// <summary>
        /// Загрузка XML
        /// </summary>
        /// <param name="source"></param>
        private void LoadXml(string source)
        {
            var serializer = new XmlSerializer(GetType());
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(source));
            var obj = serializer.Deserialize(ms);
            foreach (var p in obj.GetType().GetProperties())
            {
                var p2 = GetType().GetProperty(p.Name);
                if (p2 != null && p2.CanWrite) p2.SetValue(this, p.GetValue(obj, null), null);
            }
        }
    }
}