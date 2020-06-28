using Fias.Loader.EfMsSql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fias.Loader.EfMsSql
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        private static string _conn;
        public DataContext(string connectionString)
        {
            _conn = connectionString;
            Database.EnsureCreated();
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrWhiteSpace(_conn))
                _conn = "Data Source=HP;Initial Catalog=FIAS_622;Integrated Security=True";
            optionsBuilder.UseSqlServer(_conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<AddressWorks>().HasKey(sc => new { sc.AddressId, sc.LicenseWorkId });
        }

        public DbSet<DbActualStatus> ActualStatuses { get; set; }
        public DbSet<DbAddressObjectType> AddressObjectTypes { get; set; }
        public DbSet<DbCenterStatus> CenterStatuses { get; set; }
        public DbSet<DbCurrentStatus> CurrentStatuses { get; set; }
        public DbSet<DbEstateStatus> EstateStatuses { get; set; }
        public DbSet<DbFlatType> FlatTypes { get; set; }
        public DbSet<DbNormativeDocumentType> NormativeDocumentTypes { get; set; }
        public DbSet<DbOperationStatus> OperationStatuses { get; set; }

        public DbSet<DbRoomType> RoomTypes { get; set; }
        public DbSet<DbStructureStatus> StructureStatuses { get; set; }
    }
}
