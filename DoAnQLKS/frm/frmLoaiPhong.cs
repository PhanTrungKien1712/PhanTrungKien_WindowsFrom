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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        LoaiPhongDAO loaiphongDAO = new LoaiPhongDAO();
        string AddOrEdit = null;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            OnOff(true);
            loadLoaiPhong();
        }
        private void loadLoaiPhong()
        {
            dgvDanhSach.DataSource = loaiphongDAO.getList();
            txtTongLoaiP.Text = loaiphongDAO.getCount().ToString();
        }
        private void OnOff(bool value)
        {
            txtMaLoai.Enabled = !value;
            txtTenLoai.Enabled = !value;
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
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtGhiChu.Text = "";
            txtMaLoai.Focus();
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
            txtMaLoai.Enabled = false;
            AddOrEdit = "Edit";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLoai.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng cần xóa.");
                    return;
                }
                if (MessageBox.Show("Bạn muốn xóa " + txtTenLoai.Text + " ?", "Xóa", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string maloai = txtMaLoai.Text.Trim();
                    LoaiPhong lp = loaiphongDAO.getRow(maloai);
                    loaiphongDAO.Delete(lp);
                    loadLoaiPhong();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTongLoaiP.Text = loaiphongDAO.getCount().ToString();
            dgvDanhSach.DataSource = loaiphongDAO.getList();
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
                            if (txtMaLoai.Text == "" || txtTenLoai.Text == "" || txtGhiChu.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                LoaiPhong lp = new LoaiPhong();
                                lp.MaLoai = txtMaLoai.Text.Trim();
                                lp.TenLoai = txtTenLoai.Text.Trim();
                                lp.GhiChu = txtGhiChu.Text.Trim();
                                //thêm
                                loaiphongDAO.Insert(lp);
                                txtTongLoaiP.Text = loaiphongDAO.getCount().ToString();
                                dgvDanhSach.DataSource = loaiphongDAO.getList();
                                MessageBox.Show("Thêm thành công", "Thông báo");
                            }
                            break;
                        }
                    case "Edit":
                        {
                            if (txtMaLoai.Text == "")
                            {
                                MessageBox.Show("Bạn chưa chọn mã khách hàng cần cập nhật.");
                                return;
                            }
                            else if (txtTenLoai.Text == "" || txtGhiChu.Text == "")
                            {
                                MessageBox.Show("Bạn chưa nhập đủ dữ liệu.");
                                return;
                            }
                            else
                            {
                                string maloai = txtMaLoai.Text.Trim();
                                LoaiPhong lp = loaiphongDAO.getRow(maloai);
                                lp.MaLoai = txtMaLoai.Text.Trim();
                                lp.TenLoai = txtTenLoai.Text.Trim();
                                lp.GhiChu = txtGhiChu.Text.Trim();
                                //thêm
                                loaiphongDAO.Update(lp);
                                txtTongLoaiP.Text = loaiphongDAO.getCount().ToString();
                                dgvDanhSach.DataSource = loaiphongDAO.getList();
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
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbLoaiPhong"]);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                int vt = e.RowIndex;
                //Đưa dữ liệu lên lưới
                txtMaLoai.Text = dgvDanhSach.Rows[vt].Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = dgvDanhSach.Rows[vt].Cells["TenLoai"].Value.ToString();
                txtGhiChu.Text = dgvDanhSach.Rows[vt].Cells["GhiChu"].Value.ToString();
            }
        }
    }
}
