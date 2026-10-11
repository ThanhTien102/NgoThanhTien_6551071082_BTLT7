using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    /// <summary>
    /// Service Interface cho thể loại sách
    /// Định nghĩa tất cả business logic operations
    /// </summary>
    public interface ITheLoaiSachService
    {
        /// <summary>
        /// Lấy tất cả thể loại sách và sắp xếp theo MaTL tăng dần
        /// </summary>
        /// <returns>Danh sách tất cả thể loại sách</returns>
        Task<List<TheLoaiSach>> GetAllAsync();

        /// <summary>
        /// Lấy thể loại sách theo MaTL
        /// </summary>
        /// <param name="maTL">Mã thể loại</param>
        /// <returns>Thể loại sách hoặc null nếu không tìm thấy</returns>
        Task<TheLoaiSach?> GetByIdAsync(int maTL);

        /// <summary>
        /// Tìm kiếm thể loại sách theo tên (chứa chuỗi tìm kiếm)
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách thể loại sách phù hợp</returns>
        Task<List<TheLoaiSach>> SearchByNameAsync(string keyword);

        /// <summary>
        /// Thêm một thể loại sách mới
        /// Kiểm tra tên không được trống và không trùng lặp
        /// </summary>
        /// <param name="tenTheLoai">Tên thể loại sách</param>
        /// <param name="moTa">Mô tả (tùy chọn)</param>
        /// <returns>Thể loại sách vừa thêm</returns>
        /// <exception cref="ArgumentException">Nếu tên trống hoặc trùng lặp</exception>
        Task<TheLoaiSach> AddAsync(string tenTheLoai, string? moTa = null);

        /// <summary>
        /// Cập nhật thông tin thể loại sách
        /// </summary>
        /// <param name="maTL">Mã thể loại sách cần cập nhật</param>
        /// <param name="tenTheLoai">Tên thể loại sách mới</param>
        /// <param name="moTa">Mô tả mới (tùy chọn)</param>
        /// <returns>Thể loại sách đã cập nhật</returns>
        /// <exception cref="ArgumentException">Nếu không tìm thấy hoặc dữ liệu không hợp lệ</exception>
        Task<TheLoaiSach> UpdateAsync(int maTL, string tenTheLoai, string? moTa = null);

        /// <summary>
        /// Xóa một thể loại sách
        /// </summary>
        /// <param name="maTL">Mã thể loại sách cần xóa</param>
        /// <returns>True nếu xóa thành công, False nếu không tìm thấy</returns>
        /// <exception cref="DbUpdateException">Nếu vi phạm foreign key constraint</exception>
        Task<bool> DeleteAsync(int maTL);

        /// <summary>
        /// Kiểm tra tên thể loại sách đã tồn tại chưa
        /// </summary>
        /// <param name="tenTheLoai">Tên thể loại sách</param>
        /// <param name="excludeMaTL">Mã thể loại cần loại trừ khi kiểm tra (dùng cho Update)</param>
        /// <returns>True nếu tồn tại, False nếu chưa</returns>
        Task<bool> IsNameExistsAsync(string tenTheLoai, int? excludeMaTL = null);

        /// <summary>
        /// Đếm tổng số thể loại sách
        /// </summary>
        /// <returns>Số lượng thể loại sách</returns>
        Task<int> CountAsync();
    }
}
