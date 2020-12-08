using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class userfrm : Form
    {
        string _connectionString = $"Server={Properties.Settings.Default.Server};Initial Catalog={Properties.Settings.Default.Database};Persist Security Info=False;User ID={Properties.Settings.Default.UserName};Password={Properties.Settings.Default.Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=50;";
        
        public userfrm()
        {
            InitializeComponent();
            user.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        }

        private void CrateWeight_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Userfrm_Load(object sender, EventArgs e)
        {
            userrole.Items.Add("Admin");
            userrole.Items.Add("Supervisor");
            userrole.Items.Add("Slaughter");
            userrole.Text = "Slaughter";
            loaddata();

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

        private void Refresh_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))

            {
                SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [dbo].[users] WHERE ([Adname] = @user)", conn);
                check_User_Name.Parameters.AddWithValue("@user", user.Text);
                conn.Open();
                int UserExist = (int)check_User_Name.ExecuteScalar();

                if (UserExist > 0)
                {
                    MessageBox.Show(user.Text +" Already Exists");
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
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
}
