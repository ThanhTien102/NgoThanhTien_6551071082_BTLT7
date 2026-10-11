using Bai2.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Bai2
{
    public partial class Form1 : Form
    {
        private HoiVienContext context;
        private int? selectedId = null;

        public Form1()
        {
            InitializeComponent();
            context = new HoiVienContext();
        }

        // ========== LOAD DATA ==========
        private void Form1_Load()
        {
            LoadData();
        }

        private void LoadData(string? searchTerm = null)
        {
            try
            {
                dgvHoiVien.Rows.Clear();

                var data = context.HoiViens.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    data = data.Where(h =>
                        h.HoTen.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        h.SDT.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        h.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                    );
                }

                foreach (var item in data)
                {
                    dgvHoiVien.Rows.Add(
                        item.MaHV,
                        item.HoTen,
                        item.GioiTinh ? "Nam" : "Nữ",
                        item.NgaySinh.ToString("dd/MM/yyyy"),
                        item.SDT,
                        item.Email,
                        item.HangThanhVien,
                        item.NgayDangKy.ToString("dd/MM/yyyy HH:mm"),
                        item.TrangThai ? "Đang hoạt động" : "Ngừng hoạt động"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== VALIDATION ==========
        private Dictionary<string, string> ValidateInput()
        {
            var errors = new Dictionary<string, string>();

            // Validate Họ Tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errors["HoTen"] = "Họ tên không được để trống";
            }

            // Validate SDT
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                errors["SDT"] = "Số điện thoại không được để trống";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtSDT.Text, @"^\d{10,15}$"))
            {
                errors["SDT"] = "Số điện thoại phải có 10-15 chữ số";
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errors["Email"] = "Email không được để trống";
            }
            else if (!txtEmail.Text.Contains("@"))
            {
                errors["Email"] = "Email phải chứa ký tự '@'";
            }

            // Validate Ngày Sinh
            if (dtngaySinh.Value > DateTime.Now)
            {
                errors["NgaySinh"] = "Ngày sinh không được lớn hơn ngày hiện tại";
            }
            else
            {
                var age = DateTime.Now.Year - dtngaySinh.Value.Year;
                if (dtngaySinh.Value > DateTime.Now.AddYears(-age))
                    age--;

                // Lưu ý: không rõ yêu cầu tuổi cụ thể, nên kiểm tra tuổi hợp lệ
                if (age < 0)
                {
                    errors["NgaySinh"] = "Tuổi không hợp lệ";
                }
            }

            return errors;
        }

        // ========== CLEAR FORM ==========
        private void ClearForm()
        {
            txtHoTen.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            dtngaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            cmbHangThanhVien.SelectedIndex = 0;
            chkDangHoatDong.Checked = true;
            selectedId = null;
        }

        // ========== BUTTON EVENTS ==========
        private void BtnThem_Click()
        {
            var errors = ValidateInput();
            if (errors.Count > 0)
            {
                string errorMessage = string.Join("\n", errors.Values);
                MessageBox.Show(errorMessage, "Lỗi Kiểm Tra Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var hoiVien = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = radNam.Checked,
                    NgaySinh = dtngaySinh.Value.Date,
                    SDT = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HangThanhVien = cmbHangThanhVien.SelectedItem.ToString()!,
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkDangHoatDong.Checked
                };

                context.HoiViens.Add(hoiVien);
                context.SaveChanges();

                MessageBox.Show("Thêm hội viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (DbUpdateException dbEx)
            {
                string errorMsg = "Lỗi khi thêm: Lỗi database";
                if (dbEx.InnerException != null)
                    errorMsg += $"\n{dbEx.InnerException.Message}";
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi thêm:\n{ex.Message}";
                if (ex.InnerException != null)
                    errorMsg += $"\n\nChi tiết: {ex.InnerException.Message}";
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click()
        {
            if (selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn một hội viên để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var errors = ValidateInput();
            if (errors.Count > 0)
            {
                string errorMessage = string.Join("\n", errors.Values);
                MessageBox.Show(errorMessage, "Lỗi Kiểm Tra Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var hoiVien = context.HoiViens.FirstOrDefault(h => h.MaHV == selectedId);
                if (hoiVien == null)
                {
                    MessageBox.Show("Không tìm thấy hội viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hoiVien.HoTen = txtHoTen.Text.Trim();
                hoiVien.GioiTinh = radNam.Checked;
                hoiVien.NgaySinh = dtngaySinh.Value.Date;
                hoiVien.SDT = txtSDT.Text.Trim();
                hoiVien.Email = txtEmail.Text.Trim();
                hoiVien.HangThanhVien = cmbHangThanhVien.SelectedItem.ToString()!;
                hoiVien.TrangThai = chkDangHoatDong.Checked;

                context.SaveChanges();

                MessageBox.Show("Cập nhật hội viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (DbUpdateException dbEx)
            {
                string errorMsg = "Lỗi khi sửa: Lỗi database";
                if (dbEx.InnerException != null)
                    errorMsg += $"\n{dbEx.InnerException.Message}";
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi sửa:\n{ex.Message}";
                if (ex.InnerException != null)
                    errorMsg += $"\n\nChi tiết: {ex.InnerException.Message}";
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click()
        {
            if (selectedId == null)
            {
                MessageBox.Show("Vui lòng chọn một hội viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa hội viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                var hoiVien = context.HoiViens.FirstOrDefault(h => h.MaHV == selectedId);
                if (hoiVien == null)
                {
                    MessageBox.Show("Không tìm thấy hội viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                context.HoiViens.Remove(hoiVien);
                context.SaveChanges();

                MessageBox.Show("Xóa hội viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadData();
            }
            catch (DbUpdateException dbEx)
            {
                string errorMsg = "Lỗi khi xóa: Lỗi database";
                if (dbEx.InnerException != null)
                    errorMsg += $"\n{dbEx.InnerException.Message}";
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi xóa:\n{ex.Message}";
                if (ex.InnerException != null)
                    errorMsg += $"\n\nChi tiết: {ex.InnerException.Message}";
                MessageBox.Show(errorMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTim_Click()
        {
            LoadData(txtTim.Text);
        }

        private void BtnLamMoi_Click()
        {
            txtTim.Text = "";
            ClearForm();
            LoadData();
        }

        private void DgvHoiVien_CellClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dgvHoiVien.Rows[e.RowIndex];
            selectedId = (int)row.Cells[0].Value;

            try
            {
                var hoiVien = context.HoiViens.FirstOrDefault(h => h.MaHV == selectedId);
                if (hoiVien != null)
                {
                    txtHoTen.Text = hoiVien.HoTen;
                    txtSDT.Text = hoiVien.SDT;
                    txtEmail.Text = hoiVien.Email;
                    dtngaySinh.Value = hoiVien.NgaySinh;
                    radNam.Checked = hoiVien.GioiTinh;
                    radNu.Checked = !hoiVien.GioiTinh;
                    cmbHangThanhVien.SelectedItem = hoiVien.HangThanhVien;
                    chkDangHoatDong.Checked = hoiVien.TrangThai;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                context?.Dispose();
            }
        }
    }
}
