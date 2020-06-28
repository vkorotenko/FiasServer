#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 22:02
#endregion


using System;
using System.IO;
using System.Xml.Serialization;

namespace VKorotenko.Poco
{
    [Serializable]
    public class Config
    {
        static XmlSerializer _formatter = new XmlSerializer(typeof(Config));
        public string FullPath { get; set; }
        public string ConnectionString { get; set; }
        public string DbBackEnd { get; set; }
        public bool Override { get; set; }
        public bool Swap { get; set; }

        public static void Save(string path, Config config)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            _formatter.Serialize(fs, config);
        }

        public static Config Load(string path)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            return (Config)_formatter.Deserialize(fs);
        }

    }
}
