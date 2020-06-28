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
    public class DictResult
    {
        public ActualStatus[] ActualStatuses { get; set; }
        public AddressObjectType[] AddressObjectTypes { get; set; }
        public CenterStatus[] CenterStatuses { get; set; }
        public CurrentStatus[] CurrentStatuses { get; set; }
        public EstateStatus[] EstateStatuses { get; set; }
        public FlatType[] FlatTypes { get; set; }
        public NormativeDocumentType[] NormativeDocumentTypes { get; set; }
        public OperationStatus[] OperationStatuses { get; set; }
        public RoomType[] RoomTypes { get; set; }
        public StructureStatus[] StructureStatuses { get; set; }

    }
}