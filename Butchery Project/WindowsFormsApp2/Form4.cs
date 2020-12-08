using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        private string _ChosenEntry = "";
        public  string myValue = "";

        public Form4()
        {
            InitializeComponent();
            //dgvdetails.Rows.Add(1);

            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_fcl_weighDataSet3.Receipts' table. You can move, or remove it, as needed.
            this.receiptsTableAdapter3.Fill(this._fcl_weighDataSet3.Receipts);
            // TODO: This line of code loads data into the '_fcl_weighDataSet2.Receipts' table. You can move, or remove it, as needed.
            this.receiptsTableAdapter2.Fill(this._fcl_weighDataSet2.Receipts);
            // TODO: This line of code loads data into the '_fcl_weighDataSet1.Receipts' table. You can move, or remove it, as needed.
            this.receiptsTableAdapter1.Fill(this._fcl_weighDataSet1.Receipts);
            // TODO: This line of code loads data into the '_fcl_weighDataSet.Receipts' table. You can move, or remove it, as needed.
            this.receiptsTableAdapter.Fill(this._fcl_weighDataSet.Receipts);
            loadgrid();

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.receiptsTableAdapter.FillBy(this._fcl_weighDataSet.Receipts);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.receiptsTableAdapter1.FillBy(this._fcl_weighDataSet1.Receipts);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.receiptsTableAdapter1.FillBy2(this._fcl_weighDataSet1.Receipts);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.receiptsTableAdapter2.FillBy3(this._fcl_weighDataSet2.Receipts);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.receiptsTableAdapter2.FillBy(this._fcl_weighDataSet2.Receipts);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.receiptsTableAdapter2.FillBy1(this._fcl_weighDataSet2.Receipts);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void Importdate_KeyDown(object sender, KeyEventArgs e)
        {  //when key entered is pressed it calls the post button
            if (e.KeyCode == Keys.Enter)
            {
                Searchslapmark();



            }
        }

        private void Searchvendor()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }
                /*
                 SELECT  [ReceiptNo],[VendorNo],[VendorName],[ReceiptDate],[ItemNo],[Description],[ReceivedQty],[ImportTime],[UserID],[Slaughtered]FROM [dbo].[Receipts]
                 
                 */
                String q = "select VendorTag,ReceiptNo,ReceivedQty,VendorNo,VendorName from Receipts   where " +
                            "VendorTag ='" + Importdate.Text + "'";


                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvdetails.DataSource = table;

            }

        }

        private void importDate_ValueChanged(object sender, EventArgs e)
        {
            // Change the gridview to read only selected items

           //ImportDate.Format = DateTimePickerFormat.Custom;
           //ImportDate.CustomFormat = "yyyy-MM-dd";

            //DateTime endDate = Convert.ToDateTime(this.importDate.Text);
            //endDate = endDate.AddDays(1);

            //MessageBox.Show(SlaughterDate.Text + "|" + endDate.ToString());


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }
                /*
                 SELECT  [ReceiptNo],[VendorNo],[VendorName],[ReceiptDate],[ItemNo],[Description],[ReceivedQty],[ImportTime],[UserID],[Slaughtered]FROM [dbo].[Receipts]
                 
                 */
                String q = "select VendorTag,ReceiptNo,ReceivedQty,VendorNo,VendorName from Receipts   where " +
                            "VendorTag ='" + Importdate.Text + "'";
                           

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvdetails.DataSource = table;

            }

        }
        private void loaddata()
        {

            dgvdetails.DataSource = null;
            dgvdetails.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }

                String q = "select VendorTag,ReceiptNo,Description,ReceivedQty,VendorNo,VendorName from Receipts  order by ID   ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvdetails.DataSource = table;

            }
            //MessageBox.Show(Sla

        }

        private void loadgrid()
        {

            dgvdetails.DataSource = null;
            dgvdetails.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }

                String q = "select ReceiptNo,VendorName,ReceivedQty,VendorNo,itemno,Description from Receipts   ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvdetails.DataSource = table;

            }
            //MessageBox.Show(Sla

        }

        private void ReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change the gridview to show only selected items

            

        }

        private void VendorNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change the gridview to show only selected items


        }

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

        private void receiptsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Importdate_TextChanged(object sender, EventArgs e)
        {

        }
        private void Searchslapmark()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }
                /*
                 SELECT  [ReceiptNo],[VendorNo],[VendorName],[ReceiptDate],[ItemNo],[Description],[ReceivedQty],[ImportTime],[UserID],[Slaughtered]FROM [dbo].[Receipts]
                 
                 */
                String q = "select EnrolmentNo,ReceiptNo,VendorNo,VendorName,ItemNo,Description,ReceivedQty  from Receipts   where " +
                            "ReceiptNo ='" + Importdate.Text + "'";


                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvdetails.DataSource = table;

            }
        }
        private void Searchvendorno()
        {

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    return;
                }
                /*
                 SELECT  [ReceiptNo],[VendorNo],[VendorName],[ReceiptDate],[ItemNo],[Description],[ReceivedQty],[ImportTime],[UserID],[Slaughtered]FROM [dbo].[Receipts]
                 
                 */
                String q = "select EnrolmentNo,ReceiptNo,VendorNo,VendorName,ItemNo,Description,ReceivedQty from Receipts   where " +
                            "VendorNo ='" + textBox1.Text + "'";


                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvdetails.DataSource = table;

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void vendorsearch(object sender, KeyEventArgs e)
        {

           
        }

       

        private void Vendorsearchno_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vendorsearchno(object sender, KeyEventArgs e)
        {

        }

        private void Vendorsearchno_Keydown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Searchvendorno();



            }
        }

      
        private void dgvdetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form1 frm1 = new Form1();
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvdetails.Rows[e.RowIndex];
               myValue = dgvdetails.SelectedCells[0].Value.ToString();
               // frm1.ReceiptNo.Text = myValue;
                frm1.Show();
                this.Close();

               


            }

       



    }

        public static class ControlID
        {
            public static string TextData { get; set; }
        }
        private void Dgvdetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Dgvdetails_SelectionChanged(object sender, EventArgs e)
        {
            //Form1 frm1 = new Form1();
           // frm1.ReceiptNo.Text = dgvdetails.SelectedCells[0].Value.ToString();
        }

        private void Dgvdetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 frm1 = new Form1();
          //  frm1.ReceiptNo.Text = dgvdetails.SelectedCells[0].Value.ToString();
        }

        private void Dgvdetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 frm1 = new Form1();
           // frm1.ReceiptNo.Text = dgvdetails.SelectedCells[0].Value.ToString();

        }
    }
}
