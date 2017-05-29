
using Bai1_QLNS.Controller;
using Bai1_QLNS.Models;
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
    public partial class frmThem : Form
    {
        List<string> lstNameCV, lstNamePB;
        ChucVuController cvc = new ChucVuController();
        PhongBanController pbc = new PhongBanController();
        NhanVienController nvc = new NhanVienController();
        string anh;
        public frmThem()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btnAnh_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                anh = ofd.FileName;
            }
        }
        public int checkData(string str, List<string> lstT)
        {
            int index = 0;
            for (int i = 0; i < lstT.Count; i++)
            {
                if (str == lstT[i]) index = i;
            }
            return index + 1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            int gioitinh;
            if (rdbNam.Checked == true) gioitinh = 1;
            else gioitinh = 0;
            int ret = nvc.Insert(
                new NhanVien()
                {
                    Ten = txtTen.Text,
                    Ngaysinh = dtpNgaySinh.Value,
                    Gioitinh = gioitinh,
                    Anh = anh,
                    Diachi = txtDiaChi.Text,
                    Dantoc = txtDanToc.Text,
                    Tongiao = txtTonGiao.Text,
                    Sodienthoai = txtSDT.Text,
                    Socmt = txtCMND.Text,
                    Tinhtrang = "Tốt",
                    MaPB = checkData(cmbPhongBan.Text, lstNamePB),
                    MaCV = checkData(cmbChucVu.Text, lstNameCV),
                    MaTDHV = 1,
                    Ngoaingu = txtNgoaiNgu.Text,
                    MaHD = 1,
                    MaSBH = 1,
                    MaKT = 1,
                    MaKL = 1,
                    MaL = 1,
                    Ghichu = "ABC"
                });
            if (ret == 1)
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Success!");
                this.Close();
            }
            else
                MessageBox.Show("Thêm không thành công.Xin kiểm tra lại!", "Failed!");
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r = (MessageBox.Show("Bạn thật sự muốn hủy?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void frmThem_Load(object sender, EventArgs e)
        {
            cmbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            lstNameCV = cvc.GetNameObj(1);
            lstNamePB = pbc.GetNameObj(1);
            foreach (string s in lstNameCV)
            {
                cmbChucVu.Items.Add(s);
            }
            foreach (string s in lstNamePB)
            {
                cmbPhongBan.Items.Add(s);
            }
            cmbPhongBan.Text = "Phòng tài chính";
            cmbChucVu.Text = "Nhân viên";
        }
    }
}
