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
        public string AppName { get; set; }
        public string FiasConnection { get; set; }
        public string DbBack { get; set; }
        public string FullPath { get; set; }
    }

}
