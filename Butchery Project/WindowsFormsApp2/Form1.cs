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


namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        private DataTable dtRunningTot = new DataTable();
        public static string StrConn = "";
        private string newrecptno;
        string[] byprods = { "By Product" };

        string[] middlesnonpieces = { "G1194", "G1195", "G1229", "G1230", "G1231", "G1245" };

        //TODO: INSTANT C# TODO TASK: Insert the following converted event handler wireups at the end of the 'InitializeComponent' method for forms, 'Page_Init' for web pages, or into a constructor for other classes:

        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=0;";
        double MPerc;
        string Itemno;
        string Desc;
        string CType;
        int Rqty, wqty;
        int check = 0;
        //int Rqty, Sqty;
        //string RNo = ReceiptNo.Text;

        double CR = 0.0; double WT = 0.0; double NT; double TT = 0.0; double AW = 0.0; double BW = 0.0; double SDA = 0.0;double SDB = 0.0;double STW = 0.0;
        private MessageBoxButtons MessageBoxButtons;
        String CLC;

        private void Total_TextChanged(object sender, EventArgs e)
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
            cmbcrateweight.Text = "7.5";
            //userperm();
            User.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
           // ScaleID.Text = Properties.Settings.Default.ScaleLID;
            this.Deleteoldreceipts();
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



            }

            else if (Txtrole.Text == "Supervisor")
            {
                Refreshlegs.Enabled = false;
               // button2.Enabled = false;
               // usersToolStripMenuItem.Enabled = false;
                configurationsToolStripMenuItem.Enabled = false;
                readweightlegs.Enabled = false;



            }
            else if (Txtrole.Text == "")
            {

                MessageBox.Show(User.Text + "  Has not Been Created Contact IT For Support");
                this.Close();
            }
            else
            {
                readweightlegs.Enabled = true;
                readweightmiddles.Enabled = true;
                readweightshoulders.Enabled = true;
                readg10.Enabled = true;


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
            
            readweightlegs.Focus();
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

          //  this.initComBo();
            this.Totalreceivedtoday();
            txttrid.Text = "";
            readweightlegs.Text = "0.0";
         
           // this.specials();
            Refreshlegs.Focus();

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
        public void passdata()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;//InitializeComponent();
            TT = Convert.ToDouble(readweightlegs.Text = "0.0");
           // AW = Convert.ToDouble(SideA.Text = "0.0");
           // BW = Convert.ToDouble(SideB.Text = "0.0");
            readweightlegs.Text = "0.0";
            readweightmiddles.Text = "0.0";
            readweightshoulders.Text = "0.0";
            loadG1030();
            LoadG1031();
            txtnetwso2.Text = "0.0";
            readweightlegs.Text = "0.0";
            readg10.Text = "0.0";
           // CarcassType.Text.Replace(" ", "");
            Txtbacon.Text= "0";
            Txtsows.Text = "0";
            legscrate.Items.Add("4");
            legscrate.Items.Add("3");
            legscrate.Items.Add("2");
            legscrate.Items.Add("1");
            cmbcrateweight.Items.Add("7.5");
            cmbcrateweight.Items.Add("8.0");
            middlescrate.Items.Add("4");
            middlescrate.Items.Add("3");
            middlescrate.Items.Add("2");
            middlescrate.Items.Add("1");
            shoulderscrate.Items.Add("4");
            shoulderscrate.Items.Add("3");
            shoulderscrate.Items.Add("2");
            shoulderscrate.Items.Add("1");

            legscrate.Text = "4";
            middlescrate.Text = "4";
            shoulderscrate.Text = "4";
           

            Bacons();
            sows();
            Loadlegsby();
            dgvlegbyproducts.ClearSelection();
            dgvlegsmain.ClearSelection();


            rdbaconers.Checked = true;
           // rdlegs.Checked = true;

            //SideB.Text = "0.0";
            //SideA.Text = "0.0";
            // Totalqty();
            userperm();
            //rdA.Checked = true;
            //CarcassType.Text = CarcassType.Text.Replace(" ", "");
      
            Deleteoldreceipts();
            Totalreceivedtoday();
            Loadlegs();
            Loadlegsby();
            Loadmiddles();
            loadmiddlesbys();
            loadshoulders();
            loadshouldersby();
            TotalTotal();
            loadweighedlegs();
            loadweighedmiddles();
            loadweighedshoulders();
            Totalnumberofpieceslegs();
            Totalnumberofpiecesmiddles();
            Totalnumberofpiecesshoulders();
            loadcarcassweigheddata();

            if (lbltotalpieceswlegs.Text == "") txtnoplegs.Text = "0";
            if (lbltotalpieceswmiddles.Text == "") txtnopmiddles.Text = "0";
            if (lbltotalpieceswshoulders.Text == "") txtnopshoulders.Text = "0";

            //DGVTotalS();
            DGVTotalS();
            readweightlegs.Text = "0.0";
     



            //CrateTotal.Items.Add("2.4");
            //CrateTotal.Text = "1.5";
           // this.specials();


            //Form4 frm = new Form4();
            //DialogResult res = frm.ShowDialog();

            //if (res != System.Windows.Forms.DialogResult.OK)
            //{
            //    frm.Dispose();
            //    return;
            //}
            //this.ReceiptNo.Text = frm.ChosenEntry;
            //frm.Dispose();
       

            Refreshlegs.Focus();
             
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
                String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1100' AND outputptype='Main product'";
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
                String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1102' AND outputptype='Main product'";
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
                String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1101' AND outputptype='Main product'";
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
        private void Bacons()
        {
            //if (Txtbsides.Text == "") Txtbsides.Text = "0";
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
                String q = "select baconers from pbreaking where cast( butchdate as date) = cast(getdate() as date) ";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {

                    cmd.CommandText = q;
                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            txtbcos.Text = Convert.ToString(result);

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
            Rqty= Convert.ToDouble(lbllegpiec.Text);
           if (lblinputmiddleleg.Text == "By Product")
            {
                txtnoplegs.Text = "0";
               
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                        "VALUES ('" + lblitemno.Text + "','"
                                                          + lbldesc.Text + "','"
                                                          + lbllegpiec.Text + "','"
                                                          + lblcodeselleg.Text + "','"
                                                          + lblitemdescselleg.Text + "','"
                                                          + lblinputmiddleleg.Text + "','"
                                                          + legscrate.Text + "','"
                                                          + txtnoplegs.Text + "','"
                                                          + NETWeightlegs.Text + "','"
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
                            loadweighedlegs();
                            Totalnumberofpieceslegs();









                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }
            }

           else if (lblinputmiddleleg.Text == "Main Product")
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
                    String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1100' AND outputptype='Main product'";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {

                        cmd.CommandText = q;

                        //using (var reader = cmd.ExecuteReader())
                        {
                            cmd.ExecuteNonQuery();
                            object result = cmd.ExecuteScalar();


                            {
                                //t db;
                               //b = Convert.ToInt32(result);
                               //qty = Convert.ToInt32(txtnoplegs.Text) + db;

                                string db;
                                db = Convert.ToString(result);
                                if (db == "") db = "0";
                                string nop;
                                nop = txtnoplegs.Text;
                                wqty = Convert.ToInt32(nop) + Convert.ToInt32(db);


                                //MeatPercent.Enabled = true;
                                // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                            }
                        }

                    }
                    conn.Close();

                }


                if ( wqty<=Rqty)
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {

                        //
                        String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                            "VALUES ('" + lblitemno.Text + "','"
                                                              + lbldesc.Text + "','"
                                                              + lbllegpiec.Text + "','"
                                                              + lblcodeselleg.Text + "','"
                                                              + lblitemdescselleg.Text + "','"
                                                              + lblinputmiddleleg.Text + "','"
                                                              + legscrate.Text + "','"
                                                              + txtnoplegs.Text + "','"
                                                              + NETWeightlegs.Text + "','"
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
                                loadweighedlegs();
                                Totalnumberofpieceslegs();









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

        private void Savemydatamiddles()
        {
            double Rqty = 0.0;
            lblmiddlepiec.Text.Replace(" ", "");
            Rqty = Convert.ToDouble(lblmiddlepiec.Text);
            if (middlesnonpieces.Contains(lblcodeselmiddle.Text) == true)

            {
                txtnopmiddles.Text = "0";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                        "VALUES ('" + lblitemnomiddles.Text + "','"
                                                          + lbldescmiddles.Text + "','"
                                                          + lblmiddlepiec.Text + "','"
                                                          + lblcodeselmiddle.Text + "','"
                                                          + lblitemdescselmiddle.Text + "','"
                                                          + lblinputmiddle.Text + "','"
                                                          + middlescrate.Text + "','"
                                                          + txtnopmiddles.Text + "','"
                                                          + NETWeightmiddles.Text + "','"
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
                            loadweighedmiddles();
                            Totalnumberofpiecesmiddles();








                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }

            }
            
            else if (middlesnonpieces.Contains(lblcodeselmiddle.Text) == false && byprods.Contains(lblinputmiddle.Text)==true)

            {
               //xtnopmiddles.Text = "0";
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                        "VALUES ('" + lblitemnomiddles.Text + "','"
                                                          + lbldescmiddles.Text + "','"
                                                          + lblmiddlepiec.Text + "','"
                                                          + lblcodeselmiddle.Text + "','"
                                                          + lblitemdescselmiddle.Text + "','"
                                                          + lblinputmiddle.Text + "','"
                                                          + middlescrate.Text + "','"
                                                          + txtnopmiddles.Text + "','"
                                                          + NETWeightmiddles.Text + "','"
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
                            loadweighedmiddles();
                            Totalnumberofpiecesmiddles();








                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 10");
                        }
                    }
                    conn.Close();
                }

            }



          else if (lblinputmiddle.Text == "Main Product")
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
                    String q = "SELECT sum(convert(int,nopieces ) )  FROM ButcheryData WHERE  ButchTime >= CONVERT(DateTime, DATEDIFF(DAY, 0, GETDATE())) and parentItemNo='G1102' AND outputptype='Main product'";
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
                                nop = txtnopmiddles.Text;
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

                    {
                        using (SqlConnection conn = new SqlConnection(_connectionString))
                        {

                            //
                            String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                                "VALUES ('" + lblitemnomiddles.Text + "','"
                                                                  + lbldescmiddles.Text + "','"
                                                                  + lblmiddlepiec.Text + "','"
                                                                  + lblcodeselmiddle.Text + "','"
                                                                  + lblitemdescselmiddle.Text + "','"
                                                                  + lblinputmiddle.Text + "','"
                                                                  + middlescrate.Text + "','"
                                                                  + txtnopmiddles.Text + "','"
                                                                  + NETWeightmiddles.Text + "','"
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
                                    loadweighedmiddles();
                                    Totalnumberofpiecesmiddles();








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

             




                else
                {
                    MessageBox.Show("The record could not be posted. The Number of pieces exceeds The required Number of pieces", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

           
        }
        private void Savemydatashoulders()
        {
            double Rqty = 0.0;
            lbllegpiec.Text.Replace(" ", "");
            Rqty = Convert.ToDouble(lblmiddlepiec.Text);

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
                                if (db =="") db = "0";
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
             

                MessageBox.Show("Please select Item No","BAWS" ,MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        

            else 

            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    readg10.Text.Replace("\n","");
                    //
                    String q5 = "INSERT INTO [dbo].[ButcheryData]([parentItemNo],[parentinputtype],[parentnopieces],[ItemNo],[outputpname],[outputptype],[Nocrates],[nopieces],[NetWeight],[ButchTime],[UserID])" +
                                                        "VALUES ('" + lblG10itemno.Text + "','"
                                                          + lbltype.Text + "','"
                                                          + lblG10desc.Text + "','"
                                                          + lblG10itemno.Text + "','"
                                                          + lblG10desc.Text + "','"
                                                          + lblG10desc.Text + "','"
                                                          + readg10.Text + "','"
                                                          + cmbcrateweight.Text + "','"
                                                          + txtnetwso2.Text + "','"
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
                           // Bacons();
                            //sows();

                            MessageBox.Show("Your Data Saved Succesfully","BAWS",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

            String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [ProductType]='Main Product ' and [inputtype]='Legs' and ItemNo not in ('G1030','G1031')  order by ID asc";

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
                for (int i = 1; i <= dgvlegsmain.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvlegsmain.Columns[i].Width;
                    //remove autosizing
                    dgvlegsmain.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvlegsmain.Columns[i].Width = 250;
                }
            }


           
    }

       private void Loadlegsby()
        {
            dgvlegbyproducts.DataSource = null;
            dgvlegbyproducts.Refresh();




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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [ProductType]='by Product' and [inputtype]='Legs' and ItemNo not in ('G1030','G1031')  order by ID asc";

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

                this.dgvlegbyproducts.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvlegbyproducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvlegbyproducts.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvlegbyproducts.Columns[i].Width;
                    //remove autosizing
                    dgvlegbyproducts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvlegbyproducts.Columns[i].Width = 250;
                }
            }


        }

        private void Loadmiddles()
        {
            dgvmiddlesmain.DataSource = null;
            dgvmiddlesmain.Refresh();




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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [ProductType]='Main Product' and [inputtype]='Middles' and ItemNo not in ('G1030','G1031')  order by ID desc";

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

                this.dgvmiddlesmain.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvmiddlesmain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvmiddlesmain.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvmiddlesmain.Columns[i].Width;
                    //remove autosizing
                    dgvmiddlesmain.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvmiddlesmain.Columns[i].Width = 250;
                }
            }

        }

        private void loadmiddlesbys()
        {
            dgvmiddlesbyproducts.DataSource = null;
            dgvmiddlesbyproducts.Refresh();




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

                this.dgvmiddlesbyproducts.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvmiddlesbyproducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvmiddlesbyproducts.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvmiddlesbyproducts.Columns[i].Width;
                    //remove autosizing
                    dgvmiddlesbyproducts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvmiddlesbyproducts.Columns[i].Width = 250;
                }
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
           dgvshouldersbyproducts.DataSource = null;
            dgvshouldersbyproducts.Refresh();




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

                this.dgvshouldersbyproducts.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvshouldersbyproducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvshouldersbyproducts.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvshouldersbyproducts.Columns[i].Width;
                    //remove autosizing
                    dgvshouldersbyproducts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvshouldersbyproducts.Columns[i].Width = 250;
                }
            }


        }

        private void loadweighedlegs()
        {
            dgvlegsdata.DataSource = null;
            dgvlegsdata.Refresh();




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

                String q = "select ItemNo,outputpname AS Product,outputptype as Type,CAST(Nocrates AS decimal(18,2)) AS Crates,CAST(nopieces AS decimal(18,2)) AS Pieces,CAST(NetWeight AS decimal(18,2)) AS Weight,ID from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentinputtype='Pork Leg' order by ID asc";

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

        private void loadweighedmiddles()
        {
            dgvmiddlesdata.DataSource = null;
            dgvmiddlesdata.Refresh();




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

                this.dgvmiddlesdata.DataSource = table;
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
            dgvshouldersdata.DataSource = null;
            dgvshouldersdata.Refresh();




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

                this.dgvshouldersdata.DataSource = table;
                // dgvlegsmain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
             
            }
        }
        private void loaddata()
        {

            dgvlegbyproducts.DataSource = null;
            dgvlegbyproducts.Refresh();
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

                this.dgvlegbyproducts.DataSource = table;

            }
            //MessageBox.Show(Sla

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
            if (MessageBox.Show("Are You Sure You Want To Close The Application?", "CMWAS",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                // Cancel the Closing event
                e.Cancel = true;
            }
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
            readweightlegs.Focus();
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
            TxtSsides.Text = (Convert.ToDouble(Txtsows.Text) * 2).ToString("#,0.00");
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
                readweightlegs.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                readweightlegs.ReadOnly = true;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                readweightlegs.ReadOnly = false;
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
                readweightlegs.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                readweightlegs.ReadOnly = true;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                readweightlegs.ReadOnly = false;
                return false;


            }



        }

        private void Readw1_Click(object sender, EventArgs e)
        {
            
        }

        private void Readw2_Click(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click_2(object sender, EventArgs e)
        {
          
            
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {

                    //
                    String q5 = "INSERT INTO [dbo].[Pbreaking]([Baconers],[Sows],[butchdate],[UserID])" +
                                                        "VALUES ('" +Txtbsides.Text  + "','"
                                                          +TxtSsides.Text + "','"
                                                          
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
            txtshoulders.Text= (txtbcos.Text);
            txtmiddles.Text= (txtbcos.Text);
            lbllegpiec.Text= (txtbcos.Text);
            lblmiddlepiec.Text= (txtbcos.Text);
            lblshoulderpiec.Text= (txtbcos.Text);
        }

        private void Txtsws_TextChanged(object sender, EventArgs e)
        {
            Txtleanpork.Text = txtsws.Text;
            Txtsemilean.Text = txtsws.Text;
        }

        private void Rdbaconers_CheckedChanged(object sender, EventArgs e)
        {

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
                dgvlegbyproducts.ClearSelection();

            }
        }

        private void Dgvlegbyproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvlegbyproducts.Rows[e.RowIndex];
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
            NETWeightlegs.Text = (Convert.ToDouble(readweightlegs.Text) -CT).ToString("#,0.00");
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
                DataGridViewRow row = this.dgvmiddlesmain.Rows[e.RowIndex];
                lblcodeselmiddle.Text = row.Cells[0].Value.ToString();
                lblitemdescselmiddle.Text = row.Cells[1].Value.ToString();
                lblinputmiddle.Text = "Main Product";
                dgvmiddlesbyproducts.ClearSelection();

            }
        }

        private void Dgvmiddlesbyproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvmiddlesbyproducts.Rows[e.RowIndex];
                lblcodeselmiddle.Text = row.Cells[0].Value.ToString();
                lblitemdescselmiddle.Text = row.Cells[1].Value.ToString();
                lblinputmiddle.Text = "By Product";
                dgvmiddlesmain.ClearSelection();

            }
        }

        private void Dgvshouldersmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvshouldersmain.Rows[e.RowIndex];
                lblcodeselshoulders.Text = row.Cells[0].Value.ToString();
                lblitemdescselshoulders.Text = row.Cells[1].Value.ToString();
                lblinputshoulders.Text = "Main Product";
                dgvshouldersbyproducts.ClearSelection();

            }

        }

        private void Dgvshouldersbyproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvshouldersbyproducts.Rows[e.RowIndex];
                lblcodeselshoulders.Text = row.Cells[0].Value.ToString();
                lblitemdescselshoulders.Text = row.Cells[1].Value.ToString();
                lblinputshoulders.Text = "By Product";
                dgvshouldersmain.ClearSelection();

            }
        }

        private void Dgvlegsmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvlegsmain.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = "Main Product";
                dgvlegbyproducts.ClearSelection();

            }
        }

        private void Dgvlegbyproducts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvlegbyproducts.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = "By Product";
                dgvlegsmain.ClearSelection();

            }
        }

        private void ScaleStatus_Enter(object sender, EventArgs e)
        {

        }

        private void Button3_Click_3(object sender, EventArgs e)
        {
            readweightshouldersdebon();
        }

        private void Refresh_Click_4(object sender, EventArgs e)
        {
            readweightlegsdebon();
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
                readweightlegs.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                readweightlegs.ReadOnly = true;
                COMport.Close();
                return true;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                readweightlegs.ReadOnly = false;
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
            NETWeightlegs.Text = (Convert.ToDouble(readweightlegs.Text) - CTL).ToString("#,0.00");
        }

        private void Txtnoplegs_TextChanged(object sender, EventArgs e)
        {
            //if (txtnoplegs.Text == "") txtnoplegs.Text = "0";
            //Double CT = 0.0;
            //double NOC = 0.0;
           
            //NOC = (Convert.ToDouble(txtnoplegs.Text));
           
        
            //if (NOC > 8)
            //{

            //    MessageBox.Show("No OF crates Can Not Be More Than 8");
            //    txtnoplegs.Text = "";
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
            NETWeightlegs.Text = (Convert.ToDouble(readweightlegs.Text) - CT).ToString("#,0.00");
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

            CTS= (Convert.ToDouble(shoulderscrate.Text) * 1.8);
            NETWeightshoulders.Text = (Convert.ToDouble(readweightshoulders.Text) - CTS).ToString("#,0.00");
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
            Savemydatamiddles();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Savemydatashoulders();
        }

        private void DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txtnopmiddles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lblitemdescselmiddle.Text == ".")
                {
                    MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (tridupdatemiddles.Text == ".")
                    {
                        Savemydatamiddles();
                    }

                    else
                    {
                        {
                            using (SqlConnection conn = new SqlConnection(_connectionString))
                            {

                                //
                                String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemnomiddles.Text + "',[parentinputtype]='" + lbldescmiddles.Text + "',[parentnopieces]='" + lblmiddlepiec.Text + "',[ItemNo]='" + lblcodeselmiddle.Text + "',[outputpname]='" + lblitemdescselmiddle.Text + "',[outputptype]='" + lblinputmiddle.Text + "',[Nocrates]='" + middlescrate.Text + "',[nopieces]='" + txtnopmiddles.Text + "',[NetWeight]='" + NETWeightmiddles.Text + "'  WHERE  ID='" + tridupdatemiddles.Text + "'";

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
                                        tridupdatemiddles.Text = ".";
                                        loadweighedmiddles();
                                        Totalnumberofpiecesmiddles();

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

        private void Txtnoplegs_KeyDown(object sender, KeyEventArgs e)
        {
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
                        
                   
                        
                    }

                    else
                    {
                        {
                            using (SqlConnection conn = new SqlConnection(_connectionString))
                            {

                                //
                                String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemno.Text + "',[parentinputtype]='" + lbldesc.Text + "',[parentnopieces]='" + lbllegpiec.Text + "',[ItemNo]='" + lblcodeselleg.Text + "',[outputpname]='" + lblitemdescselleg.Text + "',[outputptype]='" + lblinputmiddleleg.Text + "',[Nocrates]='" + legscrate.Text + "',[nopieces]='" + txtnoplegs.Text + "',[NetWeight]='" + NETWeightlegs.Text + "'  WHERE  ID='" + tridupdatelegs.Text + "'";

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
                                        loadweighedlegs();
                                        Totalnumberofpieceslegs();
                                      
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



        private void Txtnopshoulders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lblitemdescselshoulders.Text == ".")
                {

                    MessageBox.Show("Please select Item No", "BAWS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (tridupdateshoulders.Text == ".")
                    {
                        Savemydatashoulders();
                    }

                    else
                    {
                        {
                            using (SqlConnection conn = new SqlConnection(_connectionString))
                            {

                                //
                                String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemnoshoulders.Text + "',[parentinputtype]='" + lbldescshoulders.Text + "',[parentnopieces]='" + lblshoulderpiec.Text + "',[ItemNo]='" + lblcodeselshoulders.Text + "',[outputpname]='" + lblitemdescselshoulders.Text + "',[outputptype]='" + lblinputshoulders.Text + "',[Nocrates]='" + shoulderscrate.Text + "',[nopieces]='" + txtnopshoulders.Text + "',[NetWeight]='" + NETWeightshoulders.Text + "'  WHERE  ID='" + tridupdateshoulders.Text + "'";

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
                                        tridupdateshoulders.Text = ".";
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



                    }
                }


            }
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
                lbltype.Text = "BACONER";
                dgvbreaklegssows.ClearSelection();

            }
        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvbreaklegssows.Rows[e.RowIndex];
                lblG10itemno.Text = row.Cells[0].Value.ToString();
                lblG10desc.Text = row.Cells[1].Value.ToString();
                lbltype.Text = "SOW";
                //lblinputmiddleleg.Text = "Main product";
                dgvbreaklegsbacon.ClearSelection();

            }
        }

        private  void  loadG1030()
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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE [itemno]='G1030'   order by ID asc";

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
                dgvbreaklegsbacon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvbreaklegsbacon.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvbreaklegsbacon.Columns[i].Width;
                    //remove autosizing
                    dgvbreaklegsbacon.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvbreaklegsbacon.Columns[i].Width = 250;
                }
            }



        }


        private void LoadG1031()
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

                String q = "SELECT [ItemNo] as Code,[ProductName] as Description FROM PRODUCTS WHERE inputtype='sow'   order by ID asc";

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
                dgvbreaklegssows.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dgvlegsmain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //datagrid has calculated it's widths so we can store them
                for (int i = 1; i <= dgvbreaklegssows.Columns.Count - 1; i++)
                {
                    //store autosized widths
                    int colw = dgvbreaklegssows.Columns[i].Width;
                    //remove autosizing
                    dgvbreaklegssows.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //set width to calculated by autosize
                    dgvbreaklegssows.Columns[i].Width = 250;
                }
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

                String q = "select ItemNo,outputpname as 'Out Put',CAST(NetWeight AS decimal(18,2)) AS Weight,CAST(nopieces AS decimal(18,2)) AS Crate,parentinputtype as INPUT,ID from ButcheryData where cast (butchtime as date)=cast(getdate() as date) and parentinputtype in ('baconer','sow' ) order by ID desc";

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
                readg10.Text = Regex.Replace(sb.ToString(), "[^0-9.]", "");
                readg10.ReadOnly = true;
                COMport.Close();
                return true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Unable to read from COM port. Please make sure the weighing scale is connected to the computer and correct configuration set");
                readg10.ReadOnly = false;
                return false;
               


            }


        }

        private void Txtnetwso2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbldgvcrcbrk.Text==".")
                {
                    savemydatabreakings();
                    loadcarcassweigheddata();

                }

                else
                {
                    {
                        using (SqlConnection conn = new SqlConnection(_connectionString))
                        {

                            //
                            String q6 = "UPDATE [dbo].[ButcheryData] SET [parentItemNo]='" + lblitemno.Text + "',[parentinputtype]='" + lbltype.Text + "',[parentnopieces]='" + lblG10desc.Text + "',[ItemNo]='" + lblG10itemno.Text + "',[outputpname]='" + lblG10desc.Text + "',[outputptype]='" + lblG10desc.Text + "',[Nocrates]='" + readg10.Text + "',[nopieces]='" + cmbcrateweight.Text + "',[NetWeight]='" + txtnetwso2.Text + "'  WHERE  ID='" + lbldgvcrcbrk.Text + "'";

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
                                    loadcarcassweigheddata();

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

        private void Txtwscl2_TextChanged(object sender, EventArgs e)
        {  

           // NETWeightlegs.Text = (Convert.ToDouble(readweightlegs.Text) - CT).ToString("#,0.00");
        }

        private void Txtwscl2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Cmbcrateweight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtnetwso2.Text == "") txtnetwso2.Text = "0.0";
            //if (eadweightlegs.Text == "") readweightlegs.Text = "0";
            txtnetwso2.Text = (Convert.ToDouble(readg10.Text) - Convert.ToDouble(cmbcrateweight.Text)).ToString("#,0.00");
            readg10.Focus();
        }

        private void Readweightlegs_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Readg10_TextChanged(object sender, EventArgs e)
        {
           // if (txtnetwso2.Text == "") txtnetwso2.Text = "0.0";

            //if (eadweightlegs.Text == "") readweightlegs.Text = "0";
            //StringBuilder sb = new StringBuilder(data);
            readg10.Text.Replace("\n", "");
            txtnetwso2.Text = (Convert.ToDouble(readg10.Text) - Convert.ToDouble(cmbcrateweight.Text)).ToString("#,0.00");
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
            NETWeightlegs.Text = (Convert.ToDouble(readweightlegs.Text) - CTL).ToString("#,0.00");
            txtnoplegs.Focus();
        }

        private void Txtnetwso2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dgvlegsdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvlegsdata.Rows[e.RowIndex];
                lblcodeselleg.Text = row.Cells[0].Value.ToString();
                lblitemdescselleg.Text = row.Cells[1].Value.ToString();
                lblinputmiddleleg.Text = row.Cells[2].Value.ToString();

                tridupdatelegs.Text = row.Cells[6].Value.ToString();
             
               // dgvlegsmain.ClearSelection();

            }
        }

        private void Dgvmiddlesdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvmiddlesdata.Rows[e.RowIndex];

                lblcodeselmiddle.Text = row.Cells[0].Value.ToString();
                lblitemdescselmiddle.Text = row.Cells[1].Value.ToString();
                lblinputmiddle.Text = row.Cells[2].Value.ToString();
                tridupdatemiddles.Text = row.Cells[6].Value.ToString();

                // dgvlegsmain.ClearSelection();

            }
        }

        private void Dgvshouldersdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvshouldersdata.Rows[e.RowIndex];
           

                lblcodeselshoulders.Text = row.Cells[0].Value.ToString();
                lblitemdescselshoulders.Text = row.Cells[1].Value.ToString();
                lblinputshoulders.Text = row.Cells[2].Value.ToString();
                tridupdateshoulders.Text = row.Cells[6].Value.ToString();

                // dgvlegsmain.ClearSelection();

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
            DataGridViewRow row = this.dgvcrcbrk.Rows[e.RowIndex];
            lblG10itemno.Text = row.Cells[0].Value.ToString();
            lblG10desc.Text = row.Cells[1].Value.ToString();
            lbltype.Text = row.Cells[4].Value.ToString();
            lbldgvcrcbrk.Text= row.Cells[5].Value.ToString();
            dgvbreaklegssows.ClearSelection();
            dgvbreaklegssows.ClearSelection();











            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

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

      
