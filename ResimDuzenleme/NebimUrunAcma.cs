using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


namespace ResimDuzenleme
{
    public partial class NebimUrunAcma : Form
    {
        public NebimUrunAcma()
        {
            InitializeComponent();
        }

        string ipAdresi = Properties.Settings.Default.txtEntegrator;

        private void NebimUrunAcma_Load(object sender, EventArgs e)
        {
            panel4.Visible = true;
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Colorcode, ColorDescription FROM MSGAllUrunLer WHERE Colorcode != '' GROUP BY Colorcode, ColorDescription Order by ColorDescription";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }

            checkedListBox1.DataSource = dt;
            checkedListBox1.DisplayMember = "ColorDescription";
            checkedListBox1.ValueMember = "Colorcode";
            foreach (DataRowView item in checkedListBox1.CheckedItems)
            {
                string colorDescription = item["ColorDescription"].ToString();
                string colorCode = item["Colorcode"].ToString();
                // colorDescription ve colorCode değerlerini istediğiniz şekilde kullanabilirsiniz.
            }
            DataTable dt2 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select Itemdim1code from MSGAllUrunLer where Itemdim1code != '' Group by Itemdim1code ORder by Itemdim1code";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt2);
                }
            }

            checkedListBox2.DataSource = dt2;
            checkedListBox2.DisplayMember = "Itemdim1code";
            checkedListBox2.ValueMember = "Itemdim1code";
            foreach (DataRowView item in checkedListBox1.CheckedItems)
            {
                string Itemdim1code = item["Itemdim1code"].ToString();

                // colorDescription ve colorCode değerlerini istediğiniz şekilde kullanabilirsiniz.
            }

            DataTable dt4 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select SirketKodu,DataBaseNebim from ZTMSGTicUrunAcmaParametreleri where DataBaseNebim != '' Group by SirketKodu,DataBaseNebim ORder by SirketKodu";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt4);
                }
            }

            checkedListBox3.DataSource = dt4;
            checkedListBox3.DisplayMember = "DataBaseNebim";
            checkedListBox3.ValueMember = "SirketKodu";
            foreach (DataRowView item in checkedListBox3.CheckedItems)
            {
                string colorDescription = item["DataBaseNebim"].ToString();
                string colorCode = item["SirketKodu"].ToString();
                // colorDescription ve colorCode değerlerini istediğiniz şekilde kullanabilirsiniz.
            }




            DataTable dt3 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select ProductHierarchyID,Hierarji = Case When ProductHierarchyLevel05 != '' Then ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03+ ' > '+ ProductHierarchyLevel04+ ' > '+ ProductHierarchyLevel05 Else  Case When  ProductHierarchyLevel04 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03+ ' > '+ ProductHierarchyLevel04 Else  Case When ProductHierarchyLevel03 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03 Else  Case When ProductHierarchyLevel02 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02 Else  Case When ProductHierarchyLevel01 != '' THEN ProductHierarchyLevel01  else '' END End ENd End End from MSGAllUrunLer  where  ProductHierarchyLevel01 != '' ORder by ProductHierarchyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt3);
                }
            }

            checkedListBoxControl1.DataSource = dt3;
            checkedListBoxControl1.DisplayMember = "Hierarji";
            checkedListBoxControl1.ValueMember = "ProductHierarchyID";
            foreach (DataRowView item in checkedListBox1.CheckedItems)
            {
                string HierarchyID = item["ProductHierarchyID"].ToString();
                string Hierarji = item["Hierarji"].ToString();
                // colorDescription ve colorCode değerlerini istediğiniz şekilde kullanabilirsiniz.
            }

            comboBoxEdit1.SelectedIndex = 0;
            cmbVergiGrubu.SelectedIndex = 2;
        }


        private List<string> GetSirketKodlari()
        {
            List<string> sirketKodlari = new List<string>();

            foreach (DataRowView item in checkedListBox3.CheckedItems)
            {
                string sirketKodu = item["SirketKodu"].ToString();
                sirketKodlari.Add(sirketKodu);
            }

            return sirketKodlari;
        }


        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedIndex = comboBoxEdit1.SelectedIndex;

            if (selectedIndex == 1)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (selectedIndex == 2)
            {
                panel1.Visible = true;
                panel2.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


            string anaUrunKodu = txtAnaUrunKodu.Text;
            List<string> sirketKodlari = GetSirketKodlari(); // ZtTicUrunAcmaParametreleri tablosundan SirketKodları döndüren bir fonksiyon oluşturmanız gerekiyor.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO ZTMSGTicUrunKartiAcma(ID, AnaUrunKodu, NebimUrunKodu, NebimUrunAdi, Variant, UrunHiyerarsi, MaddeVergiGrubu, MaddeHesapGrubu, MagazadaSatisaAcik, MagazadaKullanimaAcik, InternetteSatisaAcik) select @ID, @AnaUrunKodu, @NebimUrunKodu, @NebimUrunAdi, @Variant, @UrunHiyerarsi, @MaddeVergiGrubu, @MaddeHesapGrubu, @MagazadaSatisaAcik, @MagazadaKullanimaAcik, @InternetteSatisaAcik where  @NebimUrunKodu not in (select  NebimUrunKodu from ZTMSGTicUrunKartiAcma)";

                foreach (string sirketKodu in sirketKodlari)
                {
                    foreach (var item in checkedListBoxControl1.CheckedItems)
                    {
                        DataRowView row = item as DataRowView;
                        string checkedValue = row["ProductHierarchyID"].ToString(); // ValueMemberFieldName'i kendi ValueMember alanınıza göre güncelleyin.

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@ID", Guid.NewGuid());
                            command.Parameters.AddWithValue("@AnaUrunKodu", anaUrunKodu);
                            command.Parameters.AddWithValue("@NebimUrunKodu", $"{anaUrunKodu}-{sirketKodu}-{checkedValue}");
                            command.Parameters.AddWithValue("@NebimUrunAdi", txtNebimUrunAdi.Text);
                            command.Parameters.AddWithValue("@Variant", comboBoxEdit1.SelectedIndex);
                            command.Parameters.AddWithValue("@UrunHiyerarsi", $"{ checkedValue}");
                            command.Parameters.AddWithValue("@MaddeVergiGrubu", cmbVergiGrubu.Text);
                            command.Parameters.AddWithValue("@MaddeHesapGrubu", textBox1.Text);
                            command.Parameters.AddWithValue("@MagazadaSatisaAcik", checkBox1.Checked);
                            command.Parameters.AddWithValue("@MagazadaKullanimaAcik", checkBox2.Checked);
                            command.Parameters.AddWithValue("@InternetteSatisaAcik", checkBox3.Checked);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (string sirketKodu in sirketKodlari)
                {
                    foreach (var item in checkedListBoxControl1.CheckedItems)
                    {
                        var row3 = item as DataRowView;
                        string checkedValue = row3["ProductHierarchyID"].ToString();
                        foreach (object itemChecked in checkedListBox1.CheckedItems)
                        {

                            var row = itemChecked as DataRowView;
                            // ValueMemberFieldName'i kendi ValueMember alanınıza göre güncelleyin.
                            string checkedValue1 = row[checkedListBox1.ValueMember].ToString();
                            string displayValue1 = row[checkedListBox1.DisplayMember].ToString();

                            // Eğer itemChecked2 seçili değilse
                            if (checkedListBox2.CheckedItems.Count == 0)
                            {
                                using (SqlCommand command = new SqlCommand("INSERT INTO ZTMSGTicUrunVariant (ID, Itemcode, ColorCode, Colordescription, Itemdim1code, Barcode, SirketKodu) VALUES (NEWID(), @Itemcode, @ColorCode, @Colordescription, @Itemdim1code, @Barcode, @SirketKodu)", connection))
                                {
                                    command.Parameters.AddWithValue("@Itemcode", $"{anaUrunKodu}-{sirketKodu}-{checkedValue}");
                                    command.Parameters.AddWithValue("@ColorCode", checkedValue1);
                                    command.Parameters.AddWithValue("@Colordescription", displayValue1);
                                    command.Parameters.AddWithValue("@Itemdim1code", "");
                                    command.Parameters.AddWithValue("@Barcode", "");
                                    command.Parameters.AddWithValue("@SirketKodu", sirketKodu);

                                    command.ExecuteNonQuery();
                                }
                            }
                            // Eğer hem itemChecked hem de itemChecked2 seçiliyse
                            else
                            {
                                foreach (object itemChecked2 in checkedListBox2.CheckedItems)
                                {
                                    var row2 = itemChecked2 as DataRowView;
                                    string checkedValue2 = row2["Itemdim1code"].ToString(); // Burada "ValueField" yerine kendi alanınızın adını kullanın.

                                    using (SqlCommand command = new SqlCommand("INSERT INTO ZTMSGTicUrunVariant (ID, Itemcode, ColorCode, Colordescription, Itemdim1code, Barcode, SirketKodu) VALUES (NEWID(), @Itemcode, @ColorCode, @Colordescription, @Itemdim1code, @Barcode, @SirketKodu)", connection))
                                    {
                                        command.Parameters.AddWithValue("@Itemcode", $"{anaUrunKodu}-{sirketKodu}-{checkedValue}");
                                        command.Parameters.AddWithValue("@ColorCode", checkedValue1);
                                        command.Parameters.AddWithValue("@Colordescription", displayValue1);
                                        command.Parameters.AddWithValue("@Itemdim1code", checkedValue2);
                                        command.Parameters.AddWithValue("@Barcode", "");
                                        command.Parameters.AddWithValue("@SirketKodu", sirketKodu);

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        if (comboBoxEdit1.SelectedIndex == 0)
                        {
                            using (SqlCommand command = new SqlCommand("INSERT INTO ZTMSGTicUrunVariant (ID, Itemcode, ColorCode, Colordescription, Itemdim1code, Barcode, SirketKodu) VALUES (NEWID(), @Itemcode, @ColorCode, @Colordescription, @Itemdim1code, @Barcode, @SirketKodu)", connection))
                            {
                                command.Parameters.AddWithValue("@Itemcode", $"{anaUrunKodu}-{sirketKodu}-{checkedValue}");
                                command.Parameters.AddWithValue("@ColorCode", "");
                                command.Parameters.AddWithValue("@Colordescription", "");
                                command.Parameters.AddWithValue("@Itemdim1code", "");
                                command.Parameters.AddWithValue("@Barcode", $"{anaUrunKodu}-{sirketKodu}-{checkedValue}");
                                command.Parameters.AddWithValue("@SirketKodu", sirketKodu);

                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {

                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ZTMSGTicUrunKartiAcma WHERE AnaUrunKodu = @AnaUrunKodu ORDER BY NebimUrunKodu", connection))
                {
                    command.Parameters.AddWithValue("@AnaUrunKodu", anaUrunKodu);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            panel4.Visible = true;
        }

        private void BtnOzellikler_Click(object sender, EventArgs e)
        {
            string anaUrunKodu = txtAnaUrunKodu.Text;

            NebimOzellik ozellikForm = new NebimOzellik();
            ozellikForm.AnaUrunKodu = anaUrunKodu;
            ozellikForm.ShowDialog();


        }

        private void btnbarcode_Click(object sender, EventArgs e)
        {
            string anaUrunKodu = txtAnaUrunKodu.Text;

            NebimBarkod ozellikForm = new NebimBarkod();
            ozellikForm.AnaUrunKodu = anaUrunKodu;
            ozellikForm.ShowDialog();
        }

        private void BtnFiyat_Click(object sender, EventArgs e)
        {
            string anaUrunKodu = txtAnaUrunKodu.Text;

            NebimFiyat ozellikForm = new NebimFiyat();
            ozellikForm.AnaUrunKodu = anaUrunKodu;
            ozellikForm.ShowDialog();
        }

        private void BtnResimler_Click(object sender, EventArgs e)
        {
            string anaUrunKodu = txtAnaUrunKodu.Text;

            NebimResim ozellikForm = new NebimResim();
            ozellikForm.AnaUrunKodu = anaUrunKodu;
            ozellikForm.ShowDialog();
        }

        private async Task<string> ConnectIntegrator()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://" + ipAdresi + "/IntegratorService/Connect");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                VM_HttpConnectionRequest session = JsonConvert.DeserializeObject<VM_HttpConnectionRequest>(responseBody);

                string sessionId = session.SessionId;
                // Console.WriteLine(responseBody);
                return sessionId;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP isteği başarısız: {ex.Message}");
                return null;
            }
        }

        private async Task<List<Itemm>> VeritabanindanItemGetir(string anaUrunKodu)
        {
            List<Itemm> itemms = new List<Itemm>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_MSZTNebimUrunListesi", conn);
                command.CommandType = CommandType.StoredProcedure;

                // @AnaUrunKodu parametresini ekleyin
                command.Parameters.Add(new SqlParameter("@AnaUrunKodu", SqlDbType.NVarChar, 500));
                command.Parameters["@AnaUrunKodu"].Value = anaUrunKodu;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Itemm itemm = new Itemm();

                    itemm.ModelType = reader["ModelType"].ToString();
                    itemm.ItemTypeCode = reader["ItemTypeCode"].ToString();
                    itemm.ItemCode = reader["ItemCode"].ToString();
                    itemm.ItemDescription = reader["ItemDescription"].ToString();
                    itemm.ItemDimTypeCode = Convert.ToInt32(reader["ItemDimTypeCode"]);
                    itemm.ItemTaxGrCode = reader["ItemTaxGrCode"].ToString();
                    itemm.ProductHierarchyID = Convert.ToInt32(reader["ProductHierarchyID"]);
                    itemm.UsePOS = Convert.ToBoolean(reader["UsePOS"]);
                    itemm.UseStore = Convert.ToBoolean(reader["UseStore"]);
                    itemm.UseInternet = Convert.ToBoolean(reader["UseInternet"]);
                    itemm.UnitOfMeasureCode1 = reader["UnitOfMeasureCode1"].ToString();
                    itemm.UseBatch = Convert.ToBoolean(reader["UseBatch"]);
                    itemm.UseManufacturing = Convert.ToBoolean(reader["UseManufacturing"]);
                    itemm.UseRoll = Convert.ToBoolean(reader["UseRoll"]);
                    itemm.UseSerialNumber = Convert.ToBoolean(reader["UseSerialNumber"]);

                    string variantJson = reader["Variant"].ToString();

                    if (!string.IsNullOrEmpty(variantJson) && variantJson != "null")
                    {
                        JArray variantArray = JArray.Parse(variantJson);
                        itemm.Variants = variantArray.ToObject<List<Variant>>();
                    }

                    string BarcodesJson = reader["Barcodes"].ToString();

                    if (!string.IsNullOrEmpty(BarcodesJson) && BarcodesJson != "null")
                    {
                        JArray BarcodesArray = JArray.Parse(BarcodesJson);
                        itemm.Barcodes = BarcodesArray.ToObject<List<Barcodes>>();
                    }

                    string BasePricesJson = reader["BasePrices"].ToString();

                    if (!string.IsNullOrEmpty(BasePricesJson) && BasePricesJson != "null")
                    {
                        JArray BasePricesArray = JArray.Parse(BasePricesJson);
                        itemm.BasePrices = BasePricesArray.ToObject<List<BasePrice>>();
                    }

                    string DescriptionsJson = reader["Descriptions"].ToString();

                    if (!string.IsNullOrEmpty(DescriptionsJson) && DescriptionsJson != "null")
                    {
                        JArray DescriptionsArray = JArray.Parse(DescriptionsJson);
                        itemm.Descriptions = DescriptionsArray.ToObject<List<Descriptions>>();
                    }

                    string ItemNotesJson = reader["ItemNotes"].ToString();

                    if (!string.IsNullOrEmpty(ItemNotesJson) && ItemNotesJson != "null")
                    {
                        JArray ItemNotesArray = JArray.Parse(ItemNotesJson);
                        itemm.ItemNotes = ItemNotesArray.ToObject<List<ItemNote>>();
                    }
                    // Diğer alanları doldurmak için benzer işlemler...

                    itemms.Add(itemm);
                }
            }

            return itemms;
        }

        private async void nbmNebimAktar_Click(object sender, EventArgs e)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;

            string kolonAdi = Properties.Settings.Default.txtlot; // Kolon adını alır.

            if (!string.IsNullOrWhiteSpace(kolonAdi))
            {
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Şimdi aldığınız veriyi cdLot tablosuna ekleyin.
                    string insertQuery = $"INSERT INTO cdLot (LotCode, ItemDimTypeCode, IsBlocked) " +
                                         $"SELECT {kolonAdi}, 2, 0 " +
                                         $"FROM ztTicUrunler " +
                                         $"WHERE {kolonAdi} != '' AND {kolonAdi} NOT IN (SELECT LotCode FROM cdLot) " +
                                         $"GROUP BY {kolonAdi}";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} rows inserted.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir kolon adı giriniz!");
            }


            // İşlem başlangıç mesajı
            labelStatus.Text = "İşlem başladı...";

            string sessionID = await ConnectIntegrator();

            List<Itemm> items = await VeritabanindanItemGetir(txtAnaUrunKodu.Text);

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            int postCount = 0;
            foreach (var item in items)
            {



                // JSON dizesini oluştur
                string json = JsonConvert.SerializeObject(item, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                //string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "İşlem tamamlandı.";
        }
    }
}
