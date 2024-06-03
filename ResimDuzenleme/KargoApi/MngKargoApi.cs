using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResimDuzenleme.KargoApi
{
    public partial class MngKargoApi : Form
    {
        public MngKargoApi()
        {
            InitializeComponent();
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Burada Kullanılan Tablolar : ZTMSGMngKargoApi");
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


            using (SqlConnection connn = new SqlConnection(connectionString))
            {
                string query = "delete  ZTMSGMngKargoApi";
                using (SqlCommand cmd = new SqlCommand(query, connn))
                {



                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    connn.Open();
                    cmd.ExecuteNonQuery();


                }
            }


            if (string.IsNullOrWhiteSpace(txtCustomerCode.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                // Eğer txtCustomerCode veya txtPassword boşsa, kullanıcıya bir hata mesajı göster.
                MessageBox.Show("Zorunlu alanları giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ZTMSGMngKargoApi (CustomerCode,ClientId,ClientSecret,PassWord,MusteriKoduGonder,BarkodCikti) VALUES (@CustomerCode,@ClientId,@ClientSecret,@PassWord,@MusteriKoduGonder,@BarkodCikti)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {


                        cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerCode.Text);
                        cmd.Parameters.AddWithValue("@ClientId", txtClientId.Text);
                        cmd.Parameters.AddWithValue("@ClientSecret", txtClientSecret.Text);
                        cmd.Parameters.AddWithValue("@PassWord", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@MusteriKoduGonder", cmbMusteriKodu.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@BarkodCikti", cmbBarkod.SelectedItem.ToString());

                        //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                        //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                        conn.Open();
                        cmd.ExecuteNonQuery();


                    }
                }
            }
            MessageBox.Show("Kayıt Başarılı");
        }

        private void MngKargoApi_Load(object sender, EventArgs e)
        {
            cmbMusteriKodu.SelectedIndex = 0; // İlk elemanı seçili yapar
            cmbBarkod.SelectedIndex = 0;
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Burada Kullanılan Tablolar : ZTMSGMngKargoApi");
        }
    }
}
