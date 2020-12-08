namespace WindowsFormsApp2
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Importdate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.receiptsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._fcl_weighDataSet = new WindowsFormsApp2._fcl_weighDataSet();
            this.receiptsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this._fcl_weighDataSet1 = new WindowsFormsApp2._fcl_weighDataSet1();
            this.receiptsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this._fcl_weighDataSet2 = new WindowsFormsApp2._fcl_weighDataSet2();
            this.receiptsBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this._fcl_weighDataSet3 = new WindowsFormsApp2._fcl_weighDataSet3();
            this.receiptsTableAdapter = new WindowsFormsApp2._fcl_weighDataSetTableAdapters.ReceiptsTableAdapter();
            this.receiptsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.receiptsTableAdapter1 = new WindowsFormsApp2._fcl_weighDataSet1TableAdapters.ReceiptsTableAdapter();
            this.receiptsTableAdapter2 = new WindowsFormsApp2._fcl_weighDataSet2TableAdapters.ReceiptsTableAdapter();
            this.receiptsTableAdapter3 = new WindowsFormsApp2._fcl_weighDataSet3TableAdapters.ReceiptsTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvdetails = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Importdate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox1.Location = new System.Drawing.Point(419, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search Vendor";
            // 
            // Importdate
            // 
            this.Importdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Importdate.Location = new System.Drawing.Point(107, 19);
            this.Importdate.Name = "Importdate";
            this.Importdate.Size = new System.Drawing.Size(200, 20);
            this.Importdate.TabIndex = 8;
            this.Importdate.TextChanged += new System.EventHandler(this.Importdate_TextChanged);
            this.Importdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Importdate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reciept No";
            // 
            // receiptsBindingSource
            // 
            this.receiptsBindingSource.DataMember = "Receipts";
            this.receiptsBindingSource.DataSource = this._fcl_weighDataSet;
            this.receiptsBindingSource.CurrentChanged += new System.EventHandler(this.receiptsBindingSource_CurrentChanged);
            // 
            // _fcl_weighDataSet
            // 
            this._fcl_weighDataSet.DataSetName = "_fcl_weighDataSet";
            this._fcl_weighDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // receiptsBindingSource2
            // 
            this.receiptsBindingSource2.DataMember = "Receipts";
            this.receiptsBindingSource2.DataSource = this._fcl_weighDataSet1;
            // 
            // _fcl_weighDataSet1
            // 
            this._fcl_weighDataSet1.DataSetName = "_fcl_weighDataSet1";
            this._fcl_weighDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // receiptsBindingSource3
            // 
            this.receiptsBindingSource3.DataMember = "Receipts";
            this.receiptsBindingSource3.DataSource = this._fcl_weighDataSet2;
            // 
            // _fcl_weighDataSet2
            // 
            this._fcl_weighDataSet2.DataSetName = "_fcl_weighDataSet2";
            this._fcl_weighDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // receiptsBindingSource4
            // 
            this.receiptsBindingSource4.DataMember = "Receipts";
            this.receiptsBindingSource4.DataSource = this._fcl_weighDataSet3;
            // 
            // _fcl_weighDataSet3
            // 
            this._fcl_weighDataSet3.DataSetName = "_fcl_weighDataSet3";
            this._fcl_weighDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // receiptsTableAdapter
            // 
            this.receiptsTableAdapter.ClearBeforeFill = true;
            // 
            // receiptsBindingSource1
            // 
            this.receiptsBindingSource1.DataMember = "Receipts";
            this.receiptsBindingSource1.DataSource = this._fcl_weighDataSet;
            // 
            // receiptsTableAdapter1
            // 
            this.receiptsTableAdapter1.ClearBeforeFill = true;
            // 
            // receiptsTableAdapter2
            // 
            this.receiptsTableAdapter2.ClearBeforeFill = true;
            // 
            // receiptsTableAdapter3
            // 
            this.receiptsTableAdapter3.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvdetails);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 297);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvdetails
            // 
            this.dgvdetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvdetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvdetails.Location = new System.Drawing.Point(0, 19);
            this.dgvdetails.Name = "dgvdetails";
            this.dgvdetails.Size = new System.Drawing.Size(645, 278);
            this.dgvdetails.TabIndex = 0;
            this.dgvdetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgvdetails_CellClick);
            this.dgvdetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdetails_CellContentClick);
            this.dgvdetails.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgvdetails_CellContentDoubleClick);
            this.dgvdetails.SelectionChanged += new System.EventHandler(this.Dgvdetails_SelectionChanged);
            this.dgvdetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Dgvdetails_MouseDoubleClick);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox2.Location = new System.Drawing.Point(593, 376);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 11;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 384);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imported Receipts";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fcl_weighDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private _fcl_weighDataSet _fcl_weighDataSet;
        private System.Windows.Forms.BindingSource receiptsBindingSource;
        private _fcl_weighDataSetTableAdapters.ReceiptsTableAdapter receiptsTableAdapter;
        private System.Windows.Forms.BindingSource receiptsBindingSource1;
        private _fcl_weighDataSet1 _fcl_weighDataSet1;
        private System.Windows.Forms.BindingSource receiptsBindingSource2;
        private _fcl_weighDataSet1TableAdapters.ReceiptsTableAdapter receiptsTableAdapter1;
        private _fcl_weighDataSet2 _fcl_weighDataSet2;
        private System.Windows.Forms.BindingSource receiptsBindingSource3;
        private _fcl_weighDataSet2TableAdapters.ReceiptsTableAdapter receiptsTableAdapter2;
        private _fcl_weighDataSet3 _fcl_weighDataSet3;
        private System.Windows.Forms.BindingSource receiptsBindingSource4;
        private _fcl_weighDataSet3TableAdapters.ReceiptsTableAdapter receiptsTableAdapter3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvdetails;
        private System.Windows.Forms.TextBox Importdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}