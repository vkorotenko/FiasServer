#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  11.07.2020 15:17
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
    /// Делегат обработки комнаты
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="args">Параметры</param>
    public delegate void RoomParsed(object sender, RoomEventArgs args);
    #endregion

    /// <summary>
    /// Обработчик для домов
    /// </summary>
    public class RoomProcessor
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
        public RoomProcessor(string pathToZip)
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
                            if (reader.Name == Room.ContainerTag)
                            {
                                if (reader.HasAttributes)
                                {
                                    var result = Utils.GetXmlForElement(reader);
                                    try
                                    {
                                        var c = new Room(result);
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
                if (!entry.Name.ToUpperInvariant().StartsWith(Room.Start.ToUpperInvariant())) continue;
                NodeName = entry.Name;
                var stream = entry.Open();
                return stream;
            }
            return null;
        }

        /// <summary>
        /// Событие обработки Stead.
        /// </summary>
        public event RoomParsed ItemParsed;
        /// <summary>
        /// Обработчик добавления Stead.
        /// </summary>
        /// <param name="s">Отправитель</param>
        /// <param name="item">Обработанный документ</param>
        protected virtual void OnItemParsed(object s, Room item)
        {
            ItemParsed?.Invoke(s, new RoomEventArgs(item, Count));
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
