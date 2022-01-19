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
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        PhongDAO phongDAO = new PhongDAO();
        LoaiPhongDAO loaiphongDAO = new LoaiPhongDAO();
        string AddOrEdit = null;
        private void frmPhong_Load(object sender, EventArgs e)
        { 
            OnOff(true);
            loadLoaiPhong();
            loadPhong();
        }
        private void loadPhong()
        {
            dgvDanhSach.DataSource = phongDAO.getList();
            txtTongP.Text = phongDAO.getCount().ToString();
        }
        private void loadLoaiPhong ()
        {
            cbLoaiPhong.DataSource = loaiphongDAO.getList();
            cbLoaiPhong.DisplayMember = "TenLoai";
            cbLoaiPhong.ValueMember = "MaLoai";
        }
        private void OnOff(bool value)
        {
            cbLoaiPhong.Enabled = !value;
            txtMaP.Enabled = !value;
            txtTenP.Enabled = !value;
            txtDienTich.Enabled = !value;
            txtGiaThue.Enabled = !value;
            btnThem.Enabled = value;
            btnCapNhat.Enabled = value;
            btnXoa.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnDong.Enabled = value;
        }
        public void Clear()
        {
            cbLoaiPhong.Text = "";
            txtMaP.Text = "";
            txtTenP.Text = "";
            txtDienTich.Text = "";
            txtGiaThue.Text = "";
            txtMaP.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaP.Enabled = true;
            AddOrEdit = "Add";
            Clear();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            OnOff(false);
            txtMaP.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaP.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn phòng cần xóa.");
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa " + txtTenP.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string map = txtMaP.Text.Trim();
                    Phong p = phongDAO.getRow(map);
                    phongDAO.Delete(p);
                    loadPhong();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongP.Text = phongDAO.getCount().ToString();
            dgvDanhSach.DataSource = phongDAO.getList();
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
                            if (cbLoaiPhong.Text == "" || txtMaP.Text == "" || txtTenP.Text == "" || txtDienTich.Text == "" || txtGiaThue.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                Phong p = new Phong();
                                p.MaLoai = cbLoaiPhong.SelectedValue.ToString();
                                p.MaP = txtMaP.Text.Trim();
                                p.TenP = txtTenP.Text.Trim();
                                p.DienTich = double.Parse(txtDienTich.Text);
                                p.GiaThue = int.Parse(txtGiaThue.Text.Trim());
                                //thêm
                                phongDAO.Insert(p);
                                txtTongP.Text = phongDAO.getCount().ToString();
                                dgvDanhSach.DataSource = phongDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            break;
                        }
                    case "Edit":
                        {
                            if (txtMaP.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn phòng cần cập nhật.");
                                return;
                            }
                            else if (cbLoaiPhong.Text == "" || txtTenP.Text == "" || txtDienTich.Text == "" || txtGiaThue.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                string map = txtMaP.Text.Trim();
                                Phong p = phongDAO.getRow(map);
                                p.MaLoai = cbLoaiPhong.SelectedValue.ToString();
                                p.MaP = txtMaP.Text.Trim();
                                p.TenP = txtTenP.Text.Trim();
                                p.DienTich = double.Parse(txtDienTich.Text);
                                p.GiaThue = int.Parse(txtGiaThue.Text.Trim());
                                //cập nhật
                                phongDAO.Update(p);
                                dgvDanhSach.DataSource = phongDAO.getList();
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
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbPhong"]);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaP.Text = dgvDanhSach.Rows[vt].Cells["MaP"].Value.ToString();
                txtTenP.Text = dgvDanhSach.Rows[vt].Cells["TenP"].Value.ToString();
                cbLoaiPhong.Text = dgvDanhSach.Rows[vt].Cells["LoaiPhong"].Value.ToString();
                txtDienTich.Text = dgvDanhSach.Rows[vt].Cells["DienTich"].Value.ToString();
                txtGiaThue.Text = dgvDanhSach.Rows[vt].Cells["GiaThue"].Value.ToString();
            }
        }
    }
}
