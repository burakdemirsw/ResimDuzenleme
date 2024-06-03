using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class TrendyolApi : Form
    {
        public TrendyolApi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TrendyolApi_Load(object sender, EventArgs e)
        {
            txtApiKey.Text = Properties.Settings.Default.txtApiKey;
            txtApiSecret.Text = Properties.Settings.Default.txtApiSecret;
            TxtSatici.Text = Properties.Settings.Default.TxtSatici;
         
        }

        private void TrendyolApi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.txtApiKey = txtApiKey.Text;
            Properties.Settings.Default.txtApiSecret = txtApiSecret.Text;
            Properties.Settings.Default.TxtSatici = TxtSatici.Text;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrendyolApi.ActiveForm.Close();
        }
    }
}
