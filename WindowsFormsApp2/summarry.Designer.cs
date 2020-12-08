namespace WindowsFormsApp2
{
    partial class summarry
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(summarry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SlaughterDateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.totalw = new System.Windows.Forms.TextBox();
            this.ExportExcel = new System.Windows.Forms.Button();
            this.SlaughterDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvbaconers = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SOWS = new System.Windows.Forms.GroupBox();
            this.dgvsows = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbaconers)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SOWS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsows)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SlaughterDateTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.totalw);
            this.groupBox1.Controls.Add(this.ExportExcel);
            this.groupBox1.Controls.Add(this.SlaughterDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // SlaughterDateTo
            // 
            this.SlaughterDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaughterDateTo.Location = new System.Drawing.Point(298, 14);
            this.SlaughterDateTo.Name = "SlaughterDateTo";
            this.SlaughterDateTo.Size = new System.Drawing.Size(153, 20);
            this.SlaughterDateTo.TabIndex = 33;
            this.SlaughterDateTo.ValueChanged += new System.EventHandler(this.SlaughterDateTo_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "To Date:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(627, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Export To PDF";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(457, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Export To Excel Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // totalw
            // 
            this.totalw.Location = new System.Drawing.Point(770, 16);
            this.totalw.Name = "totalw";
            this.totalw.ReadOnly = true;
            this.totalw.Size = new System.Drawing.Size(105, 20);
            this.totalw.TabIndex = 27;
            this.totalw.Visible = false;
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
            // 
            // SlaughterDate
            // 
            this.SlaughterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaughterDate.Location = new System.Drawing.Point(77, 13);
            this.SlaughterDate.Name = "SlaughterDate";
            this.SlaughterDate.Size = new System.Drawing.Size(153, 20);
            this.SlaughterDate.TabIndex = 1;
            this.SlaughterDate.ValueChanged += new System.EventHandler(this.SlaughterDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date:";
            // 
            // dgvbaconers
            // 
            this.dgvbaconers.BackgroundColor = System.Drawing.Color.White;
            this.dgvbaconers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbaconers.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbaconers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvbaconers.Location = new System.Drawing.Point(6, 19);
            this.dgvbaconers.Name = "dgvbaconers";
            this.dgvbaconers.Size = new System.Drawing.Size(343, 268);
            this.dgvbaconers.TabIndex = 2;
            this.dgvbaconers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvbaconers);
            this.groupBox2.Location = new System.Drawing.Point(14, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 293);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BACONERS";
            // 
            // SOWS
            // 
            this.SOWS.Controls.Add(this.dgvsows);
            this.SOWS.Location = new System.Drawing.Point(405, 69);
            this.SOWS.Name = "SOWS";
            this.SOWS.Size = new System.Drawing.Size(372, 293);
            this.SOWS.TabIndex = 4;
            this.SOWS.TabStop = false;
            this.SOWS.Text = "SOWS";
            // 
            // dgvsows
            // 
            this.dgvsows.BackgroundColor = System.Drawing.Color.White;
            this.dgvsows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvsows.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsows.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvsows.Location = new System.Drawing.Point(6, 19);
            this.dgvsows.Name = "dgvsows";
            this.dgvsows.Size = new System.Drawing.Size(343, 268);
            this.dgvsows.TabIndex = 2;
            // 
            // summarry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(794, 374);
            this.Controls.Add(this.SOWS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "summarry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pork Breaking Report";
            this.Load += new System.EventHandler(this.summarry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbaconers)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.SOWS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox totalw;
        private System.Windows.Forms.Button ExportExcel;
        private System.Windows.Forms.DateTimePicker SlaughterDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvbaconers;
        private System.Windows.Forms.DateTimePicker SlaughterDateTo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox SOWS;
        private System.Windows.Forms.DataGridView dgvsows;
    }
}