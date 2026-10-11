using Microsoft.EntityFrameworkCore;

namespace Bai2.Models
{
    public class HoiVienContext : DbContext
    {
        public DbSet<HoiVien> HoiViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Cập nhật connection string theo SQL Server của bạn
            // Đối với LocalDB: (localdb)\mssqllocaldb
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=HoiVien;Trusted_Connection=true;",
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                )
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HoiVien>(entity =>
            {
                entity.ToTable("HoiVien");
                entity.HasKey(e => e.MaHV);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SDT)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HangThanhVien)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NgayDangKy)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.TrangThai)
                    .HasDefaultValue(true);
            });
        }
    }
}
