using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;




namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        private string[] loadedInput = null;
        static Tables ObjCrTables;
        static Database ObjCrDtabase;
        static Tables crTables;
        static Database crDatabase;
        static TableLogOnInfo crTableLogonInfo;
        static ConnectionInfo crConnectionInfo;

        public Form3()
        {
            //User.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            InitializeComponent();

        }

        private void BrowseImportFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImportPath.Text = openFileDialog.FileName;
                button1.PerformClick();
                Form1 frm = new Form1();
                frm.initComBo();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImportPath.Text = openFileDialog.FileName;
                {
                    try
                    {
                        string path = ImportPath.Text;
                        // FileUpload1.SaveAs(path);
                        // Connection String to Excel Workbook  
                        string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                        using (OleDbConnection con = new OleDbConnection(excelCS))
                        {



                            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                            con.Open();
                            // Create DbDataReader to Data Worksheet  
                            DbDataReader dr = cmd.ExecuteReader();


                            // SQL Server Connection String  
                            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                            // Bulk Copy to SQL Server   


                            SqlBulkCopy bulkInsert = new SqlBulkCopy(_connectionString);

                            bulkInsert.DestinationTableName = "Products";



                            SqlBulkCopyColumnMapping ItemNo = new SqlBulkCopyColumnMapping("ItemNo", "ItemNo");
                            bulkInsert.ColumnMappings.Add(ItemNo);
                            SqlBulkCopyColumnMapping ProductName = new SqlBulkCopyColumnMapping("ProductName", "ProductName");
                            bulkInsert.ColumnMappings.Add(ProductName);
                            SqlBulkCopyColumnMapping ProductType = new SqlBulkCopyColumnMapping("ProductType", "ProductType");
                            bulkInsert.ColumnMappings.Add(ProductType);
                            SqlBulkCopyColumnMapping inputtype = new SqlBulkCopyColumnMapping("inputtype", "inputtype");
                            bulkInsert.ColumnMappings.Add(inputtype);
                            SqlBulkCopyColumnMapping UserID = new SqlBulkCopyColumnMapping("UserID", "UserID");
                            bulkInsert.ColumnMappings.Add(UserID);
                            SqlBulkCopyColumnMapping createdate = new SqlBulkCopyColumnMapping("createdate", "createdate");
                            bulkInsert.ColumnMappings.Add(createdate);
                            SqlBulkCopyColumnMapping barcodeID = new SqlBulkCopyColumnMapping("barcodeID", "barcodeID");
                            bulkInsert.ColumnMappings.Add(barcodeID);
                     

                            bulkInsert.WriteToServer(dr);
                            //BindData();

                            MessageBox.Show("Your file uploaded successfully Please Click Submit To finish Your Order");
                            loaddata();


                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }

            }// Parsing the text file
























        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {


                //Find your textbox within the row
                DataGridViewRow row = new DataGridViewRow();
                row = dgvdetails.CurrentRow;
                int intRow = new Int32();
                intRow = row.Index;
                lbltrid.Text = dgvdetails[0, row.Index].Value.ToString();
                txtitemno.Text = dgvdetails[1, row.Index].Value.ToString();
                txtpname.Text = dgvdetails[2, row.Index].Value.ToString();
                txtbarcode.Text = dgvdetails[3, row.Index].Value.ToString();
                producttype.Text = dgvdetails[4, row.Index].Value.ToString();
                inputtype.Text = dgvdetails[5, row.Index].Value.ToString();
                txtbom.Text = dgvdetails[6, row.Index].Value.ToString();
              



            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            producttype.Items.Add("Main Product");
            producttype.Items.Add("By Product");
            producttype.Items.Add("Input");
            producttype.Text = "Main Product";
            inputtype.Text = "Leg";
            inputtype.Items.Add("Leg");
            inputtype.Items.Add("Middle");
            inputtype.Items.Add("Shoulder");
            inputtype.Items.Add("Beheading pig");
            inputtype.Items.Add("Beheading sow");
            inputtype.Items.Add("Baconer");
            inputtype.Items.Add("Input");
            inputtype.Items.Add("Sow");
            inputtype.Items.Add("Fat Stripping");
            inputtype.Items.Add("Slicing");
            //inputtype.Items.Add("Sow");

            loaddata();
         
        }

        private void ImportPath_TextChanged(object sender, EventArgs e)
        {

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

                String q = "SELECT ID,ItemNo,ProductName,barcodeID,ProductType,inputtype,bom,UserID,createdate AS 'Date Create'    FROM Products  order by ID desc";

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
        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void CrateWeight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            txtpname.Text.Replace("(", "");
            txtpname.Text.Replace(")", "");
            txtbarcode.Text.Trim();
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = " set ANSI_WARNINGS OFF   INSERT INTO [dbo].[Products]([ItemNo],[ProductName],[ProductType],[inputtype],[UserID],[createdate],[barcodeID],[bom])" +
                                                        "VALUES ('" + txtitemno.Text + "','"
                                                          + txtpname.Text + "','"
                                                          + producttype.Text + "','"
                                                          + inputtype.Text + "','"
                                                           + Environment.UserName + "','"
                                                            + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                           + txtbarcode.Text + "','"
                                                            + txtbom.Text + "')";



                    using (SqlCommand cmd = new SqlCommand(q5, conn))
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 12");
                            return;
                        }
                        try
                        {
                            cmd.ExecuteNonQuery();


                            MessageBox.Show(txtpname.Text, "Data Saved Succesfully");
                            loaddata();
                            txtitemno.Text = "";
                            txtpname.Text = "";
                            txtbarcode.Text = "";
                            txtbom.Text = "";








                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }

            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Printbarcode();

            //ReportDocument cryRpt = new ReportDocument();
            //TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            //TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            //ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //Tables CrTables;
            //crConnectionInfo.ServerName = Properties.Settings.Default.Server;
            //crConnectionInfo.DatabaseName = Properties.Settings.Default.Database;
            //crConnectionInfo.UserID = Properties.Settings.Default.UserName;
            //crConnectionInfo.Password = Properties.Settings.Default.Password;
            //CrTables = cryRpt.Database.Tables;
            //foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            //{
            //    crtableLogoninfo = CrTable.LogOnInfo;
            //    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            //    CrTable.ApplyLogOnInfo(crtableLogoninfo);
            //}


            //var objRepShow = new rtpviewreport();

            //// Get the report parameters collection. 

            //TSLbarcodes objReport = new TSLbarcodes();

            //string strSelectionFormula;

            //// ' '' Add a parameter value - START
            //// crParameterFieldLocation = crParameterFieldDefinitions.Item("TODATE")
            //// crParameterValues = crParameterFieldLocation.CurrentValues
            //// crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            //// crParameterDiscreteValue.Value = Format(dtpTodate.Value, "dd-MMM-yyyy")
            //// crParameterValues.Add(crParameterDiscreteValue)
            //// crParameterFieldLocation.ApplyCurrentValues(crParameterValues)
            //// ' Add a parameter value - END
            //strSelectionFormula = " {Products.ID}=" + lbltrid.Text + "";
            //objRepShow.CrystalReportViewer1.PrintReport();
            //{ 
            //    var withBlock = objRepShow.CrystalReportViewer1;

            //    withBlock.ReportSource = objReport;
            //    withBlock.SelectionFormula = strSelectionFormula;
            //    withBlock.Dock = DockStyle.Fill;
            //    withBlock.ShowGroupTreeButton = false;
            //    // .DisplayGroupTree = False

            //    withBlock.ShowFirstPage();
            //    // .PrintReport() '(1, False, 0, 0)
            //    // objReport.PrinterSettings.Copies = 1
            //    // objReport.printtoprinter.noofcopies = 1
            //    // objReport.printtoprinter(1, False, 0, 0)
            //    objRepShow.CrystalReportViewer1.RefreshReport();
            //}

            //objRepShow.Refresh();
            //objRepShow.BringToFront();
            //objRepShow.Show();


        }
        private void Printbarcode()
        {
            {
                // var objReport = default(object);
                var objCrTableLogOnInfo = new TableLogOnInfo();
                var objCrConnectionIno = new ConnectionInfo();
                Database ObjCrDtabase;
                Tables ObjCrTables;
                string strSelectionFormula;
                var rptViewer = new rtpviewreport();
                strSelectionFormula = " {Products.ID}=" + lbltrid.Text + "";
                var objRepShow = new rtpviewreport();
                TSLbarcodes objReport = new TSLbarcodes();
                try
                {

                    {
                        objReport = new TSLbarcodes();
                    }
                    objCrConnectionIno.ServerName = Properties.Settings.Default.DSN; // MYSMS_SYSTEM.My.Settings.SERVERNAME   ' "MYSMS"
                    objCrConnectionIno.UserID = Properties.Settings.Default.UserName; // MYSMS_SYSTEM.My.Settings.USER_NAME
                    objCrConnectionIno.Password = Properties.Settings.Default.Password; // MYSMS_SYSTEM.My.Settings.PASSWORD
                    ObjCrDtabase = objReport.Database; // = .GetDatabase()
                    ObjCrTables = ObjCrDtabase.Tables;
                    strSelectionFormula = "";
                    strSelectionFormula = " {Products.ID}=" + lbltrid.Text + ""; // and cdate({LEAVE_APPLICATION_TB.LEAVE_START_DATE})>= #" & CDate(From_date) & "# "
                    foreach (Table objCrTable in ObjCrTables)
                    {
                        objCrTableLogOnInfo = objCrTable.LogOnInfo;
                        objCrTableLogOnInfo.ConnectionInfo = objCrConnectionIno;
                        objCrTable.ApplyLogOnInfo(objCrTableLogOnInfo);
                    }

                    objRepShow.CrystalReportViewer1.PrintReport();
                    {
                        var withBlock = objRepShow.CrystalReportViewer1;
                        withBlock.ReportSource = objReport;
                        withBlock.SelectionFormula = strSelectionFormula;
                        withBlock.Dock = DockStyle.Fill;
                        withBlock.ShowGroupTreeButton = false;
                        // .DisplayGroupTree = False

                        withBlock.ShowFirstPage();

                        objRepShow.CrystalReportViewer1.RefreshReport();
                    }

                    objRepShow.Refresh();
                    objRepShow.BringToFront();
                    objRepShow.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtbarcode.Text.Trim();
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = " set ANSI_WARNINGS OFF   update  [dbo].[Products] set [ItemNo]= '" + txtitemno.Text + "',[ProductName]='" + txtpname.Text + "',[ProductType]='" + producttype.Text + "',[inputtype]='" + inputtype.Text + "',[UserID]='" + Environment.UserName + "',[createdate]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',[barcodeID]='" + txtbarcode.Text.Trim() + "',[bom]='" + txtbom.Text.Trim() + "' where ID='" + lbltrid.Text + "'";






                    using (SqlCommand cmd = new SqlCommand(q5, conn))
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 12");
                            return;
                        }
                        try
                        {
                            cmd.ExecuteNonQuery();


                            MessageBox.Show(txtpname.Text, "Data Saved Succesfully");
                           loaddata();
                            txtitemno.Text = "";
                            txtpname.Text = "";
                            txtbarcode.Text = "";
                            txtbom.Text = "";








                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }

            }

        }

        private void txtitemno_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvdetails_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //txtitemno.Text = dgvdetails.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txtpname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtitemno.Text = "";
            txtpname.Text = "";
            txtbarcode.Text = "";
            lbltrid.Text = "";
            txtbom.Text = "";


        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtbarcode.Text.Trim();
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = " set ANSI_WARNINGS OFF   DELETE FROM  [dbo].[Products]  where ID='" + lbltrid.Text + "'";






                    using (SqlCommand cmd = new SqlCommand(q5, conn))
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 12");
                            return;
                        }
                        try
                        {
                            cmd.ExecuteNonQuery();


                            MessageBox.Show(txtpname.Text, "DELETED SUCCESSFUL");
                            loaddata();
                            txtitemno.Text = "";
                            txtpname.Text = "";
                            txtbarcode.Text = "";
                            txtbom.Text = "";








                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
             (dgvdetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProductName LIKE '%{0}%'", txtsearchname.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (dgvdetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("ItemNo LIKE '%{0}%'", txtsearchno.Text);

        }

        private void txtsearchbom_TextChanged(object sender, EventArgs e)
        {
            (dgvdetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("BarcodeID LIKE '%{0}%'", txtsearchbom.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void inputtype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
