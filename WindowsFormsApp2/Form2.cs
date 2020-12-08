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
    public partial class Form2 : Form
    {
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=50;";
        public Form2()
        {
            InitializeComponent();
            // initialize settings

            ScaleID.Text = Properties.Settings.Default.ScaleLID;
            BaudRate.Text = Properties.Settings.Default.BaudRate;
            COMPort.Text = Properties.Settings.Default.COMPort;
            Database.Text = Properties.Settings.Default.Database;
            Server.Text = Properties.Settings.Default.Server;
            UserName.Text = Properties.Settings.Default.UserName;
            Password.Text = Properties.Settings.Default.Password;
            user.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            userrole.Items.Add("Admin");
            userrole.Items.Add("Supervisor");
            userrole.Items.Add("Slaughter");
            userrole.Text = "Slaughter";
            loaddata();
        }

        private void SaveScaleSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ScaleLID = ScaleID.Text;
            Properties.Settings.Default.BaudRate = BaudRate.Text;
            Properties.Settings.Default.COMPort=COMPort.Text;
            MessageBox.Show("Scale Settings Saved Successfully");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Database = Database.Text;
            Properties.Settings.Default.Server= Server.Text;
            Properties.Settings.Default.UserName = UserName.Text;
            Properties.Settings.Default.Password = Password.Text;
            MessageBox.Show("Database Settings Saved Successfully");

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.

                userrole.Text = row.Cells[2].Value.ToString();
                user.Text = row.Cells[1].Value.ToString();

            }
        }
        private void loaddata()
        {

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
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

                String q = "select [Created] AS 'Created On',Adname as 'AD Name',Role As 'User Role' from users";

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

                this.dataGridView1.DataSource = table;

            }
            //MessageBox.Show(Sla

        }
        private void Savedata_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))

            {
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [dbo].[users] WHERE ([Adname] = @user)", conn);
                check_User_Name.Parameters.AddWithValue("@user", user.Text);
                conn.Open();
                int UserExist = (int)check_User_Name.ExecuteScalar();

                if (UserExist > 0)
                {
                    MessageBox.Show(user.Text + " Already Exists");
                    loaddata();
                }
                else
                {
                    conn.Close();
                    //insert the record
                    String q5 = " set ANSI_WARNINGS OFF INSERT INTO [dbo].[users](Adname,[Role],[Created])" +
                              "VALUES ('" + user.Text + "','"
                                + userrole.Text + "','"
                                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    using (SqlCommand cmd = new SqlCommand(q5, conn))
                    {
                        try
                        {
                            conn.Open();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "Error 8");

                            return;
                        }
                        try
                        {

                            cmd.ExecuteNonQuery();
                            MessageBox.Show(user.Text + "  Has Been Added  Succesfully");
                            loaddata();

                            //AW = Convert.ToDouble(SideA.Text = "0.0");
                            //BW = Convert.ToDouble(SideB.Text = "0.0");
                            //TT = Convert.ToDouble(Total.Text = "0.0");
                            //WT=  Convert.ToDouble(Weight.Text = "0.0");





                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + "Error 11");
                        }
                        conn.Close();
                    }
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))

                {
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [dbo].[users] WHERE ([Adname] = @user)", conn);
                    check_User_Name.Parameters.AddWithValue("@user", user.Text);
                    conn.Open();
                    int UserExist = (int)check_User_Name.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        {
                            conn.Close();
                            //insert the record
                            String q5 = "set ANSI_WARNINGS OFF update [dbo].[users] set [Role]='" + userrole.Text + "',[Created]='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where Adname='" + user.Text + "'";
                            using (SqlCommand cmd = new SqlCommand(q5, conn))
                            {
                                try
                                {
                                    conn.Open();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + "Error 8");

                                    return;
                                }
                                try
                                {

                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show(user.Text + "  User Role Updated succesfully");
                                    loaddata();

                                    //AW = Convert.ToDouble(SideA.Text = "0.0");
                                    //BW = Convert.ToDouble(SideB.Text = "0.0");
                                    //TT = Convert.ToDouble(Total.Text = "0.0");
                                    //WT=  Convert.ToDouble(Weight.Text = "0.0");





                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message + "Error 11");
                                }
                                conn.Close();
                            }
                        }
                    }
                    else
                    {
                        //insert the record
                        MessageBox.Show(user.Text + " Does Not Exist Exists Add The User Before Updating");
                        loaddata();

                    }
                }
            }














        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
