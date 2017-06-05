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
    public partial class FormSua : Form
    {
        List<string> lstNameCV, lstNamePB, lstNameTDHV;
        ChucVuController cvc = new ChucVuController();
        PhongBanController pbc = new PhongBanController();
        TrinhDoHocVanController tdhvc = new TrinhDoHocVanController();
        NhanVienController nvc = new NhanVienController();
        NhanVien nv;
        string pic;
        public FormSua(NhanVien _nv)
        {
            InitializeComponent();
            nv = _nv;
        }
        private void FormSua_Load(object sender, EventArgs e)
        {
            lstNameCV = cvc.GetNameObj(1);
            lstNamePB = pbc.GetNameObj(1);
            lstNameTDHV = tdhvc.GetNameObj(2);
            foreach (string s in lstNameCV) cmbChucVu.Items.Add(s);
            foreach (string s in lstNamePB) cmbPhongBan.Items.Add(s);
            foreach (string s in lstNameTDHV) cmbTDHV.Items.Add(s);
            txtMaNV.Text = nv.MaNV.ToString();
            txtTen.Text = nv.Ten;
            dtpNgaySinh.Text = nv.Ngaysinh.ToString();
            int crrGioiTinh = nv.Gioitinh;
            if (crrGioiTinh == 1)
                rdbNam.Checked = true;
            else rdbNu.Checked = true;
            pic = string.Format(nv.Anh);
            picAnh.Image = Image.FromFile(pic);
            txtDiaChi.Text = nv.Diachi;
            txtDanToc.Text = nv.Dantoc;
            txtTonGiao.Text = nv.Tongiao;
            txtSDT.Text = nv.Sodienthoai;
            txtCMND.Text = nv.Socmt;
            int mapb = nv.MaPB;
            string tenpb;
            tenpb = mapb == 1 ? "Phòng tài chính" : (mapb == 2 ? "Phòng nhân sự" : "Phòng quản lý");
            cmbPhongBan.Text = tenpb;
            int macv = nv.MaCV;
            string tencv;
            tencv = macv == 1 ? "Trưởng phòng" : (macv == 2 ? "Kế toán" : (macv == 3 ? "Quản lý" : (macv == 4 ? "Nhân viên" : "Bảo vệ")));
            cmbChucVu.Text = tencv;
            int matdhv = nv.MaTDHV;
            string tentdhv;
            tentdhv = matdhv == 1 ? "Công nghệ thông tin" : (matdhv == 2 ? "Điện tử viễn thông" : "Xây dựng");
            cmbTDHV.Text = tentdhv;
            txtHSL.Text = nv.MaL.ToString();
            txtNgoaiNgu.Text = nv.Ngoaingu;
            txtMaHD.Text = nv.MaHD.ToString();
            txtMaKT.Text = nv.MaKL.ToString();
            txtMaKL.Text = nv.MaKL.ToString();
            txtMaSBH.Text = nv.MaSBH.ToString();
            rtbGhiChu.Text = nv.Ghichu.ToString();
            cmbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTDHV.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r = (MessageBox.Show("Bạn thật sự muốn hủy?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (r == DialogResult.Yes)
            {
                this.Close();
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            int crrGioiTinh = 0;
            if (rdbNam.Checked == true && rdbNu.Checked == false) crrGioiTinh = 1;
            int ret = nvc.Edit(new NhanVien()
            {
                MaNV = int.Parse(txtMaNV.Text),
                Ten = txtTen.Text,
                Ngaysinh = dtpNgaySinh.Value,
                Gioitinh = crrGioiTinh,
                Anh = pic,
                Diachi = txtDiaChi.Text,
                Dantoc = txtDanToc.Text,
                Tongiao = txtTonGiao.Text,
                Sodienthoai = txtSDT.Text,
                Socmt = txtCMND.Text,
                Tinhtrang = "Tốt",
                MaPB = checkData(cmbPhongBan.Text, lstNamePB),
                MaCV = checkData(cmbChucVu.Text, lstNameCV),
                MaTDHV = checkData(cmbTDHV.Text, lstNameTDHV),
                Ngoaingu = txtNgoaiNgu.Text,
                MaHD = int.Parse(txtMaHD.Text),
                MaSBH = int.Parse(txtMaSBH.Text),
                MaKT = int.Parse(txtMaKT.Text),
                MaKL = int.Parse(txtMaKL.Text),
                MaL = int.Parse(txtHSL.Text),
                Ghichu = rtbGhiChu.Text
            });
            if (ret == 1)
            {
                MessageBox.Show("Sửa nhân viên thành công!", "Success!");
                this.Close();
            }
            else
                MessageBox.Show("Sửa không thành công.Xin kiểm tra lại!", "Failed!");
        }
    }
}
