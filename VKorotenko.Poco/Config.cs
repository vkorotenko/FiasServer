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
    /// <summary>
    /// Файл конфигурации
    /// </summary>
    [Serializable]
    public class Config
    {
        static XmlSerializer _formatter = new XmlSerializer(typeof(Config));
        /// <summary>
        /// Путь до архива ФИАС
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// Строка подключения для выбранного модуля бэкенда ДБ <see cref="DbBackEnd"/>
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Модуль бэкенда DB
        /// </summary>
        public string DbBackEnd { get; set; }
        /// <summary>
        /// Перезаписывать ли данные
        /// </summary>
        public bool Override { get; set; }
        /// <summary>
        /// Перемена базы данных после загрузки
        /// </summary>
        public bool Swap { get; set; }
        /// <summary>
        /// Сохранение конфигурации
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="config">Экземпляр конфигурации</param>
        public static void Save(string path, Config config)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            _formatter.Serialize(fs, config);
        }
        /// <summary>
        /// Загрузка конфигурации
        /// </summary>
        /// <param name="path">Путь к файлу конфигурации</param>
        /// <returns></returns>
        public static Config Load(string path)
        {
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            return (Config)_formatter.Deserialize(fs);
        }

    }
}
