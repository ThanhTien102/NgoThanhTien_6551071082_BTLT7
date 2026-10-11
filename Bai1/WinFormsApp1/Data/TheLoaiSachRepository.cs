using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data
{
    /// <summary>
    /// Repository implementation cho entity TheLoaiSach
    /// Quản lý tất cả CRUD operations cho thể loại sách
    /// </summary>
    public class TheLoaiSachRepository : IRepository<TheLoaiSach>
    {
        private readonly AppDbContext _context;

        public TheLoaiSachRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lấy tất cả thể loại sách
        /// </summary>
        public IQueryable<TheLoaiSach> GetAll()
        {
            return _context.TheLoaiSach.AsQueryable();
        }

        /// <summary>
        /// Lấy thể loại sách theo MaTL
        /// </summary>
        public async Task<TheLoaiSach?> GetByIdAsync(int id)
        {
            return await _context.TheLoaiSach.FindAsync(id);
        }

        /// <summary>
        /// Tìm các thể loại sách theo điều kiện
        /// </summary>
        public IQueryable<TheLoaiSach> Find(Expression<Func<TheLoaiSach, bool>> predicate)
        {
            return _context.TheLoaiSach.Where(predicate).AsQueryable();
        }

        /// <summary>
        /// Kiểm tra tồn tại thể loại sách theo điều kiện
        /// </summary>
        public async Task<bool> AnyAsync(Expression<Func<TheLoaiSach, bool>> predicate)
        {
            return await _context.TheLoaiSach.AnyAsync(predicate);
        }

        /// <summary>
        /// Thêm một thể loại sách mới
        /// </summary>
        public async Task<TheLoaiSach> AddAsync(TheLoaiSach entity)
        {
            _context.TheLoaiSach.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Thêm nhiều thể loại sách
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<TheLoaiSach> entities)
        {
            _context.TheLoaiSach.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cập nhật một thể loại sách
        /// </summary>
        public TheLoaiSach Update(TheLoaiSach entity)
        {
            _context.TheLoaiSach.Update(entity);
            return entity;
        }

        /// <summary>
        /// Xóa một thể loại sách
        /// </summary>
        public void Remove(TheLoaiSach entity)
        {
            _context.TheLoaiSach.Remove(entity);
        }

        /// <summary>
        /// Xóa nhiều thể loại sách
        /// </summary>
        public void RemoveRange(IEnumerable<TheLoaiSach> entities)
        {
            _context.TheLoaiSach.RemoveRange(entities);
        }

        /// <summary>
        /// Lưu tất cả thay đổi vào cơ sở dữ liệu
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
