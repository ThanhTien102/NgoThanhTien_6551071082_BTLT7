using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp1.Models
{
    /// <summary>
    /// Bảng TheLoaiSach - Mapping từ cơ sở dữ liệu (Database First)
    /// </summary>
    [Table("TheLoaiSach")]
    public class TheLoaiSach
    {
        /// <summary>
        /// Mã thể loại - Khóa chính, tự tăng
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTL { get; set; }

        /// <summary>
        /// Tên thể loại - Không được trống, duy nhất
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TenTheLoai { get; set; } = null!;

        /// <summary>
        /// Mô tả - Cho phép null
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string? MoTa { get; set; }

        /// <summary>
        /// Số lượng sách thuộc thể loại này - Mặc định 0
        /// </summary>
        public int SoLuongSach { get; set; } = 0;

        /// <summary>
        /// Ngày tạo - Mặc định GETDATE()
        /// </summary>
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
