using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.Json;

namespace ResimDuzenleme
{

    public class DatabaseService
    {
        private readonly string _connectionString;
        private TrendyolService trendyolService;
        public DatabaseService()
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            _connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
        }

        public async Task SaveProduct(TrendyolContentModel product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("USP_MSZTTrendyolUrun", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@barcode", product.Barcode);
                    command.Parameters.AddWithValue("@title", product.Title);
                    command.Parameters.AddWithValue("@productMainId", product.ProductMainId);
                    command.Parameters.AddWithValue("@brandId", product.BrandId);
                    command.Parameters.AddWithValue("@categoryId", product.pimCategoryId);
                    command.Parameters.AddWithValue("@stockCode", product.StockCode);
                    command.Parameters.AddWithValue("@dimensionalWeight", 1);
                    command.Parameters.AddWithValue("@vatRate", product.VatRate);
                    command.Parameters.AddWithValue("@currencyType", "TRY");
                    command.Parameters.AddWithValue("@quantity", product.Quantity);
                    command.Parameters.AddWithValue("@description", product.Description);
                    command.Parameters.AddWithValue("@listPrice", product.ListPrice);
                    command.Parameters.AddWithValue("@salePrice", product.SalePrice);
                    command.Parameters.AddWithValue("@cargoCompanyId", 1);

                    await command.ExecuteNonQueryAsync();
                }
            }


        }
        // ... mevcut kodlar ...

        public async Task SaveProductImage(string barcode, string url)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("USP_MSZTTrendyolResim", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@barcode", barcode);
                    command.Parameters.AddWithValue("@Url", url);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveProductImage2(string barcode, string url)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("USP_MSZTTrendyolResimIndir", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@barcode", barcode);
                    command.Parameters.AddWithValue("@Url", url);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task SaveProductAttribute(string barcode, ProductAttribute attribute)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("USP_MSZTTrendyolOzellik", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@barcode", barcode);
                    command.Parameters.AddWithValue("@attributeId", attribute.AttributeId);
                    command.Parameters.AddWithValue("@attributeName", attribute.AttributeName);
                    command.Parameters.AddWithValue("@attributeValueId", attribute.AttributeValueId);
                    command.Parameters.AddWithValue("@attributeValue", attribute.AttributeValue);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task ProductUpdate()
        {
            DeliveryOption option = new DeliveryOption();
            option.deliveryDuration = 2;
            option.fastDeliveryType = "FAST_DELIVERY";
            PhotoDuzenleme.Root itemModels = new PhotoDuzenleme.Root();
            List<Item2> item33 = new List<Item2>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("USP_MSZTTrendyolUrunGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Item2 item = new Item2();
                            item.barcode = reader["Barcode"].ToString();
                            item.title = reader["Title"].ToString();
                            item.productMainId = reader["ProductMainId"].ToString();
                            item.brandId = Convert.ToInt32(reader["BrandId"]);
                            item.categoryId = Convert.ToInt32(reader["CategoryId"]);
                            item.stockCode = reader["StockCode"].ToString();
                            item.dimensionalWeight = Convert.ToInt32(reader["DimensionalWeight"]);
                            item.description = reader["Description"].ToString();
                            item.deliveryDuration = 2;
                            // item.deliveryOption = option;
                            item.vatRate = Convert.ToInt32(reader["VatRate"]);
                            item.cargoCompanyId = 17;
                            item.shipmentAddressId = Convert.ToInt32(reader["ShipmentAddressId"]);
                            item.returningAddressId = Convert.ToInt32(reader["ReturningAddressId"]);
                            string jsonImages = reader["images"].ToString();
                            item.images = JsonSerializer.Deserialize<List<image>>(jsonImages);
                            string jsonAttiribute = reader["attributes"].ToString();
                            item.attributes = JsonSerializer.Deserialize<List<attribute>>(jsonAttiribute);

                            item33.Add(item);


                        }
                    }
                }

                itemModels.item33 = item33;
                string ApiKey = Properties.Settings.Default.txtApiKey;
                string ApiSecret = Properties.Settings.Default.txtApiSecret;
                trendyolService = new TrendyolService($"{ApiKey}", $"{ApiSecret}");
                await trendyolService.UpdateItemsAsync(itemModels);
            }


        }
    }
}
