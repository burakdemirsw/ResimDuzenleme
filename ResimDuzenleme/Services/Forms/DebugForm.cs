using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimDuzenleme.Services.Forms
{
    public partial class DebugForm : DevExpress.XtraEditors.XtraForm
    {
        private Timer timer;

        public DebugForm( List<string> errors)
        {
            InitializeComponent();
            // Timer'ı başlat ve her 3 saniyede bir Tick olayını tetikle
            timer = new Timer();
            timer.Start();
            timer.Interval = 3000; // 3000 milisaniye = 3 saniye
            timer.Tick += Timer_Tick;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            clearTextBox();
            setErrors();
          
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            StaticVariables.errors.Clear();
            clearTextBox();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            setErrors();
        }

        private void setErrors( )
        {
            foreach (var error in StaticVariables.errors)
            {
                this.richTextBox1.Text += error + Environment.NewLine;
            }
        }
        private void clearTextBox( )
        {
            this.richTextBox1.Text = "";
        }
    }
}