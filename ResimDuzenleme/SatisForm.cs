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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ResimDuzenleme
{
    public partial class SatisForm : Form
    {
        private Timer timer;
        private Timer salesDataTimer;
        private Timer paketlenenTimer;
        private Timer kargolananTimer;

        public SatisForm()
        {
            InitializeComponent();


            // Genel veri timer'ı
            timer = new Timer();
            timer.Interval = 60000; // 5 saniyede bir güncelle
            timer.Tick += Timer_Tick;
            timer.Start();

            // Satış verileri timer'ı
            salesDataTimer = new Timer();
            salesDataTimer.Interval = 60000; // 5 saniyede bir güncelle
            salesDataTimer.Tick += (s, e) => UpdateCharts();
            salesDataTimer.Tick += (s, e) => UpdateChartCount();
            salesDataTimer.Tick += (s, e) => SelectOdeme();
            salesDataTimer.Tick += (s, e) => SelectPazaryeri();
            salesDataTimer.Tick += (s, e) => SelectSite();
            salesDataTimer.Stop();

            // Paketlenen timer'ı
            paketlenenTimer = new Timer();
            paketlenenTimer.Interval = 60000; // 5 saniyede bir güncelle
            paketlenenTimer.Tick += (s, e) => UpdateChartsPaketlenen();
            paketlenenTimer.Tick += (s, e) => UpdateChartsCountPaketlenen();
            paketlenenTimer.Tick += (s, e) => SelectOdeme();
            paketlenenTimer.Tick += (s, e) => SelectOdeme();
            paketlenenTimer.Tick += (s, e) => SelectSite();
            paketlenenTimer.Stop();

            // Kargolanan timer'ı
            kargolananTimer = new Timer();
            kargolananTimer.Interval = 60000; // 5 saniyede bir güncelle
            kargolananTimer.Tick += (s, e) => UpdateChartsPKargolanan();
            kargolananTimer.Tick += (s, e) => UpdateChartsCountPKargolanan();
            kargolananTimer.Tick += (s, e) => SelectOdeme();
            kargolananTimer.Tick += (s, e) => SelectOdeme();
            kargolananTimer.Tick += (s, e) => SelectSite();
            kargolananTimer.Stop();

            // Form yüklendiğinde veriyi getir
            UpdateCharts();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Her zamanlayıcı tetiklendiğinde verileri güncelle
            //UpdateSalesData();

            //// Diğer zamanlayıcılar için de benzer güncelleme işlemlerini ekleyebilirsiniz
            //UpdateChartsPaketlenen();
            //UpdateChartsPKargolanan();
        }

   

        private void SatisForm_Load(object sender, EventArgs e)
        {
            // Form yüklenirken ilk veriyi getir
            salesDataTimer.Start();
            UpdateCharts();
            UpdateChartCount();
            SelectOdeme();
            SelectPazaryeri();
            SelectSite();
            Sil();
            //dataGridView1.RowDefaultCellStyleChanged += dataGridView1_RowDefaultCellStyleChanged;
            //dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;


        }

        private void UpdateCharts()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrol() WHERE Orderdate >= '{selectedDate}' AND DURUMU = 'SİPARİŞ İLE İLGİLİ İŞLEM YAPILMADI' ORDER BY OrderDate,Pazaryeri,[Site Sipariş No]";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }



        private void UpdateChartCount()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT CreatedDate=ISNULL((Convert(Date,CreatedDate,102)),SPACE(0)),OrderDate=Convert(Date,OrderDate,102),[Ürün Kodu],Miktar,Tutar FROM MSG_SiparisKontrolCount() WHERE OrderDate >= '{selectedDate}' AND CreatedDate >= '1900-01-01' AND DURUMU = 'SİPARİŞ İLE İLGİLİ İŞLEM YAPILMADI' ORDER BY OrderDate,CreatedDate";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView5.DataSource = dataTable;
                    }
                }
            }
          
        }


        //private void UpdateChartCount()
        //{
        //    // Grafikleri güncelleme kodları burada olacak
        //    // Örneğin, Chart kontrolü üzerinde verileri güncelle

        //    string serverName = Properties.Settings.Default.SunucuAdi;
        //    string userName = Properties.Settings.Default.KullaniciAdi;
        //    string password = Properties.Settings.Default.Sifre;
        //    string database = Properties.Settings.Default.database;
        //    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //        connection.Open();
        //        string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        //        string sqlQuery = $"SELECT Photo, OrderDate, Barcode,[Ürün Kodu],[Ürün Adı],[Renk Kodu],[Renk],[Beden], Miktar, Tutar FROM MSG_SiparisKontrolCount()  ORDER BY OrderDate,[Ürün Kodu],[Renk Kodu],[Beden]";

        //        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                DataTable dataTable = new DataTable();
        //                dataTable.Load(reader);
        //                dataGridView5.DataSource = dataTable;
        //            }
        //        }
        //    }

        //}



        private string UpdateChartCount2()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrolCount() WHERE OrderDate >= '{selectedDate}' AND CreatedDate >= '1900-01-01' AND DURUMU = 'SİPARİŞ İLE İLGİLİ İŞLEM YAPILMADI' ORDER BY OrderDate,CreatedDate";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView5.DataSource = dataTable;
                        int recordsCount = dataTable.Rows.Count;
                        return $"İşlenen kayıt sayısı: {recordsCount}";
                    }
                }
            }
        
        }




        private void Sil()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            // DataGridView'den seçili olan satırın SirketKodu değerini al
         
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ZTMSGKargoTakip WHERE KargoNo = ''";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ZTMSGKargoTakipKontrol WHERE KargoNo = ''";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        private void SelectOdeme()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrolOdeme() WHERE Orderdate >= '{selectedDate}' Order by ORderDate, OdemeTipi, Site, Durumu";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
               
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
        }

        private void SelectPazaryeri()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrolPazaryeri() WHERE Orderdate >= '{selectedDate}'  Order by ORderDate, Pazaryeri";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView4.DataSource = dataTable;
                    }
                }
            }
        }

        private void SelectSite()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrolSite() WHERE Orderdate >= '{selectedDate}'  Order by ORderDate, Site";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
               
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView3.DataSource = dataTable;
                    }
                }
            }
        }




        private void btnIslemYapilmayanlar_Click(object sender, EventArgs e)
        {
            salesDataTimer.Start();
            paketlenenTimer.Stop();
            kargolananTimer.Stop();
            UpdateCharts();
            UpdateChartCount();
        }
        private void UpdateChartsPaketlenen()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrol() WHERE Orderdate >= '{selectedDate}'  and  DURUMU = 'PAKETLENDİ' ORDER BY OrderDate,Pazaryeri,[Site Sipariş No]";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }



        private void UpdateChartsCountPaketlenen()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrolCount() WHERE CreatedDate >= '{selectedDate}'  and  DURUMU = 'PAKETLENDİ' ORDER BY OrderDate,CreatedDate";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))

                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView5.DataSource = dataTable;
                    }
                }
            }
        }


        private void UpdateChartsPKargolanan()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrol() WHERE Orderdate >= '{selectedDate}'  and  DURUMU = 'KARGOLANDI' ORDER BY OrderDate,Pazaryeri,[Site Sipariş No]";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
               
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }


        private void UpdateChartsCountPKargolanan()
        {
            // Grafikleri güncelleme kodları burada olacak
            // Örneğin, Chart kontrolü üzerinde verileri güncelle

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string sqlQuery = $"SELECT * FROM MSG_SiparisKontrolCount() WHERE CreatedDate >= '{selectedDate}'  and  DURUMU = 'KARGOLANDI' ORDER BY OrderDate,CreatedDate";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))

                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView5.DataSource = dataTable;
                    }
                }
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        
            SelectOdeme();
            SelectPazaryeri();
            SelectSite();
        }
        private void btnPaketlenenler_Click(object sender, EventArgs e)
        {
            salesDataTimer.Stop();
            paketlenenTimer.Start();
            kargolananTimer.Stop();
            UpdateChartsPaketlenen();
            UpdateChartsCountPaketlenen();
        }

        private void btnKargolonan_Click(object sender, EventArgs e)
        {
            salesDataTimer.Stop();
            paketlenenTimer.Stop();
            kargolananTimer.Start();
            UpdateChartsPKargolanan();
            UpdateChartsCountPKargolanan();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "GÜNCELLEMELERİ DURDUR")
            {
                salesDataTimer.Stop();
                paketlenenTimer.Stop();
                kargolananTimer.Stop();
                timer.Stop();
                button1.Text = "GÜNCELLEMELERİ BAŞLAT";
            }
            else
            {
                salesDataTimer.Start();
                paketlenenTimer.Stop();
                kargolananTimer.Stop();
                timer.Start();
                button1.Text = "GÜNCELLEMELERİ DURDUR";
            }
       

        }
        private void ExportDataGridViewToPdf(string filePath)
        {
            // PDF dokümanını oluştur
            Document pdfDoc = new Document(PageSize.A4);
            try
            {
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                // PdfPTable oluştur. Sütun sayısı dataGridView'in sütun sayısına eşit olmalı.
                PdfPTable pdfTable = new PdfPTable(dataGridView5.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Sütun başlıklarını ekle
                foreach (DataGridViewColumn column in dataGridView5.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }

                // Satırları ve hücreleri ekle
                foreach (DataGridViewRow row in dataGridView5.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                    }
                }

                pdfDoc.Add(pdfTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF dönüştürme sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                pdfDoc.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "PDF olarak kaydet";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportDataGridViewToPdf(filePath);
                MessageBox.Show("PDF başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
