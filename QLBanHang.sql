CREATE DATABASE QLBanHang
GO

USE QLBanHang
GO

CREATE TABLE KhachHang
(
	MaKH int primary key identity,
	HoTen nvarchar(50),
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	Email nvarchar(100),
	DiaChi nvarchar(200),
	DienThoai varchar(50),
	GioiTinh nvarchar(3),
	NgaySinh Datetime,

)
GO

CREATE TABLE LoaiSanPham
(
	MaLoaiSP int primary key identity,
	TenLoaiSP nvarchar(50)
)
GO

CREATE TABLE SanPham
(
	MaSP int primary key identity,
	TenSP nvarchar(100),
	GiaBan decimal(18,0),
	MoTa nvarchar(MAX),
	AnhBia nvarchar(50),
	NgayCapNhat datetime,
)
GO

CREATE TABLE SanPhamThuocLoaiSanPham
(
	MaSP int not null,
	MaLoaiSP int not null,
	CONSTRAINT PK_ThuocSP PRIMARY KEY (MaSP, MaLoaiSP),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP),
	FOREIGN KEY (MaLoaiSP) REFERENCES LoaiSanPham(MaLoaiSP),

)
GO

CREATE TABLE DonHang
(
	MaDonHang int primary key identity,
	DaThanhToan int,
	TinhTrangGiaoHang int,
	NgayDat DateTime,
	NgayGiao DateTime,
	MaKH int,
	FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
)
GO

CREATE TABLE ChiTietDonHang
(
	MaDonHang int,
	MaSP int,
	SoLuong int,
	DonGian nchar(10),
	CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (MaDonHang, MaSP),
	FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
	FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
GO
CREATE TABLE POST_PARENT
(
	MaPostParent int identity primary key,
	Title nvarchar(100)
)
GO
CREATE TABLE POST
(
	MaBai int identity primary key,
	Title nvarchar(200),
	Content nvarchar(max),
	MaPostParent int,
	FOREIGN Key (MaPostParent) References POST_PARENT(MaPostParent)
)
GO