using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace ResimDuzenleme
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void SaveCredentials(string userName, string password, bool rememberMe)
        {
            // Kullanıcı adı ve şifreyi byte dizisine çevir
            byte[] userNameBytes = Encoding.UTF8.GetBytes(userName);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Verileri şifrele
            byte[] encryptedUserName = ProtectedData.Protect(userNameBytes, null, DataProtectionScope.CurrentUser);
            byte[] encryptedPassword = ProtectedData.Protect(passwordBytes, null, DataProtectionScope.CurrentUser);

            // Şifreli verileri yerel ayarlara kaydet
            Properties.Settings.Default.EncryptedUserName = Convert.ToBase64String(encryptedUserName);
            Properties.Settings.Default.EncryptedPassword = Convert.ToBase64String(encryptedPassword);
            Properties.Settings.Default.RememberMe = rememberMe; // "Beni Hatırla" seçeneğini kaydet
            Properties.Settings.Default.Save();
        }

        private void LoadCredentials()
        {
            if (Properties.Settings.Default.RememberMe)
            {
                byte[] decryptedUserName = ProtectedData.Unprotect(
                    Convert.FromBase64String(Properties.Settings.Default.EncryptedUserName),
                    null,
                    DataProtectionScope.CurrentUser);
                byte[] decryptedPassword = ProtectedData.Unprotect(
                    Convert.FromBase64String(Properties.Settings.Default.EncryptedPassword),
                    null,
                    DataProtectionScope.CurrentUser);

                textBox1.Text = Encoding.UTF8.GetString(decryptedUserName);
                textBox2.Text = Encoding.UTF8.GetString(decryptedPassword);
                checkBoxBeniHatirla.Checked = true;
            }
        }
        private void ClearCredentials()
        {
            // Kaydedilmiş bilgileri temizle
            Properties.Settings.Default.EncryptedUserName = string.Empty;
            Properties.Settings.Default.EncryptedPassword = string.Empty;
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBoxBeniHatirla.Checked)
            {
                SaveCredentials(textBox1.Text, textBox2.Text, true);
            }
            else
            {
                ClearCredentials(); // Bu metodun tanımını yapmanız gerekecek
            }
            string username = textBox1.Text;
            string password2 = textBox2.Text;
            string yetki = "1"; // Varsayılan yetki
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT Yetki,StoreCode FROM ZTMSGUserLogin WHERE UserName = @username AND PassWord = @password", connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password2);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            yetki = reader["Yetki"].ToString();
                            var storeCode = reader["StoreCode"].ToString();

                            Properties.Settings.Default.StoreCode = storeCode;
                            Properties.Settings.Default.Save();
                            Yonlendir(yetki);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // SQL bağlantısı başarısız olursa hata mesajını göster
                MessageBox.Show("Lütfen Veri Tabanı Bağlantısını yapın: " + ex.Message);
                Yonlendir(yetki);
            }

            // Yetki seviyesine göre işlem yap
       
        }
        private void Yonlendir(string yetki)
        {
            if (yetki == "1")
            {
                this.Hide(); // Şu anki LoginForm'u gizle
                Misigo frm = new Misigo();
                frm.FormClosed += (s, args) => this.Show(); // Magaza formu kapandığında LoginForm'u tekrar göster
                frm.Show();

            }
            else if (yetki == "2")
            {
                this.Hide(); // Şu anki LoginForm'u gizle
                Magaza frm = new Magaza();
                frm.FormClosed += (s, args) => this.Show(); // Magaza formu kapandığında LoginForm'u tekrar göster
                frm.Show();


            }
            // Diğer yetkiler için benzer işlemler
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoginForm.ActiveForm.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadCredentials();
       

        }
    }
}
