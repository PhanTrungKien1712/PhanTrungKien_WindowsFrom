GO
USE MASTER
GO 
IF EXISTS(SELECT NAME FROM SYSDATABASES WHERE NAME = 'QLKS')
	DROP DATABASE QLKS
GO
-- Tạo CSDL QL_BOATS
CREATE DATABASE QLKS
GO
USE QLKS
GO
SET DATEFORMAT DMY;
GO
/*Table KhachHang*/
CREATE TABLE KhachHang
(
	[MaKH] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenKH] NVARCHAR(100) NOT NULL, 
	[DiaChi] NVARCHAR(200) NOT NULL,
    [SDT] NVARCHAR(20) NOT NULL
)
--drop table KhachHang

/*Table NhanVien*/

CREATE TABLE NhanVien
(
	[MaNV] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenNV] NVARCHAR(200) NOT NULL, 
	[NgaySinh] DATE NOT NULL,
    [SDT] NVARCHAR(20) NOT NULL
)
Go
--drop table NhanVien

/*Table Phong*/
CREATE TABLE Phong
(
	[MaP] NVARCHAR(10) NOT NULL PRIMARY KEY, 
    [TenP] NVARCHAR(100) NOT NULL, 
	[MaLoai] NVARCHAR(10),
    [DienTich] FLOAT NOT NULL,
	[GiaThue] INTEGER NOT NULL
) 
Go
--drop table Phong
/*Table LoaiPhong*/
CREATE TABLE LoaiPhong
(
	[MaLoai]  NVARCHAR(10) PRIMARY KEY, 
    [TenLoai] NVARCHAR(100) NOT NULL, 
	[GhiChu] NVARCHAR(200) NULL,
)
Go
--drop table LoaiPhong

/*Table ThuePhong*/
CREATE TABLE ThuePhong
(
	[MaThue] NVARCHAR(10) PRIMARY KEY, 
    [MaKH] NVARCHAR(10) NOT NULL, 
	[MaP] NVARCHAR(10) NOT NULL,
	[NgayVao] DATE NOT NULL,
	[NgayRa] DATE NOT NULL,
	[DatCoc] FLOAT NOT NULL,
)
Go
--drop table ThuePhong

/*Table ThanhToan*/

CREATE TABLE ThanhToan
(
	[MaTT] NVARCHAR(10) NOT NULL PRIMARY KEY, 
	[MaThue] NVARCHAR(10),
    [Tien] FLOAT NOT NULL, 
	[HTTT] NVARCHAR(100) NOT NULL,
	[GhiChu] NVARCHAR(200) NULL,
	[NgayTT] DATE NOT NULL,
)
Go
--drop table ThanhToan

/*Table ThnahVien*/
CREATE TABLE ThanhVien
(
	[MaTV] INT IDENTITY(1,1) PRIMARY KEY,
	[TenDangNhap] NVARCHAR(100) NOT NULL,
	[MatKhau] NVARCHAR(20) NOT NULL,
	[HoTen] NVARCHAR(100) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[DienThoai] NVARCHAR(20) NOT NULL,
	[Quyen] NVARCHAR(50) NULL
)


--drop table ThanhVien
/* Khoa ngoai*/
ALTER TABLE Phong ADD CONSTRAINT FK_MaLoai_Phong FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai) 
ALTER TABLE ThanhToan ADD CONSTRAINT FK_MaThue_ThanhToan FOREIGN KEY (MaThue) REFERENCES ThuePhong(MaThue) 
ALTER TABLE ThuePhong ADD CONSTRAINT FK_MaP_ThuePhong FOREIGN KEY (MaP) REFERENCES Phong(MaP) 
ALTER TABLE ThuePhong ADD CONSTRAINT FK_MaKH_ThuePhong FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)

/*..............................*/
INSERT INTO KhachHang VALUES(2119110254,N'Huỳnh Thị Thùy Vân',N'Vũng Tàu','(+84)65 464 46 46')
INSERT INTO KhachHang VALUES(2119110265,N'Lê Cảnh Đức',N'Đồng Nai','(+84)64 656 14 55')
INSERT INTO KhachHang VALUES(2119110266,N'Nguyễn Trung Hậu',N'Tây Ninh','(+84)95 465 62 59')
INSERT INTO KhachHang VALUES(2119110295,N'Nguyễn Thanh Lâm',N'Đắk Lắk','(+84)12 586 89 39')
INSERT INTO KhachHang VALUES(2119110279,N'Vi Quốc Tiến',N'Đồng Nai','(+84)52 559 76 90')
INSERT INTO KhachHang VALUES(2119110235,N'Hồ Minh Nghĩa',N'Hồ Chí Minh','(+84)13 456 89 81')

/*....................................*/
INSERT INTO NhanVien VALUES(2119110189,N'Nguyễn Vũ Tuyên','17/01/1999','(+84)65 464 46 46')
INSERT INTO NhanVien VALUES(2119110136,N'Cao Thị Thùy Trang','11/02/2001','(+84)56 679 93 69')
INSERT INTO NhanVien VALUES(2119110126,N'Vi Thị Thu Hằng','29/05/2001','(+84)98 763 20 15')
INSERT INTO NhanVien VALUES(2119110102,N'Hồ Điệp','12/12/2001','(+84)36 578 92 46')
INSERT INTO NhanVien VALUES(2119110115,N'Trần Ngọc Khương','26/07/2001','(+84)36 987 54 20')
INSERT INTO NhanVien VALUES(2119110145,N'Phan Chính','30/06/2001','(+84)54 896 32 15')

/*..............................*/
INSERT INTO LoaiPhong VALUES(1, N'Standard',N'Tiêu chuẩn')
INSERT INTO LoaiPhong VALUES(2, N'Superior',N'Chất lượng cao')
INSERT INTO LoaiPhong VALUES(3, N'Deluxe',N'Chất lượng tốt hơn')
INSERT INTO LoaiPhong VALUES(4, N'Connecting room',N'Gia đình')

/*..............................*/
INSERT INTO Phong VALUES(11,'N11',1,25,1500000)
INSERT INTO Phong VALUES(22,'N22',2,50,2000000)
INSERT INTO Phong VALUES(33,'N33',3,75,2500000)
INSERT INTO Phong VALUES(44,'N44',4,100,3000000)

/*..............................*/
INSERT INTO ThuePhong VALUES(111,2119110254,11,'02/07/2021','04/07/2021',1500000)
INSERT INTO ThuePhong VALUES(222,2119110265,22,'04/07/2021','06/07/2021',2000000)
INSERT INTO ThuePhong VALUES(333,2119110266,33,'01/07/2021','03/07/2021',2500000)
INSERT INTO ThuePhong VALUES(444,2119110295,44,'05/07/2021','10/07/2021',3000000)

/*..............................*/
INSERT INTO ThanhToan VALUES(2119111,111,1500000,N'Internet Banking',N'Đã chuyển','04/07/2021')
INSERT INTO ThanhToan VALUES(2119222,222,2000000,N'Internet Banking',N'Đã chuyển','06/07/2021')
INSERT INTO ThanhToan VALUES(2119333,333,2500000,N'Tiền mặt',N'Đã trả','03/07/2021')
INSERT INTO ThanhToan VALUES(2119444,444,3000000,N'Quet thẻ',N'Đã chuyển','10/07/2021')

/*....................................*/
INSERT INTO ThanhVien VALUES(N'admin',N'123456', N'Phan Trung Kiên', N'phankien209@gmail.com', '(+84)33 9080 761', null)


select*from KhachHang
select*from NhanVien
select*from Phong
select*from LoaiPhong
select*from ThuePhong
select*from ThanhToan
select*from ThanhVien

/*
1.	Khách hàng (Mã khách hàng, Tên khách hàng, Địa chỉ, Số điện thoại)
2.	Nhân viên (Mã nhân viên, Họ tên, Ngày sinh, Số điện thoại)
3.	Phòng (Mã phòng, Tên phòng, Mã loại, Diện tích, Giá thuê)
4.	Loại phòng (Mã loại, Tên loại, Ghi chú)
5.	Thuê phòng (Mã thuê, Mã khách, Mã phòng, Ngày vào, Ngày ra, Đặt cọc)
6.	Thanh toán (Mã thanh tóan, Mã thuê, Thành tiền, Hình thức thanh toán, Ghi chú, Ngày thanh toán)
7.	Thành viên (Mã thành viên, Tên đăng nhập, Mật khẩu, Họ tên, Email, Điện thoại, Quyền)
*/
