namespace WindowsFormsApp2
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ImportPath = new System.Windows.Forms.TextBox();
            this.BrowseImportFile = new System.Windows.Forms.Button();
            this.dgvdetails = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtbom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.lbltrid = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.inputtype = new System.Windows.Forms.ComboBox();
            this.producttype = new System.Windows.Forms.ComboBox();
            this.txtitemno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtpname = new System.Windows.Forms.TextBox();
            this.txtsearchname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtsearchno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsearchbom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ImportPath);
            this.groupBox1.Controls.Add(this.BrowseImportFile);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 488);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(107, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "BATCH IMPORT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImportPath
            // 
            this.ImportPath.Location = new System.Drawing.Point(87, 19);
            this.ImportPath.Name = "ImportPath";
            this.ImportPath.Size = new System.Drawing.Size(182, 20);
            this.ImportPath.TabIndex = 2;
            this.ImportPath.TextChanged += new System.EventHandler(this.ImportPath_TextChanged);
            // 
            // BrowseImportFile
            // 
            this.BrowseImportFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BrowseImportFile.Location = new System.Drawing.Point(6, 16);
            this.BrowseImportFile.Name = "BrowseImportFile";
            this.BrowseImportFile.Size = new System.Drawing.Size(75, 23);
            this.BrowseImportFile.TabIndex = 1;
            this.BrowseImportFile.Text = "Browse";
            this.BrowseImportFile.UseVisualStyleBackColor = false;
            this.BrowseImportFile.Click += new System.EventHandler(this.BrowseImportFile_Click);
            // 
            // dgvdetails
            // 
            this.dgvdetails.AllowUserToDeleteRows = false;
            this.dgvdetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvdetails.Location = new System.Drawing.Point(6, 12);
            this.dgvdetails.Name = "dgvdetails";
            this.dgvdetails.Size = new System.Drawing.Size(877, 286);
            this.dgvdetails.TabIndex = 4;
            this.dgvdetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvdetails.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdetails_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvdetails);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(35, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 304);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtbom);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtbarcode);
            this.groupBox3.Controls.Add(this.lbltrid);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.inputtype);
            this.groupBox3.Controls.Add(this.producttype);
            this.groupBox3.Controls.Add(this.txtitemno);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.txtpname);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(42, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(888, 132);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtbom
            // 
            this.txtbom.Location = new System.Drawing.Point(672, 16);
            this.txtbom.Name = "txtbom";
            this.txtbom.Size = new System.Drawing.Size(210, 20);
            this.txtbom.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(581, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "BOM:";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button6.Location = new System.Drawing.Point(9, 95);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 32);
            this.button6.TabIndex = 75;
            this.button6.Text = "NEW PRODUCT";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(581, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "BARCODE:";
            // 
            // txtbarcode
            // 
            this.txtbarcode.Location = new System.Drawing.Point(672, 68);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Size = new System.Drawing.Size(210, 20);
            this.txtbarcode.TabIndex = 73;
            this.txtbarcode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbltrid
            // 
            this.lbltrid.AutoSize = true;
            this.lbltrid.Location = new System.Drawing.Point(713, 105);
            this.lbltrid.Name = "lbltrid";
            this.lbltrid.Size = new System.Drawing.Size(0, 13);
            this.lbltrid.TabIndex = 72;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.Location = new System.Drawing.Point(738, 94);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 32);
            this.button5.TabIndex = 71;
            this.button5.Text = "PRINT BARCODE";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button4.Location = new System.Drawing.Point(540, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 32);
            this.button4.TabIndex = 70;
            this.button4.Text = "DELETE  PRODUCT";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(346, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 32);
            this.button3.TabIndex = 69;
            this.button3.Text = "UPDATE PRODUCT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(182, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "SAVE PRODUCT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // inputtype
            // 
            this.inputtype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.inputtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputtype.Location = new System.Drawing.Point(412, 15);
            this.inputtype.Name = "inputtype";
            this.inputtype.Size = new System.Drawing.Size(157, 21);
            this.inputtype.TabIndex = 68;
            this.inputtype.SelectedIndexChanged += new System.EventHandler(this.inputtype_SelectedIndexChanged);
            // 
            // producttype
            // 
            this.producttype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.producttype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.producttype.Location = new System.Drawing.Point(141, 15);
            this.producttype.Name = "producttype";
            this.producttype.Size = new System.Drawing.Size(122, 21);
            this.producttype.TabIndex = 67;
            // 
            // txtitemno
            // 
            this.txtitemno.Location = new System.Drawing.Point(141, 68);
            this.txtitemno.Name = "txtitemno";
            this.txtitemno.Size = new System.Drawing.Size(128, 20);
            this.txtitemno.TabIndex = 66;
            this.txtitemno.TextChanged += new System.EventHandler(this.txtitemno_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(273, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 65;
            this.label3.Text = "INPUT TYPE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "ITEM CODE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "PRODUCT TYPE:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(279, 69);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(133, 16);
            this.label30.TabIndex = 62;
            this.label30.Text = "PRODUCT NAME:";
            this.label30.Click += new System.EventHandler(this.label30_Click);
            // 
            // txtpname
            // 
            this.txtpname.Location = new System.Drawing.Point(418, 68);
            this.txtpname.Name = "txtpname";
            this.txtpname.Size = new System.Drawing.Size(157, 20);
            this.txtpname.TabIndex = 2;
            this.txtpname.TextChanged += new System.EventHandler(this.txtpname_TextChanged);
            // 
            // txtsearchname
            // 
            this.txtsearchname.Location = new System.Drawing.Point(431, 154);
            this.txtsearchname.Name = "txtsearchname";
            this.txtsearchname.Size = new System.Drawing.Size(209, 20);
            this.txtsearchname.TabIndex = 79;
            this.txtsearchname.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(286, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "Search Item Name:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtsearchno
            // 
            this.txtsearchno.Location = new System.Drawing.Point(110, 154);
            this.txtsearchno.Name = "txtsearchno";
            this.txtsearchno.Size = new System.Drawing.Size(170, 20);
            this.txtsearchno.TabIndex = 81;
            this.txtsearchno.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(39, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 80;
            this.label7.Text = "Item No:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtsearchbom
            // 
            this.txtsearchbom.Location = new System.Drawing.Point(696, 154);
            this.txtsearchbom.Name = "txtsearchbom";
            this.txtsearchbom.Size = new System.Drawing.Size(228, 20);
            this.txtsearchbom.TabIndex = 79;
            this.txtsearchbom.TextChanged += new System.EventHandler(this.txtsearchbom_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(646, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "Barc:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 570);
            this.Controls.Add(this.txtsearchbom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtsearchno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtsearchname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADD PRODUCTS";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ImportPath;
        private System.Windows.Forms.Button BrowseImportFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvdetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtpname;
        private System.Windows.Forms.TextBox txtitemno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox inputtype;
        private System.Windows.Forms.ComboBox producttype;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lbltrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtbom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtsearchname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsearchno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsearchbom;
        private System.Windows.Forms.Label label8;
    }
}