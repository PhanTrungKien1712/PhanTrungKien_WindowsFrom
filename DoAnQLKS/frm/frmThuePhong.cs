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
    public partial class frmThuePhong : Form
    {
        public frmThuePhong()
        {
            InitializeComponent();
        }
        KhachHangDAO khachhangDAO = new KhachHangDAO();
        PhongDAO phongDAO = new PhongDAO();
        ThuePhongDAO thuephongDAO = new ThuePhongDAO();
        string AddOrEdit = null;
        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            loadThuePhong();
            loadKhachHang();
            loadPhong();
            OnOff(true);
        }
        private void loadThuePhong()
        {
            dgvDanhSach.DataSource = thuephongDAO.getList();
            txtTongThueP.Text = thuephongDAO.getCount().ToString();
        }
        private void loadKhachHang()
        {
            cbKhachHang.DataSource = khachhangDAO.getList();
            cbKhachHang.DisplayMember = "TenKH";
            cbKhachHang.ValueMember = "MaKH";
        }
        private void loadPhong()
        {
            cbPhong.DataSource = phongDAO.getList();
            cbPhong.DisplayMember = "TenP";
            cbPhong.ValueMember = "MaP";
        }
        private void OnOff(bool value)
        {
            txtMaThue.Enabled = !value;
            cbKhachHang.Enabled = !value;
            cbPhong.Enabled = !value;
            dtpNgayVao.Enabled = !value;
            dtpNgayRa.Enabled = !value;
            txtDatCoc.Enabled = !value;
            btnThem.Enabled = value;
            btnCapNhat.Enabled = value;
            btnXoa.Enabled = value;
            btnLuu.Enabled = !value;
            btnHuy.Enabled = !value;
            btnDong.Enabled = value;
        }
        public void Clear()
        {
            txtMaThue.Text = "";
            cbKhachHang.Text = "";
            cbPhong.Text = "";
            dtpNgayVao.Text = "";
            dtpNgayRa.Text = "";
            txtDatCoc.Text = "";
            txtMaThue.Focus();
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
            txtMaThue.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaThue.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn nhân viên cần xóa.");
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa " + txtMaThue.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string mathue = txtMaThue.Text.Trim();
                    ThuePhong tp = thuephongDAO.getRow(mathue);
                    thuephongDAO.Delete(tp);
                    loadThuePhong();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongThueP.Text = thuephongDAO.getCount().ToString();
            dgvDanhSach.DataSource = thuephongDAO.getList();
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
                            if (this.checkPhong(cbPhong.Text) == false)
                            {
                                throw new Exception("Phòng đã được thuê");
                            }
                            if (txtMaThue.Text == "" || cbKhachHang.Text == "" || cbPhong.Text == "" || dtpNgayVao.Text == "" || dtpNgayRa.Text == "" || txtDatCoc.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                ThuePhong tp = new ThuePhong();
                                tp.MaThue = txtMaThue.Text.Trim();
                                tp.MaKH = cbKhachHang.SelectedValue.ToString();
                                tp.MaP = cbPhong.SelectedValue.ToString();
                                tp.NgayVao = DateTime.Parse(dtpNgayVao.Text);
                                tp.NgayRa = DateTime.Parse(dtpNgayRa.Text);
                                tp.DatCoc = Double.Parse(txtDatCoc.Text);
                                //thêm
                                thuephongDAO.Insert(tp);
                                txtTongThueP.Text = thuephongDAO.getCount().ToString();
                                dgvDanhSach.DataSource = thuephongDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            break;
                        }
                    case "Edit":
                        {
                            if (this.checkPhong(cbPhong.Text) == false)
                            {
                                throw new Exception("Phòng đã được thuê");
                            }
                            if (txtMaThue.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn mã thuê cần cập nhật.");
                                return;
                            }
                            else if (cbKhachHang.Text == "" || cbPhong.Text == "" || dtpNgayVao.Text == "" || dtpNgayRa.Text == "" || txtDatCoc.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                string mathue = txtMaThue.Text.Trim();
                                ThuePhong tp = thuephongDAO.getRow(mathue);
                                tp.MaThue = txtMaThue.Text.Trim();
                                tp.MaKH = cbKhachHang.SelectedValue.ToString();
                                tp.MaP = cbPhong.SelectedValue.ToString();
                                tp.NgayVao = DateTime.Parse(dtpNgayVao.Text);
                                tp.NgayRa = DateTime.Parse(dtpNgayRa.Text);
                                tp.DatCoc = Double.Parse(txtDatCoc.Text);
                                //cập nhật
                                thuephongDAO.Update(tp);
                                dgvDanhSach.DataSource = thuephongDAO.getList();
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
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThuePhong"]);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaThue.Text = dgvDanhSach.Rows[vt].Cells["MaThue"].Value.ToString();
                cbKhachHang.Text = dgvDanhSach.Rows[vt].Cells["KhachHang"].Value.ToString();
                cbPhong.Text = dgvDanhSach.Rows[vt].Cells["Phong"].Value.ToString();
                dtpNgayVao.Text = dgvDanhSach.Rows[vt].Cells["NgayVao"].Value.ToString();
                dtpNgayRa.Text = dgvDanhSach.Rows[vt].Cells["NgayRa"].Value.ToString();
                txtDatCoc.Text = dgvDanhSach.Rows[vt].Cells["DatCoc"].Value.ToString();
            }
        }
        //Hàm kiểm tra phòng
        public bool checkPhong(string phong)
        {
            if (dgvDanhSach.Rows.Count == 0)
            {
                return true;
            }
            for (int vt = 0; vt < dgvDanhSach.Rows.Count - 1; vt++)
            {
                if (dgvDanhSach.Rows[vt].Cells["Phong"].Value.ToString() == phong)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
