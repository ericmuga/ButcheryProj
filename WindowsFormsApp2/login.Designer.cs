namespace WindowsFormsApp2
{
    partial class login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.Btnok = new System.Windows.Forms.Button();
            this.Txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Netweight = new System.Windows.Forms.Label();
            this.showpwd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Btnok
            // 
            this.Btnok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Btnok.Location = new System.Drawing.Point(132, 107);
            this.Btnok.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.Btnok.Name = "Btnok";
            this.Btnok.Size = new System.Drawing.Size(147, 30);
            this.Btnok.TabIndex = 44;
            this.Btnok.Text = "LOGIN";
            this.Btnok.UseVisualStyleBackColor = false;
            this.Btnok.Click += new System.EventHandler(this.Btnok_Click);
            // 
            // Txtpassword
            // 
            this.Txtpassword.Location = new System.Drawing.Point(105, 78);
            this.Txtpassword.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.Txtpassword.Name = "Txtpassword";
            this.Txtpassword.PasswordChar = '*';
            this.Txtpassword.Size = new System.Drawing.Size(222, 20);
            this.Txtpassword.TabIndex = 43;
            this.Txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtpassword_KeyDown);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(105, 22);
            this.txtusername.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(222, 20);
            this.txtusername.TabIndex = 42;
            this.txtusername.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            this.txtusername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtusername_KeyDown);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Red;
            this.Label8.Location = new System.Drawing.Point(3, 81);
            this.Label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(65, 13);
            this.Label8.TabIndex = 41;
            this.Label8.Text = "Password:";
            // 
            // Netweight
            // 
            this.Netweight.AutoSize = true;
            this.Netweight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Netweight.ForeColor = System.Drawing.Color.Red;
            this.Netweight.Location = new System.Drawing.Point(3, 25);
            this.Netweight.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Netweight.Name = "Netweight";
            this.Netweight.Size = new System.Drawing.Size(73, 13);
            this.Netweight.TabIndex = 40;
            this.Netweight.Text = "User Name:";
            // 
            // showpwd
            // 
            this.showpwd.AutoSize = true;
            this.showpwd.Location = new System.Drawing.Point(12, 115);
            this.showpwd.Name = "showpwd";
            this.showpwd.Size = new System.Drawing.Size(102, 17);
            this.showpwd.TabIndex = 45;
            this.showpwd.Text = "Show Password";
            this.showpwd.UseVisualStyleBackColor = true;
            this.showpwd.CheckedChanged += new System.EventHandler(this.showpwd_CheckedChanged);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(342, 148);
            this.Controls.Add(this.showpwd);
            this.Controls.Add(this.Btnok);
            this.Controls.Add(this.Txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Netweight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Btnok;
        internal System.Windows.Forms.TextBox Txtpassword;
        internal System.Windows.Forms.TextBox txtusername;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Netweight;
        private System.Windows.Forms.CheckBox showpwd;
    }
}