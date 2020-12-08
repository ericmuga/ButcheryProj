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


namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
      
        public Form5()
        {
            InitializeComponent();
          
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_fcl_weighDataSet4.SlaughterData' table. You can move, or remove it, as needed.
            this.slaughterDataTableAdapter.Fill(this._fcl_weighDataSet4.SlaughterData);
			SlaughterDate.Format = DateTimePickerFormat.Custom;
			SlaughterDate.CustomFormat = "dd/MMM/yyyy";
			SlaughterDate_ValueChanged(new object(), new EventArgs());
            dataGridView1.Columns["SlaughterTime"].DefaultCellStyle.Format = "dd/MMM/yyyy HH:mm";
         




        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.slaughterDataTableAdapter.FillBy(this._fcl_weighDataSet4.SlaughterData);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void SlaughterDate_ValueChanged(object sender, EventArgs e)

        {    //NB-PLEASE ENSURE THE COMPUTER TIME READING IS YYYY-MM-DD BEFORE EXPORTING ELSE WILL THROW AN ERROR
            //SlaughterDate.Format = DateTimePickerFormat.Custom;
            //SlaughterDate.CustomFormat = ("dd/MM/yyyy 00:00:00");


			
			
			
			

			DateTime endDate =  Convert.ToDateTime(this.SlaughterDate.Text);

            
			endDate =endDate.AddDays(1);

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
                string xwz;
                xwz = SlaughterDate.Text;
                String q = "SELECT SlaughterTime,ItemNo as Prodcode,vendorno as SuppCode,ReceiptNo,TotalWeight,Class FROM [dbo].[SlaughterDatasummarry] where " +
                 "SlaughterTime >='" + xwz + "' and SlaughterTime <= '" + endDate.ToString("dd/MMM/yyyy 00:00:00") + "' order by ID ";

				var table = new DataTable();
                using (var da = new SqlDataAdapter(q, _connectionString))
                    {
                        try
                        {
                            da.Fill(table);
						Totalweighedtoday();

						}
                        catch ( Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
               
                conn.Close();

                this.dataGridView1.DataSource = table;

            }
            //MessageBox.Show(SlaughterDate.Text+" 00:00:00.000");
        }
		private void Totalweighedtoday()
		{

			//SlaughterDate.Format = DateTimePickerFormat.Custom;
			//SlaughterDate.CustomFormat = "dd/MM/yyyy";







			DateTime endDate = Convert.ToDateTime(this.SlaughterDate.Text);


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

                string xwz;
                xwz = SlaughterDate.Text;
                String q = "select count(*)   from [SlaughterDatasummarry] where " +
                            "SlaughterTime >='" + xwz + "'"
                             + " AND  SlaughterTime<='" + endDate.ToString("dd/MMM/yyyy 00:00:00") + "'";

                using (SqlCommand cmd = new SqlCommand(q, conn))
				{

					cmd.CommandText = q;

					//using (var reader = cmd.ExecuteReader())
					{
						cmd.ExecuteNonQuery();
						object result = cmd.ExecuteScalar();


						{
							totalw.Text = Convert.ToString(result);

							//MeatPercent.Enabled = true;
							// receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
						}
					}

				}
				conn.Close();

			}

		}

        private void Totalweighedpervendor()
        {
            DateTime endDate = Convert.ToDateTime(this.SlaughterDate.Text);
            string xwz;
            xwz = SlaughterDate.Text;
         


        

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

     

                xwz = SlaughterDate.Text;
                String query = "SELECT  count(*) FROM [dbo].[SlaughterDatasummarry]";
                query += " WHERE SlaughterTime >='" + xwz + "'"
                     + " AND  SlaughterTime<='" + endDate.ToString("dd/MMM/yyyy 00:00:00") + "' AND VendorNo='" + Txtrecptno.Text + "'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.CommandText = query;

                    //using (var reader = cmd.ExecuteReader())
                    {
                        cmd.ExecuteNonQuery();
                        object result = cmd.ExecuteScalar();


                        {
                            totalw.Text = Convert.ToString(result);

                            //MeatPercent.Enabled = true;
                            // receiptDetails.Text = $"Receipt no: {receiptNumber.Text} Vendor Name: {vendorName} Animal Type: {CType}";                           
                        }
                    }

                }
                conn.Close();

            }


        }
        private void ExportTextFile_Click(object sender, EventArgs e)
        {
            string path = "",refine="";

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path=saveFileDialog.FileName;

            
            refine = (path + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

            TextWriter writer = new StreamWriter(refine);

            string input = ""; ; int index=0;
            string date,time="";
            DateTime sd;
            for (int i=0; i<dataGridView1.Rows.Count-1;i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    input = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //truncate the weight and meat percent
                        //input.Replace(@"G0110", @"G0101");
                        //input.Replace(@"G0111", @"G0102");
                        //input.Replace(@"G0113", @"G0104");
                   if (j == 0)
                    {

                       // time = Convert.ToDateTime(input).ToString("HH:mm");
                        date = Convert.ToDateTime(input).ToString("dd/MM/yyyy");
                        input = "\""+date ;
                    }
                    if (j==1)
                    {
                        input = input.Replace(" ", "");
                            //input.Replace(@"G0110", @"G0101");
                            //input.Replace(@"G0111", @"G0102");
                            //input.Replace(@"G0113", @"G0104");
                        }
						if (j == 2)
						{
							input = input.Replace(" ", "");
							
						}
                        if (j == 3)
                        {
                            input = input.Replace(" ", "");
                        }

                        //    if (j == 4)
                        //{
                        //    

                        //}
                        if (j == 4)
                        {
                            input = input.Replace(" ", "");
                        }

                        if (j == 5) writer.Write(input + "\"");

                        else writer.Write(input + "\",\"");
                        input = input.Remove(input.LastIndexOf(".") + 1).Replace(".", "");
                    }
                writer.WriteLine("");

            }
            writer.Close();
				
            MessageBox.Show( totalw.Text + "    Rows Exported Successfully");
        }
        else
            { 
                MessageBox.Show("Invalid Export Location");
            }
        }



        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            string path = "", refine = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = saveFileDialog.FileName;

                refine = (path + DateTime.Now.ToString("dd/MM/yyyy") + ".csv");

                TextWriter writer = new StreamWriter(refine);

                string input = ""; ; int index = 0;
                string date, time = "";
                //DateTime sd;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        input = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        //truncate the weight and meat percent
                        input.Replace(@"G0110", @"G0101");
                        input.Replace(@"G0111", @"G0102");
                        input.Replace(@"G0113", @"G0104");
                        if (j == 0)
                        {
                            time = Convert.ToDateTime(input).ToString("HH:mm");
                            date = Convert.ToDateTime(input).ToString("dd/MM/yyyy");
                            input = date + "," + time;
                        }
                        if (j == 1)
                        {
                            input = input.Replace(" ", "");
                            
                        }

                        if (j == 3 || j == 4)
                        {
                            input = input.Remove(input.LastIndexOf(".") + 1).Replace(".", "");
                        }

                        //if (j != 4)
                            writer.Write(input + ",");
                    }
                    writer.WriteLine("");

                }
                writer.Close();
               
                MessageBox.Show(totalw.Text +   "  Rows Exported Successfully");

            }
            else
            {
                MessageBox.Show("Invalid Export Location");
            }
        }

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
      private void Exportexcel()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel._Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
              
                // creating new Excelsheet in workbook  
               // Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                XcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                XcelApp.Columns.AutoFit();
                XcelApp.Visible = true;
            }

        }
        

        private void Button1_Click(object sender, EventArgs e)
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
           // MessageBox.Show("Data Exported Succesfully");


        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;

            pdfTable.WidthPercentage = 70;
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
            using (FileStream stream = new FileStream(folderPath + "Slaughterdata.pdf", FileMode.Create))
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
            System.Diagnostics.Process.Start(@"C:/PDFs/Slaughterdata.pdf");

        }

        private void ReceiptNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        private DataTable PopulateDataGridView()
        {
            string xwz;
            xwz = SlaughterDate.Text;
            DateTime endDate = Convert.ToDateTime(this.SlaughterDate.Text);


            endDate = endDate.AddDays(1);
            string query = "SELECT SlaughterTime,ItemNo as Prodcode,vendorno as SuppCode,ReceiptNo,TotalWeight FROM [dbo].[SlaughterDatasummarry]";
            query += " WHERE SlaughterTime >='" + xwz + "'"
                 + " AND  SlaughterTime<='" + endDate.ToString("dd/MMM/yyyy 00:00:00") + "' AND VendorNo LIKE '%' + @VendorNo + '%' ";
            //query += " OR @VendorNo = ''";
          
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@VendorNo", Txtrecptno.Text.Trim());
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                        
                     
                    }
                }
            }
            
        }

        private void Txtrecptno_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.PopulateDataGridView();
            Totalweighedpervendor();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void slaughterDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
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
               
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy4ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
    

