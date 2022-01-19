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
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }
        ThanhToanDAO thanhtoanDAO = new ThanhToanDAO();
        ThuePhongDAO thuephongDAO = new ThuePhongDAO();
        string AddOrEdit = null;
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            OnOff(true);
            txtMaTT.Enabled = true;
            loadThanhToan();
            loadThuePhong();
        }
        private void loadThanhToan()
        {
            dgvDanhSach.DataSource = thanhtoanDAO.getList();
            txtTongTT.Text = thanhtoanDAO.getCount().ToString();
        }
        private void loadThuePhong()
        {
            cbMaThue.DataSource = thuephongDAO.getList();
            cbMaThue.DisplayMember = "MaThue";
            cbMaThue.ValueMember = "MaThue";
        }
        private void OnOff(bool value)
        {
            txtMaTT.Enabled = !value;
            cbMaThue.Enabled = !value;
            txtTien.Enabled = !value;
            txtHTTT.Enabled = !value;
            dtpNgayTT.Enabled = !value;
            txtGhiChu.Enabled = !value;
            btnThem.Enabled = value;
            btnCapNhat.Enabled = value;
            btnXoa.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnDong.Enabled = value;
        }
        public void Clear()
        {
            txtMaTT.Text = "";
            cbMaThue.Text = "";
            txtTien.Text = "";
            txtHTTT.Text = "";
            dtpNgayTT.Text = "";
            txtGhiChu.Text = "";
            txtMaTT.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaTT.Enabled = true;
            AddOrEdit = "Add";
            Clear();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaTT.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaTT.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn phòng cần xóa.");
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa " + txtMaTT.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string matt = txtMaTT.Text.Trim();
                    ThanhToan tt = thanhtoanDAO.getRow(matt);
                    thanhtoanDAO.Delete(tt);
                    loadThanhToan();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongTT.Text = thanhtoanDAO.getCount().ToString();
            dgvDanhSach.DataSource = thanhtoanDAO.getList();
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
                            if (txtMaTT.Text == "" || cbMaThue.Text == "" || txtTien.Text == "" || txtHTTT.Text == "" || dtpNgayTT.Text == "" || txtGhiChu.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                ThanhToan tt = new ThanhToan();
                                tt.MaTT = txtMaTT.Text.Trim();
                                tt.MaThue = cbMaThue.SelectedValue.ToString();
                                tt.Tien = int.Parse(txtTien.Text.Trim());
                                tt.HTTT = txtHTTT.Text.Trim();
                                tt.NgayTT = DateTime.Parse(dtpNgayTT.Text);
                                tt.GhiChu = txtGhiChu.Text.Trim();
                                //thêm
                                thanhtoanDAO.Insert(tt);
                                txtTongTT.Text = thanhtoanDAO.getCount().ToString();
                                dgvDanhSach.DataSource = thanhtoanDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            break;
                        }
                    case "Edit":
                        {
                            if (txtMaTT.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn phòng cần cập nhật.");
                                return;
                            }
                            else if (cbMaThue.Text == "" || txtTien.Text == "" || txtHTTT.Text == "" || dtpNgayTT.Text == "" || txtGhiChu.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                string matt = txtMaTT.Text.Trim();
                                ThanhToan tt = thanhtoanDAO.getRow(matt);
                                tt.MaTT = txtMaTT.Text.Trim();
                                tt.MaThue = cbMaThue.SelectedValue.ToString();
                                tt.Tien = int.Parse(txtTien.Text.Trim());
                                tt.HTTT = txtHTTT.Text.Trim();
                                tt.NgayTT = DateTime.Parse(dtpNgayTT.Text);
                                tt.GhiChu = txtGhiChu.Text.Trim();
                                //cập nhật
                                thanhtoanDAO.Update(tt);
                                dgvDanhSach.DataSource = thanhtoanDAO.getList();
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
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThanhToan"]);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaTT.Text = dgvDanhSach.Rows[vt].Cells["MaTT"].Value.ToString();
                cbMaThue.Text = dgvDanhSach.Rows[vt].Cells["MaThue"].Value.ToString();
                txtTien.Text = dgvDanhSach.Rows[vt].Cells["Tien"].Value.ToString();
                txtHTTT.Text = dgvDanhSach.Rows[vt].Cells["HTTT"].Value.ToString();
                dtpNgayTT.Text = dgvDanhSach.Rows[vt].Cells["NgayTT"].Value.ToString();
                txtGhiChu.Text = dgvDanhSach.Rows[vt].Cells["GhiChu"].Value.ToString();
            }
        }
    }
}
