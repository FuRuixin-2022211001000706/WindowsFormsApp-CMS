using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReportsForm: Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MonthlyConsumableForm monthlyConsumableForm = new MonthlyConsumableForm();
            monthlyConsumableForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            MonthlyCustomerReportForm monthlyCustomerReportForm = new MonthlyCustomerReportForm();
            monthlyCustomerReportForm.ShowDialog();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            WorkerAlignBalanceReportForm workerAlignBalanceReportForm = new WorkerAlignBalanceReportForm();
            workerAlignBalanceReportForm.ShowDialog();
        }
    }
}
