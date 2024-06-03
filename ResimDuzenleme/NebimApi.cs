using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
namespace ResimDuzenleme
{
    public partial class NebimApi : Form
    {
        public NebimApi( )
        {
            InitializeComponent();
        }

        private void NebimApi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SunucuAdi = textBoxServerName.Text;
            Properties.Settings.Default.KullaniciAdi = textBoxUserName.Text;
            Properties.Settings.Default.Sifre = textBoxPassword.Text;
            Properties.Settings.Default.StoredProcedureAdi = textBoxStoredProcedureName.Text;
            Properties.Settings.Default.database = txtdatabase.Text;
            Properties.Settings.Default.txtEntegrator = txtEntegrator.Text;
            Properties.Settings.Default.txtOfis = txtOfis.Text;
            Properties.Settings.Default.txtPos = txtPos.Text;
            Properties.Settings.Default.txtMagaza = txtMagaza.Text;
            Properties.Settings.Default.txtDepo = txtDepo.Text;
            Properties.Settings.Default.txtBarkodTipi = txtBarkodTipi.Text;
            Properties.Settings.Default.txtlot = txtLot.Text;
            Properties.Settings.Default.txtSiteAdi = txtSiteAdi.Text;
            Properties.Settings.Default.txtWsYetki = txtWsYetki.Text;
            Properties.Settings.Default.DEUser = textBox1.Text;
            Properties.Settings.Default.DESifre = textBox2.Text;
            Properties.Settings.Default.Surec = comboBox1.SelectedItem.ToString();
            Properties.Settings.Default.Save();
        }

        private void NebimApi_Load(object sender, EventArgs e)
        {
            textBoxServerName.Text = Properties.Settings.Default.SunucuAdi;
            textBoxUserName.Text = Properties.Settings.Default.KullaniciAdi;
            textBoxPassword.Text = Properties.Settings.Default.Sifre;
            textBoxStoredProcedureName.Text = Properties.Settings.Default.StoredProcedureAdi;
            txtdatabase.Text = Properties.Settings.Default.database;
            txtEntegrator.Text = Properties.Settings.Default.txtEntegrator;
            txtOfis.Text = Properties.Settings.Default.txtOfis;
            txtPos.Text = Properties.Settings.Default.txtPos;
            txtMagaza.Text = Properties.Settings.Default.txtMagaza;
            txtDepo.Text = Properties.Settings.Default.txtDepo;
            txtBarkodTipi.Text = Properties.Settings.Default.txtBarkodTipi;
            txtLot.Text = Properties.Settings.Default.txtlot;
            txtSiteAdi.Text = Properties.Settings.Default.txtSiteAdi;
            txtWsYetki.Text = Properties.Settings.Default.txtWsYetki;
            textBox1.Text = Properties.Settings.Default.DEUser;
            textBox2.Text = Properties.Settings.Default.DESifre;
            string surec = Properties.Settings.Default.Surec;

            // ComboBox öğelerini yineleyerek eşleşme arayın
            foreach (var item in comboBox1.Items)
            {
                // Burada, ComboBox öğeleri string ise doğrudan karşılaştırma yapılır
                if (item.ToString() == surec)
                {
                    comboBox1.SelectedItem = item;
                    break; // Eşleşme bulunduğunda döngüden çık
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Entegrator = txtEntegrator.Text;
                string SiteAdi = txtSiteAdi.Text;
                string WsYetki = txtWsYetki.Text;
                string DEUser = textBox1.Text;
                string DESifre = textBox2.Text;


                string serverName = textBoxServerName.Text;
                string userName = textBoxUserName.Text;
                string password = textBoxPassword.Text;
                string database = txtdatabase.Text;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "delete ZTMSGSettings";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    string query2 = "INSERT INTO ZTMSGSettings (Entegrator,SiteAdi,WsYetki,DEUser,DESifre) VALUES (@Entegrator,@SiteAdi,@WsYetki,@DEUser,@DESifre)";


                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@Entegrator", Entegrator);
                        command.Parameters.AddWithValue("@SiteAdi", SiteAdi);
                        command.Parameters.AddWithValue("@WsYetki", WsYetki);
                        command.Parameters.AddWithValue("@DEUser", DEUser);
                        command.Parameters.AddWithValue("@DESifre", DESifre);


                        command.ExecuteNonQuery();
                    }
                }


                NebimApi.ActiveForm.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnbarkoddizayn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string initialDirectory = Path.Combine(projectPath, "Barkod");

                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.Filter = "repx files (*.repx)|*.repx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    // Create a new target file path
                    string targetPath = Path.Combine(initialDirectory, "Barkod.repx");

                    // Use File.Copy to copy the file
                    File.Copy(filePath, targetPath, true); // overwrite if already exists

                    MessageBox.Show("Dosya başarıyla kaydedildi.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string initialDirectory = Path.Combine(projectPath, "general");

                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.Filter = "xslt files (*.xslt)|*.xslt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    // Create a new target file path
                    string targetPath = Path.Combine(initialDirectory, "general.repx");

                    // Use File.Copy to copy the file
                    File.Copy(filePath, targetPath, true); // overwrite if already exists

                    MessageBox.Show("Dosya başarıyla kaydedildi.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string initialDirectory = Path.Combine(projectPath, "Gider");

                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.Filter = "repx files (*.repx)|*.repx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    // Create a new target file path
                    string targetPath = Path.Combine(initialDirectory, "InvoiceR.repx");

                    // Use File.Copy to copy the file
                    File.Copy(filePath, targetPath, true); // overwrite if already exists

                    MessageBox.Show("Dosya başarıyla kaydedildi.");
                }
            }
        }
    }
}
