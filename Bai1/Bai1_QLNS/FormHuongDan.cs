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
    public partial class FormHuongDan : Form
    {
        public FormHuongDan()
        {
            InitializeComponent();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Đăng nhập")
            {
                webBrowser1.Navigate(@"C:\Users\Dell\Desktop\Quanlynhansu\QuanLyNhanSu1\Bai1\Guide\Dangnhap.html");
            }
            if (e.Node.Text == "Xem nhân viên")
            {
                webBrowser1.Navigate(@"C:\Users\Dell\Desktop\Quanlynhansu\QuanLyNhanSu1\Bai1\Guide\Xemnhanvien.html");
            }
            if (e.Node.Text == "Thêm nhân viên")
            {
                webBrowser1.Navigate(@"C:\Users\Dell\Desktop\Quanlynhansu\QuanLyNhanSu1\Bai1\Guide\Themnhanvien.html");
            }
            if (e.Node.Text == "Sửa nhân viên")
            {
                webBrowser1.Navigate(@"C:\Users\Dell\Desktop\Quanlynhansu\QuanLyNhanSu1\Bai1\Guide\Suanhanvien.html");
            }
            if (e.Node.Text == "Xóa nhân viên")
            {
                webBrowser1.Navigate(@"C:\Users\Dell\Desktop\Quanlynhansu\QuanLyNhanSu1\Bai1\Guide\Xoanhanvien.html");
            }
            if (e.Node.Text == "Xem thêm")
            {
                webBrowser1.Navigate(@"C:\Users\Dell\Desktop\Quanlynhansu\QuanLyNhanSu1\Bai1\Guide\Xemthem.html");
            };
        }
    }
}
