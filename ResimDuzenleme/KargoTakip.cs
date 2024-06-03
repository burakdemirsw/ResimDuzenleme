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
    public partial class KargoTakip : Form
    {
        public KargoTakip()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KargoApi.MngKargoApi frm = new KargoApi.MngKargoApi();
    
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KargoApi.ArasKargoApi frm = new KargoApi.ArasKargoApi();

            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            KargoApi.YurtIciKargoApi frm = new KargoApi.YurtIciKargoApi();

            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            KargoApi.SuratKargoApi frm = new KargoApi.SuratKargoApi();

            frm.Show();
        }
    }
}
