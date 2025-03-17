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
    public partial class WorkerForm: Form
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“cMSDBDataSet.tblWorker”中。您可以根据需要移动或移除它。
            this.tblWorkerTableAdapter.Fill(this.cMSDBDataSet.tblWorker);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.cMSDBDataSet.tblWorker.Clear();
            sqlDataAdapter1.Fill(this.cMSDBDataSet.tblWorker);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(this.cMSDBDataSet.tblWorker);
            MessageBox.Show("The Woker Table is updated.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.cMSDBDataSet.tblWorker.Clear();
            sqlDataAdapter1.Fill(this.cMSDBDataSet.tblWorker);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
