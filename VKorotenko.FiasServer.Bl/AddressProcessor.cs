#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 10:48

#endregion

using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Xml;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.PureData;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Делегат завершения обработки
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="args">Аргумент</param>
    public delegate void Complete(object sender, EventArgs args);
    /// <summary>
    /// Делегат обработки адреса
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="args">Параметры</param>
    public delegate void AddressParsed(object sender, AddressProcessorEventArgs args);
    
    /// <summary>
    /// Процессор адресов.
    /// </summary>
    public class AddressProcessor
    {
        private readonly string _fullPath;
        private long _count;
        private long _take;
        /// <summary>
        /// Конструктор с полным путем к архиву для обработки
        /// </summary>
        /// <param name="pathToZip">Архив ФИАС</param>
        public AddressProcessor(string pathToZip)
        {
            _fullPath = pathToZip;
        }
        /// <summary>
        /// Запуск обработки файла
        /// </summary>
        /// <param name="take">Количество обрабатываемых адресов</param>
        public void Run(long take = long.MaxValue)
        {
            _take = take;
            using var archive = ZipFile.OpenRead(_fullPath);
            foreach (var entry in archive.Entries)
            {
                if (entry.Name.ToUpperInvariant().StartsWith(XmlAddressObject.Start.ToUpperInvariant()))
                {
                    try
                    {
                        using var stream = entry.Open();
                        var settings = new XmlReaderSettings() { };

                        var reader = XmlReader.Create(stream, settings);
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    if (reader.Name == XmlAddressObject.ContainerTag)
                                    {

                                        if (reader.HasAttributes)
                                        {
                                            var result = Utils.GetXmlForElement(reader);
                                            try
                                            {
                                                var c = new XmlAddressObject(result);
                                                var n = XmlAddressObject.Get(c);
                                                OnAddressParsed(this, n);
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
        }

        
        /// <summary>
        /// Событие обработки адреса.
        /// </summary>
        public event AddressParsed AddressParsed;
        /// <summary>
        /// Обработчик добавления адреса.
        /// </summary>
        /// <param name="s">Отправитель</param>
        /// <param name="address">Обработанный адрес</param>
        protected virtual void OnAddressParsed(object s, AddressObject address)
        {
            AddressParsed?.Invoke(s, new AddressProcessorEventArgs(address, _count));
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