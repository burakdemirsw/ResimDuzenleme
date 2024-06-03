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
    public partial class ArasKargoApi : Form
    {
        public ArasKargoApi()
        {
            InitializeComponent();
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Burada Kullanılan Tablolar : ZTMSGArasKargoApi");
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
                string query = "delete  ZTMSGArasKargoApi where KargoTipi = 'Aras Kargo'";
                using (SqlCommand cmd = new SqlCommand(query, connn))
                {



                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    connn.Open();
                    cmd.ExecuteNonQuery();


                }
            }
            using (SqlConnection connnn = new SqlConnection(connectionString))
            {
                string query = "delete  ZTMSGArasKargoApi where KargoTipi = 'Aras Kargo Set Order'";
                using (SqlCommand cmd = new SqlCommand(query, connnn))
                {



                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    connnn.Open();
                    cmd.ExecuteNonQuery();


                }
            }

            if (string.IsNullOrWhiteSpace(txtSenderCustomerCode.Text) || string.IsNullOrWhiteSpace(txtSenderPassWord.Text))
            {
                // Eğer txtCustomerCode veya txtPassword boşsa, kullanıcıya bir hata mesajı göster.
                MessageBox.Show("Zorunlu alanları giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ZTMSGArasKargoApi (KargoTipi,SenderUserName,SenderPassword,SenderCustomerCode,QueryUserName,QueryPassWord,QueryCustomerCode,AddressIdGonderimi,ParcaBilgisi,BarkodCiktisi) VALUES (@KargoTipi,@SenderUserName,@SenderPassword,@SenderCustomerCode,@QueryUserName,@QueryPassWord,@QueryCustomerCode,@AddressIdGonderimi,@ParcaBilgisi,@BarkodCiktisi)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {


                        cmd.Parameters.AddWithValue("@KargoTipi", label18.Text);
                        cmd.Parameters.AddWithValue("@SenderUserName", txtSenderUserName.Text);
                        cmd.Parameters.AddWithValue("@SenderPassword", txtSenderPassWord.Text);
                        cmd.Parameters.AddWithValue("@SenderCustomerCode", txtSenderCustomerCode.Text);
                        cmd.Parameters.AddWithValue("@QueryUserName", txtQueryUserName.Text);
                        cmd.Parameters.AddWithValue("@QueryPassWord", txtQueryPassWord.Text);
                        cmd.Parameters.AddWithValue("@QueryCustomerCode", txtQueryCustomerCode.Text);
                        cmd.Parameters.AddWithValue("@AddressIdGonderimi", cmbAddressID.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ParcaBilgisi", cmbParcaBilgisi.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@BarkodCiktisi", cmbBarkodCikti.SelectedItem.ToString());
                   


                        

                        //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                        //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                        conn.Open();
                        cmd.ExecuteNonQuery();


                    }
                }
            }



          
                using (SqlConnection conn2 = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ZTMSGArasKargoApi (KargoTipi,SenderUserName,SenderPassword,SenderCustomerCode,QueryUserName,QueryPassWord,QueryCustomerCode,AddressIdGonderimi,ParcaBilgisi,BarkodCiktisi) VALUES (@KargoTipi,@SenderUserName,@SenderPassword,@SenderCustomerCode,@QueryUserName,@QueryPassWord,@QueryCustomerCode,@AddressIdGonderimi,@ParcaBilgisi,@BarkodCiktisi)";
                    using (SqlCommand cmd = new SqlCommand(query, conn2))
                    {


                        cmd.Parameters.AddWithValue("@KargoTipi", label19.Text);
                        cmd.Parameters.AddWithValue("@SenderUserName", txtSenderUserName2.Text);
                        cmd.Parameters.AddWithValue("@SenderPassword", txtSenderPassWord2.Text);
                        cmd.Parameters.AddWithValue("@SenderCustomerCode", txtSenderCustomerCode2.Text);
                        cmd.Parameters.AddWithValue("@QueryUserName", txtQueryUserName2.Text);
                        cmd.Parameters.AddWithValue("@QueryPassWord", txtQueryPassWord2.Text);
                        cmd.Parameters.AddWithValue("@QueryCustomerCode", txtQueryCustomerCode2.Text);
                        cmd.Parameters.AddWithValue("@AddressIdGonderimi", cmbAddressID.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@ParcaBilgisi", cmbParcaBilgisi.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@BarkodCiktisi", cmbBarkodCikti.SelectedItem.ToString());





                        //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                        //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                        conn2.Open();
                        cmd.ExecuteNonQuery();


                    }
                }
            
            MessageBox.Show("Kayıt Başarılı");
        }

        private void ArasKargoApi_Load(object sender, EventArgs e)
        {
            cmbAddressID.SelectedIndex = 0; // İlk elemanı seçili yapar
            cmbBarkodCikti.SelectedIndex = 0;
            cmbParcaBilgisi.SelectedIndex = 0;
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Burada Kullanılan Tablolar : ZTMSGArasKargoApi");
        }
    }
}
