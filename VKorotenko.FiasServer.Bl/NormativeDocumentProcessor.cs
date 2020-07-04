#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.07.2020 22:29
#endregion

using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Xml;
using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Делегат обработки документа
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="args">Параметры</param>
    public delegate void DocumentParsed(object sender, NormativeDocumentEventArgs args);

    /// <summary>
    /// Парсер нормативных документов
    /// </summary>
    public class NormativeDocumentProcessor
    {
        private readonly string _fullPath;
        private long _count;
        private long _take;
        /// <summary>
        /// Имя обрабатываемого файла.
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// Процессор нормативных документов
        /// </summary>
        /// <param name="pathToZip"></param>
        public NormativeDocumentProcessor(string pathToZip)
        {
            _fullPath = pathToZip;
        }
        /// <summary>
        /// Запуск обработки файла
        /// </summary>
        /// <param name="take">Количество обрабатываемых адресов</param>
        public async Task Run(long take = long.MaxValue)
        {
            _take = take;
            using var archive = ZipFile.OpenRead(_fullPath);
            foreach (var entry in archive.Entries)
            {
                if (!entry.Name.ToUpperInvariant().StartsWith(NormativeDocument.Start.ToUpperInvariant())) continue;
                NodeName = entry.Name;
                try
                {
                    await using var stream = entry.Open();
                    var settings = new XmlReaderSettings()
                    {
                        Async = true
                    };

                    var reader = XmlReader.Create(stream, settings);
                    while (await reader.ReadAsync())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name == NormativeDocument.ContainerTag)
                                {

                                    if (reader.HasAttributes)
                                    {
                                        var result = Utils.GetXmlForElement(reader);
                                        try
                                        {
                                            var c = new NormativeDocument(result);
                                            OnDocumentParsed(this, c);
                                            _count++;
                                            if (_count > _take)
                                            {
                                                OnComplete(this);
                                                return;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Debug.WriteLine(e.Message);
                                        }
                                    }
                                }

                                break;
                        }
                    }
                }

                catch (Exception e)
                {
                    Debug.WriteLine(e.Message + " " + e.StackTrace);
                }
                OnComplete(this);
            }
        }
        /// <summary>
        /// Событие обработки документа.
        /// </summary>
        public event DocumentParsed DocumentParsed;
        /// <summary>
        /// Обработчик добавления документа.
        /// </summary>
        /// <param name="s">Отправитель</param>
        /// <param name="doc">Обработанный документ</param>
        protected virtual void OnDocumentParsed(object s, NormativeDocument doc)
        {
            DocumentParsed?.Invoke(s, new NormativeDocumentEventArgs(doc, _count));
        }
        /// <summary>
        /// Событие завершения обработки.
        /// </summary>
        public event Complete Complete;
        /// <summary>
        /// Обработчик конца обработки файла.
        /// </summary>
        /// <param name="s">Отправитель</param>
        protected virtual void OnComplete(object s)
        {
            Complete?.Invoke(s, new EventArgs());
        }
    }
}
