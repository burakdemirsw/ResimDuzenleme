namespace ResimDuzenleme
{
    partial class ExcelIslemleri
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
            this.btnCsvaktar = new System.Windows.Forms.Button();
            this.txtSpgetir = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCsvaktar
            // 
            this.btnCsvaktar.Location = new System.Drawing.Point(216, 94);
            this.btnCsvaktar.Name = "btnCsvaktar";
            this.btnCsvaktar.Size = new System.Drawing.Size(186, 22);
            this.btnCsvaktar.TabIndex = 18;
            this.btnCsvaktar.Text = "Csv Aktar";
            this.btnCsvaktar.UseVisualStyleBackColor = true;
            this.btnCsvaktar.Click += new System.EventHandler(this.btnCsvaktar_Click);
            // 
            // txtSpgetir
            // 
            this.txtSpgetir.Location = new System.Drawing.Point(12, 94);
            this.txtSpgetir.Name = "txtSpgetir";
            this.txtSpgetir.Size = new System.Drawing.Size(198, 20);
            this.txtSpgetir.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(100, 38);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(302, 20);
            this.dateTimePicker2.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(302, 20);
            this.dateTimePicker1.TabIndex = 15;
            this.dateTimePicker1.Value = new System.DateTime(2023, 6, 15, 0, 47, 17, 0);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(390, 24);
            this.button5.TabIndex = 14;
            this.button5.Text = "Ürün Excell aktar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Başlangıç Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Bitiş Tarihi";
            // 
            // ExcelIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 128);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCsvaktar);
            this.Controls.Add(this.txtSpgetir);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button5);
            this.Name = "ExcelIslemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excell İşlemleri";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcelIslemleri_FormClosing);
            this.Load += new System.EventHandler(this.ExcelIslemleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCsvaktar;
        private System.Windows.Forms.TextBox txtSpgetir;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}