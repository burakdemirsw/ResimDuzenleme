namespace ResimDuzenleme
{
    partial class frmFaturalastir
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnFaturalastir = new System.Windows.Forms.Button();
            this.BtnFaturaGoster = new System.Windows.Forms.Button();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura veya Kargo Kodu:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 311);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnFaturalastir
            // 
            this.btnFaturalastir.Location = new System.Drawing.Point(12, 51);
            this.btnFaturalastir.Name = "btnFaturalastir";
            this.btnFaturalastir.Size = new System.Drawing.Size(784, 23);
            this.btnFaturalastir.TabIndex = 3;
            this.btnFaturalastir.Text = "Nebim V3 Faturalaştır";
            this.btnFaturalastir.UseVisualStyleBackColor = true;
            this.btnFaturalastir.Click += new System.EventHandler(this.btnFaturalastir_Click);
            // 
            // BtnFaturaGoster
            // 
            this.BtnFaturaGoster.Location = new System.Drawing.Point(385, 81);
            this.BtnFaturaGoster.Name = "BtnFaturaGoster";
            this.BtnFaturaGoster.Size = new System.Drawing.Size(411, 23);
            this.BtnFaturaGoster.TabIndex = 4;
            this.BtnFaturaGoster.Text = "Fatura Göster";
            this.BtnFaturaGoster.UseVisualStyleBackColor = true;
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(13, 83);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(366, 20);
            this.txtFaturaNo.TabIndex = 5;
            this.txtFaturaNo.Text = "Lütfen Fatura veya Kargo Kodu Okutun";
            this.txtFaturaNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtFaturaNo_MouseClick);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 430);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 6;
            // 
            // frmFaturalastir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.txtFaturaNo);
            this.Controls.Add(this.BtnFaturaGoster);
            this.Controls.Add(this.btnFaturalastir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmFaturalastir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faturalaştırma Ekranı";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFaturalastir;
        private System.Windows.Forms.Button BtnFaturaGoster;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.Label labelStatus;
    }
}