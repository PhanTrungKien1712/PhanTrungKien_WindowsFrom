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

namespace DoAnQLKS.frm
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHangDAO khachhangDAO = new KhachHangDAO();
        string AddOrEdit = null;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            OnOff(true);
            loadKhachHang();         
        }
        private void loadKhachHang()
        {
            dgvDanhSach.DataSource = khachhangDAO.getList();
            txtTongKH.Text = khachhangDAO.getCount().ToString();
        }
        private void OnOff(bool value)
        {
            txtMaKH.Enabled = !value;
            txtTenKH.Enabled = !value;
            txtDiaChi.Enabled = !value;
            mtxSDT.Enabled = !value;
            btnThem.Enabled = value;
            btnCapNhat.Enabled = value;
            btnXoa.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnDong.Enabled = value;
        }
        public void Clear()
        {
            txtMaKH.Text="";
            txtTenKH.Text="";
            txtDiaChi.Text="";
            mtxSDT.Text="";
            txtMaKH.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            OnOff(false);
            AddOrEdit = "Add";
            Clear();                    
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaKH.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {          
            try           
            {
                if (txtMaKH.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng cần xóa.");
                    return;
                }                
                if(MessageBox.Show("Bạn muốn xóa " + txtTenKH.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string makh = txtMaKH.Text.Trim();
                    KhachHang kh = khachhangDAO.getRow(makh);
                    khachhangDAO.Delete(kh);
                    loadKhachHang();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongKH.Text = khachhangDAO.getCount().ToString();
            dgvDanhSach.DataSource = khachhangDAO.getList();
            Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || mtxSDT.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                KhachHang kh = new KhachHang();
                                kh.MaKH = txtMaKH.Text.Trim();
                                kh.TenKH = txtTenKH.Text.Trim();
                                kh.DiaChi = txtDiaChi.Text.Trim();
                                kh.SDT = mtxSDT.Text.Trim();
                                //thêm
                                khachhangDAO.Insert(kh);
                                txtTongKH.Text = khachhangDAO.getCount().ToString();
                                dgvDanhSach.DataSource = khachhangDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }    
                            break;
                        }
                    case "Edit":
                        {
                            if (txtMaKH.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn mã khách hàng cần cập nhật.");
                                return;
                            }
                            else if (txtTenKH.Text == "" || txtDiaChi.Text == "" || mtxSDT.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                string makh = txtMaKH.Text.Trim();
                                KhachHang kh = khachhangDAO.getRow(makh);
                                kh.MaKH = txtMaKH.Text.Trim();
                                kh.TenKH = txtTenKH.Text.Trim();
                                kh.DiaChi = txtDiaChi.Text.Trim();
                                kh.SDT = mtxSDT.Text.Trim();
                                //cập nhật
                                khachhangDAO.Update(kh);
                                dgvDanhSach.DataSource = khachhangDAO.getList();
                                MessageBox.Show("Cập nhật thành công", "Thông báo");
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            OnOff(true);
            Clear();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            OnOff(true);
            Clear();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbKhachHang"]);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaKH.Text = dgvDanhSach.Rows[vt].Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dgvDanhSach.Rows[vt].Cells["TenKH"].Value.ToString();
                txtDiaChi.Text = dgvDanhSach.Rows[vt].Cells["DiaChi"].Value.ToString();
                mtxSDT.Text = dgvDanhSach.Rows[vt].Cells["SDT"].Value.ToString();
            }      
        }
    }
}
