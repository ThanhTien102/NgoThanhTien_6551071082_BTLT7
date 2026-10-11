using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data
{
    /// <summary>
    /// DbContext quản lý kết nối và các bảng của cơ sở dữ liệu
    /// Được tạo theo phương pháp Database First
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<TheLoaiSach> TheLoaiSach { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Chuỗi kết nối - đổi tên server và database cho phù hợp với máy của bạn
                // Sử dụng LocalDB (MSSQLLocalDB) có sẵn khi cài SQL Server Express
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyThuVien;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình ràng buộc duy nhất cho cột TenTheLoai
            modelBuilder.Entity<TheLoaiSach>(entity =>
            {
                entity.HasIndex(e => e.TenTheLoai)
                      .IsUnique()
                      .HasDatabaseName("UQ_TheLoaiSach_TenTheLoai");

                // Giá trị mặc định cho cột SoLuongSach = 0
                entity.Property(e => e.SoLuongSach)
                      .HasDefaultValue(0);

                // Giá trị mặc định cho cột NgayTao = GETDATE()
                entity.Property(e => e.NgayTao)
                      .HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
