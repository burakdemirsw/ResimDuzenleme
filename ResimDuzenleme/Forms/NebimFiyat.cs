using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class NebimFiyat : Form
    {
        public NebimFiyat( )
        {
            InitializeComponent();
        }
        public string AnaUrunKodu { get; set; }
        private void NebimFiyat_Load(object sender, EventArgs e)
        {
            label2.Text = AnaUrunKodu;
        }
        private List<string> GetSirketKodlari( )
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            List<string> sirketKodlari = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "select NebimUrunKodu from ZTMSGTicUrunKartiAcma where AnaUrunKodu = @NebimUrunKodu ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NebimUrunKodu", AnaUrunKodu);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sirketKodlari.Add(reader["NebimUrunKodu"].ToString());
                        }
                    }
                }
            }

            return sirketKodlari;
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            List<string> sirketKodlari = GetSirketKodlari(); // ZtTicUrunAcmaParametreleri tablosundan SirketKodları döndüren bir fonksiyon oluşturmanız gerekiyor.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO ZTMSGTicUrunFiyat(ID, Itemcode, BasePriceCode, Price) select @ID, @NebimUrunKodu,@BasepriceCode,@Price where  @NebimUrunKodu not in (select  Itemcode from ZTMSGTicUrunFiyat where Itemcode = @NebimUrunKodu and BasepriceCode=@BasepriceCode)";
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 1);
                        command.Parameters.AddWithValue("@Price", txtmaliyet.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 2);
                        command.Parameters.AddWithValue("@Price", txtsatinalma.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 3);
                        command.Parameters.AddWithValue("@Price", textBox3.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 4);
                        command.Parameters.AddWithValue("@Price", textBox4.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 5);
                        command.Parameters.AddWithValue("@Price", textBox5.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 6);
                        command.Parameters.AddWithValue("@Price", textBox6.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 7);
                        command.Parameters.AddWithValue("@Price", textBox7.Text);


                        command.ExecuteNonQuery();
                    }
                }
                foreach (string sirketKodu in sirketKodlari)
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", Guid.NewGuid());

                        command.Parameters.AddWithValue("@NebimUrunKodu", $"{sirketKodu}");
                        command.Parameters.AddWithValue("@BasepriceCode", 8);
                        command.Parameters.AddWithValue("@Price", textBox8.Text);


                        command.ExecuteNonQuery();
                    }
                }

            }
        }
    }
}
