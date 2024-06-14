namespace ResimDuzenleme
{
    partial class FrmIrsaliyeFaturalastirTekli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIrsaliyeFaturalastirTekli));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnkaydet = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(539, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 23);
            this.simpleButton1.TabIndex = 23;
            this.simpleButton1.Text = "Sipariş Seç";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(15, 72);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 22;
            // 
            // btnkaydet
            // 
            this.btnkaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnkaydet.ImageOptions.Image")));
            this.btnkaydet.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnkaydet.Location = new System.Drawing.Point(616, 12);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(349, 48);
            this.btnkaydet.TabIndex = 21;
            this.btnkaydet.Text = "Fatura Oluştur";
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Fatura No veya Sipariş Numarasını Yazın :";
            // 
            // FrmIrsaliyeFaturalastirTekli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 104);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnkaydet);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "FrmIrsaliyeFaturalastirTekli";
            this.Text = "FrmIrsaliyeFaturalastirTekli";
            this.Load += new System.EventHandler(this.FrmIrsaliyeFaturalastirTekli_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label labelStatus;
        private DevExpress.XtraEditors.SimpleButton btnkaydet;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}