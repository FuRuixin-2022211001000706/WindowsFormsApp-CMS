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
    public partial class CustomerForm: Form
    {
        private SqlConnection conn;
        SqlDataAdapter adapter;
        DataSet customerDataSet;
        BindingSource bindingSource;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            errCustForm.SetError(textBox1,"");
            errCustForm.SetError(textBox2, "");
            errCustForm.SetError(textBox3, "");
            errCustForm.SetError(textBox4, "");

            conn = new SqlConnection("Data Source=LAPTOP-SRN5M5NK;Initial Catalog=CMSDB;Integrated Security=True;TrustServerCertificate=True");
            adapter = new SqlDataAdapter("Select * from tblCustomer",conn);
            customerDataSet = new DataSet();
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(customerDataSet,"tblCustomer");

            bindingSource = new BindingSource();
            bindingSource.DataSource = customerDataSet;
            bindingSource.DataMember = "tblCustomer";

            textBox1.DataBindings.Add("Text", bindingSource, "CarNo");
            textBox2.DataBindings.Add("Text", bindingSource, "Name");
            textBox3.DataBindings.Add("Text", bindingSource, "Address");
            textBox4.DataBindings.Add("Text", bindingSource, "Make");

            UpdatePosition();
        }

        private void UpdatePosition()
        {
            lblPosition.Text = $"{bindingSource.Position + 1} of {bindingSource.Count}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource.EndEdit();
                adapter.Update(customerDataSet, "tblCustomer");
                MessageBox.Show("Record Saved Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position < bindingSource.Count - 1)
            {
                bindingSource.Position += 1;
            }
            UpdatePosition();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position > 0)
            {
                bindingSource.Position -= 1;
            }
            UpdatePosition();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataRow newRow = customerDataSet.Tables["tblCustomer"].NewRow();

            newRow["CarNo"] = "";
            newRow["Name"] = "";
            newRow["Address"] = "";
            newRow["Make"] = "";

            customerDataSet.Tables["tblCustomer"].Rows.Add(newRow);

            bindingSource.Position = bindingSource.Count - 1;

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            UpdatePosition();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bindingSource.CancelEdit();
        }
    }
}
