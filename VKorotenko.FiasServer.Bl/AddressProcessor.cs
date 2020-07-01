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
using System.Text;
using System.Xml;
using VKorotenko.FiasServer.Bl.Data;
using VKorotenko.FiasServer.Bl.PureData;
using VKorotenko.Poco;

namespace VKorotenko.FiasServer.Bl
{
    public delegate void Complete(object sender, EventArgs args);

    public delegate void AddressParsed(object sender, AddressProcessorEventArgs args);
    public class AddressProcessor
    {
        public Config Config { get; private set; }
        public AddressProcessor(Config config)
        {
            Config = config;
        }

        private long _count = 0;
        private long _take;
        public void Run(long take = long.MaxValue)
        {
            _take = take;
            using var archive = ZipFile.OpenRead(Config.FullPath);
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
                                            var result = GetXmlForElement(reader);
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

        private static string GetXmlForElement(XmlReader reader)
        {
            var xml = new StringBuilder();
            xml.Append($"<{reader.Name} ");
            while (reader.MoveToNextAttribute())
            {
                if (reader.Value.Contains(""))
                {
                    var quoted = reader.Value.Replace("\"", "&quot;"); 
                    xml.Append($"{reader.Name}=\"{quoted}\" ");
                }
                else
                    xml.Append($"{reader.Name}=\"{reader.Value}\" ");
            }
            xml.Append(" />");
            var result = xml.ToString();
            return result;
        }

        public event AddressParsed AddressParsed;
        protected virtual void OnAddressParsed(object s, AddressObject address)
        {
            AddressParsed?.Invoke(s, new AddressProcessorEventArgs(address, _count));
        }

        public event Complete Complete;
        protected virtual void OnComplete(Object s)
        {
            Complete?.Invoke(s, new EventArgs());
        }
    }
}