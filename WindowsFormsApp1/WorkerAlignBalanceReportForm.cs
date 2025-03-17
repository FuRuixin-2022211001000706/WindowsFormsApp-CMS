using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkerAlignBalanceReportForm: Form
    {
        public WorkerAlignBalanceReportForm()
        {
            InitializeComponent();
        }

        private void WorkerAlignBalanceReportForm_Load(object sender, EventArgs e)
        {
            //write code for data
            DataTable dt = GetCunsumableData();
            ReportDataSource rds = new ReportDataSource("WorkerAlignBalanceSet", dt);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private DataTable GetCunsumableData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SRN5M5NK;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True"))
            {
                string sql = "SELECT FORMAT(JobDate, 'MM/yyyy') AS JobDate,SUM(Alignment) AS Alignment, SUM(Balancing) AS Balancing FROM tblJobDetails WHERE JobDate >= DATEFROMPARTS(YEAR(GETDATE()), 1, 1) AND  JobDate<DATEADD(YEAR, 1, DATEFROMPARTS(YEAR(GETDATE()), 1, 1)) GROUP BY FORMAT(JobDate, 'MM/yyyy') ORDER BY JobDate";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
