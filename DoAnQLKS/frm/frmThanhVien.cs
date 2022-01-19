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
    public partial class frmThanhVien : Form
    {
        public frmThanhVien()
        {
            InitializeComponent();
        }
        ThanhVienDAO thanhvienDAO = new ThanhVienDAO();
        string AddOrEdit = null;
        private void frmThanhVien_Load(object sender, EventArgs e)
        {
            OnOff(true);
            loadThanhVien();
        }
        private void loadThanhVien()
        {
            dgvDanhSach.DataSource = thanhvienDAO.getList();
            txtTongTV.Text = thanhvienDAO.getCount().ToString();
        }
        private void OnOff(bool value)
        {
            txtMaTV.Enabled = !value;
            txtTenDangNhap.Enabled = !value;
            txtMatKhau.Enabled = !value;
            txtHoTen.Enabled = !value;
            txtDienThoai.Enabled = !value;
            txtEmail.Enabled = !value;
            txtQuyen.Enabled = !value;
            btnThem.Enabled = value;
            btnCapNhat.Enabled = value;
            btnXoa.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnDong.Enabled = value;
        }
        public void Clear()
        {
            txtMaTV.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtQuyen.Text = "";
            txtMaTV.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaTV.Enabled = false;
            AddOrEdit = "Add";
            Clear();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaTV.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTV.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn phòng cần xóa.");
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa " + txtMaTV.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int matv = int.Parse(txtMaTV.Text.Trim());
                    ThanhVien tv = thanhvienDAO.getRow(matv);
                    thanhvienDAO.Delete(tv);
                    loadThanhVien();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongTV.Text = thanhvienDAO.getCount().ToString();
            dgvDanhSach.DataSource = thanhvienDAO.getList();
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
                            if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "" || txtHoTen.Text == "" || txtDienThoai.Text == "" || txtEmail.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                ThanhVien tv = new ThanhVien();
                                tv.TenDangNhap = txtTenDangNhap.Text.Trim();
                                tv.MatKhau = txtMatKhau.Text.Trim();
                                tv.HoTen = txtHoTen.Text.Trim();
                                tv.Email = txtEmail.Text.Trim();
                                tv.DienThoai = txtDienThoai.Text.Trim();
                                tv.Quyen = txtQuyen.Text.Trim();
                                //thêm
                                thanhvienDAO.Insert(tv);
                                txtTongTV.Text = thanhvienDAO.getCount().ToString();
                                dgvDanhSach.DataSource = thanhvienDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            break;
                        }
                    case "Edit":
                        {
                            if (txtMaTV.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn phòng cần cập nhật.");
                                return;
                            }
                            else if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "" || txtHoTen.Text == "" || txtQuyen.Text == "" || txtDienThoai.Text == "" || txtEmail.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                int matv = int.Parse(txtMaTV.Text.Trim());
                                ThanhVien tv = thanhvienDAO.getRow(matv);
                                tv.TenDangNhap = txtTenDangNhap.Text.Trim();
                                tv.MatKhau = txtMatKhau.Text.Trim();
                                tv.HoTen = txtHoTen.Text.Trim();
                                tv.Email = txtEmail.Text.Trim();
                                tv.DienThoai = txtDienThoai.Text.Trim();
                                tv.Quyen = txtQuyen.Text.Trim();
                                //cập nhật
                                thanhvienDAO.Update(tv);
                                dgvDanhSach.DataSource = thanhvienDAO.getList();
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
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThanhVien"]);
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaTV.Text = dgvDanhSach.Rows[vt].Cells["MaTV"].Value.ToString();
                txtTenDangNhap.Text = dgvDanhSach.Rows[vt].Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = dgvDanhSach.Rows[vt].Cells["MatKhau"].Value.ToString();
                txtHoTen.Text = dgvDanhSach.Rows[vt].Cells["HoTen"].Value.ToString();                
                txtEmail.Text = dgvDanhSach.Rows[vt].Cells["Email"].Value.ToString();
                txtDienThoai.Text = dgvDanhSach.Rows[vt].Cells["DienThoai"].Value.ToString();
                txtQuyen.Text = dgvDanhSach.Rows[vt].Cells["Quyen"].Value.ToString();
            }
        }
    }
}
