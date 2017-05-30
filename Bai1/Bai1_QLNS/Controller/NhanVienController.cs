using Bai1_QLNS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_QLNS.Controller
{
    class NhanVienController:Core.ControllerBase<NhanVien>
    {
        public DataTable GetDataTable()
        {
            string query = "select * from ViewAllNV";
            return ToDataTable(query);
        }
        public NhanVien GetNVByID(int MaNV)
        {
            return GetAllData().Find(x => x.MaNV == MaNV);
        }
    }
}
