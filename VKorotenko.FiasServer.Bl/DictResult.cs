#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  27.06.2020 15:31

#endregion

using VKorotenko.FiasServer.Bl.Dictionary;

namespace VKorotenko.FiasServer.Bl
{
    /// <summary>
    /// Результаты обработки словарей
    /// </summary>
    public class DictResult
    {
        /// <summary>
        /// Статус актуальности
        /// </summary>
        public ActualStatus[] ActualStatuses { get; set; }
        /// <summary>
        /// Типы адресных объектов
        /// </summary>
        public AddressObjectType[] AddressObjectTypes { get; set; }
        /// <summary>
        /// Статус центра
        /// </summary>
        public CenterStatus[] CenterStatuses { get; set; }
        /// <summary>
        /// Текущий статус
        /// </summary>
        public CurrentStatus[] CurrentStatuses { get; set; }
        /// <summary>
        /// Estate
        /// </summary>
        public EstateStatus[] EstateStatuses { get; set; }
        /// <summary>
        /// Тип помещения
        /// </summary>
        public FlatType[] FlatTypes { get; set; }
        /// <summary>
        /// Тип нормативного документа
        /// </summary>
        public NormativeDocumentType[] NormativeDocumentTypes { get; set; }
        /// <summary>
        /// Операционный статус
        /// </summary>
        public OperationStatus[] OperationStatuses { get; set; }
        /// <summary>
        /// Тип комнаты
        /// </summary>
        public RoomType[] RoomTypes { get; set; }
        /// <summary>
        /// Тип структуры
        /// </summary>
        public StructureStatus[] StructureStatuses { get; set; }

    }
}