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
    public delegate void SteadParsed(object sender, SteadEventArgs args);

    public class SteadProcessor
    {
        private readonly string _fullPath;
        private long _count;
        private long _take;
        /// <summary>
        /// Имя обрабатываемого файла.
        /// </summary>
        public string NodeName { get; set; }
        public SteadProcessor(string pathToZip)
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
                if (!entry.Name.ToUpperInvariant().StartsWith(Stead.Start.ToUpperInvariant())) continue;
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
                                if (reader.Name == Stead.ContainerTag)
                                {

                                    if (reader.HasAttributes)
                                    {
                                        var result = Utils.GetXmlForElement(reader);
                                        try
                                        {
                                            var c = new Stead(result);
                                            OnSteadParsed(this, c);
                                            _count++;
                                            if (_count > _take)
                                            {
                                                OnComplete(this);
                                                return;
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Debug.WriteLine($"{e.Message} {e.StackTrace}");
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
        /// Событие обработки Stead.
        /// </summary>
        public event SteadParsed SteadParsed;
        /// <summary>
        /// Обработчик добавления Stead.
        /// </summary>
        /// <param name="s">Отправитель</param>
        /// <param name="doc">Обработанный документ</param>
        protected virtual void OnSteadParsed(object s, Stead doc)
        {
            SteadParsed?.Invoke(s, new SteadEventArgs(doc, _count));
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
