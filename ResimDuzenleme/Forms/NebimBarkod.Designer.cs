namespace ResimDuzenleme
{
    partial class NebimBarkod
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btnbarkod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 392);
            this.dataGridView1.TabIndex = 0;
            // 
            // Btnbarkod
            // 
            this.Btnbarkod.Location = new System.Drawing.Point(13, 17);
            this.Btnbarkod.Name = "Btnbarkod";
            this.Btnbarkod.Size = new System.Drawing.Size(140, 23);
            this.Btnbarkod.TabIndex = 1;
            this.Btnbarkod.Text = "Barkod Numarası Ver";
            this.Btnbarkod.UseVisualStyleBackColor = true;
            this.Btnbarkod.Click += new System.EventHandler(this.Btnbarkod_Click);
            // 
            // NebimBarkod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.Btnbarkod);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NebimBarkod";
            this.Text = "NebimBarkod";
            this.Load += new System.EventHandler(this.NebimBarkod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btnbarkod;
    }
}