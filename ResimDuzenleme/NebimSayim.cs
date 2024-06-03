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
using System.IO;

namespace ResimDuzenleme
{
    public partial class NebimSayim : Form
    {
        public Guid myGuid { get; private set; }

        public NebimSayim()
        {
            InitializeComponent();
      
        }
        private void NebimSayim_Load(object sender, EventArgs e)
        {
            myGuid = Guid.NewGuid();
        }
     

        private void ExecuteStoredProc(string barcode)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("MSG_MSRAFSAYIMOffline", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@barcode", SqlDbType.NVarChar)).Value = barcode;
                    command.Parameters.Add(new SqlParameter("@ShelfNo", SqlDbType.NVarChar)).Value = label3.Text; // Örnek değer
                    command.Parameters.Add(new SqlParameter("@OrderNumberCheck", SqlDbType.Int)).Value = 0; // Örnek değer
                    command.Parameters.Add(new SqlParameter("@ID", SqlDbType.UniqueIdentifier)).Value = myGuid; // GUID değeri eklenir

                    connection.Open();

                    // Eğer Stored Procedure sonuç döndürüyorsa, ExecuteReader kullanılabilir.
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string status = reader["Status"].ToString();
                        string description = reader["Description"].ToString();

                        if (status == "RAF")
                        {
                            label3.Text = description;
                            txtBarcode.Clear(); // txtBarcode temizlenir
                            txtBarcode.Focus();// Önemli değil denilmiş, dolayısıyla description kullanılabilir ya da başka bir değer.
                        }
                        else if (status == "Barcode")
                        {


                            int rowIndex = dataGridView1.Rows.Add(); // Yeni bir satır ekler
                            dataGridView1.Rows[rowIndex].Cells["RafNO"].Value = label3.Text; // RafNO sütununa değer atar
                            dataGridView1.Rows[rowIndex].Cells["barkod"].Value = description; // barkod sütununa değer atar



                            txtBarcode.Clear();

                       // txtBarcode temizlenir
                            txtBarcode.Focus();// txtBarcode temizlenir, Label1 değişmez.
                        }
                    }
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                {
                    string barcode = txtBarcode.Text;
                    ExecuteStoredProc(barcode);
                }
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kullanıcıya onay mesajı göster
            DialogResult result = MessageBox.Show("Bu verileri silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Eğer kullanıcı "Yes" seçeneğini tıklarsa
            if (result == DialogResult.Yes)
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                // Veritabanı bağlantısını aç
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // "ZTMSRAFSAYIMOFFLINE" tablosundaki tüm verileri silmek için SQL komutunu oluştur
                    string query = "DELETE FROM ZTMSGRAFSAYIMOFFLINE WHERE SayimID = @SayimID";

                    // SQL komutunu çalıştır
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@SayimID", SqlDbType.UniqueIdentifier)).Value = myGuid; // Form yüklenirken oluşturulan GUID değerini kullan
                        command.ExecuteNonQuery();
                    }
                    // SQL komutunu çalıştır
                   
                }

                MessageBox.Show("Veriler başarıyla silindi!");
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("İşlem iptal edildi.");
            }
        }

        private void btnNebimAktar_Click(object sender, EventArgs e)
        {
            // Kayıt yolu seçmek için bir dosya diyalogu göster
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosya yolu
                string filePath = saveFileDialog.FileName;

                // DataGridView'deki verileri bir metin dosyasına yaz
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow) // Yeni oluşturulan satırı atla
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                // Hücre değerlerini dosyaya yaz
                                writer.Write(cell.Value.ToString() + "\t");
                            }
                            writer.WriteLine();
                        }
                    }
                }

                MessageBox.Show("Veriler başarıyla kaydedildi!");
            }
        }
    }
}
