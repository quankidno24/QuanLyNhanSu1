USE [QLNhanSu]
GO
/****** Object:  StoredProcedure [dbo].[procDeleteNhanVien]    Script Date: 5/30/2017 10:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[procDeleteNhanVien]
@MaNV int
as
	delete NhanVien where MaNV=@MaNV
	select 1
