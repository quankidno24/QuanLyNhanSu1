using Bai1_QLNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1_QLNS.Controller
{
    class TaikhoanController : Core.ControllerBase<Taikhoan>
    {
        public int KiemtraTK(string Tentaikhoan, string Matkhau)
        {
            int ok = 1;
            List<Taikhoan> lstTK = GetAllData();
            Taikhoan tk = null;
            tk = lstTK.Find(x => x.Tentaikhoan.TrimEnd() == Tentaikhoan);
            if (tk != null)
            {
                if (tk.Matkhau.TrimEnd() != Matkhau) ok = 2;
            }
            else ok = 0;
            return ok;
        }
    }
}
