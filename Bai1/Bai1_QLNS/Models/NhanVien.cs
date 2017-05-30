using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_QLNS.Models
{
    public class NhanVien : Core.ModelBase
    {
        public int MaNV { get { return GetINT(0); }set { SetData(0, value); } }
        public string Ten { get { return GetSTR(1); } set { SetData(1, value); } }
        public DateTime Ngaysinh { get { return GetDateTime(2); } set { SetData(2, value); } }
        public int Gioitinh { get { return GetINT(3); } set { SetData(3, value); } }
        public string Anh { get { return GetSTR(4); } set { SetData(4, value); } }
        public string Diachi { get { return GetSTR(5); } set { SetData(5, value); } }
        public string Dantoc { get { return GetSTR(6); } set { SetData(6, value); } }
        public string Tongiao { get { return GetSTR(7); } set { SetData(7, value); } }
        public string Sodienthoai { get { return GetSTR(8); } set { SetData(8, value); } }
        public string Socmt { get { return GetSTR(9); } set { SetData(9, value); } }
        public string Tinhtrang { get { return GetSTR(10); } set { SetData(10, value); } }
        public int MaPB { get { return GetINT(11); } set { SetData(11, value); } }
        public int MaCV { get { return GetINT(12); } set { SetData(12, value); } }
        public int MaTDHV { get { return GetINT(13); } set { SetData(13, value); } }
        public string Ngoaingu { get { return GetSTR(14); } set { SetData(14, value); } }
        public int MaHD { get { return GetINT(15); } set { SetData(15, value); } }
        public int MaSBH { get { return GetINT(16); } set { SetData(16, value); } }
        public int MaKT { get { return GetINT(17); } set { SetData(17, value); } }
        public int MaKL { get { return GetINT(18); } set { SetData(18, value); } }
        public int MaL { get { return GetINT(19); } set { SetData(19, value); } }
        public string Ghichu { get { return GetSTR(20); } set { SetData(20, value); } }


        public override Type GetDataType()
        {
            return this.GetType();
        }

        public override void Setup()
        {
            MaxFields = 20;
            ValueData = new object[MaxFields + 1];
        }
    }
}
