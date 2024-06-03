using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting; // Yazdırma ve önizleme için
using DevExpress.XtraReports.UserDesigner; // Rapor tasarımcısı için


namespace ResimDuzenleme
{
    public partial class DegisimListesi : Form
    {
        public DegisimListesi()
        {
            InitializeComponent();
        }
        private void OpenNebimFaturaListesi2()
        {
            var nebimFaturaListesi2 = new NebimFaturaListesiGider();
            nebimFaturaListesi2.FrmFaturalastirTekliRef2 = this; // Bu satır önemli
            nebimFaturaListesi2.MdiParent = this.MdiParent;
            nebimFaturaListesi2.Show();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenNebimFaturaListesi2();
        }

        private void DegisimListesi_Load(object sender, EventArgs e)
        {

            string storeCode = Properties.Settings.Default.StoreCode;


        }
        private DataTable GetInvoiceData(string FaturaNo)
        {
            DataTable dataTable = new DataTable();

            // Veritabanı bağlantı string'inizi buraya ekleyin
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storecode = Properties.Settings.Default.StoreCode;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_ReturnItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Invoicenumber", FaturaNo);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            gridControl1.DataSource = dataTable;
            //gridView1.Columns["InvoiceNumber"].Caption = "Fatura NO";
            //gridView1.Columns["CurrAccCode"].Caption = "Müşteri Kodu";
            //gridView1.Columns["CurrAccDescription"].Caption = "Müşteri Adı";
            //gridView1.Columns["ColorCode"].Caption = "Renk";
            //gridView1.Columns["ColorDescription"].Caption = "Renk Açıklama";
            //gridView1.Columns["ItemDim1Code"].Caption = "Beden";
            //gridView1.Columns["Qty1"].Caption = "Miktar";

            gridView1.Columns["InvoiceLineID"].Caption = "InvoiceLineID";
            gridView1.Columns["InvoiceNumber"].Caption = "InvoiceNumber";
            gridView1.Columns["CurrAccCode"].Caption = "CurrAccCode";
            gridView1.Columns["CurrAccDescription"].Caption = "CurrAccDescription";
            gridView1.Columns["Barcode"].Caption = "Barcode";
            gridView1.Columns["ItemCode"].Caption = "ItemCode";
            gridView1.Columns["ColorCode"].Caption = "ColorCode";
            gridView1.Columns["ColorDescription"].Caption = "ColorDescription";
            gridView1.Columns["ItemDim1Code"].Caption = "ItemDim1Code";
            gridView1.Columns["Qty1"].Caption = "Qty1";
            gridView1.Columns["Price"].Caption = "Price";


            //gridView1.Columns["Fatura NO"].Caption = "InvoiceNumber";
            //gridView1.Columns["Müşteri Kodu"].Caption = "CurrAccCode";
            //gridView1.Columns["Müşteri Adı"].Caption = "CurrAccDescription" ;
            //gridView1.Columns["Renk"].Caption = "ColorCode";
            //gridView1.Columns["Renk Açıklama"].Caption = "ColorDescription";
            //gridView1.Columns["Beden"].Caption = "ItemDim1Code";
            //gridView1.Columns["Miktar"].Caption = "Qty1";
            // ... Diğer sütun başlıkları

            // GridView ayarları...
            gridView1.BestFitColumns();

            return dataTable;
        }
        private void InitializeGridView()
        {
            // CheckBox için RepositoryItemCheckEdit oluştur
            RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
            gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);



            // CheckBox ile satır seçimini etkinleştir
            gridView1.OptionsSelection.MultiSelect = false;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

            gridView1.BestFitColumns();
        }


        public string TextBox1Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string NewBarcode
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }


        public string Fiyat2
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public void TriggerEnterOperation()
        {
            // Enter tuşuna basıldığında gerçekleşmesini istediğiniz işlemler
            // Örneğin, simpleButton1'in click event'ini burada çağırabilirsiniz
            simpleButton1.PerformClick();
        }

        private void AcilirPanelGoster()
        {
            using (var form = new AcilirPanelGoster())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Formdan seçilen değerleri al
                    string barcode = form.SecilenBarcode;
                    string fiyat = form.SecilenFiyat;
                    textBox3.Text = barcode;
                    textBox4.Text = fiyat;
                    // textBox6 ve textBox4 içerisindeki değerleri float tipine dönüştürmeye çalış
                    bool textBox6IsNumeric = float.TryParse(textBox6.Text, out float textBox6Value);
                    bool textBox4IsNumeric = float.TryParse(textBox4.Text, out float textBox4Value);

                    if (textBox6IsNumeric && textBox4IsNumeric)
                    {
                        // İki değer de başarıyla dönüştürüldüyse, çıkarma işlemini yap
                        float calculationResult = textBox6Value - textBox4Value;

                        // Sonucu textBox7'ye yaz
                        textBox7.Text = calculationResult.ToString();
                    }
                    else
                    {
                        // Eğer dönüştürme işlemlerinden herhangi biri başarısız olursa, hata mesajı göster
                        MessageBox.Show("Lütfen sayısal değerler giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // Burada barcode ve fiyat değerlerini kullanabilirsiniz.
                    // Örneğin, başka bir formun özelliklerine atayabilirsiniz
                    // Örneğin: digerForm.NewBarcode = barcode;
                    // Bu kısımda "digerForm" ve nasıl kullanılacağına dair daha fazla bilgiye ihtiyacımız var.
                }
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            AcilirPanelGoster();
        }
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            AcilirPanelGoster();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string FaturaNo = textBox1.Text;

                // Fatura numarasına göre verileri çek
                DataTable invoiceData = GetInvoiceData(FaturaNo);

                if (gridControl1 != null && gridView1 != null)
                {
                    // gridControl1'in MainView'unu kontrol etmek yerine, doğrudan DataSource'unu ayarla
                    gridControl1.DataSource = invoiceData;

                    // CheckBox sütunu ve GridView ayarlarını yapılandır
                    InitializeGridView(); // Bu satırı ekleyin
                    gridView1.ClearSelection();
                    gridView1.RefreshData(); // GridView verilerini yenile
                }
                else
                {
                    // gridControl veya gridView null ise, hata mesajı göster veya logla
                    Console.WriteLine("gridControl1 veya gridView1 null. Lütfen kontrol edin.");
                }
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {

            // textBox7'deki değeri float'a çevirme denemesi
            bool textBox7IsNumeric = float.TryParse(textBox7.Text, out float textBox7Value);

            if (textBox7IsNumeric && textBox7Value > 0)
            {
                // textBox7 0'dan büyük ise
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    // textBox2 boş ise uyarı ver
                    MessageBox.Show("Lütfen İban Bilgisini Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // textBox2 dolu ise SQL'e kaydetme işlemi yap
                    // SQL kaydetme işlemi burada gerçekleştirilecek

                    string serverName = Properties.Settings.Default.SunucuAdi;
                    string userName = Properties.Settings.Default.KullaniciAdi;
                    string password = Properties.Settings.Default.Sifre;
                    string database = Properties.Settings.Default.database;
                    string storecode = Properties.Settings.Default.StoreCode;
                    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                    string ordernumber = textBox1.Text;
                    string oldBarcode = textBox5.Text;


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM ZTMSGUrunDegisim WHERE Ordernumber = @Ordernumber AND OldBarcode = @OldBarcode";

                        // SQL komutunu oluştur
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Parametreleri sorguya ekleyin
                            command.Parameters.AddWithValue("@Ordernumber", ordernumber);
                            command.Parameters.AddWithValue("@OldBarcode", oldBarcode);

                            // Veritabanı bağlantısını aç
                            connection.Open();

                            // Sorguyu çalıştır
                            command.ExecuteNonQuery();

                        }
                        string query2 = "Insert Into ZTMSGUrunDegisim(Ordernumber,OldBarcode,NewBarcode,OldPrice,NewPrice,Total,Qty1,Iban,OnayDurumu) Values(@Ordernumber,@OldBarcode,@NewBarcode,@OldPrice,@NewPrice,@Total,@Qty1,@Iban,@OnayDurumu)";


                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@Ordernumber", textBox1.Text);
                            command.Parameters.AddWithValue("@OldBarcode", textBox5.Text);
                            command.Parameters.AddWithValue("@NewBarcode", textBox3.Text);
                            command.Parameters.AddWithValue("@OldPrice", textBox6.Text);
                            command.Parameters.AddWithValue("@NewPrice", textBox4.Text);
                            command.Parameters.AddWithValue("@Total", textBox7.Text);
                            command.Parameters.AddWithValue("@Qty1", textBox8.Text);
                            command.Parameters.AddWithValue("@Iban", textBox2.Text);
                            command.Parameters.AddWithValue("@OnayDurumu", "Onay Bekliyor");


                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Veri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // textBox7 0'dan büyük değilse veya sayısal bir değer içermiyorsa
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storecode = Properties.Settings.Default.StoreCode;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                string ordernumber = textBox1.Text;
                string oldBarcode = textBox5.Text;


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM ZTMSGUrunDegisim WHERE Ordernumber = @Ordernumber AND OldBarcode = @OldBarcode";

                    // SQL komutunu oluştur
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri sorguya ekleyin
                        command.Parameters.AddWithValue("@Ordernumber", ordernumber);
                        command.Parameters.AddWithValue("@OldBarcode", oldBarcode);

                        // Veritabanı bağlantısını aç
                        connection.Open();

                        // Sorguyu çalıştır
                        command.ExecuteNonQuery();

                    }
                    string query2 = "Insert Into ZTMSGUrunDegisim(Ordernumber,OldBarcode,NewBarcode,OldPrice,NewPrice,Total,Qty1,Iban,OnayDurumu) Values(@Ordernumber,@OldBarcode,@NewBarcode,@OldPrice,@NewPrice,@Total,@Qty1,@Iban,@OnayDurumu)";


                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@Ordernumber", textBox1.Text);
                        command.Parameters.AddWithValue("@OldBarcode", textBox5.Text);
                        command.Parameters.AddWithValue("@NewBarcode", textBox3.Text);
                        command.Parameters.AddWithValue("@OldPrice", textBox6.Text);
                        command.Parameters.AddWithValue("@NewPrice", textBox4.Text);
                        command.Parameters.AddWithValue("@Total", textBox7.Text);
                        command.Parameters.AddWithValue("@Qty1", textBox8.Text);
                        command.Parameters.AddWithValue("@Iban", textBox2.Text);
                        command.Parameters.AddWithValue("@OnayDurumu", "Onay Bekliyor");


                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Veri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = gridView1.FocusedRowHandle;

            // İndeks geçerli ise değerleri al
            if (index != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                // Barkod ve Fiyat değerlerini al
                object barkod = gridView1.GetRowCellValue(index, "Barcode");
                object fiyat = gridView1.GetRowCellValue(index, "Price");
                object miktar = gridView1.GetRowCellValue(index, "Qty1");

                // TextBox'lara değerleri ata
                textBox5.Text = barkod?.ToString();
                textBox6.Text = fiyat?.ToString();
                textBox8.Text = miktar?.ToString();

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
