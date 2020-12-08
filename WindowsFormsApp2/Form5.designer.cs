
namespace WindowsFormsApp2
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtrecptno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.totalw = new System.Windows.Forms.TextBox();
            this.ExportExcel = new System.Windows.Forms.Button();
            this.ExportTextFile = new System.Windows.Forms.Button();
            this.SlaughterDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.slaughterDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._fcl_weighDataSet4 = new WindowsFormsApp2._fcl_weighDataSet4();
            this.slaughterDataTableAdapter = new WindowsFormsApp2._fcl_weighDataSet4TableAdapters.SlaughterDataTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slaughterDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txtrecptno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.totalw);
            this.groupBox1.Controls.Add(this.ExportExcel);
            this.groupBox1.Controls.Add(this.ExportTextFile);
            this.groupBox1.Controls.Add(this.SlaughterDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(69, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Total Weighed";
            // 
            // Txtrecptno
            // 
            this.Txtrecptno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Txtrecptno.Location = new System.Drawing.Point(136, 43);
            this.Txtrecptno.Name = "Txtrecptno";
            this.Txtrecptno.Size = new System.Drawing.Size(195, 20);
            this.Txtrecptno.TabIndex = 31;
            this.Txtrecptno.TextChanged += new System.EventHandler(this.Txtrecptno_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Vendor  Number";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(531, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Export To PDF";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(531, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Export Detail Report Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // totalw
            // 
            this.totalw.Location = new System.Drawing.Point(444, 44);
            this.totalw.Name = "totalw";
            this.totalw.ReadOnly = true;
            this.totalw.Size = new System.Drawing.Size(71, 20);
            this.totalw.TabIndex = 27;
            // 
            // ExportExcel
            // 
            this.ExportExcel.Location = new System.Drawing.Point(888, 50);
            this.ExportExcel.Name = "ExportExcel";
            this.ExportExcel.Size = new System.Drawing.Size(17, 23);
            this.ExportExcel.TabIndex = 3;
            this.ExportExcel.Text = "Export Excel";
            this.ExportExcel.UseVisualStyleBackColor = true;
            this.ExportExcel.Visible = false;
            this.ExportExcel.Click += new System.EventHandler(this.ExportExcel_Click);
            // 
            // ExportTextFile
            // 
            this.ExportTextFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ExportTextFile.Location = new System.Drawing.Point(365, 15);
            this.ExportTextFile.Name = "ExportTextFile";
            this.ExportTextFile.Size = new System.Drawing.Size(150, 23);
            this.ExportTextFile.TabIndex = 2;
            this.ExportTextFile.Text = "ExportTextFile";
            this.ExportTextFile.UseVisualStyleBackColor = false;
            this.ExportTextFile.Click += new System.EventHandler(this.ExportTextFile_Click);
            // 
            // SlaughterDate
            // 
            this.SlaughterDate.Location = new System.Drawing.Point(138, 15);
            this.SlaughterDate.Name = "SlaughterDate";
            this.SlaughterDate.Size = new System.Drawing.Size(194, 20);
            this.SlaughterDate.TabIndex = 1;
            this.SlaughterDate.ValueChanged += new System.EventHandler(this.SlaughterDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Slaughter Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // slaughterDataBindingSource
            // 
            this.slaughterDataBindingSource.DataMember = "SlaughterData";
            this.slaughterDataBindingSource.DataSource = this._fcl_weighDataSet4;
            this.slaughterDataBindingSource.CurrentChanged += new System.EventHandler(this.slaughterDataBindingSource_CurrentChanged);
            // 
            // _fcl_weighDataSet4
            // 
            this._fcl_weighDataSet4.DataSetName = "_fcl_weighDataSet4";
            this._fcl_weighDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // slaughterDataTableAdapter
            // 
            this.slaughterDataTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.Location = new System.Drawing.Point(82, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(638, 378);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 472);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slaughter Data";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slaughterDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker SlaughterDate;
        private System.Windows.Forms.Label label1;
        private _fcl_weighDataSet4 _fcl_weighDataSet4;
        private System.Windows.Forms.BindingSource slaughterDataBindingSource;
        private _fcl_weighDataSet4TableAdapters.SlaughterDataTableAdapter slaughterDataTableAdapter;
        private System.Windows.Forms.Button ExportTextFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlaughterTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button ExportExcel;
		private System.Windows.Forms.TextBox totalw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txtrecptno;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}