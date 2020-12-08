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

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using Font = System.Drawing.Font;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp2
{
    public partial class summarry : Form
    {
        public System.Windows.Forms.DataGridViewRowCollection Rows { get; }
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";


        public summarry()
        {
            InitializeComponent();
        }

        private void ExportTextFile_Click(object sender, EventArgs e)
        {

        }

        private void SlaughterDate_ValueChanged(object sender, EventArgs e)
        {
            loaddatabaconers();
            loadsows();
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

            worksheet.Name = SlaughterDate.Text; 
            //  Microsoft.Office.Interop.Excel._Workbook workbook2= app.Workbooks.Add(Type.Missing);
            //Microsoft.Office.Interop.Excel._Worksheet worksheet2 = app.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing) as Excel.Worksheet;
            //worksheet2 = workbook.Sheets["Sheet2"];
            //worksheet2.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
            //SlaughterDate.CustomFormat = "ddMMMyyyy";
            //worksheet2.Name = "MAIN PRODUCTS";
            for (int i = 1; i < dgvbaconers.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgvbaconers.Columns[i - 1].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
            }

            for (int i = 0; i < dgvbaconers.Rows.Count - 1; i++)
            {



                for (int j = 0; j <dgvbaconers.Columns.Count; j++)
                {

                    DataGridViewCell cell = dgvbaconers[j, i];


                    worksheet.Cells[i + 2, j + 1] = cell.Value;

                    worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                }
            }
            for (int i = 6; i < dgvsows.Columns.Count + 6; i++)
            {
                worksheet.Cells[1, i] = dgvsows.Columns[i - 6].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
            }

            for (int i = 0; i < dgvsows.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvsows.Columns.Count; j++)
                {

                    DataGridViewCell cell = dgvsows[j, i];


                    worksheet.Cells[i + 2, j + 6] = cell.Value;

                    worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                    //Excel.Range tRange = worksheet.UsedRange;
                    //tRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    //tRange.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                }
            }


            worksheet = workbook.ActiveSheet;


            this.Close();

        }


        private void summarry_Load(object sender, EventArgs e)
        {
            loaddatabaconers();
            loadsows();
        }

        private void loaddatabaconers()
        {
            //NB-PLEASE ENSURE THE COMPUTER TIME READING IS YYYY-MM-DD BEFORE EXPORTING ELSE WILL THROW AN ERROR
            //SlaughterDate.Format = DateTimePickerFormat.Custom;
            //SlaughterDate.CustomFormat = ("dd/MM/yyyy 00:00:00");








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
                // string To;
                DateTime To = Convert.ToDateTime(this.SlaughterDateTo.Text);
                string inputtype;
                DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);


                To = To.AddDays(1);





                String q = "select ItemNo,outputpname as 'Out Put',sum(CAST(NetWeight AS decimal(18,2))) as Weight from ButcheryData where  parentinputtype in ('baconer') and  ButchTime >='" + startDate.ToString("dd/MMM/yyyy") + "' and  ButchTime <= '" + To.ToString("dd/MMM/yyyy") + "' group by outputpname,Itemno ";

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

                this.dgvbaconers.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; int numbweighed = 0;



                for (int i = 0; i < dgvbaconers.RowCount; i++)
                {
                    // we only sum the first and third column as an example
                    // numbweighed += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    sum1 += Convert.ToDecimal(dgvbaconers.Rows[i].Cells[2].Value);
                   // sum2 += Convert.ToDecimal(dgvbaconers.Rows[i].Cells[4].Value);




                }
                // add the total row

                string[] totalrow = new string[] {  "BACONER", "GRAND TOTALS", sum1.ToString()};
                string[] totalrow2 = new string[] { from, "VARIANCE", "0.0" };
                // dgvsum.Rows.Add(totalrow);
                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);

                //DataRow newRow2 = table.NewRow();
                //table.Rows.Add("BY PRODUCTS");







            }

        }


        private void loadsows()
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
                string inputtype;
                DateTime startDate = Convert.ToDateTime(this.SlaughterDate.Text);


                To = To.AddDays(1);





                String q = "select ItemNo,outputpname as 'Out Put',sum(CAST(NetWeight AS decimal(18,2))) as Weight from ButcheryData where  parentinputtype in ('sow') and  ButchTime >='" + startDate.ToString("dd/MMM/yyyy") + "' and  ButchTime <= '" + To.ToString("dd/MMM/yyyy") + "' group by outputpname,Itemno ";

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

                this.dgvsows.DataSource = table;


                decimal sum1 = 0; decimal sum2 = 0; int numbweighed = 0;



                for (int i = 0; i < dgvsows.RowCount; i++)
                {
                    // we only sum the first and third column as an example
                    // numbweighed += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    sum1 += Convert.ToDecimal(dgvsows.Rows[i].Cells[2].Value);
                    // sum2 += Convert.ToDecimal(dgvbaconers.Rows[i].Cells[4].Value);




                }
                // add the total row

                string[] totalrow = new string[] { "SOWS", "GRAND TOTALS", sum1.ToString() };
                string[] totalrow2 = new string[] { from, "VARIANCE", "0.0" };
                // dgvsum.Rows.Add(totalrow);
                DataRow newRow = table.NewRow();
                table.Rows.Add(totalrow);
                DataRow newRow1 = table.NewRow();
                table.Rows.Add(totalrow2);

                //DataRow newRow2 = table.NewRow();
                //table.Rows.Add("BY PRODUCTS");







            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgvbaconers.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            //Adding Header row
            foreach (DataGridViewColumn column in dgvbaconers.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(0, 255, 255);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dgvbaconers.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Slaughterdatasummarry.pdf", FileMode.Create))
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
            System.Diagnostics.Process.Start(@"C:/PDFs/Slaughterdatasummarry.pdf");
        }

        private void SlaughterDateTo_ValueChanged(object sender, EventArgs e)
        {
            loaddatabaconers();
            loadsows();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bolddg()
        {
           



        }

       

          

    }
}
