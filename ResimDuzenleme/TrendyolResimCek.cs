using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class TrendyolResimCek : Form
    {
        public TrendyolResimCek( )
        {
            InitializeComponent();
            var apiKey = Properties.Settings.Default.txtApiKey;
            var apiSecret = Properties.Settings.Default.txtApiSecret;
            _trendyolService = new TrendyolService(apiKey, apiSecret);
            _databaseService = new DatabaseService();
        }
        private TrendyolService _trendyolService;
        private DatabaseService _databaseService;
        private async void TrendyolResimCek_Load(object sender, EventArgs e)
        {
            await SendRequest();
        }
        private async Task SendRequest( )

        {
            try
            {
                var sellerId = Properties.Settings.Default.TxtSatici;
                List<TrendyolContentModel> products = await _trendyolService.GetProductsAsync(sellerId);
                var count = 1;
                foreach (var product in products)
                {
                    progressBar1.Value = (count * 100) / products.Count;
                    await _databaseService.SaveProduct(product);
                    var attributes = product.Attributes;
                    foreach (var attribute in attributes)
                    {
                        try
                        {
                            await _databaseService.SaveProductAttribute(product.Barcode, attribute);
                        }
                        catch (Exception ex)
                        {
                            // Burada hatayı loglamak veya kullanıcıya bildirmek gibi işlemler yapabilirsiniz.
                            Console.WriteLine($"An error occurred while saving product attribute. Barcode: {product.Barcode}, Attribute: {attribute}. Error: {ex.Message}");
                        }
                    }


                    List<ProductImage> Images = product.Images;
                    foreach (var image in Images)
                    {
                        await _databaseService.SaveProductImage(product.Barcode, image.Url);

                    }

                    List<ProductImage> Images2 = product.Images;
                    foreach (var image in Images2)
                    {
                        await _databaseService.SaveProductImage2(product.Barcode, image.Url);

                    }
                    // await _databaseService.SaveProductImage(barcode, Url);
                    count++;
                }
                MessageBox.Show("İşlem Tamamlandı.");
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
    }
}
