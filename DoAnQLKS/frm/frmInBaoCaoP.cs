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
using Microsoft.Reporting.WinForms;

namespace DoAnQLKS.frm
{
    public partial class frmInBaoCaoP : Form
    {
        public frmInBaoCaoP()
        {
            InitializeComponent();
        }
        PhongDAO phongDao = new PhongDAO();
        LoaiPhongDAO loaiphongDAO = new LoaiPhongDAO();
        private void frmInBaoCaoP_Load(object sender, EventArgs e)
        {
            cbLoaiPhong.ComboBox.DataSource = loaiphongDAO.getList();
            cbLoaiPhong.ComboBox.DisplayMember = "TenLoai";
            cbLoaiPhong.ComboBox.ValueMember = "MaLoai";
            cbLoaiPhong.ComboBox.SelectedIndex = 0;
            List<PhongLoaiPhong> listPhong = phongDao.getList();
            this.reportViewer1.LocalReport.ReportPath = "ReportPhong.rdlc";
            var reportDataSource = new ReportDataSource("DataSetPhong", listPhong);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string maloai = cbLoaiPhong.ComboBox.SelectedValue.ToString();
            List<PhongLoaiPhong> listPhong = phongDao.getList(maloai);
            this.reportViewer1.LocalReport.ReportPath = "ReportPhong.rdlc";
            var reportDataSource = new ReportDataSource("DataSetPhong", listPhong);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
