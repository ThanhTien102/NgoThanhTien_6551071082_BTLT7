namespace Bai2
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

        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            // Labels
            var lblHoTen = new Label();
            var lblSDT = new Label();
            var lblEmail = new Label();
            var lblNgaySinh = new Label();
            var lblHangThanhVien = new Label();
            var lblGioiTinh = new Label();

            // TextBoxes
            var txtHoTen = new TextBox();
            var txtSDT = new TextBox();
            var txtEmail = new TextBox();

            // DateTimePicker
            var dtngaySinh = new DateTimePicker();

            // RadioButtons & GroupBox
            var grpGioiTinh = new GroupBox();
            var radNam = new RadioButton();
            var radNu = new RadioButton();

            // ComboBox
            var cmbHangThanhVien = new ComboBox();

            // CheckBox
            var chkDangHoatDong = new CheckBox();

            // Buttons
            var btnThem = new Button();
            var btnSua = new Button();
            var btnXoa = new Button();
            var btnTim = new Button();
            var btnLamMoi = new Button();

            // DataGridView
            var dgvHoiVien = new DataGridView();

            // Nhãn tìm kiếm
            var lblTim = new Label();
            var txtTim = new TextBox();

            // Setup Form
            SuspendLayout();

            this.Text = "Quản Lý Hội Viên Phòng Gym FitZone";
            this.Width = 1200;
            this.Height = 700;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);

            // Setup Labels
            lblHoTen.Text = "Họ Tên:";
            lblHoTen.Location = new System.Drawing.Point(12, 12);
            lblHoTen.Size = new System.Drawing.Size(60, 20);

            lblSDT.Text = "SDT:";
            lblSDT.Location = new System.Drawing.Point(12, 40);
            lblSDT.Size = new System.Drawing.Size(60, 20);

            lblEmail.Text = "Email:";
            lblEmail.Location = new System.Drawing.Point(12, 68);
            lblEmail.Size = new System.Drawing.Size(60, 20);

            lblNgaySinh.Text = "Ngày Sinh:";
            lblNgaySinh.Location = new System.Drawing.Point(12, 96);
            lblNgaySinh.Size = new System.Drawing.Size(80, 20);

            lblGioiTinh.Text = "Giới Tính:";
            lblGioiTinh.Location = new System.Drawing.Point(500, 12);
            lblGioiTinh.Size = new System.Drawing.Size(80, 20);

            lblHangThanhVien.Text = "Hạng Thành Viên:";
            lblHangThanhVien.Location = new System.Drawing.Point(12, 124);
            lblHangThanhVien.Size = new System.Drawing.Size(120, 20);

            lblTim.Text = "Tìm Kiếm:";
            lblTim.Location = new System.Drawing.Point(12, 350);
            lblTim.Size = new System.Drawing.Size(80, 20);

            // Setup TextBoxes
            txtHoTen.Location = new System.Drawing.Point(100, 12);
            txtHoTen.Size = new System.Drawing.Size(200, 23);
            txtHoTen.Name = "txtHoTen";

            txtSDT.Location = new System.Drawing.Point(100, 40);
            txtSDT.Size = new System.Drawing.Size(200, 23);
            txtSDT.Name = "txtSDT";

            txtEmail.Location = new System.Drawing.Point(100, 68);
            txtEmail.Size = new System.Drawing.Size(200, 23);
            txtEmail.Name = "txtEmail";

            txtTim.Location = new System.Drawing.Point(100, 350);
            txtTim.Size = new System.Drawing.Size(200, 23);
            txtTim.Name = "txtTim";

            // Setup DateTimePicker
            dtngaySinh.Location = new System.Drawing.Point(100, 96);
            dtngaySinh.Size = new System.Drawing.Size(200, 23);
            dtngaySinh.Format = DateTimePickerFormat.Short;
            dtngaySinh.Name = "dtngaySinh";
            dtngaySinh.Value = DateTime.Now;

            // Setup GroupBox Giới Tính
            grpGioiTinh.Text = "Giới Tính";
            grpGioiTinh.Location = new System.Drawing.Point(500, 12);
            grpGioiTinh.Size = new System.Drawing.Size(200, 80);

            radNam.Text = "Nam";
            radNam.Location = new System.Drawing.Point(10, 20);
            radNam.Size = new System.Drawing.Size(70, 24);
            radNam.Checked = true;
            radNam.Name = "radNam";

            radNu.Text = "Nữ";
            radNu.Location = new System.Drawing.Point(100, 20);
            radNu.Size = new System.Drawing.Size(70, 24);
            radNu.Name = "radNu";

            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Controls.Add(radNu);

            // Setup ComboBox
            cmbHangThanhVien.Location = new System.Drawing.Point(140, 124);
            cmbHangThanhVien.Size = new System.Drawing.Size(160, 23);
            cmbHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cmbHangThanhVien.SelectedIndex = 0;
            cmbHangThanhVien.Name = "cmbHangThanhVien";
            cmbHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;

            // Setup CheckBox
            chkDangHoatDong.Text = "Đăng hoạt động";
            chkDangHoatDong.Location = new System.Drawing.Point(100, 152);
            chkDangHoatDong.Size = new System.Drawing.Size(130, 24);
            chkDangHoatDong.Checked = true;
            chkDangHoatDong.Name = "chkDangHoatDong";

            // Setup Buttons
            btnThem.Text = "Thêm";
            btnThem.Location = new System.Drawing.Point(750, 50);
            btnThem.Size = new System.Drawing.Size(100, 25);
            btnThem.Click += (s, e) => BtnThem_Click();

            btnSua.Text = "Sửa";
            btnSua.Location = new System.Drawing.Point(750, 85);
            btnSua.Size = new System.Drawing.Size(100, 25);
            btnSua.Click += (s, e) => BtnSua_Click();

            btnXoa.Text = "Xóa";
            btnXoa.Location = new System.Drawing.Point(750, 120);
            btnXoa.Size = new System.Drawing.Size(100, 25);
            btnXoa.Click += (s, e) => BtnXoa_Click();

            btnTim.Text = "Tìm";
            btnTim.Location = new System.Drawing.Point(310, 350);
            btnTim.Size = new System.Drawing.Size(100, 23);
            btnTim.Click += (s, e) => BtnTim_Click();

            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.Location = new System.Drawing.Point(420, 350);
            btnLamMoi.Size = new System.Drawing.Size(100, 23);
            btnLamMoi.Click += (s, e) => BtnLamMoi_Click();

            // Setup DataGridView
            dgvHoiVien.Location = new System.Drawing.Point(12, 380);
            dgvHoiVien.Size = new System.Drawing.Size(1150, 280);
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.CellClick += (s, e) => DgvHoiVien_CellClick(e);

            // Setup columns
            dgvHoiVien.Columns.Add("MaHV", "Mã HV");
            dgvHoiVien.Columns.Add("HoTen", "Họ Tên");
            dgvHoiVien.Columns.Add("GioiTinh", "Giới Tính");
            dgvHoiVien.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvHoiVien.Columns.Add("SDT", "SDT");
            dgvHoiVien.Columns.Add("Email", "Email");
            dgvHoiVien.Columns.Add("HangThanhVien", "Hạng Thành Viên");
            dgvHoiVien.Columns.Add("NgayDangKy", "Ngày Đăng Ký");
            dgvHoiVien.Columns.Add("TrangThai", "Trạng Thái");

            // Store controls as fields for Form1.cs
            this.txtHoTen = txtHoTen;
            this.txtSDT = txtSDT;
            this.txtEmail = txtEmail;
            this.txtTim = txtTim;
            this.dtngaySinh = dtngaySinh;
            this.radNam = radNam;
            this.radNu = radNu;
            this.cmbHangThanhVien = cmbHangThanhVien;
            this.chkDangHoatDong = chkDangHoatDong;
            this.dgvHoiVien = dgvHoiVien;
            this.btnThem = btnThem;
            this.btnSua = btnSua;
            this.btnXoa = btnXoa;

            // Add controls to form
            this.Controls.Add(lblHoTen);
            this.Controls.Add(lblSDT);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblNgaySinh);
            this.Controls.Add(lblHangThanhVien);
            this.Controls.Add(lblGioiTinh);
            this.Controls.Add(lblTim);
            this.Controls.Add(txtHoTen);
            this.Controls.Add(txtSDT);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtTim);
            this.Controls.Add(dtngaySinh);
            this.Controls.Add(grpGioiTinh);
            this.Controls.Add(cmbHangThanhVien);
            this.Controls.Add(chkDangHoatDong);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnSua);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnTim);
            this.Controls.Add(btnLamMoi);
            this.Controls.Add(dgvHoiVien);

            this.Load += (s, e) => Form1_Load();
            this.FormClosing += (s, e) => Form1_FormClosing(e);

            ResumeLayout(false);
        }

        // Member variables
        public TextBox txtHoTen = null!;
        public TextBox txtSDT = null!;
        public TextBox txtEmail = null!;
        public TextBox txtTim = null!;
        public DateTimePicker dtngaySinh = null!;
        public RadioButton radNam = null!;
        public RadioButton radNu = null!;
        public ComboBox cmbHangThanhVien = null!;
        public CheckBox chkDangHoatDong = null!;
        public DataGridView dgvHoiVien = null!;
        public Button btnThem = null!;
        public Button btnSua = null!;
        public Button btnXoa = null!;
    }
}
