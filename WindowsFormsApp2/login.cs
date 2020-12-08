using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;

namespace WindowsFormsApp2
{
    public partial class login : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32")]
        static extern bool Wow64DisableWow64FsRedirection(ref long oldvalue);
        [System.Runtime.InteropServices.DllImport("kernel32")]
        static extern bool Wow64EnableWow64FsRedirection(ref long oldvalue);
        private string osk = @"C:\Windows\System32\osk.exe";
        public static string loginusername = "";
        public login()
        {
            InitializeComponent();
        }
        public bool AuthenticateUser()
        {
            string path = Properties.Settings.Default.domain;
            string user = txtusername.Text;
            string pass = Txtpassword.Text;
        
            // ' MDIParent1.MdiChildren = Me
            DirectoryEntry de = new DirectoryEntry(path, user, pass, AuthenticationTypes.Secure);
            try
            {

                // run a search using those credentials.  
                // If it returns anything, then you're authenticated
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.FindOne();
                // ' MessageBox.Show("welcome")
                loginusername = txtusername.Text;
                Form1 main = new Form1();
               
    {       
        // do something here....    

    }
                main.Show();
                this.Hide();


                return true;
            }



            catch
            {
                // otherwise, it will crash out so return false



                MessageBox.Show("PLEASE CONFIRM IF YOU HAVE BEEN SET UP AS A VALID USER", "FARMERS BUTCHERY SYSTEM");


                return false;
            }
        }

        private void Btnok_Click(object sender, EventArgs e)

        {

            string path = Properties.Settings.Default.domain;
            string user = txtusername.Text;
            string pass = Txtpassword.Text;

            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "Farmerschoice.local"))
            {
                using (UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, user))
                {
                    if (usr.IsAccountLockedOut())
                    {
                        MessageBox.Show("Your Account Has Been LOCKED");
                    }
                    else
                    {
                        AuthenticateUser();
                    }
                    //Gets if account is locked out
                }
            }
          
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void login_Load(object sender, EventArgs e)
        {
            {
                txtusername.GotFocus += txtusername_GotFocus;
                Txtpassword.GotFocus += txtpassword_GotFocus;
            }

        }

        private void txtpassword_GotFocus(object sender, EventArgs e)
        {
            {
                if (txtusername.Text == "")
                {
                    var old = default(long);
                    if (Environment.Is64BitOperatingSystem)
                    {
                        System.Diagnostics.Process.Start(@"C:\Windows\WinSxS\amd64_microsoft-windows-osk_31bf3856ad364e35_10.0.18362.449_none_0098d787eb84df09\osk.exe");



                    }
                    else
                    {
                        System.Diagnostics.Process.Start(osk);


                    }
                }
            }
        }

        private void txtusername_GotFocus(object sender, EventArgs e)
        {
            {
                if (txtusername.Text == "")
                {
                    var old = default(long);
                    if (Environment.Is64BitOperatingSystem)
                    {
                        System.Diagnostics.Process.Start(@"C:\Windows\WinSxS\amd64_microsoft-windows-osk_31bf3856ad364e35_10.0.18362.449_none_0098d787eb84df09\osk.exe");



                    }
                    else
                    {
                        System.Diagnostics.Process.Start(osk);


                    }
                }
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Txtpassword.Focus();

            }
        }

        private void Txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AuthenticateUser();

            }
        }

        private void showpwd_CheckedChanged(object sender, EventArgs e)
        {
           Txtpassword.PasswordChar = showpwd.Checked ? '\0' : '*';
        }
    }
}
