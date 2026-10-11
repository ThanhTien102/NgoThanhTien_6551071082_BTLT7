using System.Linq.Expressions;

namespace WinFormsApp1.Data
{
    /// <summary>
    /// Generic Repository Interface - Định nghĩa các phương thức chung cho tất cả CRUD operations
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Lấy tất cả entities
        /// </summary>
        /// <returns>IQueryable danh sách entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Lấy entity theo ID
        /// </summary>
        /// <param name="id">ID của entity</param>
        /// <returns>Entity hoặc null nếu không tìm thấy</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Tìm entities theo điều kiện
        /// </summary>
        /// <param name="predicate">Biểu thức LINQ để lọc</param>
        /// <returns>IQueryable danh sách entities thỏa mãn điều kiện</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Kiểm tra tồn tại entity theo điều kiện
        /// </summary>
        /// <param name="predicate">Biểu thức LINQ để kiểm tra</param>
        /// <returns>True nếu tồn tại, ngược lại false</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Thêm một entity mới
        /// </summary>
        /// <param name="entity">Entity cần thêm</param>
        /// <returns>Entity đã thêm</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Thêm nhiều entities
        /// </summary>
        /// <param name="entities">Danh sách entities cần thêm</param>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Cập nhật một entity
        /// </summary>
        /// <param name="entity">Entity cần cập nhật</param>
        T Update(T entity);

        /// <summary>
        /// Xóa một entity
        /// </summary>
        /// <param name="entity">Entity cần xóa</param>
        void Remove(T entity);

        /// <summary>
        /// Xóa nhiều entities
        /// </summary>
        /// <param name="entities">Danh sách entities cần xóa</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Lưu thay đổi vào cơ sở dữ liệu
        /// </summary>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        Task<int> SaveChangesAsync();
    }
}
