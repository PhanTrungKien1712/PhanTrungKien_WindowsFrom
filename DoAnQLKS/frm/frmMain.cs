using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnQLKS.dao;
using DoAnQLKS.models;

namespace DoAnQLKS.frm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static ThanhVien thanhvien = null;
        public static TabControl tabControl = null;
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (thanhvien == null)
            {
                //Mở frm đăng nhập lên
                Form frm = new frmDangNhap();
                frm.ShowDialog();
                toolStripLabelTenDangNhap.Text = thanhvien.HoTen;
                //load Hình
                tabControlMain.ImageList = LoadImageList();
                //Gán giá trị cho
                tabControl = tabControlMain;
            }
        }

        private ImageList LoadImageList()
        {
            ImageList iconsList = new ImageList();
            iconsList.TransparentColor = Color.Blue;
            iconsList.ColorDepth = ColorDepth.Depth32Bit;
            iconsList.ImageSize = new Size(25, 25);
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\he_thong.jpg"));    //0
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\khach_hang.png"));  //1
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\nhan_vien.png"));   //2
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\phong.png"));       //3
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\thanh_toan.png"));  //4
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\thanh_vien.png"));  //5
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\tro_giup.png"));    //6
            iconsList.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resources\\trogiup.png"));     //7
            return iconsList;
        }

        private bool ExistTabPage(TabControl control, string tabPageName)
        {
            bool check = false;
            for (int i = 0; i < control.TabPages.Count; i++)
            {
                if (control.TabPages[i].Name == tabPageName)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void KhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Khách hàng";
            tab.Name = "tbKhachHang";
            tab.ImageIndex = 1;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmKhachHang();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbKhachHang"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbKhachHang"];
        }

        private void NhanVienToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Nhân viên";
            tab.Name = "tbNhanVien";
            tab.ImageIndex = 2;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmNhanVien();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbNhanVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbNhanVien"];
        }

        private void PhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Phòng";
            tab.Name = "tbPhong";
            tab.ImageIndex = 3;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmPhong();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbPhong"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbPhong"];
        }

        private void LoaiPhongToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Loại Phòng";
            tab.Name = "tbLoaiPhong";
            tab.ImageIndex = 3;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmLoaiPhong();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbLoaiPhong"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbLoaiPhong"];
        }

        private void ThuePhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Thuê Phòng";
            tab.Name = "tbThuePhong";
            tab.ImageIndex = 3;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmThuePhong();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbThuePhong"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThuePhong"];
        }

        private void TTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Thanh Toán";
            tab.Name = "tbThanhToan";
            tab.ImageIndex = 4;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmThanhToan();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbThanhToan"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThanhToan"];
        }

        private void ThanhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Thành Viên";
            tab.Name = "tbThanhVien";
            tab.ImageIndex = 5;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmThanhVien();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbThanhVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThanhVien"];
        }

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Trợ Giúp";
            tab.Name = "tbTroGiup";
            tab.ImageIndex = 6;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmTroGiup();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbTroGiup"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbTroGiup"];
        }

        private void ThongTinThanhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Thông Tin Thành Viên";
            tab.Name = "tbThongTinThanhVien";
            tab.ImageIndex = 7;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmThongTinTV();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbThongTinThanhVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThongTinThanhVien"];
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "Đổi Mật Khẩu";
            tab.Name = "tbDoiMatKhau";
            tab.ImageIndex = 7;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmDoiMatKhau();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbDoiMatKhau"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbDoiMatKhau"];
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmMain(); //Tạo đối tượng frmMain
            frmMain.thanhvien = null;
            frmMain.ActiveForm.Hide();
            frm.ShowDialog();
        }

        private void InBaoCaoKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "In Báo Cáo Khách hàng";
            tab.Name = "tbInBaoCaoKH";
            tab.ImageIndex = 1;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmInBaoCaoKH();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbInBaoCaoKH"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbInBaoCaoKH"];
        }

        private void InBaoCaoNVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "In Báo Cáo Nhân viên";
            tab.Name = "tbInBaoCaoNV";
            tab.ImageIndex = 2;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmInBaoCaoNV();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbInBaoCaoNV"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbInBaoCaoNV"];
        }

        private void InBaoCaoPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "In Báo Cáo Phòng";
            tab.Name = "tbInBaoCaoP";
            tab.ImageIndex = 3;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmInBaoCaoP();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbInBaoCaoP"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbInBaoCaoP"];
        }

        private void InBaoCaoTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo tabpage
            TabPage tab = new TabPage();
            tab.Text = "In Báo Cáo Thanh Toán";
            tab.Name = "tbInBaoCaoTT";
            tab.ImageIndex = 4;
            //Tạo form và add vào tabpage ten tab
            Form frm = new frmInBaoCaoTT();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);
            //Kiểm tra tab đã tồn tại hay chưa, nếu chưa add tab và TabControl
            if (!ExistTabPage(tabControlMain, "tbInBaoCaoTT"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbInBaoCaoTT"];
        }
    }
}
