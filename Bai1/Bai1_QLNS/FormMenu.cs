using API;
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
    public partial class frmMenu : Form
    {
        NhanVienController nvc = new NhanVienController();
        int MaNV;
        NhanVien nv;
        public frmMenu()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dgvViewAll.DataSource = null;
            dgvViewAll.DataSource = nvc.GetDataTable();
            dgvViewAll.ReadOnly = true;
            dgvViewAll.AutoResizeColumns();
            dgvViewAll.Columns["MaNV"].HeaderText = "Mã NV";
            dgvViewAll.Columns["Ten"].HeaderText = "Tên NV";
            dgvViewAll.Columns["TenPB"].HeaderText = "Phòng ban";
            dgvViewAll.Columns["TenCV"].HeaderText = "Chức vụ";
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvViewAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaNV = int.Parse(dgvViewAll.CurrentRow.Cells[0].Value.ToString());
            nv = nvc.GetNVByID(MaNV);
            txtMaNV.Text = nv.MaNV.ToString();
            txtTen.Text = nv.Ten;
            dtpNgaySinh.Text = nv.Ngaysinh.ToString();
            int crrGioiTinh = nv.Gioitinh;
            if (crrGioiTinh == 1)
                rdbNam.Checked = true;
            else rdbNu.Checked = true;
            string pic = string.Format(nv.Anh);
            picAnh.Image = Image.FromFile(pic);
            txtDiaChi.Text = nv.Diachi;
            txtDanToc.Text = nv.Dantoc;
            txtTonGiao.Text = nv.Tongiao;
            txtSDT.Text = nv.Sodienthoai;
            txtCMND.Text = nv.Socmt;
            int mapb = nv.MaPB;
            string tenpb;
            tenpb = mapb == 1 ? "Phòng tài chính" : (mapb == 2 ? "Phòng nhân sự" : "Phòng quản lý");
            txtPhongBan.Text = tenpb;
            int macv = nv.MaCV;
            string tencv;
            tencv = macv == 1 ? "Trưởng phòng" : (macv == 2 ? "Kế toán" : (macv == 3 ? "Quản lý" : (macv == 4 ? "Nhân viên" : "Bảo vệ")));
            txtChucVu.Text = tencv;
            txtHSL.Text = nv.MaL.ToString();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHuongDan hd = new FormHuongDan();
            hd.StartPosition = FormStartPosition.CenterScreen;
            hd.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmThem t = new frmThem();
            t.StartPosition = FormStartPosition.CenterScreen;
            t.FormClosed += T_FormClosed;
            t.ShowDialog();
        }

        private void T_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frmdn = new frmDangNhap();
            frmdn.ShowDialog();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            FormSua s = new FormSua(nv);
            s.StartPosition = FormStartPosition.CenterScreen;
            s.FormClosed += S_FormClosed;
            s.ShowDialog();
        }

        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = (MessageBox.Show("Bạn thật sự muốn xoá nhân viên này?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (r == DialogResult.Yes)
            {
                int ret = nvc.Delete(new NhanVien() { MaNV = int.Parse(txtMaNV.Text) });
                if (ret == 1)
                {
                    MessageBox.Show("Xóa nhân viên thành công!", "Success!");
                    LoadData();
                }
                else
                    MessageBox.Show("Xóa không thành công.Xin kiểm tra lại!", "Failed!");
            }
        }

        private void s_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkB = (CheckBox)sender;
            if (chkB.Name == "chkBMaNV")
            {
                if (chkB.Checked == true) txtTKMa.Enabled = true;
                else { txtTKMa.Text = ""; txtTKMa.Enabled = false; }
            }
            else if (chkB.Name == "chkBTenNV")
            {
                if (chkB.Checked == true) txtTKTen.Enabled = true;
                else { txtTKTen.Text = ""; txtTKTen.Enabled = false; }
            }

        }
        private void TextThayDoi(object sender, EventArgs e)
        {
            TextBox textB = (TextBox)sender;
            string query = "SELECT nv.MaNV,nv.Ten,pb.TenPB,cv.TenCV FROM NhanVien nv INNER JOIN PhongBan pb ON nv.MaPB = pb.MaPB INNER JOIN ChucVu cv ON nv.MaCV = cv.MaCV WHERE nv.MaNV like {0} AND nv.Ten like like N'%{1}%'";
            //if()
            query = string.Format(query, txtTKMa.Text, txtTKTen.Text);
            DataTable dt = DataAccess.Query(query);
            dgvViewAll.DataSource = null;
            dgvViewAll.DataSource = dt;
            dgvViewAll.ReadOnly = true;
            dgvViewAll.AutoResizeColumns();
            dgvViewAll.Columns["MaNV"].HeaderText = "Mã NV";
            dgvViewAll.Columns["Ten"].HeaderText = "Tên NV";
            dgvViewAll.Columns["TenPB"].HeaderText = "Phòng ban";
            dgvViewAll.Columns["TenCV"].HeaderText = "Chức vụ";
        }
    }
}
