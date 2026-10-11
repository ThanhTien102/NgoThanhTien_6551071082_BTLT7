namespace Bai2.Models
{
    public class HoiVien
    {
        public int MaHV { get; set; }
        public string HoTen { get; set; } = null!;
        public bool GioiTinh { get; set; } // true = Nam, false = Nữ
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HangThanhVien { get; set; } = null!; // Basic, VIP, Premium
        public DateTime NgayDangKy { get; set; }
        public bool TrangThai { get; set; }
    }
}
