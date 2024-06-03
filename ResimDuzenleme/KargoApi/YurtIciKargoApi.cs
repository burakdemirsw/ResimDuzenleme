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
    public partial class YurtIciKargoApi : Form
    {
        public YurtIciKargoApi()
        {
            InitializeComponent();
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
                string query = "delete  ZTMSGYurticiKargoApi where KargoTipi = 'Yurtiçi Kargo'";
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
                string query = "delete  ZTMSGYurticiKargoApi where KargoTipi = 'Yurtiçi Kargo Gönderici Ödemeli'";
                using (SqlCommand cmd = new SqlCommand(query, connnn))
                {



                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    connnn.Open();
                    cmd.ExecuteNonQuery();


                }
            }
            using (SqlConnection connnn4 = new SqlConnection(connectionString))
            {
                string query = "delete  ZTMSGYurticiKargoApi where KargoTipi = 'Yurtiçi Kargo Tahsilatlı'";
                using (SqlCommand cmd = new SqlCommand(query, connnn4))
                {



                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    connnn4.Open();
                    cmd.ExecuteNonQuery();


                }
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text) || string.IsNullOrWhiteSpace(txtCustomerCode.Text))
            {
                // Eğer txtCustomerCode veya txtPassword boşsa, kullanıcıya bir hata mesajı göster.
                MessageBox.Show("Zorunlu alanları giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ZTMSGYurticiKargoApi (KargoTipi,UserName,Password,CustomerCode) VALUES (@KargoTipi,@UserName,@Password,@CustomerCode)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {


                        cmd.Parameters.AddWithValue("@KargoTipi", label18.Text);
                        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassWord.Text);
                        cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerCode.Text);
                      




                        //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                        //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                        conn.Open();
                        cmd.ExecuteNonQuery();


                    }
                }
            }

            using (SqlConnection conn44 = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ZTMSGYurticiKargoApi (KargoTipi,UserName,Password,CustomerCode) VALUES (@KargoTipi,@UserName,@Password,@CustomerCode)";
                using (SqlCommand cmd = new SqlCommand(query, conn44))
                {


                    cmd.Parameters.AddWithValue("@KargoTipi", label19.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName2.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassWord2.Text);
                    cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerCode2.Text);





                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    conn44.Open();
                    cmd.ExecuteNonQuery();


                }
            }


            using (SqlConnection conn55 = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ZTMSGYurticiKargoApi (KargoTipi,UserName,Password,CustomerCode) VALUES (@KargoTipi,@UserName,@Password,@CustomerCode)";
                using (SqlCommand cmd = new SqlCommand(query, conn55))
                {


                    cmd.Parameters.AddWithValue("@KargoTipi", label21.Text);
                    cmd.Parameters.AddWithValue("@UserName", txtUserName3.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassWord3.Text);
                    cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerCode3.Text);





                    //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                    //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });


                    conn55.Open();
                    cmd.ExecuteNonQuery();


                }
            }

            MessageBox.Show("Kayıt Başarılı");
        }

        private void YurtIciKargoApi_Load(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Burada Kullanılan Tablolar : ZTMSGYurticiKargoApi");
        }
    }
}
