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
    public partial class frmInBaoCaoKH : Form
    {
        public frmInBaoCaoKH()
        {
            InitializeComponent();
        }

        private void frmInBaoCaoKH_Load(object sender, EventArgs e)
        {
            KhachHangDAO khachhangDao = new KhachHangDAO();
            List<KhachHang> listKhachHang = khachhangDao.getList();
            this.reportViewer1.LocalReport.ReportPath = "ReportKhachHang.rdlc";
            var reportDataSource = new ReportDataSource("DataSetKhachHang", listKhachHang);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
