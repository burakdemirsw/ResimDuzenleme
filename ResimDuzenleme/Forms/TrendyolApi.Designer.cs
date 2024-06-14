namespace ResimDuzenleme
{
    partial class TrendyolApi
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.TxtSatici = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "API Secret";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Satıcı ID (Cari ID)";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(102, 24);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(304, 20);
            this.txtApiKey.TabIndex = 1;
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(102, 58);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.Size = new System.Drawing.Size(304, 20);
            this.txtApiSecret.TabIndex = 1;
            // 
            // TxtSatici
            // 
            this.TxtSatici.Location = new System.Drawing.Point(102, 87);
            this.TxtSatici.Name = "TxtSatici";
            this.TxtSatici.Size = new System.Drawing.Size(304, 20);
            this.TxtSatici.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TrendyolApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 141);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtSatici);
            this.Controls.Add(this.txtApiSecret);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TrendyolApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "t";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrendyolApi_FormClosing);
            this.Load += new System.EventHandler(this.TrendyolApi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.TextBox txtApiSecret;
        private System.Windows.Forms.TextBox TxtSatici;
        private System.Windows.Forms.Button button1;
    }
}