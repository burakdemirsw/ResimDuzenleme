namespace ResimDuzenleme
{
    partial class FrmAlisSiparis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlisSiparis));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnkaydet = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEdit1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(539, 49);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 23);
            this.simpleButton1.TabIndex = 24;
            this.simpleButton1.Text = "Sipariş Seç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(15, 66);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 23;
            // 
            // btnkaydet
            // 
            this.btnkaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnkaydet.ImageOptions.Image")));
            this.btnkaydet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnkaydet.Location = new System.Drawing.Point(616, 49);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(349, 48);
            this.btnkaydet.TabIndex = 22;
            this.btnkaydet.Text = "Fatura Oluştur";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Location = new System.Drawing.Point(7, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 395);
            this.panel1.TabIndex = 21;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(958, 395);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Transparent;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(300, 75);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(309, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(300, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Sipariş Barkod";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Fatura No veya Sipariş Numarasını Yazın :";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.EditValue = null;
            this.buttonEdit1.Location = new System.Drawing.Point(120, 12);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.buttonEdit1.Properties.OffText = "Pasif";
            this.buttonEdit1.Properties.OnText = "Aktif";
            this.buttonEdit1.Size = new System.Drawing.Size(100, 24);
            this.buttonEdit1.TabIndex = 25;
            this.buttonEdit1.Toggled += new System.EventHandler(this.buttonEdit1_Toggled);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Lot Barkod Okuma :";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(300, 101);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(309, 20);
            this.textBox4.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "E Fatura NO :";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.EditValue = null;
            this.toggleSwitch1.Location = new System.Drawing.Point(350, 12);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.toggleSwitch1.Properties.OffText = "Pasif";
            this.toggleSwitch1.Properties.OnText = "Aktif";
            this.toggleSwitch1.Size = new System.Drawing.Size(100, 24);
            this.toggleSwitch1.TabIndex = 25;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Raf Takip:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(208, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 20);
            this.textBox3.TabIndex = 28;
            this.textBox3.Visible = false;
            // 
            // FrmAlisSiparis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 537);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.buttonEdit1);
            this.Name = "FrmAlisSiparis";
            this.Text = "FrmAlisSiparis";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label labelStatus;
        private DevExpress.XtraEditors.SimpleButton btnkaydet;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ToggleSwitch buttonEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
    }
}