namespace ResimDuzenleme
{
    partial class QROlusturma
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnQRcek = new System.Windows.Forms.Button();
            this.btnQRServisKontrol = new System.Windows.Forms.Button();
            this.btnUrunleriCek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnQRcek
            // 
            this.btnQRcek.Location = new System.Drawing.Point(118, 12);
            this.btnQRcek.Name = "btnQRcek";
            this.btnQRcek.Size = new System.Drawing.Size(141, 20);
            this.btnQRcek.TabIndex = 1;
            this.btnQRcek.Text = "QR OLUŞTUR";
            this.btnQRcek.UseVisualStyleBackColor = true;
            this.btnQRcek.Click += new System.EventHandler(this.btnQRcek_Click);
            // 
            // btnQRServisKontrol
            // 
            this.btnQRServisKontrol.Location = new System.Drawing.Point(12, 63);
            this.btnQRServisKontrol.Name = "btnQRServisKontrol";
            this.btnQRServisKontrol.Size = new System.Drawing.Size(247, 23);
            this.btnQRServisKontrol.TabIndex = 2;
            this.btnQRServisKontrol.Text = "TOPLU QR OLUŞTUR";
            this.btnQRServisKontrol.UseVisualStyleBackColor = true;
            this.btnQRServisKontrol.Click += new System.EventHandler(this.btnQRServisKontrol_Click);
            // 
            // btnUrunleriCek
            // 
            this.btnUrunleriCek.Location = new System.Drawing.Point(13, 34);
            this.btnUrunleriCek.Name = "btnUrunleriCek";
            this.btnUrunleriCek.Size = new System.Drawing.Size(246, 23);
            this.btnUrunleriCek.TabIndex = 3;
            this.btnUrunleriCek.Text = "SİTEDEN ÜRÜNLERİ ÇEK";
            this.btnUrunleriCek.UseVisualStyleBackColor = true;
            this.btnUrunleriCek.Click += new System.EventHandler(this.btnUrunleriCek_Click);
            // 
            // QROlusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 98);
            this.Controls.Add(this.btnUrunleriCek);
            this.Controls.Add(this.btnQRServisKontrol);
            this.Controls.Add(this.btnQRcek);
            this.Controls.Add(this.textBox1);
            this.Name = "QROlusturma";
            this.Text = "QROlusturma";
            this.Load += new System.EventHandler(this.QROlusturma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnQRcek;
        private System.Windows.Forms.Button btnQRServisKontrol;
        private System.Windows.Forms.Button btnUrunleriCek;
    }
}