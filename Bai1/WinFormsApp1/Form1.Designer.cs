namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 650);
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9F);

            // ===== Nhãn và TextBox thông tin =====
            lblMaTL = new Label();
            lblMaTL.Text = "Mã thể loại:";
            lblMaTL.Location = new Point(20, 20);
            lblMaTL.AutoSize = true;

            txtMaTL = new TextBox();
            txtMaTL.Name = "txtMaTL";
            txtMaTL.Location = new Point(130, 17);
            txtMaTL.Size = new Size(250, 23);
            txtMaTL.ReadOnly = true;
            txtMaTL.BackColor = SystemColors.Control;

            lblTenTheLoai = new Label();
            lblTenTheLoai.Text = "Tên thể loại:";
            lblTenTheLoai.Location = new Point(20, 55);
            lblTenTheLoai.AutoSize = true;

            txtTenTheLoai = new TextBox();
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Location = new Point(130, 52);
            txtTenTheLoai.Size = new Size(250, 23);

            lblMoTa = new Label();
            lblMoTa.Text = "Mô tả:";
            lblMoTa.Location = new Point(20, 90);
            lblMoTa.AutoSize = true;

            txtMoTa = new TextBox();
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Location = new Point(130, 87);
            txtMoTa.Size = new Size(250, 80);
            txtMoTa.Multiline = true;
            txtMoTa.ScrollBars = ScrollBars.Vertical;

            lblNgayTaoText = new Label();
            lblNgayTaoText.Text = "Ngày tạo:";
            lblNgayTaoText.Location = new Point(20, 180);
            lblNgayTaoText.AutoSize = true;

            lblNgayTao = new Label();
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Location = new Point(130, 180);
            lblNgayTao.Size = new Size(250, 23);
            lblNgayTao.Text = "-";

            // ===== Các nút hành động =====
            btnThem = new Button();
            btnThem.Name = "btnThem";
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(450, 15);
            btnThem.Size = new Size(100, 32);
            btnThem.Click += btnThem_Click;

            btnSua = new Button();
            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.Location = new Point(560, 15);
            btnSua.Size = new Size(100, 32);
            btnSua.Click += btnSua_Click;

            btnXoa = new Button();
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(670, 15);
            btnXoa.Size = new Size(100, 32);
            btnXoa.Click += btnXoa_Click;

            btnLamMoi = new Button();
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(780, 15);
            btnLamMoi.Size = new Size(100, 32);
            btnLamMoi.Click += btnLamMoi_Click;

            // ===== Tìm kiếm =====
            txtTimKiem = new TextBox();
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Location = new Point(20, 220);
            txtTimKiem.Size = new Size(300, 23);
            txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";

            btnTimKiem = new Button();
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Location = new Point(330, 218);
            btnTimKiem.Size = new Size(100, 27);
            btnTimKiem.Click += btnTimKiem_Click;

            // ===== DataGridView =====
            dgvTheLoaiSach = new DataGridView();
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.Location = new Point(20, 260);
            dgvTheLoaiSach.Size = new Size(910, 370);
            dgvTheLoaiSach.AllowUserToAddRows = false;
            dgvTheLoaiSach.AllowUserToDeleteRows = false;
            dgvTheLoaiSach.ReadOnly = true;
            dgvTheLoaiSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoaiSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoaiSach.MultiSelect = false;
            dgvTheLoaiSach.RowHeadersVisible = false;
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;

            // Thêm control vào Form
            Controls.Add(lblMaTL);
            Controls.Add(txtMaTL);
            Controls.Add(lblTenTheLoai);
            Controls.Add(txtTenTheLoai);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(lblNgayTaoText);
            Controls.Add(lblNgayTao);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvTheLoaiSach);
        }

        #endregion

        // Khai báo các control ở mức lớp (field-level) để Form1.cs có thể truy cập
        private Label lblMaTL = null!;
        private TextBox txtMaTL = null!;
        private Label lblTenTheLoai = null!;
        private TextBox txtTenTheLoai = null!;
        private Label lblMoTa = null!;
        private TextBox txtMoTa = null!;
        private Label lblNgayTaoText = null!;
        private Label lblNgayTao = null!;
        private Button btnThem = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
        private Button btnLamMoi = null!;
        private TextBox txtTimKiem = null!;
        private Button btnTimKiem = null!;
        private DataGridView dgvTheLoaiSach = null!;
    }
}
