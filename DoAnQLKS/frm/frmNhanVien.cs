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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        NhanVienDAO nhanvienDAO = new NhanVienDAO();
        string AddOrEdit = null;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            OnOff(true);
        }
        private void loadNhanVien()
        {
            dgvDanhSach.DataSource = nhanvienDAO.getList();
            txtTongNV.Text = nhanvienDAO.getCount().ToString();
        }
        private void OnOff(bool value)
        {
            txtMaNV.Enabled = !value;
            txtTenNV.Enabled = !value;
            dtpNgaySinh.Enabled = !value;
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
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpNgaySinh.Text = "";
            mtxSDT.Text = "";
            txtMaNV.Focus();
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
            txtMaNV.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNV.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn nhân viên cần xóa.");
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa " + txtTenNV.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string manv = txtMaNV.Text.Trim();
                    NhanVien nv = nhanvienDAO.getRow(manv);
                    nhanvienDAO.Delete(nv);
                    loadNhanVien();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongNV.Text = nhanvienDAO.getCount().ToString();
            dgvDanhSach.DataSource = nhanvienDAO.getList();
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
                            if (txtMaNV.Text == "" || txtTenNV.Text == "" || dtpNgaySinh.Text == "" || mtxSDT.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                NhanVien nv = new NhanVien();
                                nv.MaNV = txtMaNV.Text.Trim();
                                nv.TenNV = txtTenNV.Text.Trim();
                                nv.NgaySinh = DateTime.Parse(dtpNgaySinh.Text);
                                nv.SDT = mtxSDT.Text.Trim();
                                //thêm
                                nhanvienDAO.Insert(nv);
                                txtTongNV.Text = nhanvienDAO.getCount().ToString();
                                dgvDanhSach.DataSource = nhanvienDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            break;
                        }
                    case "Edit":
                        {
                            if (txtMaNV.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn mã khách hàng cần cập nhật.");
                                return;
                            }
                            else if (txtTenNV.Text == "" || dtpNgaySinh.Text == "" || mtxSDT.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                string manv = txtMaNV.Text.Trim();
                                NhanVien nv = nhanvienDAO.getRow(manv);
                                nv.MaNV = txtMaNV.Text.Trim();
                                nv.TenNV = txtTenNV.Text.Trim();
                                nv.NgaySinh = dtpNgaySinh.Value;
                                nv.SDT = mtxSDT.Text.Trim();
                                //cập nhật
                                nhanvienDAO.Update(nv);
                                dgvDanhSach.DataSource = nhanvienDAO.getList();
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
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbNhanVien"]);

        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaNV.Text = dgvDanhSach.Rows[vt].Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dgvDanhSach.Rows[vt].Cells["TenNV"].Value.ToString();
                dtpNgaySinh.Text = dgvDanhSach.Rows[vt].Cells["NgaySinh"].Value.ToString();
                mtxSDT.Text = dgvDanhSach.Rows[vt].Cells["SDT"].Value.ToString();
            }
        }
    }
}

   