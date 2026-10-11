using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    /// <summary>
    /// Service implementation cho thể loại sách
    /// Xử lý tất cả business logic và validation
    /// Sử dụng DbContext Factory để tạo context mới mỗi lần
    /// </summary>
    public class TheLoaiSachService : ITheLoaiSachService
    {
        private readonly IDbContextFactory _contextFactory;

        public TheLoaiSachService(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Lấy tất cả thể loại sách và sắp xếp theo MaTL tăng dần
        /// </summary>
        public async Task<List<TheLoaiSach>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.TheLoaiSach
                .OrderBy(t => t.MaTL)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy thể loại sách theo MaTL
        /// </summary>
        public async Task<TheLoaiSach?> GetByIdAsync(int maTL)
        {
            if (maTL <= 0)
                throw new ArgumentException("Mã thể loại phải lớn hơn 0", nameof(maTL));

            using var context = _contextFactory.CreateDbContext();
            return await context.TheLoaiSach.FindAsync(maTL);
        }

        /// <summary>
        /// Tìm kiếm thể loại sách theo tên (chứa chuỗi tìm kiếm)
        /// Không phân biệt hoa thường
        /// </summary>
        public async Task<List<TheLoaiSach>> SearchByNameAsync(string keyword)
        {
            using var context = _contextFactory.CreateDbContext();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await context.TheLoaiSach
                    .OrderBy(t => t.MaTL)
                    .ToListAsync();
            }

            keyword = keyword.Trim();
            return await context.TheLoaiSach
                .Where(t => t.TenTheLoai.Contains(keyword))
                .OrderBy(t => t.MaTL)
                .ToListAsync();
        }

        /// <summary>
        /// Thêm một thể loại sách mới
        /// Kiểm tra tên không được trống và không trùng lặp
        /// </summary>
        public async Task<TheLoaiSach> AddAsync(string tenTheLoai, string? moTa = null)
        {
            // Validate tên thể loại
            if (string.IsNullOrWhiteSpace(tenTheLoai))
                throw new ArgumentException("Tên thể loại sách không được bỏ trống", nameof(tenTheLoai));

            tenTheLoai = tenTheLoai.Trim();

            if (tenTheLoai.Length > 100)
                throw new ArgumentException("Tên thể loại sách không được vượt quá 100 ký tự", nameof(tenTheLoai));

            using var context = _contextFactory.CreateDbContext();

            // Kiểm tra trùng lặp - sử dụng ToLower() để so sánh không phân biệt hoa thường
            string tenLoai = tenTheLoai.ToLower();
            bool exists = await context.TheLoaiSach
                .AnyAsync(t => t.TenTheLoai.ToLower() == tenLoai);

            if (exists)
                throw new ArgumentException($"Tên thể loại '{tenTheLoai}' đã tồn tại", nameof(tenTheLoai));

            // Tạo thể loại sách mới
            var theLoai = new TheLoaiSach
            {
                TenTheLoai = tenTheLoai,
                MoTa = string.IsNullOrWhiteSpace(moTa) ? null : moTa.Trim(),
                SoLuongSach = 0,
                NgayTao = DateTime.Now
            };

            context.TheLoaiSach.Add(theLoai);
            await context.SaveChangesAsync();

            return theLoai;
        }

        /// <summary>
        /// Cập nhật thông tin thể loại sách
        /// </summary>
        public async Task<TheLoaiSach> UpdateAsync(int maTL, string tenTheLoai, string? moTa = null)
        {
            // Validate mã thể loại
            if (maTL <= 0)
                throw new ArgumentException("Mã thể loại phải lớn hơn 0", nameof(maTL));

            // Validate tên thể loại
            if (string.IsNullOrWhiteSpace(tenTheLoai))
                throw new ArgumentException("Tên thể loại sách không được bỏ trống", nameof(tenTheLoai));

            tenTheLoai = tenTheLoai.Trim();

            if (tenTheLoai.Length > 100)
                throw new ArgumentException("Tên thể loại sách không được vượt quá 100 ký tự", nameof(tenTheLoai));

            using var context = _contextFactory.CreateDbContext();

            // Lấy thể loại sách theo ID
            var theLoai = await context.TheLoaiSach.FindAsync(maTL);
            if (theLoai == null)
                throw new ArgumentException($"Không tìm thấy thể loại sách với mã {maTL}", nameof(maTL));

            // Kiểm tra trùng lặp tên (loại trừ chính nó)
            string tenLoai = tenTheLoai.ToLower();
            bool exists = await context.TheLoaiSach
                .AnyAsync(t => t.TenTheLoai.ToLower() == tenLoai
                            && t.MaTL != maTL);

            if (exists)
                throw new ArgumentException($"Tên thể loại '{tenTheLoai}' đã tồn tại", nameof(tenTheLoai));

            // Cập nhật thông tin
            theLoai.TenTheLoai = tenTheLoai;
            theLoai.MoTa = string.IsNullOrWhiteSpace(moTa) ? null : moTa.Trim();

            context.TheLoaiSach.Update(theLoai);
            await context.SaveChangesAsync();

            return theLoai;
        }

        /// <summary>
        /// Xóa một thể loại sách
        /// </summary>
        public async Task<bool> DeleteAsync(int maTL)
        {
            if (maTL <= 0)
                throw new ArgumentException("Mã thể loại phải lớn hơn 0", nameof(maTL));

            using var context = _contextFactory.CreateDbContext();

            var theLoai = await context.TheLoaiSach.FindAsync(maTL);
            if (theLoai == null)
                return false;

            context.TheLoaiSach.Remove(theLoai);
            await context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Kiểm tra tên thể loại sách đã tồn tại chưa
        /// </summary>
        public async Task<bool> IsNameExistsAsync(string tenTheLoai, int? excludeMaTL = null)
        {
            if (string.IsNullOrWhiteSpace(tenTheLoai))
                return false;

            tenTheLoai = tenTheLoai.Trim();
            string tenLoai = tenTheLoai.ToLower();

            using var context = _contextFactory.CreateDbContext();

            if (excludeMaTL.HasValue)
            {
                return await context.TheLoaiSach
                    .AnyAsync(t => t.TenTheLoai.ToLower() == tenLoai
                                && t.MaTL != excludeMaTL);
            }

            return await context.TheLoaiSach
                .AnyAsync(t => t.TenTheLoai.ToLower() == tenLoai);
        }

        /// <summary>
        /// Đếm tổng số thể loại sách
        /// </summary>
        public async Task<int> CountAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.TheLoaiSach.CountAsync();
        }
    }
}
