using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Data;
using WinFormsApp1.Models;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly ITheLoaiSachService _theLoaiSachService;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;

            // Khởi tạo Service với DbContextFactory
            var dbContextFactory = new AppDbContextFactory();
            _theLoaiSachService = new TheLoaiSachService(dbContextFactory);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadTheLoaiSach();
        }

        #region Load dữ liệu lên DataGridView

        /// <summary>
        /// Load toàn bộ danh sách thể loại sách từ cơ sở dữ liệu và hiển thị lên DataGridView
        /// </summary>
        private async Task LoadTheLoaiSach()
        {
            try
            {
                // Lấy danh sách thể loại sách từ Service (đã sắp xếp theo MaTL)
                var danhSach = await _theLoaiSachService.GetAllAsync();

                // Gán dữ liệu vào DataGridView
                dgvTheLoaiSach.DataSource = danhSach;

                // Đặt lại tiêu đề cột hiển thị tiếng Việt
                DatLaiTieuDeCot();

                // Xóa trắng các ô nhập liệu sau khi load
                LamTrongForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Đặt lại tiêu đề hiển thị của các cột trong DataGridView sang tiếng Việt
        /// </summary>
        private void DatLaiTieuDeCot()
        {
            if (dgvTheLoaiSach.Columns["MaTL"] != null)
                dgvTheLoaiSach.Columns["MaTL"].HeaderText = "Mã TL";

            if (dgvTheLoaiSach.Columns["TenTheLoai"] != null)
                dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên thể loại";

            if (dgvTheLoaiSach.Columns["MoTa"] != null)
                dgvTheLoaiSach.Columns["MoTa"].HeaderText = "Mô tả";

            if (dgvTheLoaiSach.Columns["SoLuongSach"] != null)
                dgvTheLoaiSach.Columns["SoLuongSach"].HeaderText = "Số lượng sách";

            if (dgvTheLoaiSach.Columns["NgayTao"] != null)
            {
                dgvTheLoaiSach.Columns["NgayTao"].HeaderText = "Ngày tạo";
                dgvTheLoaiSach.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
        }

        #endregion

        #region Sự kiện SelectionChanged - Đổ dữ liệu lên TextBox

        /// <summary>
        /// Sự kiện SelectionChanged: tự động đổ dữ liệu từ dòng đang chọn lên các TextBox và Label
        /// </summary>
        private void dgvTheLoaiSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoaiSach.CurrentRow == null)
                return;

            // Lấy đối tượng TheLoaiSach từ dòng đang chọn
            if (dgvTheLoaiSach.CurrentRow.DataBoundItem is TheLoaiSach theLoai)
            {
                txtMaTL.Text = theLoai.MaTL.ToString();
                txtTenTheLoai.Text = theLoai.TenTheLoai;
                txtMoTa.Text = theLoai.MoTa ?? string.Empty;
                lblNgayTao.Text = theLoai.NgayTao.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        #endregion

        #region Thêm mới

        /// <summary>
        /// Xử lý sự kiện click nút Thêm: thêm một thể loại sách mới vào cơ sở dữ liệu
        /// </summary>
        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi Service để thêm thể loại sách mới
                var theLoaiMoi = await _theLoaiSachService.AddAsync(
                    txtTenTheLoai.Text,
                    txtMoTa.Text
                );

                MessageBox.Show("Thêm thể loại sách thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới DataGridView ngay lập tức
                await LoadTheLoaiSach();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Dữ liệu không hợp lệ: {ex.Message}",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (ex.ParamName == "tenTheLoai" && string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
                    txtTenTheLoai.Focus();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.InnerException?.Message ?? ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Sửa

        /// <summary>
        /// Xử lý sự kiện click nút Sửa: cập nhật thông tin thể loại sách đang chọn
        /// </summary>
        private async void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra có dòng nào đang chọn
            if (dgvTheLoaiSach.CurrentRow == null ||
                dgvTheLoaiSach.CurrentRow.DataBoundItem is not TheLoaiSach theLoaiHienTai)
            {
                MessageBox.Show("Vui lòng chọn một thể loại sách cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Gọi Service để cập nhật thể loại sách
                var theLoaiCapNhat = await _theLoaiSachService.UpdateAsync(
                    theLoaiHienTai.MaTL,
                    txtTenTheLoai.Text,
                    txtMoTa.Text
                );

                MessageBox.Show("Cập nhật thể loại sách thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới DataGridView ngay lập tức
                await LoadTheLoaiSach();

                // Chọn lại dòng vừa sửa
                ChonDungDong(theLoaiCapNhat.MaTL);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Dữ liệu không hợp lệ: {ex.Message}",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (ex.ParamName == "tenTheLoai" && string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
                    txtTenTheLoai.Focus();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.InnerException?.Message ?? ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chọn lại dòng trong DataGridView theo MaTL
        /// </summary>
        private void ChonDungDong(int maTL)
        {
            foreach (DataGridViewRow row in dgvTheLoaiSach.Rows)
            {
                if (row.DataBoundItem is TheLoaiSach t && t.MaTL == maTL)
                {
                    row.Selected = true;
                    dgvTheLoaiSach.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        #endregion

        #region Xóa

        /// <summary>
        /// Xử lý sự kiện click nút Xóa: xóa thể loại sách đang chọn
        /// </summary>
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra có dòng nào đang chọn
            if (dgvTheLoaiSach.CurrentRow == null ||
                dgvTheLoaiSach.CurrentRow.DataBoundItem is not TheLoaiSach theLoaiHienTai)
            {
                MessageBox.Show("Vui lòng chọn một thể loại sách cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thể loại '{theLoaiHienTai.TenTheLoai}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Gọi Service để xóa thể loại sách
                bool deleted = await _theLoaiSachService.DeleteAsync(theLoaiHienTai.MaTL);

                if (deleted)
                {
                    MessageBox.Show("Xóa thể loại sách thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới DataGridView ngay lập tức
                    await LoadTheLoaiSach();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thể loại sách cần xóa!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DbUpdateException)
            {
                // Bắt lỗi ràng buộc khóa ngoài: thể loại đang được sách khác tham chiếu
                MessageBox.Show(
                    $"Không thể xóa thể loại '{theLoaiHienTai.TenTheLoai}' vì đang có sách tham chiếu đến thể loại này.\n" +
                    "Vui lòng xóa các sách liên quan trước.",
                    "Lỗi ràng buộc dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Làm mới

        /// <summary>
        /// Xử lý sự kiện click nút Làm mới: xóa trắng form và tải lại dữ liệu
        /// </summary>
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await LoadTheLoaiSach();
        }

        /// <summary>
        /// Xóa trắng các ô nhập liệu
        /// </summary>
        private void LamTrongForm()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();
            lblNgayTao.Text = "-";
        }

        #endregion

        #region Tìm kiếm

        /// <summary>
        /// Xử lý sự kiện click nút Tìm kiếm: lọc danh sách theo TenTheLoai bằng LINQ Contains
        /// </summary>
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();

                // Gọi Service để tìm kiếm
                var ketQua = await _theLoaiSachService.SearchByNameAsync(tuKhoa);

                // Hiển thị kết quả lọc trực tiếp lên DataGridView
                dgvTheLoaiSach.DataSource = ketQua;
                DatLaiTieuDeCot();

                if (ketQua.Count == 0 && !string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show($"Không tìm thấy thể loại nào chứa '{tuKhoa}'.",
                        "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LamTrongForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
