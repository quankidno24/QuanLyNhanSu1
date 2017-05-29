using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_QLNS
{
    static class Program
    {
        public static bool OpenDetailFormOnClose { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DataAccess.ConnectionString = "server=MONCRIS-PC\\SQLEXPRESS;database=QLNhanSu;integrated security = SSPI";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenDetailFormOnClose = false;
            Application.Run(new frmDangNhap());
            if (OpenDetailFormOnClose)
                Application.Run(new frmMenu());
                
        }
    }
}
