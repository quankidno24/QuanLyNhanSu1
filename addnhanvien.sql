USE [QLNhanSu]
GO
/****** Object:  StoredProcedure [dbo].[procAddNhanVien]    Script Date: 5/30/2017 10:04:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[procAddNhanVien]
@Ten nvarchar(50),
@Ngaysinh date,
@Gioitinh bit,
@Anh nchar(50),
@Diachi nvarchar(50),
@Dantoc nvarchar(50),
@Tongiao nvarchar(50),
@Sodienthoai float,
@Socmt nchar(15),
@Tinhtrang nvarchar(50),
@MaPB int,
@MaCV int,
@MaTDHV int,
@Ngoaingu nvarchar(50),
@MaHD int,
@MaSBH int,
@MaKT int,
@MaKL int,
@MaL int,
@Ghichu ntext
as
	insert into NhanVien(Ten,Ngaysinh,Gioitinh,Anh,Diachi,Dantoc,
	Tongiao,Sodienthoai,Socmt,Tinhtrang,MaPB,MaCV,MaTDHV,Ngoaingu,MaHD,MaSBH,MaKT,MaKL,MaL,Ghichu) 
	values(@Ten,@Ngaysinh,@Gioitinh,@Anh,@Diachi,@Dantoc,
	@Tongiao,@Sodienthoai,@Socmt,@Tinhtrang,@MaPB,@MaCV,@MaTDHV,@Ngoaingu,@MaHD,@MaSBH,@MaKT,@MaKL,@MaL,@Ghichu)
	select 1
