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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    throw new Exception("Username không được để trống");
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    throw new Exception("Password không được để trống");
                }
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                //Bổ sung E
                ThanhVienDAO thanhvienDAO = new ThanhVienDAO();
                ThanhVien tv = thanhvienDAO.getRow(username);
                if (tv == null)
                {
                    lblThongBao.Text = "Tài khoản không tồn tại";
                }
                else
                {
                    if (tv.MatKhau == password)
                    {
                        frmMain.thanhvien = tv;
                        this.Close();
                    }
                    else
                    {
                        lblThongBao.Text = "Mật khẩu không chính xác";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
