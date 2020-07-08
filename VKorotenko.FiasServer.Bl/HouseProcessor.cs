#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.07.2020 22:29
#endregion

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Xml;
using VKorotenko.FiasServer.Bl.Data;

namespace VKorotenko.FiasServer.Bl
{
    #region Делегат обработки элемента
    /// <summary>
    /// Делегат обработки дома
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="args">Параметры</param>
    public delegate void HouseParsed(object sender, HouseEventArgs args);
    #endregion

    /// <summary>
    /// Обработчик для домов
    /// </summary>
    public class HouseProcessor
    {
        private readonly string _fullPath;
        private long _take;
        /// <summary>
        /// Имя обрабатываемого файла.
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// Число обработанных элементов.
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// процессор <see cref="House"/>
        /// </summary>
        /// <param name="pathToZip">Путь к файлу ФИАС</param>
        public HouseProcessor(string pathToZip)
        {
            _fullPath = pathToZip;

        }
        /// <summary>
        /// Запуск обработки файла
        /// </summary>
        /// <param name="take">Количество обрабатываемых записей</param>
        public async Task Run(long take = long.MaxValue)
        {
            _take = take;
            try
            {
                var reader = GetReader();
                while (await reader.ReadAsync())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == House.ContainerTag)
                            {
                                if (reader.HasAttributes)
                                {
                                    var result = Utils.GetXmlForElement(reader);
                                    try
                                    {
                                        var c = new House(result);
                                        OnItemParsed(this, c);
                                        Count++;
                                        if (Count > _take)
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
        /// <summary>
        /// Заполнение словарей
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public async Task RunDictionary(long take = long.MaxValue)
        {
            _take = take;
            Count = 0;
            try
            {
                var reader = GetReader();
                while (await reader.ReadAsync())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == House.ContainerTag)
                            {
                                if (reader.HasAttributes)
                                {
                                    
                                    try
                                    {
                                        var c = new House();
                                        var hr = false;
                                        var br = false;
                                        while (reader.MoveToNextAttribute())
                                        {
                                            if (reader.Name == HouseTags.HOUSENUM)
                                            {
                                                c.HOUSENUM = reader.Value.Trim();
                                                hr = true;
                                            }

                                            if (reader.Name == HouseTags.BUILDNUM)
                                            {
                                                c.BUILDNUM = reader.Value.Trim();
                                                br = true;
                                            }
                                            if (hr && br) break;
                                        }
                                        OnItemParsed(this, c);
                                        Count++;
                                        if (Count > _take)
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

        private XmlReader GetReader()
        {
            var stream = GetStream();
            var settings = new XmlReaderSettings()
            {
                Async = true
            };
            var reader = XmlReader.Create(stream, settings);
            return reader;
        }
        private Stream GetStream()
        {
            var ff = ZipFile.OpenRead(_fullPath);
            foreach (var entry in ff.Entries)
            {
                if (!entry.Name.ToUpperInvariant().StartsWith(House.Start.ToUpperInvariant())) continue;
                NodeName = entry.Name;
                var stream = entry.Open();
                return stream;
            }
            return null;
        }

        /// <summary>
        /// Событие обработки Stead.
        /// </summary>
        public event HouseParsed ItemParsed;
        /// <summary>
        /// Обработчик добавления Stead.
        /// </summary>
        /// <param name="s">Отправитель</param>
        /// <param name="item">Обработанный документ</param>
        protected virtual void OnItemParsed(object s, House item)
        {
            ItemParsed?.Invoke(s, new HouseEventArgs(item, Count));
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


