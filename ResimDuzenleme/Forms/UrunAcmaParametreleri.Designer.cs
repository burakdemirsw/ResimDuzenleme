namespace ResimDuzenleme
{
    partial class UrunAcmaParametreleri
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
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSirketKodu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.txtResimYolu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNebimUrl = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(112, 8);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(418, 20);
            this.txtDatabase.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database :";
            // 
            // txtSirketKodu
            // 
            this.txtSirketKodu.Location = new System.Drawing.Point(112, 34);
            this.txtSirketKodu.Name = "txtSirketKodu";
            this.txtSirketKodu.Size = new System.Drawing.Size(418, 20);
            this.txtSirketKodu.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şirket Kodu :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(518, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(455, 118);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnsil
            // 
            this.btnsil.Location = new System.Drawing.Point(455, 300);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(75, 23);
            this.btnsil.TabIndex = 4;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // txtResimYolu
            // 
            this.txtResimYolu.Location = new System.Drawing.Point(112, 57);
            this.txtResimYolu.Name = "txtResimYolu";
            this.txtResimYolu.Size = new System.Drawing.Size(418, 20);
            this.txtResimYolu.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nebim Dosya Yolu :";
            // 
            // txtNebimUrl
            // 
            this.txtNebimUrl.Location = new System.Drawing.Point(112, 83);
            this.txtNebimUrl.Name = "txtNebimUrl";
            this.txtNebimUrl.Size = new System.Drawing.Size(418, 20);
            this.txtNebimUrl.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 86);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(59, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Nebim Url :";
            // 
            // UrunAcmaParametreleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 327);
            this.Controls.Add(this.btnsil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNebimUrl);
            this.Controls.Add(this.txtResimYolu);
            this.Controls.Add(this.txtSirketKodu);
            this.Controls.Add(this.txtDatabase);
            this.Name = "UrunAcmaParametreleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UrunAcmaParametreleri";
            this.Load += new System.EventHandler(this.UrunAcmaParametreleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSirketKodu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.TextBox txtResimYolu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNebimUrl;
        private System.Windows.Forms.Label label;
    }
}