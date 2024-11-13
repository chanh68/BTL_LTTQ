using DAL_QuanLy;
using DTO_QuanLy;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class ReportSanPham : Form
    {
        private DAL_ReportSanPham _reportSanPhamDAL = new DAL_ReportSanPham();
        public ReportSanPham()
        {
            InitializeComponent();
        }

        private void ReportSanPham_Load(object sender, EventArgs e)
        {
            string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "Report_SanPham.rdlc");
            reportViewer1.LocalReport.ReportPath = reportPath;
            // this.reportViewer1.RefreshReport();
            LoadReportData("");
        }
        private void LoadReportData(string productID = "")
        {
            List<DTO_ReportSanPham> reportList;

            if (string.IsNullOrEmpty(productID))
            {
                reportList = _reportSanPhamDAL.GetAllReportSanPhamData();
            }
            else
            {
                reportList = _reportSanPhamDAL.GetReportSanPhamData(productID);
            }

            DataTable reportData = _reportSanPhamDAL.ConvertSanPhamListToDataTable(reportList);

            ReportDataSource rds = new ReportDataSource("DataSet_SanPham", reportData);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }



        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string productID = txtMaSanPham.Text.Trim();

            if (!string.IsNullOrEmpty(productID))
            {
                LoadReportData(productID);
            }
            else
            {
                LoadReportData();
            }

        }
    }
}
