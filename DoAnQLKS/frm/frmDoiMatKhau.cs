using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQLKS.dao;
using DoAnQLKS.models;
using DoAnQLKS.Library;

namespace DoAnQLKS.frm
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                //thành viên đang đăng nhập
                ThanhVien thanhvien = frmMain.thanhvien;
                if (thanhvien.MatKhau != txtMatKhauCu.Text) 
                {
                    throw new Exception("Mật khẩu cũ không chính xác");
                }
                if (string.IsNullOrEmpty(txtMatKhauCu.Text) || string.IsNullOrEmpty(txtXNMatKhau.Text))
                {
                    throw new Exception("Mật khẩu không được để trống");
                }    
                if (!txtMatKhauMoi.Text.Trim().Equals(txtXNMatKhau.Text.Trim()))
                {
                    throw new Exception("Xác nhận mật khẩu mới không khớp");
                }
                string matkhau = txtMatKhauCu.Text.Trim();
                thanhvien.MatKhau = matkhau; //Cập nhật mật khẩu
                ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
                thanhVienDAO.Update(thanhvien);
                frmMain.thanhvien = thanhvien;
                MessageBox.Show("Cập nhật thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbDoiMatKhau"]);
        }
    }
}
