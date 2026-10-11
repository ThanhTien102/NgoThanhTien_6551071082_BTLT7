-- Tạo database HoiVien
CREATE DATABASE HoiVien;
GO

-- Sử dụng database HoiVien
USE HoiVien;
GO

-- Tạo bảng HoiVien
CREATE TABLE HoiVien (
	MaHV INT PRIMARY KEY IDENTITY(1,1),
	HoTen NVARCHAR(100) NOT NULL,
	GioiTinh BIT NOT NULL, -- 1 = Nam, 0 = Nữ
	NgaySinh DATE NOT NULL,
	SDT VARCHAR(15) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	HangThanhVien NVARCHAR(20) NOT NULL, -- Basic, VIP, Premium
	NgayDangKy DATETIME NOT NULL DEFAULT GETDATE(),
	TrangThai BIT NOT NULL DEFAULT 1 -- 1 = Active, 0 = Inactive
);

-- Chèn dữ liệu mẫu
INSERT INTO HoiVien (HoTen, GioiTinh, NgaySinh, SDT, Email, HangThanhVien, NgayDangKy, TrangThai)
VALUES 
(N'Hồ Văn Vân', 1, '1999-07-11', '0738735879', 'hovanvan@gmail.com', N'Basic', GETDATE(), 1),
(N'Nguyễn Ninh', 1, '1999-10-11', '0738731034', 'nguyennih@gmail.com', N'Premium', GETDATE(), 1),
(N'Nguyễn Bỏ Độn', 1, '1999-12-29', '0738773727', 'nguyenbodop@gmail.com', N'Basic', GETDATE(), 1),
(N'Nguyễn Xim', 1, '1999-07-17', '0373586597', 'nguyenxim@gmail.com', N'VIP', GETDATE(), 1),
(N'Nguyễn Tương', 0, '1999-07-22', '0738775931', 'nguyentuan@gmail.com', N'Premium', GETDATE(), 1);
