using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

namespace ResimDuzenleme
{

    public class TrendyolService
    {
        private readonly string _apiKey = Properties.Settings.Default.txtApiKey;
        private readonly string _apiSecret = Properties.Settings.Default.txtApiSecret;

        string apiKey = Properties.Settings.Default.txtApiKey;
        string apiSecret = Properties.Settings.Default.txtApiSecret;
        string sellerId = Properties.Settings.Default.TxtSatici;
        private readonly RestClient _client;

        public TrendyolService(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _client = new RestClient("https://api.trendyol.com/sapigw");
        }

        public async Task<List<TrendyolContentModel>> GetProductsAsync(string sellerId)
        {
            var request = new RestRequest($"https://api.trendyol.com/sapigw/suppliers/{sellerId}/products?page=0&size=100000&approved=True", Method.Get);
            request.AddHeader("User-Agent", $"{sellerId} - Trendyolsoft");
            request.AddHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}"))}");

            RestResponse response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                TrendyolItemModel productResponse = JsonConvert.DeserializeObject<TrendyolItemModel>(response.Content);
                return productResponse.Content;
            }
            else
            {
            
                throw new Exception("API request failed: " + response.ErrorMessage);
            }
        }

        public async Task<bool> UpdateItemsAsync(PhotoDuzenleme.Root root)
        {


            string jsonContent = System.Text.Json.JsonSerializer.Serialize(root);

            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Put, $"https://api.trendyol.com/sapigw/suppliers/{sellerId}/v2/products");
            request.Headers.Add("User-Agent", $"{sellerId} - Trendyolsoft");
            request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}"))}");
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // Request başarılı oldu
                Console.WriteLine("Request was successful");
            }
            else
            {
                // Request hatalı oldu
                var m = response.RequestMessage;
                Console.WriteLine($"Request failed with status code {response.StatusCode}");
            }
            return true;


        }


    }
}
