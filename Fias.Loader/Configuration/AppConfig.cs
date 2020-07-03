#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  28.06.2020 10:21
#endregion

namespace Fias.Loader.Configuration
{
    /// <summary>
    /// Конфигурация приложения считываемая из appsettings.json
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Строка соединения
        /// </summary>
        public string FiasConnection { get; set; }
        /// <summary>
        /// Движок базы данных
        /// </summary>
        public string DbBack { get; set; }
        /// <summary>
        /// Путь к архиву загруженной базы ФИАС
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// Обрабатываемые таблицы при загрузке. 
        /// </summary>
        public string[] ProcessTables { get; set; }
    }

}
