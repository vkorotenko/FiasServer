#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 12:24

#endregion

namespace VKorotenko.FiasServer.Bl.Download
{
    /// <summary>
    ///     Пакет информации о файлах
    /// </summary>
    public class DownloadFileInfo
    {
        /// <summary>
        ///     Идентификатор версии
        /// </summary>
        public int VersionId { get; set; }

        /// <summary>
        ///     Текстовая версия
        /// </summary>
        public string TextVersion { get; set; }

        /// <summary>
        ///     Url полной базы в DBF
        /// </summary>
        public string FiasCompleteDbfUrl { get; set; }

        /// <summary>
        ///     Url полной базы в XML
        /// </summary>
        public string FiasCompleteXmlUrl { get; set; }

        /// <summary>
        ///     Url дельты базы в DBF
        /// </summary>
        public string FiasDeltaDbfUrl { get; set; }

        /// <summary>
        ///     Url дельты базы в XML
        /// </summary>
        public string FiasDeltaXmlUrl { get; set; }

        /// <summary>
        ///     Url  базы кладр в ARJ
        /// </summary>
        public string Kladr4ArjUrl { get; set; }

        /// <summary>
        ///     Url  базы кладр в 7ZIP
        /// </summary>
        public string Kladr47ZUrl { get; set; }
    }
}