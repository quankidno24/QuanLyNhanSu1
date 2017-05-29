using Bai1_QLNS.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_QLNS
{
    public partial class frmDangNhap : Form
    {
        TaikhoanController tkc = new TaikhoanController();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string Taikhoan = txtTK.Text;
            string Matkhau = txtMK.Text;
            int ok = tkc.KiemtraTK(Taikhoan, Matkhau);
            if (ok == 0) MessageBox.Show("Tài khoản không tồn tại.Vui lòng kiểm tra lại!");
            if (ok == 2) MessageBox.Show("Nhập mật khẩu không đúng.Vui lòng kiểm tra lại!");
            if (ok == 1)
            {
                Program.OpenDetailFormOnClose = true;
                this.Close();
                frmMenu Menu = new frmMenu();
                Menu.StartPosition = FormStartPosition.CenterScreen;
                Menu.ShowDialog();
            }
        }
    }
}
