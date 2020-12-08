using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Text.RegularExpressions;
using userauth;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;




namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        private DataTable dtRunningTot = new DataTable();
        public static string StrConn = "";
        private string newrecptno;
        string[] byprods = { "By Product" };

        string[] middlesnonpieces = { "G1194", "G1195", "G1229", "G1230", "G1231", "G1245" };
        userauth.userauthlist checkuser = new userauth.userauthlist();
        //TODO: INSTANT C# TODO TASK: Insert the following converted event handler wireups at the end of the 'InitializeComponent' method for forms, 'Page_Init' for web pages, or into a constructor for other classes:
        DayOfWeek wk = DateTime.Today.DayOfWeek;

        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=0;";
        string _connectionStringNAV = $"Server={Properties.Settings.Default.NAVserver};Initial Catalog={Properties.Settings.Default.NAVdb};Persist Security Info=False;User ID={Properties.Settings.Default.Navuser};Password={Properties.Settings.Default.Navpassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=0;";
        double MPerc;
        string Itemno;
        string Desc;
        string CType;
        int Rqty, wqty;
        int check = 0;
        //int Rqty, Sqty;
        //string RNo = ReceiptNo.Text;

        double CR = 0.0; double WT = 0.0; double NT; double TT = 0.0; double AW = 0.0; double BW = 0.0; double SDA = 0.0; double SDB = 0.0; double STW = 0.0;
        private MessageBoxButtons MessageBoxButtons;
        String CLC;

        private void Total_TextChanged(object sender, EventArgs e)
        {

        }
        private void todayscarcass()
        {


        }
        private void Total_Leave(object sender, EventArgs e)
        {

            //CarcassType.Text = "";
            //MeatPercent.Text = "";
            // MeatPercent.ReadOnly = true;

            //try
            //{
            //    if (Total.Text == "") Total.Text = "0";

            // NT=(Convert.ToDouble(Total.Text) - Convert.ToDouble(Properties.Settings.Default.CrateTotal));
            //    var result = NT - Math.Truncate(NT);


            //    //if (result > 0.00)
            //    //    NT = Math.Ceiling(NT);
            //    //else NT = Math.Floor(NT);
            //    NetTotal.Text = NT.ToString();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + "Error 1");
            //}



        }
        public void Reload()
        {
            this.Refresh();
        }
        public Form1()
        {

            InitializeComponent();
            cmbcrateweight.Text = "4";
            //userperm();
            string getuser;
            getuser = login.loginusername;
            User.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            txtdaywk.Text = (DateTime.Today.DayOfWeek).ToString();
            // ScaleID.Text = Properties.Settings.Default.ScaleLID;
           // this.Deleteoldreceipts();
            this.initComBo();
            this.userperm();
            Form4 f4 = new Form4();
            // f4.ReloadForm1 +=Reload;
            // CarcassType.Text.Replace(" ", "");
            //this.specials();
            if (Txtrole.Text == "Slaughter")
            {


                // readweightlegs.Text.Remove(0);
                //readweightlegs.Digital Display, 36pt, style=Bold =true;
                // readweightlegs.Focus();
                //readweightlegs.Enabled = false;
                // readweightlegs.BackColor = Color.balck;
                ////  readweightlegs.BackColor=black;
                //  readweightmiddles.Enabled = true;
                //  readweightshoulders.Enabled =true;
                //  readg10.Enabled = true;


                exportedSlaughterToolStripMenuItem.Enabled = false;
                deliveriesPerPeriodToolStripMenuItem.Enabled = true;
                deliveriesPerVendorToolStripMenuItem.Enabled = false;
                //readweightlegs.Enabled = false;
                configurationsToolStripMenuItem.Enabled = false;
                //tabControl1.Controls.Remove(plegdebon);
                //pbreaking.Enabled = false;
                // plegdebon.Enabled = false;



            }

            else if (Txtrole.Text == "Supervisor")
            {
                Refreshlegs.Enabled = false;
                // button2.Enabled = false;
                // usersToolStripMenuItem.Enabled = false;
                configurationsToolStripMenuItem.Enabled = false;
                richTextBox2.Enabled = false;



            }
            else if (Txtrole.Text == "")
            {

                MessageBox.Show(User.Text + "  Has not Been Created Contact IT For Support");
                this.Close();
            }
            else
            {
                richTextBox2.Enabled = true;
                readweightmiddles.Enabled = true;
                readweightshoulders.Enabled = true;
                richTextBox1.Enabled = true;


            }



        }


        private void configurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // New up the condfig page
            Form2 Config = new Form2();
            Config.Show();
        }

        private void SlapMark_SelectedIndexChanged(object sender, EventArgs e)
        {

            //        // fetch selected Vendor
            //        string Slap = Grnnumber.SelectedValue.ToString();

            //        using (SqlConnection conn = new SqlConnection(_connectionString))
            //        {ss

            //            try
            //            {

            //                conn.Open();
            //            }
            //            catch (Exception ex)
            //            {

            //                MessageBox.Show(ex.Message);
            //                return;
            //            }
            //DateTime todaysDate = DateTime.Now;
            //String q = "SELECT * FROM [dbo].[Receipts] WHERE VendorTag ='" + Slap + "'" + " AND  receiptdate='" + todaysDate + "'";
            //            using (SqlCommand cmd = new SqlCommand(q, conn))
            //            {

            //                cmd.CommandText = q;

            //                using (var reader = cmd.ExecuteReader())
            //                {
            //                    if (!reader.Read())
            //                    {
            //                        MessageBox.Show("Invalid receipt number. Please confirm before proceeding");
            //                        // MeatPercent.Enabled = false;
            //                    }
            //                    else
            //                    {
            //                        VendorName.Text = reader["VendorName"].ToString();
            //                        VendorNo.Text = reader["VendorNo"].ToString();
            //                        ReceiptNo.Text = reader["ReceiptNo"].ToString();
            //                        //MeatPercent.Enabled = true;
            //                        // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
            //                    }
            //                }

            //            }
            //            conn.Close();

            //        }

        }


        private void User_TextChanged(object sender, EventArgs e)
        {

        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // New up the condfig page
            Form3 ImportData = new Form3();
            ImportData.Show();
        }


        private void fetchdata()
        {
            // fetch selected Vendor



        }
        private void ReceiptNo_Leave(object sender, EventArgs e)
        {
            // fetch selected Vendor




        }

        private void CarcassType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarcassType_Leave(object sender, EventArgs e)
        {



        }


        private void MeatPercent_TextChanged(object sender, EventArgs e)
        {
            // Get the Classification

        }

        private void MeatPercent_Leave(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {

            // readTotal();
            Weighlivestock();

            richTextBox2.Focus();
            //initComBo();

            //if (SideA.Text == "0.0")
            //{
            //    SideA.Text = NetTotal.Text;
            //}
            //else if (SideB.Text == "0.0")
            //{
            //    SideB.Text= NetTotal.Text;
            //}

            //TT = AW + BW;


        }

        private void Weighlivestock()
        {


        }

        private void Weighnonlivestock()
        {

        }

        private void importedReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ImportedData = new Form4();
            ImportedData.Show();


        }

        private void exportedSlaughterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form SlaughterData = new Form5();
            SlaughterData.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
         



            richTextBox2.Text = "0.0";
            tridupdatelegs.Text = ".";
          
            //tridupdatemiddles.Text = ".";
            //tridupdateshoulders.Text = ".";
            lblidstrip.Text = ".";
            loadtwosidesC();
            sidesweight();
            loadtwoparts();
            Loadbehadingsproducts();
            loadbeheaded();
            Bacons();
            loadbutchleg();
            loadbutchmiddle();
            loadbutchshoulder();
            loadrinds();
            Totalsidesbacon();
            Totalsidessows();
            loadbeheaded();
            loadtwosides();
            sidesweightS();
            loadsavedslicessum();
            loadinputBaconer();
            loadinputsow();
            Totalreceivedtoday();
            Loadlegs();
            TotalTotal();
            loadweighedlegs();
            loadweighedshoulders();
            Totalnumberofpieceslegs();
            Totalnumberofpiecesmiddles();
            Totalnumberofpiecesshoulders();
            loadcarcassweigheddata();
            loadstrips();
            loadsavedslices();
            loadthreeparts();
            DGVTotalS();
            loadtwosidesC();
            sidesweight();
            Totalsidesbacon();
            Totalsidessows();
            //Refreshlegs.Focus();

        }

        private void Deleteoldreceipts()  //am deleting old receipts due to the slapmark get affected when selected
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
                String q = "delete from Receipts where cast( ImportTime as date) < cast(getdate() as date)";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;


                    {
                        cmd.ExecuteNonQuery();




                    }

                }
                conn.Close();

            }


        }

        public void initComBo()
        {

        }

        
        public void legpieces()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                   String q = "SELECT sum(convert(int,nopieces) )  FROM ButcheryData WHERE barcodeID='" + lblbarcodeno.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)"; 
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                lblpiecesperpleg.Text = Convert.ToString(db);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }
                    String w = "SELECT sum(convert(int,NetWeight) )  FROM ButcheryData WHERE barcodeID='" + lblbarcodeno.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(w, conn))
                    {

                        cmd.CommandText = w;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db2;
                                db2 = Convert.ToString(result);
                                if (db2 == "") db2 = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                weightsperitem.Text = Convert.ToString(db2);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }



                    conn.Close();




                }


            }


        }
        public void sidesweight()

        {
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                    String q = "SELECT sum(convert(int,netweight) )  FROM ButcheryData WHERE Itemno='" + lblbcn.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                txtcumbcn.Text = Convert.ToString(db);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }



                    conn.Close();




                }


            }


        }
        public void Totalsidesbacon()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                    String q = "SELECT COUNT(*) * 2  FROM ButcheryData WHERE Itemno='" + lblbcn.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();
                            Totalreceivedtoday();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                txtactivebacons.Text = Convert.ToString(db);
                                //  double NOCL = 0.0;
                                //  NOCL = (Convert.ToDouble(txtbcos.Text));

                                txtbaconremaining.Text = (Convert.ToDouble(txtbcos.Text) - Convert.ToDouble(txtactivebacons.Text)).ToString("#,0.00");

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }



                    conn.Close();




                }


            }


        }
        public void Totalsidessows()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                    String q = "SELECT COUNT(*) * 2  FROM ButcheryData WHERE Itemno='" + lblsws.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                txtactivesows.Text = Convert.ToString(db);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }



                    conn.Close();




                }


            }


        }
        public void sidesweightS()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                    String q = "SELECT sum(convert(int,netweight) )  FROM ButcheryData WHERE Itemno='" + lblsws.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                txtdgvsows.Text = Convert.ToString(db);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }
                    String W = "SELECT COUNT(*) FROM ButcheryData WHERE Itemno='" + lblsws.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(W, conn))
                    {

                        cmd.CommandText = W;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result2 = cmd.ExecuteScalar();


                            {

                                string db1;
                                db1 = Convert.ToString(result2);
                                if (db1 == "") db1 = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                txtactivesows.Text = Convert.ToString(db1);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }


                    conn.Close();




                }


            }


        }


        public void Middlepieces()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                    String q = "";// "SELECT sum(convert(int,nopieces) )  FROM ButcheryData WHERE outputpname='" + //lblitemdescselmiddle.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                               // lblpiecesperpmiddle.Text = Convert.ToString(db);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }



                    conn.Close();




                }


            }



        }

        public void shoulderspieces()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                    String q = "SELECT sum(convert(int,nopieces) )  FROM ButcheryData WHERE outputpname='" + lblitemdescselshoulders.Text + "' and Cast (ButchTime as date)=cast (getdate() as date)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                //Txttotalrectoday.Text = Convert.ToString(result);
                                lblpiecesperpshoulders.Text = Convert.ToString(db);

                                //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }



                    conn.Close();




                }


            }

        }

       private void loadlivedata()

        {











        }
        private void loadthreeparts()
        {
            dgvLMS.DataSource = null;
            dgvLMS.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
               // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);




             string xwz;
             xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18,2))) AS 'CRATES',sum(CAST(NetWeight AS decimal(18,2))) as Weight FROM ButcheryData WHERE parentinputtype   in('baconer','sow' )  and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvLMS.DataSource = table;
             

                decimal sum1 = 0; decimal sum2 = 0; //decimal //sumpigs = 0; decimal //variance2 = 0;

               // sumpigs = Convert.ToDecimal(txtbcos.Text) + Convert.ToDecimal(txtactivesows.Text);



                for (int i = 0; i < dgvLMS.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvLMS.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dgvLMS.Rows[i].Cells[4].Value);






                }
                // add the total row

                string[] totalrow = new string[] { from, "Three Parts", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "", "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }
        private void loadslices()
        {
            dgvsumslices.DataSource = null;
            dgvsumslices.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);



                string xwz;
                xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18,2))) AS 'Pieces',sum(CAST(NetWeight AS decimal(18,2))) as Weight FROM ButcheryData WHERE  parentinputtype='Slicing' and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvsumslices.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvsumslices.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvsumslices.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dgvsumslices.Rows[i].Cells[4].Value);





                }
                // add the total row

                string[] totalrow = new string[] { from, "Three Parts", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "", "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }
        private void loadtwoparts()
        {
            dgvhalfs.DataSource = null;
            dgvhalfs.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);





                //inputtype = Txtinputtype.Text;
                //if (Txtinputtype.Text == "LEG")
                //{
                //    inputtype = "G1100";
                //}
                //if (Txtinputtype.Text == "MIDDLES")
                //{
                //    inputtype = "G1102";
                //}
                //if (Txtinputtype.Text == "SHOULDERS")
                //{
                //    inputtype = "G1101";
                //}


                string
          xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(NetWeight AS decimal(18,2))) as Weight FROM ButcheryData WHERE ITEMNO in ('G1030','G1031' ) and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvhalfs.DataSource = table;

                if (txtslaughtersows.Text == "") { txtslaughtersows.Text = "0"; }
                if (txtslaughterbcn.Text == "") { txtslaughterbcn.Text = "0"; }
                decimal sum1 = 0; decimal sum2 = 0; decimal sumpigs = 0; decimal variance2 = 0;

                sumpigs = Convert.ToDecimal(txtslaughterbcn.Text) + Convert.ToDecimal(txtslaughtersows.Text);

                for (int i = 0; i < dgvhalfs.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvhalfs.Rows[i].Cells[3].Value);
                 //   sum2 += Convert.ToDecimal(dgvthreesides.Rows[i].Cells[4].Value);





                }
                // add the total row

                string[] totalrow = new string[] { "Two Sides", "GRAND TOTALS", sumpigs.ToString(), sum1.ToString() };
               // string[] totalrow2 = new string[] { "", "VARIANCE", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
               








            }





        }
        private void loadbutchshoulder()
        {
            dgvshoulderdeboning.DataSource = null;
            dgvshoulderdeboning.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
              




                //inputtype = Txtinputtype.Text;
                //if (Txtinputtype.Text == "LEG")
                //{
                //    inputtype = "G1100";
                //}
                //if (Txtinputtype.Text == "MIDDLES")
                //{
                //    inputtype = "G1102";
                //}
                //if (Txtinputtype.Text == "SHOULDERS")
                //{
                //    inputtype = "G1101";
                //}


                string xwz;
                xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS Name,sum(CAST(NetWeight AS decimal(18,2))) as Weight,sum(CAST(nopieces AS decimal(18,2))) AS 'Pieces',parentItemNo as 'Type'  FROM ButcheryData WHERE parentinputtype not in('Bacon, Carcass - Sid','Bacon, Carcass - Sid','BACONER','SOW') and outputptype ='Shoulder ' and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype,parentItemNo order by parentItemNo desc ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvshoulderdeboning.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvshoulderdeboning.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvshoulderdeboning.Rows[i].Cells[2].Value);
                    sum2 += Convert.ToDecimal(dgvshoulderdeboning.Rows[i].Cells[3].Value);





                }
                // add the total row

                string[] totalrow = new string[] {  "Shoulders", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] {  from, "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }
        private void loadbutchmiddle()
        {
            dgvmiddlesdeboning.DataSource = null;
            dgvmiddlesdeboning.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);




                //inputtype = Txtinputtype.Text;
                //if (Txtinputtype.Text == "LEG")
                //{
                //    inputtype = "G1100";
                //}
                //if (Txtinputtype.Text == "MIDDLES")
                //{
                //    inputtype = "G1102";
                //}
                //if (Txtinputtype.Text == "SHOULDERS")
                //{
                //    inputtype = "G1101";
                //}


                string xwz;
                xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS Name,sum(CAST(NetWeight AS decimal(18,2))) as Weight,sum(CAST(nopieces AS decimal(18,2))) AS 'Pieces',parentItemNo as 'Type'   FROM ButcheryData WHERE parentinputtype not in('Bacon, Carcass - Sid','Bacon, Carcass - Sid','BACONER','SOW') and outputptype ='Middle' and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype,parentItemNo order by parentItemNo desc ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvmiddlesdeboning.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvmiddlesdeboning.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvmiddlesdeboning.Rows[i].Cells[2].Value);
                    sum2 += Convert.ToDecimal(dgvmiddlesdeboning.Rows[i].Cells[3].Value);





                }
                // add the total row

                string[] totalrow = new string[] {  "Middles", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }
        private void loadrinds()
        {
            dgvoutput.DataSource = null;
            dgvoutput.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);






                //inputtype = Txtinputtype.Text;
                //if (Txtinputtype.Text == "LEG")
                //{
                //    inputtype = "G1100";
                //}
                //if (Txtinputtype.Text == "MIDDLES")
                //{
                //    inputtype = "G1102";
                //}
                //if (Txtinputtype.Text == "SHOULDERS")
                //{
                //    inputtype = "G1101";
                //}


                string xwz;
                xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS Name,sum(CAST(NetWeight AS decimal(18,2))) as Weight,sum(CAST(nopieces AS decimal(18,2))) AS 'PIECES'  FROM ButcheryData WHERE parentinputtype not in('Bacon, Carcass - Sid','Bacon, Carcass - Sid','BACONER','SOW') and outputptype ='Rinds with Fat ' and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype,parentItemNo  ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvoutput.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvoutput.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvoutput.Rows[i].Cells[2].Value);
                    sum2 += Convert.ToDecimal(dgvoutput.Rows[i].Cells[3].Value);





                }
                // add the total row

                string[] totalrow = new string[] { "RINDS", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }

        private void cumulatives()
        {
            
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDate.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);
                DateTime endDate = Convert.ToDateTime(this.SlaughterDate.Text);



                endDate = endDate.AddDays(1);






                string xwz;
                xwz = SlaughterDateTo.Text;
                if (xwz == "")
                { 
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                String q = "SELECT  Itemno,outputpname AS Name,sum(CAST(NetWeight AS decimal(18,2))) as Weight,sum(CAST(nopieces AS decimal(18,2))) AS 'PIECES'  FROM ButcheryData WHERE parentinputtype not in('Bacon, Carcass - Sid','Bacon, Carcass - Sid','BACONER','SOW')  and cast (butchtime as date)=cast(getdate() as date) group by outputpname,Itemno,outputptype,parentItemNo  ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                //this.dgvcumulatives.DataSource = table;


                //decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                //for (int i = 0; i < dgvlegdeboning.RowCount; i++)
                //{

                //    sum1 += Convert.ToDecimal(dgvlegdeboning.Rows[i].Cells[2].Value);
                //    sum2 += Convert.ToDecimal(dgvlegdeboning.Rows[i].Cells[3].Value);





                //}
                // add the total row

                //string[] totalrow = new string[] { "Legs", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                //string[] totalrow2 = new string[] { "", "VARIANCE", "0.0", "0.0" };

                //DataRow newRow = table.NewRow();
                //table.Rows.Add(totalrow);
                //DataRow newRow1 = table.NewRow();
                //table.Rows.Add(totalrow2);








            }





        }
        private void loadbutchleg()
        {
            dgvlegdeboning.DataSource = null;
            dgvlegdeboning.Refresh();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {

                    conn.Open();
                }
                catch (Exception ex)
                {

                    //MessageBox.Show(ex.Message);
                    return;
                }

                string from;
                from = SlaughterDateTo.Text;
                // string To;
                // DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                // DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);





                //inputtype = Txtinputtype.Text;
                //if (Txtinputtype.Text == "LEG")
                //{
                //    inputtype = "G1100";
                //}
                //if (Txtinputtype.Text == "MIDDLES")
                //{
                //    inputtype = "G1102";
                //}
                //if (Txtinputtype.Text == "SHOULDERS")
                //{
                //    inputtype = "G1101";
                //}

                string xwz;
                xwz = SlaughterDateTo.Text;
                if (xwz == "")
                {
                    xwz = DateTime.Today.ToString("dd/MMM/yyyy");
                }
                DateTime endDate = Convert.ToDateTime(xwz);


                endDate = endDate.AddDays(1);
                String q = "SELECT  Itemno,outputpname AS Name,sum(CAST(NetWeight AS decimal(18,2))) as Weight,sum(CAST(nopieces AS decimal(18,2))) AS 'PIECES' ,parentItemNo as 'Type' FROM ButcheryData WHERE parentinputtype not in('Bacon, Carcass - Sid','Bacon, Carcass - Sid','BACONER','SOW') and outputptype ='Leg' and  ButchTime  >='" + xwz + "' and ButchTime <= '" + endDate.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype,parentItemNo order by parentItemNo desc  ";

                var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                {
                    try
                    {
                        da.Fill(table);
                        //Totalweighedtoday();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvlegdeboning.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvlegdeboning.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvlegdeboning.Rows[i].Cells[2].Value);
                    sum2 += Convert.ToDecimal(dgvlegdeboning.Rows[i].Cells[3].Value);





                }
                // add the total row

                string[] totalrow = new string[] { "Legs", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] {"", "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkuser.AuthenticateUserme() == true) 
            {
                lblbcn.Text = "G1030";
                
                this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;//InitializeComponent();
            TT = Convert.ToDouble(richTextBox2.Text = "0.0");
                richTextBox2.ReadOnly = true;
                txtwscl1.ReadOnly = true;
                // Totalreceivedtoday();
              
                // //
                userperm();
                Bacons();
                loadtwosidesC();
                totalslaughtered();
                sidesweight();
                loadtwoparts();
                Loadbehadingsproducts();
                loadbeheaded();
              
                loadbutchleg();
                loadbutchmiddle();
                loadbutchshoulder();
                loadrinds();
                Totalsidesbacon();
                Totalsidessows();
                loadbeheaded();
                loadtwosides();
                sidesweightS();
                loadsavedslicessum();
                loadinputBaconer();
                loadinputsow();
                Totalreceivedtoday();
                Loadlegs();
                TotalTotal();
                loadweighedlegs();
                loadweighedshoulders();
                Totalnumberofpieceslegs();
                Totalnumberofpiecesmiddles();
                Totalnumberofpiecesshoulders();
                loadcarcassweigheddata();
                loadstrips();
                loadsavedslices();
                loadthreeparts();
                DGVTotalS();
                    txtnetfats.ReadOnly = true;
                txtwscl1.Enabled = true;
                this.dgvlegsmain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            dgvbreaklegsbacon.ReadOnly = true;
            dgvbreaklegssows.ReadOnly = true;
            dgvlegsmain.ReadOnly = true;
             dgvlegsmain.ReadOnly = true;
            dgvlegsmain.ReadOnly = true;
            dgvLMS.ReadOnly = true;
          
            dgvshouldersmain.ReadOnly = true;
            dgvbeheading.ReadOnly = true;
            dgvstrip.ReadOnly = true;
              

                richTextBox2.Text = "0.0";
            readweightmiddles.Text = "0.0";
             cmbtare.Text = "2.4";
            readweightshoulders.Text = "0.0";
                txtnoplegs.Text = "0";
                // loadG1030();
                // LoadG1031();

            txtnetwso2.Text = "0.0";
            richTextBox2.Text = "0.0";
            richTextBox1.Text = "0.0";
            txtslicingscale.Text = "0.0";
         

                Txtbacon.Text = "0";
            Txtsows.Text = "0";
            legscrate.Items.Add("4");
                legscrate.Items.Add("0");
                legscrate.Items.Add("1");
                legscrate.Items.Add("2");
                legscrate.Items.Add("3");
               
          
            cmbcrateweight.Items.Add("5");
            middlescrate.Items.Add("4");
            middlescrate.Items.Add("3");
            middlescrate.Items.Add("2");
            middlescrate.Items.Add("1");
            shoulderscrate.Items.Add("4");
            shoulderscrate.Items.Add("3");
            shoulderscrate.Items.Add("2");
            shoulderscrate.Items.Add("1");


            cmbnocfats.Items.Add("4");
            cmbnocfats.Items.Add("3");
            cmbnocfats.Items.Add("2");
            cmbnocfats.Items.Add("1");

            legscrate.Text = "4";
            middlescrate.Text = "4";
            shoulderscrate.Text = "4";
            cmbnocfats.Text = "4";
            cmbcrateweight.Text = "5";

          
           
         //  Loadlegsby();
          //   dgvlegsmain.ClearSelection();
            dgvlegsmain.ClearSelection();


            rdbaconers.Checked = true;
           
          
            dgvbreaklegsbacon.ClearSelection();
            dgvbreaklegssows.ClearSelection();
            dgvlegsmain.ClearSelection();
          //   dgvlegsmain.ClearSelection();
            dgvLMS.ClearSelection();
           // //dgvmiddlesbyproducts.ClearSelection();
            dgvshouldersmain.ClearSelection();
            dgvbeheading.ClearSelection();
            dgvstrip.ClearSelection();
          

         

                if (lbltotalpieceswlegs.Text == "") txtnoplegs.Text = "0";
            if (lbltotalpieceswmiddles.Text == "") txtnopmiddles.Text = "0";
            if (lbltotalpieceswshoulders.Text == "") txtnopshoulders.Text = "0";

           
           
            richTextBox2.Text = "0.0";


               

                Refreshlegs.Focus();
            }
            else
            {

               this.Close();
            }

        }

        private void Totalnumberofpieceslegs()
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
                String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='Main Product' AND outputptype='Leg'";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;

                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            lbltotalpieceswlegs.Text = Convert.ToString(result);
                            if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                conn.Close();

            }





        }

        private void Totalnumberofpiecesmiddles()
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
                String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and  parentItemNo='Main Product' AND outputptype='Middle'";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;

                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            lbltotalpieceswmiddles.Text = Convert.ToString(result);


                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                conn.Close();

            }
        }

        private void Totalnumberofpiecesshoulders()
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
                String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and  parentItemNo='Main Product' AND outputptype='Shoulder'";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;

                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            lbltotalpieceswshoulders.Text = Convert.ToString(result);
                            if (lbltotalpieceswshoulders.Text == "") lbltotalpieceswshoulders.Text = "0";

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                conn.Close();

            }


        }
        private void totalslaughtered()
        {
            if (txtslaughterbcn.Text == "") txtslaughterbcn.Text = "0";
            if (txtslaughtersows.Text == "") txtslaughtersows.Text = "0";

            if (SlaughterDateTo.Text == "") { SlaughterDateTo.Text = DateTime.Today.ToString("dd/MMM/yyyy"); }
           



            string
            xwz = SlaughterDateTo.Text;
            if (xwz == "")
            {
                xwz = DateTime.Today.ToString("dd/MMM/yyyy");
            }
             DateTime endDate = Convert.ToDateTime(xwz);
          

            endDate = endDate.AddDays(1);
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
                String q = "select count(*) * 2 from ButcheryData where ItemNo='G1030' and  ButchTime>='"+xwz + "' and ButchTime<='" + endDate.ToString("dd/MMM/yyyy") + "'";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;
                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            //if (Txttotalrectoday.Text == "") Txttotalrectoday.Text = "0";
                            txtslaughterbcn.Text = Convert.ToString(result);
                            if (txtslaughterbcn.Text == "") txtslaughterbcn.Text = "0";
                           // Txttotalrectoday.Text = (Convert.ToDouble(txtbcos.Text) / 2).ToString("#,0.00");

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                String w = "select count(*) *2 from ButcheryData where ItemNo = 'G1031' and  ButchTime>='" + xwz + "' and ButchTime<='" + endDate.ToString("dd/MMM/yyyy") + "'";
                using (SqlCommand cmd = new SqlCommand(w, conn))
                {

                    cmd.CommandText = w;
                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            txtslaughtersows.Text = Convert.ToString(result);
                            if  ( txtslaughtersows.Text=="")  txtslaughtersows.Text="0";
                            // totalweighedtoday.Text = txtsws.Text;

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }

                conn.Close();

            }


        }
        private void Bacons()
        {
            if (Txtbsides.Text == "") Txtbsides.Text = "0";
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
                String q = "select Baconers from [Pbreaking] where cast (butchdate as date)= cast (getdate() as date) ORDER BY ID DESC"  ;
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;
                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        { 
                            //if (Txttotalrectoday.Text == "") Txttotalrectoday.Text = "0";
                            txtbcos.Text = Convert.ToString(result);
                            if (txtbcos.Text == "") txtbcos.Text = "0";
                            Txttotalrectoday.Text = (Convert.ToDouble(txtbcos.Text) / 2).ToString("#,0.00");

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                String w = "select Sows from [Pbreaking] where cast (butchdate as date)= cast (getdate() as date) ORDER BY ID DESC ";
                using (SqlCommand cmd = new SqlCommand(w, conn))
                {

                    cmd.CommandText = w;
                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            txtsowsrecv.Text = Convert.ToString(result);
                            //  txtsws.Text = Convert.ToString(result);
                            // totalweighedtoday.Text = txtsws.Text;

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }

                conn.Close();

            }


        }
        private void sows()
        {
            //using (SqlConnection conn = new SqlConnection(_connectionStringNAV))
            //{

            //    try
            //    {
            //        conn.Open();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //        return;
            //    }
            //    String q = "select count(*) * 2 from [Farmers Choice Ltd_$Slaughter Data] where cast ([Slaughter Date] as date)= cast(DATEADD(day,-1,GETDATE()) as date) and [Item No_]='G0111' ";
            //    using (SqlCommand cmd = new SqlCommand(q, conn))
            //    {

            //        cmd.CommandText = q;
            //        //using (var reader = cmd.ExecuteReader())
            //        {
            //            cmd.ExecuteNonQuery();
            //            object result = cmd.ExecuteScalar();


            //            {
            //               totalweighedtoday.Text = Convert.ToString(result);

            //                //MeatPercent.Enabled = true;
            //                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
            //            }
            //        }

            //    }
            //    conn.Close();

            //}




        }
        private void TotalTotal()
        {




        }


        private void userperm()
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
                String q = "SELECT  [Role]  FROM [dbo].[users] where Adname='" + User.Text + "'";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;
                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            Txtrole.Text = Convert.ToString(result);

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                conn.Close();

            }


        }
        public void Totalreceivedtoday()

        {
            DateTime date = DateTime.Now;

            string dateToday = date.ToString("d");
            DayOfWeek day = DateTime.Now.DayOfWeek;
            string dayToday = day.ToString();

            if ((day == DayOfWeek.Monday))
            {
                
                DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);


                navdate = navdate.AddDays(-3);
                using (SqlConnection conn = new SqlConnection(_connectionStringNAV))
                {
                    
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
                        String q = "select count(*)  from [FCL$SlaughterData] where  SlaughterDate= '" + navdate.ToString("dd/MMM/yyyy") + "' and [ItemNo]='G0110'";
                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {

                            cmd.CommandText = q;

                            //using (var reader = cmd.ExecuteReader())
                            {
                                cmd.ExecuteNonQuery();
                                object result = cmd.ExecuteScalar();


                                {
                                    //Txttotalrectoday.Text = Convert.ToString(result);
                                    Txtbacon.Text = Convert.ToString(result);

                                    //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                    //MeatPercent.Enabled = true;
                                    // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                                }
                            }

                        }
                        String w = "select count(*)  from [FCL$SlaughterData] where  [SlaughterDate] = '" + navdate.ToString("dd/MMM/yyyy") + "' and [ItemNo]='G0111'";
                        using (SqlCommand cmd = new SqlCommand(w, conn))
                        {

                            cmd.CommandText = w;

                            //using (var reader = cmd.ExecuteReader())
                            {
                                cmd.ExecuteNonQuery();
                                object result = cmd.ExecuteScalar();


                                {
                                    // totalweighedtoday.Text = Convert.ToString(result);
                                    Txtsows.Text = Convert.ToString(result);

                                    //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                    //MeatPercent.Enabled = true;
                                    // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                                }
                            }

                        }

                        conn.Close();




                    }


                }
            } else
                using (SqlConnection conn = new SqlConnection(_connectionStringNAV))
                {
                    DateTime navdate = Convert.ToDateTime(SlaughterDate.Text);
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
                        String q = "select count(*)  from [FCL$SlaughterData] where  SlaughterDate= '" + navdate.ToString("dd/MMM/yyyy") + "' and [ItemNo]='G0110'";
                        using (SqlCommand cmd = new SqlCommand(q, conn))
                        {

                            cmd.CommandText = q;

                            //using (var reader = cmd.ExecuteReader())
                            {
                                cmd.ExecuteNonQuery();
                                object result = cmd.ExecuteScalar();


                                {
                                    //Txttotalrectoday.Text = Convert.ToString(result);
                                    Txtbacon.Text = Convert.ToString(result);

                                    //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                    //MeatPercent.Enabled = true;
                                    // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                                }
                            }

                        }
                        String w = "select count(*)  from [FCL$SlaughterData] where  [SlaughterDate] = '" + navdate.ToString("dd/MMM/yyyy") + "' and [ItemNo]='G0111'";
                        using (SqlCommand cmd = new SqlCommand(w, conn))
                        {

                            cmd.CommandText = w;

                            //using (var reader = cmd.ExecuteReader())
                            {
                                cmd.ExecuteNonQuery();
                                object result = cmd.ExecuteScalar();


                                {
                                    // totalweighedtoday.Text = Convert.ToString(result);
                                    Txtsows.Text = Convert.ToString(result);

                                    //if (lbltotalpieceswlegs.Text == "") lbltotalpieceswlegs.Text = "0";

                                    //MeatPercent.Enabled = true;
                                    // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                                }
                            }

                        }

                        conn.Close();




                    }


                }


            
        }

        private void Received_TextChanged(object sender, EventArgs e)
        {

        }

        private void NetTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void SideA_TextChanged(object sender, EventArgs e)

        {
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void SumTotal()
        {




        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SideB_TextChanged(object sender, EventArgs e)
        {

            // SDB = Convert.ToDouble(Total.Text);


        }

        private void button2_Click(object sender, EventArgs e)
        {


        }





        private void Savemydatalegs()


        {
            double Rqty = 0.0;
            lbllegpiec.Text.Replace(" ", "");
            Rqty = Convert.ToDouble(lbllegpiec.Text);
           
          
            {

                string date;

                //if (lblinputmiddleleg.Text== "Beheading pig" || lblinputmiddleleg.Text == "Beheading sow")

                //{

                //    date = dtpslota.Text;


                //} else
                //{
                //    date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //}
                if (txtnoplegs.Text == "") { txtnoplegs.Text = "0.0"; }
                date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID],[BarcodeID])" +
                                                        "VALUES ('" + lbldeboning.Text + "','"
                                                          + lblinputmiddleleg.Text + "','"
                                                          + lbllegpiec.Text + "','"
                                                          + lblcodeselleg.Text + "','"
                                                          + lblitemdescselleg.Text + "','"
                                                          + lblinputmiddleleg.Text + "','"
                                                          + legscrate.Text + "','"
                                                          + txtnoplegs.Text + "','"
                                                          + NETWeightlegs.Text.Replace(",","") + "','"
                                                        
                                                          + date + "','"
                                                          + User.Text + "','"
                                                          + lblbarcodeno.Text + "')";




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
                          //  Bacons();
                            // sows();

                            MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadweighedlegs();

                            Totalnumberofpieceslegs();
                            Totalnumberofpiecesmiddles();
                            Totalnumberofpiecesshoulders();
                            loadbeheaded();









                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }
            }

           
            //{
            //    using (SqlConnection conn = new SqlConnection(_connectionString))
            //    {

            //        try
            //        {
            //            conn.Open();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //            return;
            //        }
            //        String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1100' AND outputptype='Main product'";
            //        using (SqlCommand cmd = new SqlCommand(q, conn))
            //        {

            //            cmd.CommandText = q;

            //            //using (var reader = cmd.ExecuteReader())
            //            {
            //                cmd.ExecuteNonQuery();
            //                object result = cmd.ExecuteScalar();


            //                {
            //                    //t db;
            //                    //b = Convert.ToInt32(result);
            //                    //qty = Convert.ToInt32(txtnoplegs.Text) + db;

            //                    string db;
            //                    db = Convert.ToString(result);
            //                    if (db == "") db = "0";
            //                    string nop;
            //                    nop = txtnoplegs.Text;
            //                    //wqty = Convert.ToInt32(nop) + Convert.ToInt32(db);


            //                    //MeatPercent.Enabled = true;
            //                    // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
            //                }
            //            }

            //        }
            //        conn.Close();

            //    }


            //    //if (wqty <= Rqty)
            //    //{
            //    //    using (SqlConnection conn = new SqlConnection(_connectionString))
            //    //    {

            //    //        //
            //    //        String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
            //    //                                            "VALUES ('" + lblitemno.Text + "','"
            //    //                                              + lbldesc.Text + "','"
            //    //                                              + lbllegpiec.Text + "','"
            //    //                                              + lblcodeselleg.Text + "','"
            //    //                                              + lblitemdescselleg.Text + "','"
            //    //                                              + lblinputmiddleleg.Text + "','"
            //    //                                              + legscrate.Text + "','"
            //    //                                              + txtnoplegs.Text + "','"
            //    //                                              + NETWeightlegs.Text + "','"
            //    //                                              + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
            //    //                                               + User.Text + "')";




            //    //        using (SqlCommand cmd = new SqlCommand(q5, conn))
            //    //        {
            //    //            try
            //    //            {
            //    //                conn.Open();
            //    //            }
            //    //            catch (Exception ex)
            //    //            {
            //    //                MessageBox.Show(ex.Message + "Error 12");
            //    //                return;
            //    //            }
            //    //            try
            //    //            {
            //    //                cmd.ExecuteNonQuery();
            //    //                Bacons();
            //    //                sows();

            //    //                MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //                loadweighedlegs();
            //    //                Totalnumberofpieceslegs();









            //    //            }
            //    //            catch (Exception ex)
            //    //            {
            //    //                MessageBox.Show(ex.Message + "Error 10");
            //    //            }
            //    //        }
            //    //        conn.Close();
            //    //    }

            //    //}
            //    //else
            //    //{

            //    //    MessageBox.Show("The record could not be posted. The Number of pieces exceeds The required Number of pieces", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //}

            //}
        }

        //private void Savemydatamiddles()
        //{
        //    double Rqty = 0.0;
        //  //  lblmiddlepiec.Text.Replace(" ", "");
        //  //  Rqty = Convert.ToDouble(lblmiddlepiec.Text);
        //    if (middlesnonpieces.Contains(lblcodeselmiddle.Text) == true)

        //    {
        //        txtnopmiddles.Text = "0";
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {

        //            //
        //            String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
        //                                                "VALUES ('" + lblitemnomiddles.Text + "','"
        //                                                  + lbldescmiddles.Text + "','"
        //                                                  + lblmiddlepiec.Text + "','"
        //                                                  + lblcodeselmiddle.Text + "','"
        //                                                  + //lblitemdescselmiddle.Text + "','"
        //                                                  + lblinputmiddle.Text + "','"
        //                                                  + middlescrate.Text + "','"
        //                                                  + txtnopmiddles.Text + "','"
        //                                                  + NETWeightmiddles.Text + "','"
        //                                                  + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
        //                                                   + User.Text + "')";




        //            using (SqlCommand cmd = new SqlCommand(q5, conn))
        //            {
        //                try
        //                {
        //                    conn.Open();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message + "Error 12");
        //                    return;
        //                }
        //                try
        //                {
        //                    cmd.ExecuteNonQuery();
        //                    Bacons();
        //                    sows();

        //                    MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    loadweighedmiddles();
        //                    Totalnumberofpiecesmiddles();








        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message + "Error 10");
        //                }
        //            }
        //            conn.Close();
        //        }

        //    }

        //    else if (middlesnonpieces.Contains(lblcodeselmiddle.Text) == false && byprods.Contains(lblinputmiddle.Text) == true)

        //    {
        //        //xtnopmiddles.Text = "0";
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {

        //            //
        //            String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
        //                                                "VALUES ('" + lblitemnomiddles.Text + "','"
        //                                                  + lbldescmiddles.Text + "','"
        //                                                  + lblmiddlepiec.Text + "','"
        //                                                  + lblcodeselmiddle.Text + "','"
        //                                                  + //lblitemdescselmiddle.Text + "','"
        //                                                  + lblinputmiddle.Text + "','"
        //                                                  + middlescrate.Text + "','"
        //                                                  + txtnopmiddles.Text + "','"
        //                                                  + NETWeightmiddles.Text + "','"
        //                                                  + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
        //                                                   + User.Text + "')";




        //            using (SqlCommand cmd = new SqlCommand(q5, conn))
        //            {
        //                try
        //                {
        //                    conn.Open();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message + "Error 12");
        //                    return;
        //                }
        //                try
        //                {
        //                    cmd.ExecuteNonQuery();
        //                    Bacons();
        //                    sows();

        //                    MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    loadweighedmiddles();
        //                    Totalnumberofpiecesmiddles();








        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message + "Error 10");
        //                }
        //            }
        //            conn.Close();
        //        }

        //    }



        //    else if (lblinputmiddle.Text == "Main Product")
        //    {
        //        using (SqlConnection conn = new SqlConnection(_connectionString))
        //        {

        //            try
        //            {
        //                conn.Open();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                return;
        //            }
        //            String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1102' AND outputptype='Main product'";
        //            using (SqlCommand cmd = new SqlCommand(q, conn))
        //            {

        //                cmd.CommandText = q;

        //                //using (var reader = cmd.ExecuteReader())
        //                {
        //                    cmd.ExecuteNonQuery();
        //                    object result = cmd.ExecuteScalar();


        //                    {
        //                        string db;
        //                        db = Convert.ToString(result);
        //                        if (db == "") db = "0";
        //                        string nop;
        //                        nop = txtnopmiddles.Text;
        //                        wqty = Convert.ToInt32(nop) + Convert.ToInt32(db);


        //                        //MeatPercent.Enabled = true;
        //                        // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
        //                    }
        //                }

        //            }
        //            conn.Close();

        //        }


        //        if (wqty <= Rqty)
        //        {

        //            {
        //                using (SqlConnection conn = new SqlConnection(_connectionString))
        //                {

        //                    //
        //                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
        //                                                        "VALUES ('" + lblitemnomiddles.Text + "','"
        //                                                          + lbldescmiddles.Text + "','"
        //                                                          + lblmiddlepiec.Text + "','"
        //                                                          + lblcodeselmiddle.Text + "','"
        //                                                          + //lblitemdescselmiddle.Text + "','"
        //                                                          + lblinputmiddle.Text + "','"
        //                                                          + middlescrate.Text + "','"
        //                                                          + txtnopmiddles.Text + "','"
        //                                                          + NETWeightmiddles.Text + "','"
        //                                                          + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
        //                                                           + User.Text + "')";




        //                    using (SqlCommand cmd = new SqlCommand(q5, conn))
        //                    {
        //                        try
        //                        {
        //                            conn.Open();
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            MessageBox.Show(ex.Message + "Error 12");
        //                            return;
        //                        }
        //                        try
        //                        {
        //                            cmd.ExecuteNonQuery();
        //                            Bacons();
        //                            sows();

        //                            MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                            loadweighedmiddles();
        //                            Totalnumberofpiecesmiddles();








        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            MessageBox.Show(ex.Message + "Error 10");
        //                        }
        //                    }
        //                    conn.Close();
        //                }

        //            }


        //        }






        //        else
        //        {
        //            MessageBox.Show("The record could not be posted. The Number of pieces exceeds The required Number of pieces", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }


        //    }


        //}
        private void Savemydatashoulders()
        {
            double Rqty = 0.0;
            lbllegpiec.Text.Replace(" ", "");
           // Rqty = Convert.ToDouble(lblmiddlepiec.Text);

            if (lblinputshoulders.Text == "By Product")
            {
                txtnopshoulders.Text = "0";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                              "VALUES ('" + lblitemnoshoulders.Text + "','"
                                                                + lbldescshoulders.Text + "','"
                                                                + lblshoulderpiec.Text + "','"
                                                                + lblcodeselshoulders.Text + "','"
                                                                + lblitemdescselshoulders.Text + "','"
                                                                + lblinputshoulders.Text + "','"
                                                                + shoulderscrate.Text + "','"
                                                                + txtnopshoulders.Text + "','"
                                                                + NETWeightshoulders.Text + "','"
                                                                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                                 + User.Text + "')";




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
                         
                           
                            MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtnopshoulders.Text = "";
                            loadweighedshoulders();
                            Totalnumberofpiecesshoulders();
                            //Bacons();
                           // sows();









                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }

            }

            else if (lblinputshoulders.Text == "Main Product")
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
                    String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1101' AND outputptype='Main product'";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();





                            object result = cmd.ExecuteScalar();



                            {

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                string nop;
                                nop = txtnopshoulders.Text;
                                wqty = Convert.ToInt32(nop) + Convert.ToInt32(db);


                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }
                    conn.Close();

                }

                if (wqty <= Rqty)
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {

                        //
                        String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                            "VALUES ('" + lblitemnoshoulders.Text + "','"
                                                              + lbldescshoulders.Text + "','"
                                                              + lblshoulderpiec.Text + "','"
                                                              + lblcodeselshoulders.Text + "','"
                                                              + lblitemdescselshoulders.Text + "','"
                                                              + lblinputshoulders.Text + "','"
                                                              + shoulderscrate.Text + "','"
                                                              + txtnopshoulders.Text + "','"
                                                              + NETWeightshoulders.Text + "','"
                                                              + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                               + User.Text + "')";




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
                                Bacons();
                                sows();

                                MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadweighedshoulders();
                                Totalnumberofpiecesshoulders();








                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + "Error 10");
                            }
                        }
                        conn.Close();


                    }

                }
                else
                {

                    MessageBox.Show("The record could not be posted. The Number of pieces exceeds The required Number of pieces", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void savemydatabreakings()
        {
            if (lblG10itemno.Text == ".")
            {


                MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }


            else

            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    richTextBox1.Text.Replace("\n", "");
                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID],[BarcodeID])" +
                                                        "VALUES ('" + lblG10itemno.Text + "','"
                                                          + lbltype.Text + "','"
                                                          + lblG10desc.Text + "','"
                                                          + lblG10itemno.Text + "','"
                                                          + lblG10desc.Text + "','"
                                                          + lblG10desc.Text + "','"
                                                          + richTextBox1.Text + "','"
                                                          + cmbcrateweight.Text + "','"
                                                          + txtnetwso2.Text + "','"
                                                          + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                          + User.Text + "','"
                                                          + lblbrbarcode.Text + "')";




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
                            // Bacons();
                            //sows();

                            MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // loadweighedshoulders();
                            // Totalnumberofpiecesshoulders();
                            //readg10.Text = "0.0";
                            // txtnetwso2.Text = "0.0";


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


        private void saveslicing()
        {
            if (lblstripcode.Text == ".")
            {


                MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }


            else

            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    //readg10.Text.Replace("\n", "");
                    //
                    String q5 =" INSERT INTO[dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID],[BarcodeID])"  +
                                                        "VALUES ('" + slicetype.Text + "','"
                                                              + lblslice.Text + "','"
                                                          + txtslicingscale.Text + "','"
                                                          + lblstripcode.Text + "','"
                                                          + stripname.Text + "','"
                                                         + slicetype.Text + "','"
                                                          + cmbnocfats.Text + "','"
                                                          + slcingnop.Text + "','"
                                                          + txtnetfats.Text + "','"
                                                          + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                        + User.Text + "','"
                                                          + stripbarcode.Text + "')";




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
                            // Bacons();
                            //sows();
                            clearcontrols();

                            MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // loadweighedshoulders();
                            // Totalnumberofpiecesshoulders();
                            //readg10.Text = "0.0";
                            txtslicingscale.Text = "0.0";








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
        private void button1_Click(object sender, EventArgs e)
        {

        }




        private void Totalqty() // we pass the Total quantites to  the text box 
        {

        }

        private void post(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {



                // button1.PerformClick();
                // Savemydata();



            }
        }



        private void dgvdetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Loadlegs()
        {

            dgvlegsmain.DataSource = null;
            dgvlegsmain.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName],[Inputtype] as Deboning,[ProductType] as Type,[BarcodeID] as Barcode FROM PRODUCTS where bom='' order by ID asc";

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

                this.dgvlegsmain.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvlegsmain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvlegsmain.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvlegsmain.Columns[i].Width;
                //    //remove autosizing
                //    dgvlegsmain.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    dgvlegsmain.Columns[i].Width = 500;
                //}
            }



        }

        private void Loadbehadingsproducts()
        {
            dgvshouldersmain.DataSource = null;
            dgvshouldersmain.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName]as Name,[Inputtype] as Source FROM PRODUCTS WHERE [ProductType]='by Product' and [inputtype] in ('Beheading pig','Beheading sow')   order by ID desc";

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

                this.dgvshouldersmain.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // dgvlegsmain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ////dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ////datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <=  dgvlegsmain.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw =  dgvlegsmain.Columns[i].Width;
                //    //remove autosizing
                //     dgvlegsmain.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //     dgvlegsmain.Columns[i].Width = 250;
                //}
            }


        }

        private void Loadmiddles()
        {
            dgvbreaklegsbacon.DataSource = null;
            dgvbreaklegsbacon.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description,inputtype,BarcodeID FROM PRODUCTS WHERE ProductType = 'By Product' AND inputtype IN ('BACONER') ORDER BY inputtype";

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

                this.dgvbreaklegsbacon.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
              //  dgvshouldersmain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvtwosides.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvtwosides.Columns[i].Width;
                //    //remove autosizing
                //    dgvtwosides.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    dgvtwosides.Columns[i].Width = 250;
                //}
            }

        }

        private void loadmiddlesbys()
        {
            ////dgvmiddlesbyproducts.DataSource = null;
           // //dgvmiddlesbyproducts.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [ProductType]='By Product' and [inputtype]='Middles'  order by ID asc";

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

               // this.//dgvmiddlesbyproducts.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               // //dgvmiddlesbyproducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= //dgvmiddlesbyproducts.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = //dgvmiddlesbyproducts.Columns[i].Width;
                //    //remove autosizing
                //    //dgvmiddlesbyproducts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    //dgvmiddlesbyproducts.Columns[i].Width = 250;
                //}
            }




        }

        private void loadshoulders()
        {
            dgvshouldersmain.DataSource = null;
            dgvshouldersmain.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [ProductType]='Main Product' and [inputtype]='Shoulders' and ItemNo not in ('G1030','G1031')  order by ID asc";

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

                this.dgvshouldersmain.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvshouldersmain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvshouldersmain.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvshouldersmain.Columns[i].Width;
                    //remove autosizing
                    dgvshouldersmain.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvshouldersmain.Columns[i].Width = 250;
                }
            }


        }

        private void loadshouldersby()
        {
            dgvbeheading.DataSource = null;
            dgvbeheading.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [ProductType]='By Product' and [inputtype]='Shoulders'  order by ID asc";

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

                this.dgvbeheading.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvbeheading.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvbeheading.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvbeheading.Columns[i].Width;
                    //remove autosizing
                    dgvbeheading.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvbeheading.Columns[i].Width = 250;
                }
            }


        }

        private void loadweighedlegs()
        {
            dgvlegsdata.DataSource = null;
            dgvlegsdata.Refresh();
         //   dgvcumulatives.DataSource = null;
          //  dgvcumulatives.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "select ItemNo,outputpname AS Product,outputptype AS Source,CAST(Nocrates AS decimal(18,2)) AS Crates,CAST(nopieces AS decimal(18,2)) AS Pieces,CAST(NetWeight AS decimal(18,2)) AS Weight,BarcodeID,ID,parentItemNo AS Type from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentinputtype not in('Bacon, Carcass - Sid','Bacon, Carcass - Sid','BACONER','SOW')  order by ID desc";

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

                this.dgvlegsdata.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvlegsdata.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //  dgvlegsdata.Columns[1].Width = 250;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvlegsdata.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvlegsdata.Columns[i].Width;
                //    //remove autosizing
                //    dgvlegsdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize

                //}
            }

        }

        private void loadbeheaded()
        {
            dgvbeheading.DataSource = null;
            dgvbeheading.Refresh();
            //   dgvcumulatives.DataSource = null;
            //  dgvcumulatives.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                
                String q = "SELECT Itemno, outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18, 2))) AS 'CRATES',sum(CAST(NetWeight AS decimal(18, 2))) as Weight  from ButcheryData where parentinputtype in ('Beheading sow','Beheading Pig') and cast (butchtime as date)=cast (getdate() as date)  GROUP BY outputpname,Itemno,outputptype ";

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

                this.dgvbeheading.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvbeheading.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvbeheading.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dgvbeheading.Rows[i].Cells[4].Value);






                }
                // add the total row

                string[] totalrow = new string[] { "", "Two Sides", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };


                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);

                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // dgvbeheading.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //  dgvlegsdata.Columns[1].Width = 250;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvlegsdata.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvlegsdata.Columns[i].Width;
                //    //remove autosizing
                //    dgvlegsdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize

                //}
            }

        }


        private void loadweighedmiddlesno()
        {
            dgvshoulderdeboning.DataSource = null;
            dgvshoulderdeboning.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "select ItemNo,outputpname AS Product,outputptype as Type,CAST(Nocrates AS decimal(18,2)) AS Crates,CAST(nopieces AS decimal(18,2)) AS Pieces,CAST(NetWeight AS decimal(18,2)) AS Weight,ID from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentItemNo='G1102' order by ID desc";

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

                this.dgvshoulderdeboning.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvmiddlesdata.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvmiddlesdata.Columns[i].Width;
                //    //remove autosizing
                //    dgvmiddlesdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    dgvmiddlesdata.Columns[i].Width = 250;
                //}
            }
        }

        private void loadweighedshoulders()
        {
           // dgvshouldersdata.DataSource = null;
           // dgvshouldersdata.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "select ItemNo,outputpname AS Product,outputptype as Type,CAST(Nocrates AS decimal(18,2)) AS Crates,CAST(nopieces AS decimal(18,2)) AS Pieces,CAST(NetWeight AS decimal(18,2)) AS Weight,ID from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentItemNo='G1101' order by ID desc";

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

               // this.dgvshouldersdata.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }
        }
        private void loaddata()
        {

            dgvlegsmain.DataSource = null;
            dgvlegsmain.Refresh();
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

                String q = "SELECT  Row_Number() OVER(order by id) as 'Carcass Number',SlaughterTime,vendorname,CAST(SideTotal AS decimal(18,2)) AS 'A and B' FROM [dbo].[SlaughterData] where SlaughterTime>'" + DateTime.Today.ToString("yyyy-MM-dd h:mm tt") + "' order by ID desc";

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

                this.dgvlegsmain.DataSource = table;

            }
            //MessageBox.Show(Sla

        }
        private void loadtwosidesC()
        {

            dgvfullcarcass.DataSource = null;
            dgvfullcarcass.Refresh();
           
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

                    String q = "SELECT [ItemNo] as Code,CAST (NetWeight AS NUMERIC(18,1)) AS Weight,parentinputtype AS Input FROM ButcheryData WHERE  ItemNo IN ('G1030','G1031')and  cast (butchtime as date)=cast(getdate() as date) order by ID DESC";

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

                    this.dgvfullcarcass.DataSource = table;
                    // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvfullcarcass.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //datagrid has calculated it's widths so we can store them
                    //for (int i = 1; i <= dgvfullcarcass.Columns.Count - 1; i++)
                    //{
                    //    //store autosized widths
                    //    int colw = dgvfullcarcass.Columns[i].Width;
                    //    //remove autosizing
                    //    dgvfullcarcass.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //    //set width to calculated by autosize
                    //    dgvfullcarcass.Columns[i].Width = 250;
                    //}
                }


                

            }
            //MessageBox.Show(Sla

        }
        private void loadtwosides()
        {

           // dgvsows.DataSource = null;
          //  dgvsows.Refresh();

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

                    String q = "SELECT [ItemNo] as Code,CAST (NetWeight AS NUMERIC(18,1)) AS Weight  FROM ButcheryData WHERE  ItemNo ='G1031'and  cast (butchtime as date)=cast(getdate() as date) order by ID asc";

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

                  //  this.dgvsows.DataSource = table;
                    // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dgvsows.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    ////dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    ////datagrid has calculated it's widths so we can store them
                    //for (int i = 1; i <= dgvsows.Columns.Count - 1; i++)
                    //{
                    //    //store autosized widths
                    //    int colw = dgvsows.Columns[i].Width;
                    //    //remove autosizing
                    //    dgvsows.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //    //set width to calculated by autosize
                    //    dgvsows.Columns[i].Width = 250;
                    //}
                }




            }
            //MessageBox.Show(Sla

        }

        private void loadstrips()
        {
            dgvstrip.DataSource = null;
            dgvstrip.Refresh();
            dgvstripout.DataSource = null;
            dgvstripout.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName],[inputtype],Producttype,[BarcodeID] as Description FROM PRODUCTS WHERE [inputtype]='Slicing' and ProductType='Input' order by ID asc";

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

               

                this.dgvstrip.DataSource = table;
                dgvstrip.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvstrip.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvstrip.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                String w = "SELECT [ItemNo] as Code,[ProductName],[inputtype],Producttype,[BarcodeID] as Description FROM PRODUCTS WHERE [inputtype]='Slicing'and ProductType not in ('Input') order by ID asc";

                var table2 = new DataTable();
                using (var dt = new SqlDataAdapter(w, _connectionString))
                {
                    try
                    {
                        dt.Fill(table2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }

                conn.Close();

                this.dgvstripout.DataSource = table2;
                dgvstripout.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvstripout.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               // dgvstripout.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them

            }




        }


        private void deliveriesPerPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detailed rptdetailed = new Detailed();
            //Form1 mainfrm = new Form1();
            //rptsummarry.MdiParent = this.MdiParent;


            rptdetailed.Show();
        }

        private void dgvsum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGVTotalS()
        {





        }
        private DataTable FillDatatable(string Query)
        {
            DataTable objDT = new DataTable();
            SqlDataAdapter objda = new SqlDataAdapter(Query, _connectionString);
            objda.Fill(objDT);
            return objDT;
        }
        private void dgvsum_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deliveriesPerVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            summarry rptsummarry = new summarry();
            //Form1 mainfrm = new Form1();
            //rptsummarry.MdiParent = this.MdiParent;


            rptsummarry.Show();


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {



            // DialogResult dialog = MessageBox.Show("Are You Sure You Want To Close The Application ? ", "BAWS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void Label8_Click_1(object sender, EventArgs e)
        {

        }

        private void Label23_Click(object sender, EventArgs e)
        {

        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form userfrm = new userfrm();
            userfrm.Show();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if (MessageBox.Show("Are You Sure You Want To Close The Application?", "CMWAS",
            //MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //  {
            // Cancel the Closing event
            // e.Cancel = true;
         //   this.Close();
           // }
        }

        private void Label19_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void CrateTotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refreshlegs.Focus();
        }

        private void Desc_TextChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Refresh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //readTotal();
            Weighlivestock();
            richTextBox2.Focus();
        }

        private void LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.initComBo();
        }

        private void ToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.initComBo();
        }

        private void Txtclcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtstw_TextChanged(object sender, EventArgs e)
        {


        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }

        private void Txtbacon_TextChanged(object sender, EventArgs e)
        {
            if (Txtbsides.Text == "") Txtbsides.Text = "0";
            if (Txtbacon.Text == "") Txtbacon.Text = "0";
            Txtbsides.Text = (Convert.ToDouble(Txtbacon.Text) * 2).ToString("#,0.00");
        }

        private void Txtsows_TextChanged(object sender, EventArgs e)
        {
            if (TxtSsides.Text == "") TxtSsides.Text = "0";
            if (Txtsows.Text == "") Txtsows.Text = "0";
            TxtSsides.Text = Txtsows.Text;
        }

        private void Label29_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label39_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label40_Click(object sender, EventArgs e)
        {

        }

        private void Label41_Click(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label42_Click(object sender, EventArgs e)
        {

        }

        private void Label43_Click(object sender, EventArgs e)
        {

        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label44_Click(object sender, EventArgs e)
        {

        }

        private void Label38_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click_1(object sender, EventArgs e)
        {

        }
        private bool Readweight2()
        {
            string port = Properties.Settings.Default.COMPort2;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                richTextBox2.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                richTextBox2.ReadOnly = true;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                richTextBox2.ReadOnly = false;
                return false;


            }



        }
        private bool Readweight1()
        {
            string port = Properties.Settings.Default.COMPort1;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                richTextBox2.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                richTextBox2.ReadOnly = true;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                richTextBox2.ReadOnly = false;
                return false;


            }



        }

        private void Readw1_Click(object sender, EventArgs e)
        {

        }

        private void Readw2_Click(object sender, EventArgs e)
        {
            readtwosides();
            //read the weight from bthe scale
        }

        private void Button3_Click_2(object sender, EventArgs e)
        {


            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[Pbreaking]([Baconers],[Sows],[butchdate],[UserID])" +
                                                        "VALUES ('" + Txtbsides.Text + "','"
                                                          + TxtSsides.Text + "','"

                                                          + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                           + User.Text + "')";

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
                            Bacons();
                            sows();
                            MessageBox.Show("Data Saved Succesfully");








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

        private void Txtbcos_TextChanged(object sender, EventArgs e)
        {
            txtlegs.Text = (txtbcos.Text);
            txtshoulders.Text = (txtbcos.Text);
            txtmiddles.Text = (txtbcos.Text);
            lbllegpiec.Text = (txtbcos.Text);
           // lblmiddlepiec.Text = (txtbcos.Text);
            lblshoulderpiec.Text = (txtbcos.Text);
        }

        private void Txtsws_TextChanged(object sender, EventArgs e)
        {
           // Txtleanpork.Text = txtsws.Text;
           // Txtsemilean.Text = txtsws.Text;
        }

        private void Rdbaconers_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbaconers.Checked == true) { rdsows.Checked = false; }
            // rdbaconers.Checked = true;
        }

        private void Rdlegs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label40_Click_1(object sender, EventArgs e)
        {

        }

        private void Readw4_Click(object sender, EventArgs e)
        {
            readweightwso2();
            NETWeightshoulders.Text = txtnetwso2.Text;
            NETWeightmiddles.Text = txtnetwso2.Text;
            NETWeightlegs.Text = txtnetwso2.Text;
            txtnetfats.Text = txtnetwso2.Text;
            // readweightlegsdebon();

            // readweightmiddlesdebon();
            // readweightshouldersdebon();
            //readweightstripping();
            txtnetwso2.Focus();
        }

        private void Label38_Click_1(object sender, EventArgs e)
        {

        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void Dgvsum_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvlegsmain.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = "Main product";
                 dgvlegsmain.ClearSelection();

            }
        }

        private void  dgvlegsmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this. dgvlegsmain.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = "By product";
                dgvlegsmain.ClearSelection();
            }
        }

        private void Total_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Refresh_Click_2(object sender, EventArgs e)
        {
            // readTotal();
        }

        private void ReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_Click_3(object sender, EventArgs e)
        {

        }

        private void Total_TextChanged_2(object sender, EventArgs e)
        {
            Double CT = 0.0;
            CT = (Convert.ToDouble(legscrate.Text) * 1.8);
            NETWeightlegs.Text = (Convert.ToDouble(richTextBox2.Text) - CT).ToString("#,0.00");
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SlapMark_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Dgvmiddlesmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvLMS.Rows[e.RowIndex];
                lblcodeselmiddle.Text = row.Cells[0].Value.ToString();
                //lblitemdescselmiddle.Text = row.Cells[1].Value.ToString();
                lblinputmiddle.Text = "Main Product";
                Middlepieces();
                //dgvmiddlesbyproducts.ClearSelection();
                dgvbreaklegsbacon.ClearSelection();
                dgvbreaklegssows.ClearSelection();
                dgvlegsmain.ClearSelection();
                 dgvlegsmain.ClearSelection();
                //dgvmiddlesmain.ClearSelection();
                //dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                dgvbeheading.ClearSelection();
                dgvstrip.ClearSelection();
                //txtsearchmiddlemain.Text = "";
                txtnopmiddles.Focus();


            }
        }

        private void Dgvmiddlesbyproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //DataGridViewRow row = this.//dgvmiddlesbyproducts.Rows[e.RowIndex];
                //lblcodeselmiddle.Text = row.Cells[0].Value.ToString();
                //lblitemdescselmiddle.Text = row.Cells[1].Value.ToString();
                lblinputmiddle.Text = "By Product";
                Middlepieces();
                dgvLMS.ClearSelection();
                dgvbreaklegsbacon.ClearSelection();
                dgvbreaklegssows.ClearSelection();
                dgvlegsmain.ClearSelection();
                 dgvlegsmain.ClearSelection();
                dgvLMS.ClearSelection();
                ////dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                dgvbeheading.ClearSelection();
                dgvstrip.ClearSelection();
                //txtsearchmiddleleg.Text = "";
                txtnopmiddles.Focus();

            }
        }

        private void Dgvshouldersmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvshouldersmain.Rows[e.RowIndex];
              Txtsearchlegby.Text = row.Cells[0].Value.ToString();
                if (e.RowIndex < 0)
                {
                    return;
                }

                int index = e.RowIndex;
                dgvshouldersmain.Rows[index].Selected = true;
                //lblinputshoulders.Text = "Main Product";
                //shoulderspieces();
                //dgvshouldersbyproducts.ClearSelection();
                //dgvbreaklegsbacon.ClearSelection();
                //dgvbreaklegssows.ClearSelection();
                //dgvlegsmain.ClearSelection();
                // dgvlegsmain.ClearSelection();
                //dgvtwosides.ClearSelection();
                ////dgvmiddlesbyproducts.ClearSelection();
                //dgvshouldersmain.ClearSelection();
                //dgvshouldersbyproducts.ClearSelection();
                //dgvstrip.ClearSelection();
                //txtsearchshouldersmain.Text = "";
                //txtnopshoulders.Focus();


            }

        }

        private void Dgvshouldersbyproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvbeheading.Rows[e.RowIndex];
                lblcodeselshoulders.Text = row.Cells[0].Value.ToString();
                lblitemdescselshoulders.Text = row.Cells[1].Value.ToString();
                lblinputshoulders.Text = "By Product";
                dgvshouldersmain.ClearSelection();
                txtnopshoulders.Focus();
                dgvbreaklegsbacon.ClearSelection();
                dgvbreaklegssows.ClearSelection();
                dgvlegsmain.ClearSelection();
                 dgvlegsmain.ClearSelection();
                dgvLMS.ClearSelection();
                ////dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                txtsearchshouldersmainby.Text = "";
                dgvstrip.ClearSelection();

            }
        }

        private void Dgvlegsmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            {

                this.dgvlegsmain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                DataGridViewRow row = new DataGridViewRow();
                row = dgvlegsmain.CurrentRow;
                int intRow = new Int32();
                intRow = row.Index;
            

                int index = e.RowIndex;
                dgvlegsmain.Rows[index].Selected = true;

                lblcodeselleg.Text = dgvlegsmain[0, row.Index].Value.ToString();
                lblitemdescselleg.Text = dgvlegsmain[1, row.Index].Value.ToString();
                lblinputmiddleleg.Text = dgvlegsmain[2, row.Index].Value.ToString();
                lbldeboning.Text = dgvlegsmain[3, row.Index].Value.ToString();
                lblbarcodeno.Text = dgvlegsmain[4, row.Index].Value.ToString();
                if (e.RowIndex < 0)
                {
                    return;

                }





                legpieces();
                 dgvlegsmain.ClearSelection();
                dgvbreaklegsbacon.ClearSelection();
                dgvbreaklegssows.ClearSelection();
                //dgvlegsmain.ClearSelection();
                 dgvlegsmain.ClearSelection();
                dgvLMS.ClearSelection();
                //dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                dgvbeheading.ClearSelection();
                dgvstrip.ClearSelection();
                // txtnoplegs.focus();
                txtnoplegs.Focus();
                txtsearchmainleg.Text = "";

            }
        }

        private void  dgvlegsmain_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this. dgvlegsmain.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = "By Product";
                dgvlegsmain.ClearSelection();
                dgvbreaklegsbacon.ClearSelection();
                dgvbreaklegssows.ClearSelection();
                dgvlegsmain.ClearSelection();
                // dgvlegsmain.ClearSelection();
                dgvLMS.ClearSelection();
                //dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                dgvbeheading.ClearSelection();
                dgvstrip.ClearSelection();
                //txtnoplegs.focus();
                txtnoplegs.Focus();
                Txtsearchlegby.Text = "";
            }
        }

        private void ScaleStatus_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click_3(object sender, EventArgs e)
        {

            readweightshouldersdebon();
            txtnetfats.Text = NETWeightshoulders.Text;
            NETWeightmiddles.Text = NETWeightshoulders.Text;
            NETWeightlegs.Text = NETWeightshoulders.Text;
            txtnetwso2.Text = NETWeightshoulders.Text;


        }

        private void Refresh_Click_4(object sender, EventArgs e)
        {
            readweightlegsdebon();

           // NETWeightshoulders.Text = NETWeightlegs.Text;
           // NETWeightmiddles.Text = NETWeightlegs.Text;
           // txtnetfats.Text = NETWeightlegs.Text;
          //  txtnetwso2.Text = NETWeightlegs.Text;


        }

        private bool readweightlegsdebon()
        {
            string port = Properties.Settings.Default.COMPort;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                //readg10.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                //readg10.ReadOnly = true;
                richTextBox2.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");

                richTextBox2.ReadOnly = true;
                //richTextBox1.Text = readweightlegs.Text; do it later
                //txtfatstripping.Text = readweightlegs.Text;
                txtslicingscale.Text = richTextBox2.Text;
                manual.Checked = false;
               // readweightmiddles.Text = readweightlegs.Text; ;
               // readweightshoulders.Text = readweightlegs.Text;
                COMport.Close();
                return true;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                richTextBox2.ReadOnly = false;
                return false;


            }

            //If we managed to open port



        }
        private bool readweightmiddlesdebon()
        {
            string port = Properties.Settings.Default.COMPort;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                readweightmiddles.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                readweightmiddles.ReadOnly = true;
                richTextBox1.Text = readweightmiddles.Text;
                richTextBox2.Text = readweightmiddles.Text;
                txtslicingscale.Text = readweightmiddles.Text;
                readweightshoulders.Text = readweightmiddles.Text;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                readweightmiddles.ReadOnly = false;
                return false;


            }


        }

        private void RefreshMiddles_Click(object sender, EventArgs e)
        {

            readweightmiddlesdebon();
            NETWeightshoulders.Text = NETWeightmiddles.Text;
            txtnetfats.Text = NETWeightmiddles.Text;
            NETWeightlegs.Text = NETWeightmiddles.Text;
            txtnetwso2.Text = NETWeightmiddles.Text;

        }

        private void Legscrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double CTL = 0.0;
            double NOCL = 0.0;
            NOCL = (Convert.ToDouble(legscrate.Text));
            if (NOCL > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTL = (Convert.ToDouble(legscrate.Text) * 1.8);
            NETWeightlegs.Text = (Convert.ToDouble(richTextBox2.Text) - CTL).ToString("#,0.00");
            shoulderscrate.Text = legscrate.Text;
            middlescrate.Text = legscrate.Text;
            cmbnocfats.Text = legscrate.Text;
            cmbcrateweight.Text = legscrate.Text;
            txtnoplegs.Focus();
        }

        private void Txtnoplegs_TextChanged(object sender, EventArgs e)
        {
            //int parsedValue;
            //if (!int.TryParse(txtnoplegs.Text, out parsedValue))
            //{
            //    MessageBox.Show("This is a number only field");
            //    return;
            //}
        }

        private void Readweightlegs_TextChanged(object sender, EventArgs e)
        {
            Double CT = 0.0;
            double NOC = 0.0;
            NOC = (Convert.ToDouble(legscrate.Text));
            if (NOC > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CT = (Convert.ToDouble(legscrate.Text) * 1.8);
            NETWeightlegs.Text = (Convert.ToDouble(richTextBox2.Text) - CT).ToString("#,0.00");
            txtnoplegs.Focus();
        }

        private void Readweightmiddles_TextChanged(object sender, EventArgs e)
        {
            Double CTM = 0.0;
            double NOCM = 0.0;
            NOCM = (Convert.ToDouble(middlescrate.Text));
            if (NOCM > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTM = (Convert.ToDouble(middlescrate.Text) * 1.8);
            NETWeightmiddles.Text = (Convert.ToDouble(readweightmiddles.Text) - CTM).ToString("#,0.00");
            txtnopmiddles.Focus();
        }

        private void Middlescrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double CTM = 0.0;
            double NOCM = 0.0;
            NOCM = (Convert.ToDouble(middlescrate.Text));
            if (NOCM > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTM = (Convert.ToDouble(middlescrate.Text) * 1.8);
            NETWeightmiddles.Text = (Convert.ToDouble(readweightmiddles.Text) - CTM).ToString("#,0.00");
            legscrate.Text = middlescrate.Text;
            shoulderscrate.Text = middlescrate.Text;
            cmbnocfats.Text = middlescrate.Text;
            cmbcrateweight.Text = middlescrate.Text;
            txtnopmiddles.Focus();
        }

        private void Shoulderscrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double CTS = 0.0;
            double NOCS = 0.0;
            NOCS = (Convert.ToDouble(shoulderscrate.Text));
            if (NOCS > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTS = (Convert.ToDouble(shoulderscrate.Text) * 1.8);
            NETWeightshoulders.Text = (Convert.ToDouble(readweightshoulders.Text) - CTS).ToString("#,0.00");

            legscrate.Text = shoulderscrate.Text;
            middlescrate.Text = shoulderscrate.Text;
            cmbnocfats.Text = shoulderscrate.Text;
            cmbcrateweight.Text = shoulderscrate.Text;
            txtnopshoulders.Focus();
        }

        private void Readweightshoulders_TextChanged(object sender, EventArgs e)
        {
            Double CTS = 0.0;
            double NOCS = 0.0;
            NOCS = (Convert.ToDouble(shoulderscrate.Text));
            if (NOCS > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTS = (Convert.ToDouble(shoulderscrate.Text) * 1.8);
            NETWeightshoulders.Text = (Convert.ToDouble(readweightshoulders.Text) - CTS).ToString("#,0.00");
            txtnopshoulders.Focus();


        }

        private void Button2_Click_2(object sender, EventArgs e)
        {
            Savemydatalegs();
        }

        private void Button3_Click_4(object sender, EventArgs e)
        {
           // Savemydatamiddles();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Savemydatashoulders();
        }

        private void DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       // private void Txtnopmiddles_KeyDown(object sender, KeyEventArgs e)
        //{
        //    double NTW = 0.0;
        //    NTW = Convert.ToDouble(NETWeightmiddles.Text);
        //    if (NTW <= 0)
        //    {
        //        MessageBox.Show("NET Weight Should not be less Than Zero");
        //    }
        //    else
        //    {

        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            if (lblitemdescselmiddle.Text == ".")
        //            {
        //                MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            else
        //            {
        //                if (tridupdatemiddles.Text == ".")
        //                {
        //                    Savemydatamiddles();
        //                    clearcontrols();
        //                    //readweightmiddles.Text = "0.0";
        //                    readweightlegs.Text = "0.0";
        //                    readweightmiddles.Text = "0.0";
        //                    readweightshoulders.Text = "0.0";
        //                    txtfatstripping.Text = "0.0";
        //                    richTextBox1.Text = "0.0";
        //                    txtnopmiddles.Text = "";
        //                    middlescrate.Text = "4";

        //                }

        //                else
        //                {
        //                    {
        //                        using (SqlConnection conn = new SqlConnection(_connectionString))
        //                        {

        //                            //
        //                            String q6 = "";// "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemnomiddles.Text + "',[parentinputtype]='" + lbldescmiddles.Text + "',[parentnopieces]='" + lblmiddlepiec.Text + "',[ItemNo]='" + lblcodeselmiddle.Text + "',[outputpname]='" + //lblitemdescselmiddle.Text + "',[outputptype]='" + lblinputmiddle.Text + "',[Nocrates]='" + middlescrate.Text + "',[nopieces]='" + txtnopmiddles.Text + "',[NetWeight]='" + NETWeightmiddles.Text + "'  WHERE  ID='" + tridupdatemiddles.Text + "'";

        //                            using (SqlCommand cmd = new SqlCommand(q6, conn))
        //                            {
        //                                try
        //                                {
        //                                    conn.Open();
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    MessageBox.Show(ex.Message + "Error 12");
        //                                    return;
        //                                }
        //                                try
        //                                {
        //                                    cmd.ExecuteNonQuery();
        //                                    MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                                    tridupdatemiddles.Text = ".";
        //                                    clearcontrols();
        //                                    loadweighedmiddles();
        //                                    Totalnumberofpiecesmiddles();
        //                                    readweightmiddles.Text = "0.0";
        //                                    txtnopmiddles.Text = "";
        //                                    readweightlegs.Text = "0.0";
        //                                    readweightmiddles.Text = "0.0";
        //                                    readweightshoulders.Text = "0.0";
        //                                    txtfatstripping.Text = "0.0";
        //                                    middlescrate.Text = "4";


        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    MessageBox.Show(ex.Message + "Error 10");
        //                                }
        //                            }
        //                            conn.Close();
        //                        }

        //                    }


        //                }



        //            }



        //        }

        //    }
        //}

        private void Txtnoplegs_KeyDown(object sender, KeyEventArgs e)
        {
            double ntw = 0.0;
            ntw = Convert.ToDouble(NETWeightlegs.Text);
            if (ntw <= 0)
            {
                MessageBox.Show("Net Weight Should Not Be Less Than 0");
            }

            else {

                if (e.KeyCode == Keys.Enter)



                {
                    if (lblitemdescselleg.Text == ".")
                    {
                        MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        if (tridupdatelegs.Text == ".")
                        {


                            Savemydatalegs();
                            clearcontrols();
                            richTextBox2.Text = "0.0";
                            txtnoplegs.Text = "";
                            richTextBox2.Text = "0.0";
                            readweightmiddles.Text = "0.0";
                            readweightshoulders.Text = "0.0";
                            txtslicingscale.Text = "0.0";
                            richTextBox1.Text = "0.0";
                            legscrate.Text = "4";




                        }

                        else
                        {
                            {
                                using (SqlConnection conn = new SqlConnection(_connectionString))
                                {

                                    //
                                    String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lbldeboning.Text + "',[parentinputtype]='" + lbldesc.Text + "',[parentnopieces]='" + lbllegpiec.Text + "',[ItemNo]='" + lblcodeselleg.Text + "',[outputpname]='" + lblitemdescselleg.Text + "',[outputptype]='" + lblinputmiddleleg.Text + "',[Nocrates]='" + legscrate.Text + "',[nopieces]='" + txtnoplegs.Text + "',[NetWeight]='" + NETWeightlegs.Text + "' ,BarcodeID='" + lblbarcodeno.Text + "' WHERE  ID='" + tridupdatelegs.Text + "'";

                                    using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                                            MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            tridupdatelegs.Text = ".";
                                            clearcontrols();
                                            loadweighedlegs();
                                            Totalnumberofpieceslegs();
                                            richTextBox2.Text = "0.0";
                                            txtnoplegs.Text = "";
                                            richTextBox2.Text = "0.0";
                                            readweightmiddles.Text = "0.0";
                                            readweightshoulders.Text = "0.0";
                                            txtslicingscale.Text = "0.0";
                                            legscrate.Text = "4.0";

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



                    }


                }

            }
        }



        private void Txtnopshoulders_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Txtnopshoulders_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtnopmiddles_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvbreaklegsbacon.Rows[e.RowIndex];
                lblG10itemno.Text = row.Cells[0].Value.ToString();
                lblG10desc.Text = row.Cells[1].Value.ToString();
                lblbrbarcode.Text = row.Cells[2].Value.ToString();
                Txtsearchlegby.Text = row.Cells[0].Value.ToString();
                lbltype.Text = "BACONER";
                dgvbreaklegssows.ClearSelection();
                dgvbreaklegssows.ClearSelection();
                dgvlegsmain.ClearSelection();
                 dgvlegsmain.ClearSelection();
                dgvLMS.ClearSelection();
                //dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                dgvbeheading.ClearSelection();
                dgvstrip.ClearSelection();
                txtnetwso2.Focus();


            }
        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvbreaklegssows.Rows[e.RowIndex];
                lblG10itemno.Text = row.Cells[0].Value.ToString();
                lblG10desc.Text = row.Cells[1].Value.ToString();
                lblbrbarcode.Text = row.Cells[2].Value.ToString();
                Txtsearchlegby.Text = row.Cells[0].Value.ToString();
                lbltype.Text = "SOW";
                //lblinputmiddleleg.Text = "Main product";
                dgvbreaklegsbacon.ClearSelection();
                dgvbreaklegsbacon.ClearSelection();
                //dgvbreaklegssows.ClearSelection();
                dgvlegsmain.ClearSelection();
                 dgvlegsmain.ClearSelection();
                dgvLMS.ClearSelection();
                //dgvmiddlesbyproducts.ClearSelection();
                dgvshouldersmain.ClearSelection();
                dgvbeheading.ClearSelection();
                dgvstrip.ClearSelection();
                txtnetwso2.Focus();

            }
        }

        private void loadinputBaconer()
        {
            dgvbreaklegsbacon.DataSource = null;
            dgvbreaklegsbacon.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName],[BarcodeID] as Description FROM PRODUCTS WHERE SCALEID='2'  and inputtype='Baconer' order by ID asc";

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

                this.dgvbreaklegsbacon.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvbreaklegsbacon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ////dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ////datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvbreaklegsbacon.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvbreaklegsbacon.Columns[i].Width;
                //    //remove autosizing
                //    dgvbreaklegsbacon.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    dgvbreaklegsbacon.Columns[i].Width = 250;
                //}
            }



        }


        private void loadinputsow()
        {
            dgvbreaklegssows.DataSource = null;
            dgvbreaklegssows.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "SELECT [ItemNo] as Code,[ProductName],[BarcodeID] as Description FROM PRODUCTS WHERE inputtype='sow' and SCALEID='2'   order by ID asc";

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

                this.dgvbreaklegssows.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvbreaklegssows.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ////dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ////datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvbreaklegssows.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvbreaklegssows.Columns[i].Width;
                //    //remove autosizing
                //    dgvbreaklegssows.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    dgvbreaklegssows.Columns[i].Width = 250;
                //}
            }




        }

        private void loadcarcassweigheddata()
        {
            dgvcrcbrk.DataSource = null;
            dgvcrcbrk.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "select ItemNo,outputpname as 'Out Put',CAST(NetWeight AS decimal(18,2)) AS Weight,CAST(nopieces AS decimal(18,2)) AS Crate,parentinputtype as INPUT,ID,[BarcodeID] from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentinputtype in ('baconer','sow' ) order by ID desc";

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

                this.dgvcrcbrk.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvcrcbrk.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                ////dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ////datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvcrcbrk.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw =dgvcrcbrk.Columns[i].Width;
                //    //remove autosizing
                //    dgvcrcbrk.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize
                //    dgvcrcbrk.Columns[i].Width = 250;
                //}
            }


        }


        private void Label44_Click_1(object sender, EventArgs e)
        {

        }

        private void Label22_Click(object sender, EventArgs e)
        {

        }
        private bool readweightwso2()
        {
            string port = Properties.Settings.Default.COMPort;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                richTextBox1.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                richTextBox1.ReadOnly = true;

                txtslicingscale.Text = richTextBox1.Text;
                richTextBox2.Text = richTextBox1.Text;
                readweightmiddles.Text = richTextBox1.Text;
                readweightshoulders.Text = richTextBox1.Text;

                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                richTextBox1.ReadOnly = false;
                return false;



            }


        }

        private void Txtnetwso2_KeyDown(object sender, KeyEventArgs e)
        {
            double NTW = 0;
            NTW = Convert.ToDouble(txtnetwso2.Text);

            if (e.KeyCode == Keys.Enter)
            { if (NTW <= 0)
                {
                    MessageBox.Show("Net Weight Should not be less than 0");
                }
                else
                {

                    if (lbldgvcrcbrk.Text == ".")
                    {
                        savemydatabreakings();
                        clearcontrols();
                        loadcarcassweigheddata();
                        richTextBox2.Text = "0.0";
                        readweightmiddles.Text = "0.0";
                        readweightshoulders.Text = "0.0";
                        txtslicingscale.Text = "0.0";
                        richTextBox1.Text = "0.0";
                        cmbcrateweight.Text = "4";



                    }

                    else
                    {
                        {
                            using (SqlConnection conn = new SqlConnection(_connectionString))
                            {

                                //
                                String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemno.Text + "',[parentinputtype]='" + lbltype.Text + "',[parentnopieces]='" + lblG10desc.Text + "',[ItemNo]='" + lblG10itemno.Text + "',[outputpname]='" + lblG10desc.Text + "',[outputptype]='" + lblG10desc.Text + "',[Nocrates]='" + richTextBox1.Text + "',[nopieces]='" + cmbcrateweight.Text + "',[NetWeight]='" + txtnetwso2.Text + "'  WHERE  ID='" + lbldgvcrcbrk.Text + "'";

                                using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                                        MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        lbldgvcrcbrk.Text = ".";
                                        clearcontrols();
                                        loadcarcassweigheddata();
                                        cmbcrateweight.Text = "4";
                                        richTextBox1.Text = "0.0";

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


                }



            }
        }

        private void Txtwscl2_TextChanged(object sender, EventArgs e)
        {

            // NETWeightlegs.Text = (Convert.ToDouble(readweightlegs.Text) - CT).ToString("#,0.00");
        }

        private void Txtwscl2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Cmbcrateweight_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double CTL = 0.0;
            double NOCL = 0.0;
            NOCL = (Convert.ToDouble(cmbcrateweight.Text));
           //if (NOCL > 4)
           // {

           //     MessageBox.Show("No OF crates Can Not Be More Than 4");
           // }

            CTL = (Convert.ToDouble(cmbcrateweight.Text));
            txtnetwso2.Text = (Convert.ToDouble(richTextBox1.Text).ToString("#,0.00"));
            shoulderscrate.Text = cmbcrateweight.Text;
            middlescrate.Text = cmbcrateweight.Text;
            cmbnocfats.Text = cmbcrateweight.Text;
            legscrate.Text = cmbcrateweight.Text;
            txtnetwso2.Focus();

        }

        private void Readweightlegs_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Readg10_TextChanged(object sender, EventArgs e)
        {
            Double CTL = 0.0;
            double NOCL = 0.0;
            NOCL = (Convert.ToDouble(cmbcrateweight.Text));
            if (NOCL > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTL = (Convert.ToDouble(cmbcrateweight.Text) * 1.8);
            txtnetwso2.Text = (Convert.ToDouble(richTextBox1.Text) - CTL).ToString("#,0.00");
            shoulderscrate.Text = cmbcrateweight.Text;
            middlescrate.Text = cmbcrateweight.Text;
            cmbnocfats.Text = cmbcrateweight.Text;
            legscrate.Text = cmbcrateweight.Text;
            txtnetwso2.Focus();

        }

        private void Readg10_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Readweightlegs_TextChanged_2(object sender, EventArgs e)
        {
            Double CTL = 0.0;
            double NOCL = 0.0;
            NOCL = (Convert.ToDouble(legscrate.Text));
            if (NOCL > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTL = (Convert.ToDouble(legscrate.Text) * 1.8);
            NETWeightlegs.Text = (Convert.ToDouble(richTextBox2.Text) - CTL).ToString("#,0.00");
            txtnoplegs.Focus();
        }

        private void Txtnetwso2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgvlegsdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double CTL = 0.0;
            if (e.RowIndex >= 0)
            {
                this.dgvlegsdata.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                DataGridViewRow row = this.dgvlegsdata.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = row.Cells[2].Value.ToString();
                NETWeightlegs.Text = row.Cells[5].Value.ToString();
                legscrate.Text = row.Cells[3].Value.ToString();
                tridupdatelegs.Text = row.Cells[7].Value.ToString();
                lbldeboning.Text = row.Cells[8].Value.ToString();
                lblbarcodeno.Text = row.Cells[6].Value.ToString();
                CTL = (Convert.ToDouble(legscrate.Text) * 1.8);
                richTextBox2.Text = (Convert.ToDouble(NETWeightlegs.Text) + CTL).ToString("#,0.00");

                // dgvlegsmain.ClearSelection();

            }
        }

        private void Dgvmiddlesdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            double CTM = 0.0;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvshoulderdeboning.Rows[e.RowIndex];

             

                CTM = (Convert.ToDouble(middlescrate.Text) * 1.8);
                readweightmiddles.Text = (Convert.ToDouble(NETWeightmiddles.Text) + CTM).ToString("#,0.00");

                // dgvlegsmain.ClearSelection();


            }
        }

        private void Dgvshouldersdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // double CTS = 0.0;
            if (e.RowIndex >= 0)
            {
               // DataGridViewRow row = this.dgvshouldersdata.Rows[e.RowIndex];



            }
        }

        private void Lbltotalpieceswlegs_Click(object sender, EventArgs e)
        {

        }

        private void Lblinputshoulders_Click(object sender, EventArgs e)
        {

        }

        private void Lbltotalpieceswmiddles_Click(object sender, EventArgs e)
        {

        }

        private void Lbllegpiec_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            double CTL = 0.0;
            CTL = (Convert.ToDouble(cmbcrateweight.Text) * 1.8);
            DataGridViewRow row = this.dgvcrcbrk.Rows[e.RowIndex];
            lblG10itemno.Text = row.Cells[0].Value.ToString();
            lblG10desc.Text = row.Cells[1].Value.ToString();
            lbltype.Text = row.Cells[4].Value.ToString();
            lbldgvcrcbrk.Text = row.Cells[5].Value.ToString();
            lblbrbarcode.Text = row.Cells[6].Value.ToString();
            txtnetwso2.Text = row.Cells[2].Value.ToString();
            cmbcrateweight.Text = row.Cells[3].Value.ToString();
          //  readg10.Text = (Convert.ToDouble(txtnetwso2.Text) + CTL).ToString("#,0.00");



            dgvbreaklegssows.ClearSelection();
            dgvbreaklegssows.ClearSelection();












        }

        private void Txtfatstripping_TextChanged(object sender, EventArgs e)
        {
            Double CTS = 0.0;
            double NOCS = 0.0;
            NOCS = (Convert.ToDouble(cmbnocfats.Text));
            if (NOCS > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTS = (Convert.ToDouble(cmbnocfats.Text) * 1.8);
            txtnetfats.Text = (Convert.ToDouble(txtslicingscale.Text) - CTS).ToString("#,0.00");


            txtnetfats.Focus();
        }

        private void Cmbnocfats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Double CTS = 0.0;
            double NOCS = 0.0;
            NOCS = (Convert.ToDouble(cmbnocfats.Text));
            if (NOCS > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTS = (Convert.ToDouble(cmbnocfats.Text) * 1.8);
            txtnetfats.Text = (Convert.ToDouble(txtslicingscale.Text) - CTS).ToString("#,0.00");

          
        }

        private void Btnfatstrip_Click(object sender, EventArgs e)
        {
            //readweightwso2();
            //readweightlegsdebon();
            //readweightmiddlesdebon();
            //readweightshouldersdebon();
            //  readweightstripping();
            // readtwosides();
            readweightlegsdebon();
           




        }
        private void calcs()
        {



        }
        private bool readtwosides()
        {

            string port = Properties.Settings.Default.COMPort;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                txtwscl1.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                txtwscl1.ReadOnly = true;
             


                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                txtslicingscale.ReadOnly = false;
                return false;


            }





        }

        private void Dgvstrip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvstrip.Rows[e.RowIndex];
                Txtsearchlegby.Text = row.Cells[0].Value.ToString();
                if (e.RowIndex < 0)
                {
                    return;
                }

            } 
            int index = e.RowIndex;
                dgvshouldersmain.Rows[index].Selected = true;
                //lblinputshoulders.Text = "Main Product";



                // Txtsearchlegby.Text = row.Cells[0].Value.ToString();
                //DataGridViewRow row = this.dgvstrip.Rows[e.RowIndex];
                //stripname.Text = row.Cells[1].Value.ToString();
                //lblstripcode.Text = row.Cells[0].Value.ToString();
                //lblslice.Text= row.Cells[2].Value.ToString();
                //slicetype.Text = row.Cells[3].Value.ToString();
                //stripbarcode.Text = row.Cells[4].Value.ToString();
                ////lblslice.Text = row.Cells[3].Value.ToString();
                ////lblfatsripping.Text = "Main Product";
                ////dgvshouldersbyproducts.ClearSelection();
                //txtnetfats.Focus();
                //dgvbreaklegsbacon.ClearSelection();
                //dgvbreaklegssows.ClearSelection();
                //dgvlegsmain.ClearSelection();
                // dgvlegsmain.ClearSelection();
                //dgvtwosides.ClearSelection();
                ////dgvmiddlesbyproducts.ClearSelection();
                //dgvshouldersmain.ClearSelection();
                //dgvbeheading.ClearSelection();

            }


            private void Txtnetfats_KeyDown(object sender, KeyEventArgs e)
        {
            double NTW = 0.0;
            NTW = Convert.ToDouble(txtnetfats.Text);
            if (NTW <= 0)
            {
                MessageBox.Show("NET Weight Should not be less Than ZERO");
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (lblstripcode.Text == ".")
                    {
                        MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        if (lblidstrip.Text == ".")
                        {


                            saveslicing();

                            loadsavedslices();
                                clearcontrols(); 
                            richTextBox2.Text = "0.0";
                            txtnoplegs.Text = "";
                            richTextBox2.Text = "0.0";
                            readweightmiddles.Text = "0.0";
                            readweightshoulders.Text = "0.0";
                            txtslicingscale.Text = "0.0";
                            richTextBox1.Text = "0.0";
                            cmbnocfats.Text = "4";




                        }

                        else
                        {
                            {
                                using (SqlConnection conn = new SqlConnection(_connectionString))
                                {

                                    //
                                    String q6 = "UPDATE [dbo].[ButcheryData] SET [ItemNo]='" + lblstripcode.Text + "',[outputpname]='" + lblstripname.Text + "',[Nocrates]='" + txtslicingscale.Text + "',[NetWeight]='" + txtnetfats.Text + "'  WHERE  ID='" + lblidstrip.Text + "'";

                                    using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                                            MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            lblidstrip.Text = ".";
                                            clearcontrols();
                                            loadsavedslices();
                                            txtslicingscale.Text = "0.0";
                                            richTextBox2.Text = "0.0";
                                            readweightmiddles.Text = "0.0";
                                            readweightshoulders.Text = "0.0";
                                            txtslicingscale.Text = "0.0";
                                            cmbnocfats.Text = "4";


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



                    }

                }

            }

        }

        private void loadsavedslicessum()
        {
            dgvsumslices.DataSource = null;
            dgvsumslices.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = " SELECT Itemno, outputpname AS 'Name',outputptype AS Type,sum(CAST(nopieces AS decimal(18, 2))) AS 'Pieces',sum(CAST(NetWeight AS decimal(18, 2))) as Weight FROM ButcheryData WHERE cast (butchtime as date)=cast(getdate() as date) and parentinputtype='Slicing'  group by outputpname,Itemno,outputptype";

                //  String q = "select ItemNo,outputpname AS Product,outputptype as Type,CAST(Nocrates AS decimal(18,2)) AS Crates,CAST(nopieces AS decimal(18,2)) AS Pieces,CAST(NetWeight AS decimal(18,2)) AS Weight,ID from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentinputtype='Slicing' order by ID desc";

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

                this.dgvsumslices.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvsumslices.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //  dgvlegsdata.Columns[1].Width = 250;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvlegsdata.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvlegsdata.Columns[i].Width;
                //    //remove autosizing
                //    dgvlegsdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize

                //}
            }

        }

        private void loadsavedslices()
        {
            dgvslices.DataSource = null;
            dgvslices.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "select ItemNo,outputpname AS Product,outputptype as Type,CAST(Nocrates AS decimal(18,2)) AS Crates,CAST(nopieces AS decimal(18,2)) AS Pieces,CAST(NetWeight AS decimal(18,2)) AS Weight,ID from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentinputtype='Slicing' order by ID desc";

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

                this.dgvslices.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvslices.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //  dgvlegsdata.Columns[1].Width = 250;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvlegsdata.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvlegsdata.Columns[i].Width;
                //    //remove autosizing
                //    dgvlegsdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize

                //}
            }

        }

        
    private void dgvwdslices(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvsumslices.Rows[e.RowIndex];


                lblstripcode.Text = row.Cells[0].Value.ToString();
                lblstripname.Text = row.Cells[1].Value.ToString();
                txtslicingscale.Text = row.Cells[3].Value.ToString();
                txtnetfats.Text = row.Cells[5].Value.ToString();
                lblidstrip.Text = row.Cells[6].Value.ToString();



                // dgvlegsmain.ClearSelection();

            }
        }

        private void Txtnopshoulders_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void Dgvloadexcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void Button2_Click_3(object sender, EventArgs e)
        {
            string fname = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Excel File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            if (fdlg.ShowDialog() == DialogResult.OK)
            if (fdlg.ShowDialog() == DialogResult.OK)
            if (fdlg.ShowDialog() == DialogResult.OK)
                        {
                fname = fdlg.FileName;
            }

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fname);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            // dt.Column = colCount;  
            dgvloadexcel.ColumnCount = colCount;
            dgvloadexcel.RowCount = rowCount;
           // int maxnumber = 1000;
          
            // progressTimer1.Enabled = true;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {


                    //write the value to the Grid  
                 
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        dgvloadexcel.Rows[i - 1].Cells[j - 1].Value = xlRange.Cells[i, j].Value2.ToString();
                    }
                  


                    // Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");  
                    // dgvloadexcel.Rows[i].Cells[8].back = Color.Red;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = rowCount;
                    for (int x = 0; x <= i - 1; x++)
                    {
                        Application.DoEvents();
                        // dgvloadexcel.Rows.Add(new string[] { Convert.ToString(x) });
                        // Thread.Sleep(50);
                        progressBar1.BeginInvoke(new Action(() => progressBar1.Value = x));
                        progressBar1.CreateGraphics().DrawString(x.ToString()   + "", new Font("Arial",
                        (float)12.25, FontStyle.Regular),
                        Brushes.Red, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));


                    }

                    //add useful things here!     
                }
            }
           

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            //progressBar1.cust = "UPLOAD COMPLETE";

            dgvloadexcel.ClearSelection();
            dgvloadexcel.MultiSelect= true;
           
           // dgvloadexcel.SelectedColumns[0].Selected = true;
           // dgvloadexcel.Rows[1].Selected = true;






        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void clearcontrols()
        {
            lblbrbarcode.Text = ".";
           // Txtsearchlegby.Text = "";
            txtsearchmainleg.Text ="";
            lblG10itemno.Text = ".";
            lblG10desc.Text = ".";
            lbltype.Text = ".";
            lblitemdescselleg.Text = ".";
            lblcodeselleg.Text = ".";
            lblinputmiddleleg.Text = ".";
            //lblitemdescselmiddle.Text = ".";
            lblcodeselmiddle.Text = ".";
            lblinputmiddle.Text = ".";
            lblitemdescselshoulders.Text = ".";
            lblcodeselshoulders.Text = ".";
            lblinputshoulders.Text = ".";
            lblstripname.Text = ".";
            lblstripcode.Text = ".";
            shoulderscrate.Text = "4";
            cmbnocfats.Text = "4";
            legscrate.Text = "4";
            middlescrate.Text = "4";
            cmbcrateweight.Text = "4";
            lblbarcodeno.Text = "";
            lbldeboning.Text = "";
            txtnetfats.Text = "";
            slcingnop.Text = "";

        }
        private void Button3_Click_5(object sender, EventArgs e)
        {


            dgvloadexcel.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in dgvloadexcel.Rows)
            {
                

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = " SET ANSI_WARNINGS OFF INSERT INTO [dbo].[sliceddata](ItemNoinput,descinput,pcsinput,Weightinput,ItemNooutput,descoutput,pcsoutput,weighoutput,variances,ButchTime,UserID)" +
                              "VALUES (@ItemNoinput,@descinput,@pcsinput,@Weightinput,@ItemNooutput,@descoutput,@pcsoutput,@weighoutput,@variances,@ButchTime,@UserID)";

                    using (SqlCommand cmd = new SqlCommand(q5, conn))
                    {
                      //  if (row.Cells[i].Value == null) row.Cells[i].Value = "";

                        if (row.Cells[0].Value == null)
                        {
                            row.Cells[0].Value = DBNull.Value;
                        }
                      
                        if (row.Cells[1].Value == null)
                        {
                            row.Cells[1].Value = DBNull.Value;
                        }
                      
                        if (row.Cells[2].Value == null)
                        {
                            row.Cells[2].Value = DBNull.Value;
                        }
                      
                        if (row.Cells[3].Value == null)
                        {
                            row.Cells[3].Value = DBNull.Value;
                        }
                      
                        if (row.Cells[4].Value == null)
                        {
                            row.Cells[4].Value = DBNull.Value;
                        }
                   
                        if (row.Cells[5].Value == null)
                        {
                            row.Cells[5].Value = DBNull.Value;
                        }
                      
                        if (row.Cells[6].Value == null)
                        {
                            row.Cells[6].Value = DBNull.Value;
                        }
                      
                        if (row.Cells[7].Value == null)
                        {
                            row.Cells[7].Value = DBNull.Value;
                        }
                     
                        if (row.Cells[8].Value == null)
                        {
                            row.Cells[8].Value = DBNull.Value;
                        }
                      





                        cmd.Parameters.AddWithValue("@ItemNoinput", SqlDbType.NVarChar).Value = row.Cells[0].Value;
                        cmd.Parameters.AddWithValue("@descinput", SqlDbType.NVarChar).Value = row.Cells[1].Value;
                        cmd.Parameters.AddWithValue("@pcsinput", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                        cmd.Parameters.AddWithValue("@Weightinput", SqlDbType.NVarChar).Value = row.Cells[3].Value;
                        cmd.Parameters.AddWithValue("@ItemNooutput", SqlDbType.NVarChar).Value = row.Cells[4].Value;
                        cmd.Parameters.AddWithValue("@descoutput", SqlDbType.NVarChar).Value = row.Cells[5].Value;
                        cmd.Parameters.AddWithValue("@pcsoutput", SqlDbType.NVarChar).Value = row.Cells[6].Value;
                        cmd.Parameters.AddWithValue("@weighoutput", SqlDbType.NVarChar).Value = row.Cells[7].Value;
                        cmd.Parameters.AddWithValue("@variances", SqlDbType.NVarChar).Value = row.Cells[8].Value;
                        cmd.Parameters.AddWithValue("@ButchTime", SqlDbType.DateTime).Value =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        cmd.Parameters.AddWithValue("@UserID", SqlDbType.NVarChar).Value = User.Text;
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
                            // Bacons();
                            //sows();

                            
                            // loadweighedshoulders();
                            // Totalnumberofpiecesshoulders();
                            //readg10.Text = "0.0";
                            // txtnetwso2.Text = "0.0";


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }

                    conn.Close();
                   
                }

            }

            MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Txtnetfats_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgvloadexcel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void Txtwscl1_TextChanged(object sender, EventArgs e)
        {
            //double NOCL = 0.0;
            //NOCL = (Convert.ToDouble(cmbtare.Text));
            //if (txtwscl1.Text == "") { txtwscl1.Text = "0.0"; }
            //txtNetwbacos.Text = (Convert.ToDouble(txtwscl1.Text) - NOCL).ToString("#,0.00");

            txtNetwbacos.Text = txtwscl1.Text;

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void SlaughterDate_ValueChanged(object sender, EventArgs e)
        {
            Totalreceivedtoday();
        }

        private void Txtsearchmainleg_TextChanged(object sender, EventArgs e)
        {
            (dgvlegsmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Barcode LIKE '%{0}%'", txtsearchmainleg.Text);
            dgvlegsmain.ClearSelection();
            dgvlegsmain.MultiSelect = true;
            this.dgvlegsmain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvlegsmain.Rows[0].Selected = true;
            this.dgvlegsmain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewRow row = new DataGridViewRow();
            row = dgvlegsmain.CurrentRow;
            int intRow = new Int32();
            intRow = row.Index;
            lblcodeselleg.Text = dgvlegsmain[0, row.Index].Value.ToString();
            lblitemdescselleg.Text = dgvlegsmain[1, row.Index].Value.ToString();
            lblinputmiddleleg.Text = dgvlegsmain[2, row.Index].Value.ToString();
            lbldeboning.Text = dgvlegsmain[3, row.Index].Value.ToString();
            lblbarcodeno.Text = dgvlegsmain[4, row.Index].Value.ToString();
            this.dgvlegsmain.MultiSelect = false;



            // (dgvmiddlesmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("BarcodeID LIKE '%{0}%'", txtsearchmainleg.Text);
            // (dgvshouldersmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("BarcodeID LIKE '%{0}%'", txtsearchmainleg.Text);

            // (dgvlegsmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '='", txtsearchmainleg.Text);
            //// (dgvmiddlesmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchmainleg.Text);


            // if (dgvmiddlesmain != null || dgvmiddlesmain.Rows.Count != 0)
            // {
            //     button4.PerformClick();
            //     txtsearchmainleg.Text = "";


            // }
            //(dgvlegsmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Description LIKE '%{0}%'", txtsearchmainleg.Text);
        }

        private void Txtsearchlegby_TextChanged(object sender, EventArgs e)
        {
            ( dgvlegsmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", Txtsearchlegby.Text);
        }

        private void Txtsearchmiddlemain_TextChanged(object sender, EventArgs e)
        {
           // (dgvmiddlesmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchmiddlemain.Text);
        }

        private void Txtsearchmiddleleg_TextChanged(object sender, EventArgs e)
        {
            //dgvmiddlesbyproducts.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchmiddleleg.Text);
        }

        private void Txtsearchshouldersmain_TextChanged(object sender, EventArgs e)
        {
            (dgvshouldersmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchshouldersmain.Text);
        }

        private void Txtsearchshouldersmainby_TextChanged(object sender, EventArgs e)
        {
            (dgvbeheading.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchshouldersmainby.Text);
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TotalTotal();
            loadweighedlegs();
         //   loadweighedmiddles();
            loadweighedshoulders();
            Totalnumberofpieceslegs();
            Totalnumberofpiecesmiddles();
            Totalnumberofpiecesshoulders();
            loadcarcassweigheddata();
            loadstrips();
            loadbutchleg();
            loadbutchmiddle();
            loadbutchshoulder();
            
            loadsavedslices();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dgvLMS != null || dgvLMS.Rows.Count != 0)
            {




                tabControl1.SelectedTab = middles;
            }
              
        }

        private void lblitemdescselleg_Click(object sender, EventArgs e)
        {

        }

        private void lblcodeselleg_Click(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void lblpiecesperpleg_Click(object sender, EventArgs e)
        {

        }

        private void lbltotalpieceswmiddles_Click_1(object sender, EventArgs e)
        {

        }

        private void lbltotalpieceswshoulders_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {  if (txtwscl1.Text == ""|| txtwscl1.Text == "0")
            {
                MessageBox.Show("WEIGHT CAN NOT BE BLANK OR ZERO");
             }
            else
                
            if (rdbaconers.Checked == true)

            {

                {
                    txtwscl1.Enabled = true;
                    string nopieces;
                    nopieces = "0";
                    string bcd;
                    bcd = "1616184752865";
                    string bcl;
                    bcl = "G1030";
                    string input;
                    input = "Input";

                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {

                        //
                        String q5 = " set ANSI_WARNINGS OFF  INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID],[BarcodeID])" +
                                                            "VALUES ('" + bcl + "','"
                                                              + lblcarcasssides.Text + "','"
                                                              + nopieces + "','"
                                                              + bcl + "','"
                                                              + lblcarcasssides.Text + "','"
                                                              + lblcarcasssides.Text + "','"
                                                              + cmbtare.Text + "','"
                                                              + nopieces + "','"
                                                              + txtNetwbacos.Text.Replace(",", ".") + "','"
                                                              + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                               + User.Text + "','"
                                                               + bcd + "')";




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
                              
                                // Bacons();
                                // sows();

                                MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // loadweighedlegs();
                                // Totalnumberofpieceslegs();
                                loadtwosidesC();
                                sidesweight();
                                Totalsidesbacon();
                                Totalsidessows();

                                txtwscl1.Text = "";









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
            if (rdsows.Checked == true)

            {

                {
                    txtwscl1.Enabled = true;
                    string nopieces;
                    nopieces = "0";
                    string bcd;
                    bcd = "3635102165288";
                    string bcl;
                    bcl = "G1031";
                    string input;
                    input = "Input";

                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {

                        //
                        String q5 = " set ANSI_WARNINGS OFF  INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID],[BarcodeID])" +
                                                            "VALUES ('" + bcl + "','"
                                                              + lblcarcasssides.Text + "','"
                                                              + nopieces + "','"
                                                              + bcl + "','"
                                                              + lblcarcasssides.Text + "','"
                                                              + lblcarcasssides.Text + "','"
                                                              + cmbtare.Text + "','"
                                                              + nopieces + "','"
                                                              + txtwscl1.Text.Replace(",", ".") + "','"
                                                              + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"
                                                               + User.Text + "','"
                                                               + bcd + "')";




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
                               
                                // Bacons();
                                // sows();

                                MessageBox.Show("Your Data Saved Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // loadweighedlegs();
                                // Totalnumberofpieceslegs();
                                loadtwosides();
                                sidesweightS();
                                txtwscl1.Text = "";









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

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void lblcarcasssides_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbldgvcrcbrk_Click(object sender, EventArgs e)
        {

        }

        private void btnsavepbrck_Click(object sender, EventArgs e)
        {

        }

        private void readg10_TextChanged_1(object sender, EventArgs e)
        {
            txtnetwso2.Text = richTextBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double NTW = 0;
            NTW = Convert.ToDouble(txtnetwso2.Text);

           
            {
                if (NTW <= 0)
                {
                    MessageBox.Show("Net Weight Should not be less than 0");
                }
                else
                {

                    if (lbldgvcrcbrk.Text == ".")
                    {
                        savemydatabreakings();
                        clearcontrols();
                        loadcarcassweigheddata();
                        richTextBox2.Text = "0.0";
                        readweightmiddles.Text = "0.0";
                        readweightshoulders.Text = "0.0";
                        txtslicingscale.Text = "0.0";
                        richTextBox1.Text = "0.0";
                        cmbcrateweight.Text = "4";



                    }

                    else
                    {
                        {
                            using (SqlConnection conn = new SqlConnection(_connectionString))
                            {

                                //
                                String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemno.Text + "',[parentinputtype]='" + lbltype.Text + "',[parentnopieces]='" + lblG10desc.Text + "',[ItemNo]='" + lblG10itemno.Text + "',[outputpname]='" + lblG10desc.Text + "',[outputptype]='" + lblG10desc.Text + "',[Nocrates]='" + richTextBox1.Text + "',[nopieces]='" + cmbcrateweight.Text + "',[NetWeight]='" + txtnetwso2.Text + "',[BarcodeID]='" + lblbrbarcode.Text + "' WHERE  ID='" + lbldgvcrcbrk.Text + "'";

                                using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                                        MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        lbldgvcrcbrk.Text = ".";
                                        clearcontrols();
                                        loadcarcassweigheddata();
                                        cmbcrateweight.Text = "4";
                                        richTextBox1.Text = "0.0";

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


                }



            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        { 
            txtnetwso2.Text = (Convert.ToDouble(richTextBox1.Text)-7.2).ToString("#,0.00");
        }

        private void pbreaking_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double ntw = 0.0;
            ntw = Convert.ToDouble(NETWeightlegs.Text);
            //if (ntw <= 0)
            //{
            //    MessageBox.Show("Net Weight Should Not Be Less Than 0");
            //}

            //else
            {

               



                {
                    if (lblitemdescselleg.Text == ".")
                    {
                        MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                   else  if (lbldeboning.Text == "Main Product" && txtnoplegs.Text == "")
                    {
                        MessageBox.Show("No of pieces should not be 0");

                    }


                    else
                    {
                        if (tridupdatelegs.Text == ".")
                        {


                            Savemydatalegs();
                            richTextBox2.ReadOnly = true;
                            loadbeheaded();
                            // //
                            clearcontrols();
                            richTextBox2.Text = "0.0";
                            txtnoplegs.Text = "";
                            richTextBox2.Text = "0.0";
                            readweightmiddles.Text = "0.0";
                            readweightshoulders.Text = "0.0";
                            txtslicingscale.Text = "0.0";
                            richTextBox1.Text = "0.0";
                            legscrate.Text = "4";




                        }

                        else
                        {

                            if (lbldeboning.Text == "Main Product" && txtnoplegs.Text == "")
                            {
                                MessageBox.Show("No of pieces should not be 0");

                            }
                            if (txtnoplegs.Text == "") { txtnoplegs.Text = "0.0"; }
                            {
                                using (SqlConnection conn = new SqlConnection(_connectionString))
                                {

                                    //
                                    String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lbldeboning.Text + "',[parentinputtype]='" + lbldesc.Text + "',[parentnopieces]='" + lbllegpiec.Text + "',[ItemNo]='" + lblcodeselleg.Text + "',[outputpname]='" + lblitemdescselleg.Text + "',[outputptype]='" + lblinputmiddleleg.Text + "',[Nocrates]='" + legscrate.Text + "',[nopieces]='" + txtnoplegs.Text + "',[NetWeight]='" + NETWeightlegs.Text.Replace(",","") + "',[BarcodeID]='" + lblbarcodeno.Text + "'  WHERE  ID='" + tridupdatelegs.Text + "'";

                                    using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                                            MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            tridupdatelegs.Text = ".";
                                           
                                            clearcontrols();

                                            loadweighedlegs();
                                            Totalnumberofpieceslegs();
                                            Totalnumberofpiecesmiddles();
                                            Totalnumberofpiecesshoulders();
                                            loadbeheaded();
                                            richTextBox2.ReadOnly = true;
                                            richTextBox2.Text = "0.0";
                                            txtnoplegs.Text = "";
                                            richTextBox2.Text = "0.0";
                                            readweightmiddles.Text = "0.0";
                                            readweightshoulders.Text = "0.0";
                                            txtslicingscale.Text = "0.0";
                                            legscrate.Text = "4.0";

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



                    }


                }

            }
        }

        private void lbldeboning_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void middles_Click(object sender, EventArgs e)
        {

        }

        private void SlaughterDateTo_ValueChanged(object sender, EventArgs e)
        {
            totalslaughtered();
            loadthreeparts();
            loadtwoparts();
            loadbutchleg();
            loadbutchmiddle();
            loadbutchshoulder();
            loadrinds();
            loadslices();

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            Double CTL = 0.0;
            double NOCL = 0.0;
            NOCL = (Convert.ToDouble(legscrate.Text));
            if (NOCL > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTL = (Convert.ToDouble(legscrate.Text) * 1.8);
            NETWeightlegs.Text = (Convert.ToDouble(richTextBox2.Text) - CTL).ToString("#,0.00");
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void txtcumbcn_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void NETWeightlegs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtactivebacons_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvthreesides_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rdsows_CheckedChanged(object sender, EventArgs e)
        { 
            if (rdsows.Checked==true) { rdbaconers.Checked = false; }
           
            // rdsows.Checked = true;
           
        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void lblidstrip_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double NTW = 0.0;
            NTW = Convert.ToDouble(txtnetfats.Text);
            if (NTW <= 0)
            {
                MessageBox.Show("NET Weight Should not be less Than ZERO");
            }
            else
            {
              
                {
                    if (lblstripcode.Text == ".")
                    {
                        MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        if (lblidstrip.Text == ".")
                        {


                            saveslicing();
                            loadsavedslicessum();

                            loadsavedslices();
                            clearcontrols();
                            richTextBox2.Text = "0.0";
                            txtnoplegs.Text = "";
                            richTextBox2.Text = "0.0";
                            readweightmiddles.Text = "0.0";
                            readweightshoulders.Text = "0.0";
                            txtslicingscale.Text = "0.0";
                            richTextBox1.Text = "0.0";
                            cmbnocfats.Text = "4";




                        }

                        else
                        {
                            {
                                using (SqlConnection conn = new SqlConnection(_connectionString))
                                {

                                    //
                                    String q6 = "UPDATE [dbo].[ButcheryData] SET [ItemNo]='" + lblstripcode.Text + "',[outputpname]='" + lblstripname.Text + "',[Nocrates]='" + txtslicingscale.Text + "',[NetWeight]='" + txtnetfats.Text + "'  WHERE  ID='" + lblidstrip.Text + "'";

                                    using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                                            MessageBox.Show("Your Data Updated Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            lblidstrip.Text = ".";
                                            clearcontrols();
                                            loadsavedslices();
                                            txtslicingscale.Text = "0.0";
                                            richTextBox2.Text = "0.0";
                                            readweightmiddles.Text = "0.0";
                                            readweightshoulders.Text = "0.0";
                                            txtslicingscale.Text = "0.0";
                                            cmbnocfats.Text = "4";


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



                    }

                }

            }
        }

        private void txtslicingscale_TextChanged(object sender, EventArgs e)
        {
            Double CTL = 0.0;
            double NOCL = 0.0;
            NOCL = (Convert.ToDouble(cmbnocfats.Text));
            if (NOCL > 4)
            {

                MessageBox.Show("No OF crates Can Not Be More Than 4");
            }

            CTL = (Convert.ToDouble(cmbnocfats.Text) * 1.8);
            txtnetfats.Text = (Convert.ToDouble(txtslicingscale.Text) - CTL).ToString("#,0.00");
        }

        private void txtsearchslicingno_TextChanged(object sender, EventArgs e)
        {
            (dgvstrip.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchslicingno.Text);
            (dgvstripout.DataSource as DataTable).DefaultView.RowFilter = string.Format("Code LIKE '%{0}%'", txtsearchslicingno.Text);
        }

        private void dtpbheading_ValueChanged(object sender, EventArgs e)
        {
            //loadbeheaded();
            dgvbeheading.DataSource = null;
            dgvbeheading.Refresh();
            DateTime endDate = Convert.ToDateTime(this.dtpbheading.Text);



            endDate = endDate.AddDays(1);
            string wyz;
            dtpbheading.Value.Date.ToString("dd/MMM/yyyy");
            wyz = dtpbheading.Value.Date.ToString("dd/MMM/yyyy");
            //   dgvcumulatives.DataSource = null;
            //  dgvcumulatives.Refresh();




            //dgvlegsmain.Columns[1].Width = 108;
            //dgvlegsmain.Columns[2].Width = 108;
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

                String q = "  SELECT Itemno, outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18, 2))) AS 'CRATES',sum(CAST(NetWeight AS decimal(18, 2))) as Weight  from ButcheryData where parentinputtype in ('Beheading sow', 'Beheading Pig') and butchtime>='" + wyz+ "' and butchtime<='" + endDate.ToString("dd/MMM/yyyy") + "'   GROUP BY outputpname,Itemno,outputptype  ";

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

                this.dgvbeheading.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dgvbeheading.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dgvbeheading.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dgvbeheading.Rows[i].Cells[4].Value);






                }
                // add the total row

                string[] totalrow = new string[] { "", "Two Sides", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };


                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);

                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // dgvbeheading.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //  dgvlegsdata.Columns[1].Width = 250;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                //for (int i = 1; i <= dgvlegsdata.Columns.Count - 1; i++)
                //{
                //    //store autosized widths
                //    int colw = dgvlegsdata.Columns[i].Width;
                //    //remove autosizing
                //    dgvlegsdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //    //set width to calculated by autosize

                //}
            }
        }

        private void txtsearchbyname_TextChanged(object sender, EventArgs e)
        {
            (dgvlegsmain.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProductName LIKE '%{0}%'", txtsearchbyname.Text);
        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }

        private void dgvstripout_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvstripout.Rows[e.RowIndex];
                Txtsearchlegby.Text = row.Cells[0].Value.ToString();
                if (e.RowIndex < 0)
                {
                    return;
                }

            }
            int index = e.RowIndex;
            dgvstripout.Rows[index].Selected = true;
        }

        private void txtsearchslicingcode_TextChanged(object sender, EventArgs e)
        {
            (dgvstripout.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProductName LIKE '%{0}%'", txtsearchslicingcode.Text);
        }

        private void showpwd_CheckedChanged(object sender, EventArgs e)
        {
           if ( manual.Checked == true)
            { 

                richTextBox2.ReadOnly = false; 
            }
           else
            {
                richTextBox2.ReadOnly = true;

            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q6 = "UPDATE [dbo].[ButcheryData] SET [nopieces]=0,[Nocrates]=0 ,[NetWeight]=0  WHERE  ID='" + tridupdatelegs.Text + "'";

                    using (SqlCommand cmd = new SqlCommand(q6, conn))
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
                            MessageBox.Show("Nullified Succesfully", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tridupdatelegs.Text = ".";

                            clearcontrols();

                            loadweighedlegs();
                            Totalnumberofpieceslegs();
                            Totalnumberofpiecesmiddles();
                            Totalnumberofpiecesshoulders();
                            loadbeheaded();
                            richTextBox2.ReadOnly = true;
                            richTextBox2.Text = "0.0";
                            txtnoplegs.Text = "";
                            richTextBox2.Text = "0.0";
                            readweightmiddles.Text = "0.0";
                            readweightshoulders.Text = "0.0";
                            txtslicingscale.Text = "0.0";
                            legscrate.Text = "4.0";

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            Microsoft.Office.Interop.Excel._Worksheet worksheet2 = null;
            Microsoft.Office.Interop.Excel._Worksheet worksheet3 = null;
            Microsoft.Office.Interop.Excel._Worksheet worksheet4 = null;
            Microsoft.Office.Interop.Excel._Worksheet worksheet5 = null;
            Microsoft.Office.Interop.Excel._Worksheet worksheet6 = null;



            app.Visible = true;
          
            {
                
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Pork Breaking";
            

            // storing header part in Excel  
            for (int i = 1; i < dgvhalfs.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvhalfs.Columns[i - 1].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
            }
            for (int i = 1; i <= 8; i++) // this will apply it from col 1 to 10
            {
                worksheet.Columns[i].ColumnWidth = 15;
            }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvhalfs.Rows.Count - 1; i++)
                {



                    for (int j = 0; j < dgvhalfs.Columns.Count; j++)
                    {

                        DataGridViewCell cell = dgvhalfs[j, i];


                        worksheet.Cells[i + 2, j + 1] = cell.Value;



                        Excel.Range tRange = worksheet.UsedRange;
                        tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                        worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;




                    }
                }

            
            }
            int count = workbook.Worksheets.Count;
            Excel.Worksheet addedSheet = workbook.Worksheets.Add(Type.Missing,
            workbook.Worksheets[count], Type.Missing, Type.Missing);
            {

                worksheet2 = workbook.Sheets["Sheet2"];
                worksheet2 = workbook.ActiveSheet;
                worksheet2.Name = "Three Sides";


                // storing header part in Excel  
                for (int i = 1; i < dgvLMS.Columns.Count + 1; i++)
                {
                    worksheet2.Cells[1, i] = dgvLMS.Columns[i - 1].HeaderText;
                    worksheet2.Cells[1, i].Font.Bold = true;
                }
                for (int i = 1; i <= 8; i++) // this will apply it from col 1 to 10
                {
                    worksheet2.Columns[i].ColumnWidth = 15;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvLMS.Rows.Count - 1; i++)
                {



                    for (int j = 0; j < dgvLMS.Columns.Count; j++)
                    {

                        DataGridViewCell cell = dgvLMS[j, i];


                        worksheet2.Cells[i + 2, j + 1] = cell.Value;



                        Excel.Range tRange = worksheet2.UsedRange;
                        tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                        worksheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;




                    }
                }


            }
            int add = workbook.Worksheets.Count;
            Excel.Worksheet addsheet = workbook.Worksheets.Add(Type.Missing,
            workbook.Worksheets[count], Type.Missing, Type.Missing);
            {

                worksheet3 = workbook.Sheets["Sheet3"];
                worksheet3 = workbook.ActiveSheet;
                worksheet3.Name = "Deboning Leg";


                // storing header part in Excel  
                for (int i = 1; i < dgvlegdeboning.Columns.Count + 1; i++)
                {
                    worksheet3.Cells[1, i] = dgvlegdeboning.Columns[i - 1].HeaderText;
                    worksheet3.Cells[1, i].Font.Bold = true;
                }
                for (int i = 1; i <= 8; i++) // this will apply it from col 1 to 10
                {
                    worksheet3.Columns[i].ColumnWidth = 15;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvlegdeboning.Rows.Count - 1; i++)
                {



                    for (int j = 0; j < dgvlegdeboning.Columns.Count; j++)
                    {

                        DataGridViewCell cell = dgvlegdeboning[j, i];


                        worksheet3.Cells[i + 2, j + 1] = cell.Value;



                        Excel.Range tRange = worksheet3.UsedRange;
                        tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                        worksheet3.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;




                    }
                }


            }
            int addmd = workbook.Worksheets.Count;
            Excel.Worksheet addsheetmd = workbook.Worksheets.Add(Type.Missing,
            workbook.Worksheets[count], Type.Missing, Type.Missing);
            {

                worksheet4 = workbook.Sheets["Sheet4"];
                worksheet4 = workbook.ActiveSheet;
                worksheet4.Name = "Deboning Middle";


                // storing header part in Excel  
                for (int i = 1; i < dgvmiddlesdeboning.Columns.Count + 1; i++)
                {
                    worksheet4.Cells[1, i] = dgvmiddlesdeboning.Columns[i - 1].HeaderText;
                    worksheet4.Cells[1, i].Font.Bold = true;
                }
                for (int i = 1; i <= 8; i++) // this will apply it from col 1 to 10
                {
                    worksheet4.Columns[i].ColumnWidth = 15;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvmiddlesdeboning.Rows.Count - 1; i++)
                {



                    for (int j = 0; j < dgvmiddlesdeboning.Columns.Count; j++)
                    {

                        DataGridViewCell cell = dgvmiddlesdeboning[j, i];


                        worksheet4.Cells[i + 2, j + 1] = cell.Value;



                        Excel.Range tRange = worksheet4.UsedRange;
                        tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                        worksheet4.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;




                    }
                }


            }
            int addsh = workbook.Worksheets.Count;
            Excel.Worksheet addsheetsh = workbook.Worksheets.Add(Type.Missing,
            workbook.Worksheets[count], Type.Missing, Type.Missing);
            {

                worksheet5 = workbook.Sheets["Sheet5"];
                worksheet5 = workbook.ActiveSheet;
                worksheet5.Name = "Deboning Shoulder";


                // storing header part in Excel  
                for (int i = 1; i < dgvshoulderdeboning.Columns.Count + 1; i++)
                {
                    worksheet5.Cells[1, i] = dgvshoulderdeboning.Columns[i - 1].HeaderText;
                    worksheet5.Cells[1, i].Font.Bold = true;
                }
                for (int i = 1; i <= 8; i++) // this will apply it from col 1 to 10
                {
                    worksheet5.Columns[i].ColumnWidth = 15;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvshoulderdeboning.Rows.Count - 1; i++)
                {



                    for (int j = 0; j < dgvshoulderdeboning.Columns.Count; j++)
                    {

                        DataGridViewCell cell = dgvshoulderdeboning[j, i];


                        worksheet5.Cells[i + 2, j + 1] = cell.Value;



                        Excel.Range tRange = worksheet5.UsedRange;
                        tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                        worksheet5.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;




                    }
                }


            }
            int addsl = workbook.Worksheets.Count;
            Excel.Worksheet addsheetl = workbook.Worksheets.Add(Type.Missing,
            workbook.Worksheets[count], Type.Missing, Type.Missing);
            {

                worksheet6 = workbook.Sheets["Sheet6"];
                worksheet6= workbook.ActiveSheet;
                worksheet6.Name = "Slicing";


                // storing header part in Excel  
                for (int i = 1; i < dgvsumslices.Columns.Count + 1; i++)
                {
                    worksheet6.Cells[1, i] = dgvsumslices.Columns[i - 1].HeaderText;
                    worksheet6.Cells[1, i].Font.Bold = true;
                }
                for (int i = 1; i <= 8; i++) // this will apply it from col 1 to 10
                {
                    worksheet6.Columns[i].ColumnWidth = 15;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgvsumslices.Rows.Count - 1; i++)
                {



                    for (int j = 0; j < dgvsumslices.Columns.Count; j++)
                    {

                        DataGridViewCell cell = dgvsumslices[j, i];


                        worksheet6.Cells[i + 2, j + 1] = cell.Value;



                        Excel.Range tRange = worksheet6.UsedRange;
                        tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                        worksheet6.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;




                    }
                }


            }






            // this.Close();
        }

        private void cbsidesweight_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsidesweight.Checked == true)
            {

                txtwscl1.ReadOnly = false;
            }
            else
            {
                txtwscl1.ReadOnly = true;

            }
        }

        private void txtbaconremaining_TextChanged(object sender, EventArgs e)
        {
            txtbalance.Text = (Convert.ToDouble(txtbaconremaining.Text)/2).ToString("#,0.00");
        }

        private bool readweightshouldersdebon()
        {
            string port = Properties.Settings.Default.COMPort;    // Store the selected COM port name to "port" varaiable
            int baudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate); // Convert the baud rate string "9600" to int32 9600
            SerialPort COMport = new SerialPort(port, baudRate);
            COMport.ReadTimeout = 3500; //Setting ReadTimeout =3500 ms or 3.5 seconds
                                        // COMport.ReadTimeout = 500;
            COMport.WriteTimeout = 500;



            try
            {

                COMport.Open();
                string data = COMport.ReadLine().ToString();
                StringBuilder sb = new StringBuilder(data);
                readweightshoulders.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                readweightshoulders.ReadOnly = true;
                richTextBox1.Text = readweightshoulders.Text;
                richTextBox2.Text = readweightshoulders.Text;
                readweightmiddles.Text = readweightshoulders.Text;
                txtslicingscale.Text = readweightshoulders.Text;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                readweightshoulders.ReadOnly = false;
                return false;


            }


        }
    }

  
}
  //insert the record into the database.

      
