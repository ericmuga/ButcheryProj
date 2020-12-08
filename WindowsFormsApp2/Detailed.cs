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
using System.IO;
using System.Reflection;
using Microsoft.Office.Tools.Excel;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApp2
{
    public partial class Detailed : Form

    {
        public Microsoft.Office.Interop.Excel.Application xl;
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public Detailed()
        {
            InitializeComponent();
        }

        private void SlaughterDate_ValueChanged(object sender, EventArgs e)
        {
            if (Txtinputtype.Text == "FAT STRIPPING")
            {
                loadslicing();
            }
            else
            {
                loaddata();
                loaddataby();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
             
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
           
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
         

           
            app.Visible = true;
           
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
         

            worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;



            SlaughterDate.CustomFormat = "ddMMMyyyy";

            worksheet.Name = Txtinputtype.Text;
            //  Microsoft.Office.Interop.Excel._Workbook workbook2= app.Workbooks.Add(Type.Missing);
            //Microsoft.Office.Interop.Excel._Worksheet worksheet2 = app.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing) as Excel.Worksheet;
            //worksheet2 = workbook.Sheets["Sheet2"];
            //worksheet2.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
            //SlaughterDate.CustomFormat = "ddMMMyyyy";
            //worksheet2.Name = "MAIN PRODUCTS";
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {



                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    DataGridViewCell cell = dataGridView1[j, i];


                  worksheet.Cells[i + 2, j + 1] = cell.Value;

                    worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                }
            }
            for (int i = 7; i < dataGridView2.Columns.Count + 7; i++)
            {
                worksheet.Cells[1, i] = dataGridView2.Columns[i - 7].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
            }

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {

                    DataGridViewCell cell = dataGridView2[j, i];


                    worksheet.Cells[i + 2, j + 7] = cell.Value;

                    worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


                }
            }


            worksheet = workbook.ActiveSheet;


            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(0, 255, 255);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {

                    }
                    else
                    {
                        pdfTable.AddCell(cell.Value.ToString());

                    }


                }
            }
            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Slaughterdatadetailed.pdf", FileMode.Create))
            {




                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            this.Close();
            //MessageBox.Show("Data Exported Succesfully check it in C:\\PDFs folder");
            System.Diagnostics.Process.Start(@"C:/PDFs/Slaughterdatadetailed.pdf");
        }
        private void PopulateDataGridView()

        {

            //NB-PLEASE ENSURE THE COMPUTER TIME READING IS YYYY-MM-DD BEFORE EXPORTING ELSE WILL THROW AN ERROR
            //SlaughterDate.Format = DateTimePickerFormat.Custom;
            //SlaughterDate.CustomFormat = ("dd/MM/yyyy 00:00:00");







            DateTime endDate = Convert.ToDateTime(this.SlaughterDate.Text);


            endDate = endDate.AddDays(1);

            //MessageBox.Show(SlaughterDate.Text + "|" + endDate.ToString());

            //loadgrid

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
                //DateTime NT;
                //SlaughterDate.Format = DateTimePickerFormat.Custom;
                //SlaughterDate.CustomFormat = "yyyy-MM-dd";
                //NT = (Convert.ToDateTime(SlaughterDate.Text));

                //NT.ToString("dd/MMM/yyyy 00:00:00");
                //endDate.ToString("dd-MM-yyyy");
                //String q = "SELECT SlaughterTime,ItemNo,ReceiptNo,StockWeight,MeatPercent,[Classification Code] FROM [dbo].[SlaughterData] where SlaughterTime>'" + DateTime.Today.ToString("yyyy-MM-dd h:mm tt") + "' order by ID desc";
                string from;
                from = SlaughterDate.Text;
                string To;
                To = SlaughterDateTo.Text;


                String q = "SELECT Row_Number() OVER (PARTITION BY ReceiptNo ORDER BY ReceiptNo) as AggrNum,SlaughterTime AS LogDate,vendorno AS SuppCode,ItemNo AS ProdCode,ProdName,ReceiptNo AS GRN,CAST(SideA AS decimal(18,2)) AS WEIGHTA,CAST(  SideB AS decimal(18,2)) AS WEIGHTB,CAST(  TotalWeight AS decimal(18,2)) as TotalWeight,sum(CAST(TotalWeight AS decimal(18,2))) *0.975 as CWPercentage FROM [dbo].[SlaughterDatasummarry] where " +
                 "SlaughterTime >='" + from + "' and SlaughterTime <= '" + To + "' and vendorno='" + Txtinputtype.Text + "' group by ID,ReceiptNo,SlaughterTime,vendorno,vendorname,ItemNo,SideA,SideB,TotalWeight,ProdName order by ID   ";

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

                this.dataGridView1.DataSource = table;
                decimal sum1 = 0; decimal sum2 = 0; int numbweighed = 0;



                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    // we only sum the first and third column as an example
                    //numbweighed += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);




                }
                // add the total row
                int toatlrow = dataGridView1.RowCount - 1;
                string R;
                R = toatlrow.ToString();
             
                R = toatlrow.ToString();
                string[] totalrow = new string[] { R, from, To, "GRAND TOTALS", "", "", "0,00", "0.00", sum1.ToString(), sum2.ToString() };
                // dgvsum.Rows.Add(totalrow);
                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);


            }
        }

        private void loaddata()
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
               DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string outputtype;
                DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);


                To = To.AddDays(1);

                outputtype = Txtinputtype.Text;
                if (Txtinputtype.Text == "LEG")
                {
                    outputtype = "Leg";
                }
                if (Txtinputtype.Text == "MIDDLES")
                {
                    outputtype = "Middle";
                }
                if (Txtinputtype.Text == "SHOULDERS")
                {
                    outputtype = "Shoulder";
                }




                String q = "SELECT  Itemno,outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18,2))) AS 'PIECES',sum(CAST(NetWeight AS decimal(18,2))) as Weight FROM ButcheryData WHERE outputptype ='" + outputtype + "' and parentItemNo='MAIN PRODUCT' and  ButchTime >='" + startDate.ToString("dd/MMM/yyyy") + "' and  ButchTime <= '" + To.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype ";

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

                this.dataGridView1.DataSource = table;
              

                decimal sum1 = 0; decimal sum2 = 0; decimal variance1= 0;decimal variance2 = 0;



                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                   
                    sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    




                }
                // add the total row

                string[] totalrow = new string[] { from, "MAIN PRODUCT", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "", "VARIANCE", "0.0", "0.0" };
                
                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);

               






            }

        }

        private void loaddataby()
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
                //DateTime NT;
                //SlaughterDate.Format = DateTimePickerFormat.Custom;
                //SlaughterDate.CustomFormat = "yyyy-MM-dd";
                //NT = (Convert.ToDateTime(SlaughterDate.Text));

                //NT.ToString("dd/MMM/yyyy 00:00:00");
                //endDate.ToString("dd-MM-yyyy");
                //String q = "SELECT SlaughterTime,ItemNo,ReceiptNo,StockWeight,MeatPercent,[Classification Code] FROM [dbo].[SlaughterData] where SlaughterTime>'" + DateTime.Today.ToString("yyyy-MM-dd h:mm tt") + "' order by ID desc";
                string from;
                from = SlaughterDate.Text;
                // string To;
                DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string outputtype;
                DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);


                To = To.AddDays(1);

                outputtype = Txtinputtype.Text;
                if (Txtinputtype.Text == "LEG")
                {
                    outputtype = "Leg";
                }
                if (Txtinputtype.Text == "MIDDLES")
                {
                    outputtype = "Middle";
                }
                if (Txtinputtype.Text == "SHOULDERS")
                {
                    outputtype = "Shoulders";
                }




                String q = "SELECT  Itemno,outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18,2))) AS 'PIECES',sum(CAST(NetWeight AS decimal(18,2))) as Weight FROM ButcheryData WHERE outputptype='" + outputtype + "' and parentItemNo='BY PRODUCT' and  ButchTime >='" + startDate.ToString("dd/MMM/yyyy") + "' and  ButchTime <= '" + To.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype ";

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

                this.dataGridView2.DataSource = table;
                decimal sum1 = 0; decimal sum2 = 0; int numbweighed = 0;



                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    // we only sum the first and third column as an example
                    // numbweighed += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    sum1 += Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value);




                }
                // add the total row

                string[] totalrow = new string[] { from, "BY PRODUCT", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "", "VARIANCE", "0.0", "0.0" };
                // dgvsum.Rows.Add(totalrow);
                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);




            }



        }


        
        private void Txtrecptno_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void loadslicing()
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
                DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);


                To = To.AddDays(1);

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




                String q = "SELECT  Itemno,outputpname AS 'OUT PUT',outputptype AS TYPE,sum(CAST(nopieces AS decimal(18,2))) AS 'CRATES',sum(CAST(NetWeight AS decimal(18,2))) as Weight FROM ButcheryData WHERE parentItemNo='" + Txtinputtype.Text + "' and  ButchTime >='" + startDate.ToString("dd/MMM/yyyy") + "' and  ButchTime <= '" + To.ToString("dd/MMM/yyyy") + "'group by outputpname,Itemno,outputptype ";

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

                this.dataGridView1.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; decimal variance1 = 0; decimal variance2 = 0;



                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    sum2 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);





                }
                // add the total row

                string[] totalrow = new string[] { from, "STRIPPING", "GRAND TOTALS", sum1.ToString(), sum2.ToString() };
                string[] totalrow2 = new string[] { "", "", "VARIANCE", "0.0", "0.0" };

                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);








            }





        }

        private void Txtrecptno_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txtrecptno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                PopulateDataGridView();

                // button1.PerformClick();




            }
        }
        private void countrow()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRowHeaderCell cell = dataGridView1.Rows[i].HeaderCell;
                cell.Value = (i + 1).ToString();
                dataGridView1.Rows[i].HeaderCell = cell;
            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void SlaughterDateTo_ValueChanged(object sender, EventArgs e)
        {
            if (Txtinputtype.Text == "FAT STRIPPING")
            {
                loadslicing();
            }
            else
            {
                loaddata();
                loaddataby();
            }


        }

        private void Detailed_Load(object sender, EventArgs e)
        {
            // Loadvendors();
            // PopulateDataGridView();
            //this.WindowState = FormWindowState.Maximized;
            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;


            Txtinputtype.Items.Add("LEG");
            Txtinputtype.Items.Add("MIDDLE");
            Txtinputtype.Items.Add("SHOULDER");
            Txtinputtype.Items.Add("FAT STRIPPING");
            Txtinputtype.Text = ("LEG");
           
            //txtouttype.Items.Add("MAIN PRODUCT");
            //txtouttype.Items.Add("BY PRODUCT");
            //txtouttype.Text = "MAIN PRODUCT";
           // loaddata();
            //loaddataby();

        }

        private void Loadvendors()
        {
           
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                try
                {
                   
                    string from;
                    from = SlaughterDate.Text;
                    string To;
                    To = SlaughterDateTo.Text;
                    string query = "select DISTINCT  vendorno from SlaughterDatasummarry where  SlaughterTime >='" + from + "' and SlaughterTime <= '" + To + "' UNION ALL Select '' order by vendorno  ";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "vendorno");
                    Txtinputtype.DisplayMember = "vendorno";
                    Txtinputtype.ValueMember = "vendorno";
                    Txtinputtype.DataSource = ds.Tables["vendorno"];
                    Txtinputtype.Text = "";



                }
                catch (Exception ex)
                {
                    //Exception Message
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }

            }
        }

        private void ReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {  if (Txtinputtype.Text == "FAT STRIPPING")
            {
                loadslicing();
            }
            else
            {
                loaddata();
                loaddataby();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;


            SlaughterDate.CustomFormat = "ddMMMyyyy";

            worksheet.Name = SlaughterDate.Text;

            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {



                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    DataGridViewCell cell = dataGridView1[j, i];


                    worksheet.Cells[i + 2, j + 1] = cell.Value;



                    //worksheet.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
                }
            }
            // save the application  

            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Txtouttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void Totalw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
