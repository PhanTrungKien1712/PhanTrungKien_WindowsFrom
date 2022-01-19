using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQLKS.models;

namespace DoAnQLKS.frm
{
    public partial class frmThongTinTV : Form
    {
        public frmThongTinTV()
        {
            InitializeComponent();
        }

        private void frmThongTinTV_Load(object sender, EventArgs e)
        {
            ThanhVien thanhvien = frmMain.thanhvien;
            txtTenDangNhap.Text = thanhvien.TenDangNhap;
            txtMatKhau.Text = thanhvien.MatKhau;
            txtHoTen.Text = thanhvien.HoTen;
            txtDienThoai.Text = thanhvien.DienThoai;
            txtEmail.Text = thanhvien.Email;
            cbQuyen.Text = thanhvien.Quyen;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThongTinThanhVien"]);
        }
    }
}
