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
    public partial class frmInBaoCaoTT : Form
    {
        public frmInBaoCaoTT()
        {
            InitializeComponent();
        }
        ThanhToanDAO ttDao = new ThanhToanDAO();
        ThuePhongDAO tpDAO = new ThuePhongDAO();
        private void frmInBaoCaoTT_Load(object sender, EventArgs e)
        {
            cbMaThue.ComboBox.DataSource = tpDAO.getList();
            cbMaThue.ComboBox.DisplayMember = "MaThue";
            cbMaThue.ComboBox.ValueMember = "MaThue";
            cbMaThue.ComboBox.SelectedIndex = 0;
            List<ThanhToanThuePhong> listThanhToan = ttDao.getList();
            this.reportViewer1.LocalReport.ReportPath = "ReportThanhToan.rdlc";
            var reportDataSource = new ReportDataSource("DataSetThanhToan", listThanhToan);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string mathue = cbMaThue.ComboBox.SelectedValue.ToString();
            List<ThanhToanThuePhong> listThanhToan = ttDao.getList(mathue);
            this.reportViewer1.LocalReport.ReportPath = "ReportThanhToan.rdlc";
            var reportDataSource = new ReportDataSource("DataSetThanhToan", listThanhToan);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
