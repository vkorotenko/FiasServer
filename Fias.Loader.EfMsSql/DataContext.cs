using Fias.Loader.EfMsSql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fias.Loader.EfMsSql
{
    /// <summary>
    /// Контекст данных
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DataContext()
        {
        }
        private static string _conn;
        /// <summary>
        /// Конструктор с передачей строки соединения
        /// </summary>
        /// <param name="connectionString">Строка соединения</param>
        public DataContext(string connectionString)
        {
            _conn = connectionString;
            Database.EnsureCreated();
            Database.Migrate();
        }
        /// <summary>
        /// Конфигурировани БД
        /// </summary>
        /// <param name="optionsBuilder">Опции для билдера</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(_conn))
                _conn = "Data Source=HP;Initial Catalog=FIAS_622;Integrated Security=True";
            optionsBuilder.UseSqlServer(_conn);
        }
        /// <summary>
        /// Действия при создании модели
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<AddressWorks>().HasKey(sc => new { sc.AddressId, sc.LicenseWorkId });
        }
        /// <summary>
        /// Статус актуальности
        /// </summary>
        public DbSet<DbActualStatus> ActualStatuses { get; set; }
        /// <summary>
        /// Типы адресных объектов
        /// </summary>
        public DbSet<DbAddressObjectType> AddressObjectTypes { get; set; }
        /// <summary>
        /// Статус центра
        /// </summary>
        public DbSet<DbCenterStatus> CenterStatuses { get; set; }
        /// <summary>
        /// Текущий статус
        /// </summary>
        public DbSet<DbCurrentStatus> CurrentStatuses { get; set; }
        /// <summary>
        /// Estate
        /// </summary>
        public DbSet<DbEstateStatus> EstateStatuses { get; set; }
        /// <summary>
        /// Тип помещения
        /// </summary>
        public DbSet<DbFlatType> FlatTypes { get; set; }
        /// <summary>
        /// Тип нормативного документа
        /// </summary>
        public DbSet<DbNormativeDocumentType> NormativeDocumentTypes { get; set; }
        /// <summary>
        /// Операционный статус
        /// </summary>
        public DbSet<DbOperationStatus> OperationStatuses { get; set; }
        /// <summary>
        /// тип комнаты
        /// </summary>
        public DbSet<DbRoomType> RoomTypes { get; set; }
        /// <summary>
        /// Структурный статус
        /// </summary>
        public DbSet<DbStructureStatus> StructureStatuses { get; set; }
        /// <summary>
        /// Адресные объекты
        /// </summary>
        public DbSet<DbAddressObject> AddressObjects { get; set; }
        /// <summary>
        /// Нормативные документы
        /// </summary>
        public DbSet<DbNormativeDocument> NormativeDocuments { get; set; }
        /// <summary>
        /// Stead
        /// </summary>
        public DbSet<DbStead> Steads { get; set; }
    }
}
