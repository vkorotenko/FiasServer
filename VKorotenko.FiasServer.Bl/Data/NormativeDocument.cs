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
        public const string Root = "NormativeDocumentes";
        public const string Start = "AS_NORMDOC_";
        public const string Table = "NORMDOC";
        public const string ContainerTag = "NormativeDocument";
        #endregion

        #region Свойства

        [XmlAttribute(NormativeDocumentTags.NORMDOCID)]
        public Guid NormDocId { get; set; }
        [XmlAttribute(NormativeDocumentTags.DOCNAME)]
        public string DocName { get; set; }
        [XmlAttribute(NormativeDocumentTags.DOCDATE)]
        public string DocDate { get; set; }
        [XmlAttribute(NormativeDocumentTags.DOCNUM)]
        public string DocNum { get; set; }
        [XmlAttribute(NormativeDocumentTags.DOCTYPE)]
        public string DocType { get; set; }
        [XmlAttribute(NormativeDocumentTags.DOCIMGID)]
        public string DocImgId { get; set; }

        #endregion
        public NormativeDocument(string xml)
        {
            LoadXml(xml);
        }
        public NormativeDocument() { }

        public void LoadXml(string source)
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