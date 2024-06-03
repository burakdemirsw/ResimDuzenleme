using GoogleAPI.Domain.Models.Cargo.Mng.Request;
using GoogleAPI.Domain.Models.Cargo.Mng.Response;
using GoogleAPI.Domain.Models.Cargo.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Mng
{
    public class MngCargoService
    {
        string clientId = "13c64294-5214-4441-9a3c-506d4dd73769";
        string clientSecret = "28d13e7e94e4b8a417e2a029563eb2d0";
        string userName = "700453564";
            string password = "Asr2023.";
        public string GenerateRandomNumber()
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();

            // İlk rakamın 0 olmaması için ayrı bir işlem yapılır
            sb.Append(rand.Next(1, 10));

            // Kalan 14 hane için döngü
            for (int i = 1; i < 15; i++)
            {
                sb.Append(rand.Next(0, 10));
            }

            string randomNumberString = sb.ToString();

            return randomNumberString;

            // Gerekiyorsa büyük sayılarla çalışmak için bu string'i BigInteger'a çevirebilirsiniz.
            // Örneğin:
            // BigInteger bigInt = BigInteger.Parse(randomNumberString);
            // Console.WriteLine($"BigInteger olarak: {bigInt}");
        }
        public async Task<CreatePackage_MNG_RR> CreateCargo(CreatePackage_MNG_Request request)
        {

            string url = "https://api.mngkargo.com.tr/mngapi/api/standardcmdapi/createOrder";
     


            CreateTokenResponse_MNG token = await CreateToken();

            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });

            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Jwt.ToString());


                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {

                    CreatePackage_MNG_Response[] tokenResponse = JsonConvert.DeserializeObject<CreatePackage_MNG_Response[]>(responseContent);
                    if (tokenResponse != null && tokenResponse.Length > 0)
                    {
                        CreatePackage_MNG_RR _response = new CreatePackage_MNG_RR();
                        _response.Response = tokenResponse[0];
                        _response.Request = request;
                        return _response;

                    }
                    else
                    {
                        throw new Exception($"Gelen Yanıt Yok:{responseContent}");
                    }

                }
                else
                {
                    throw new Exception($"Yanıt Başarısız:{responseContent}");
                }
            }



            throw new NotImplementedException();
        }
        public async Task<CreateBarcode_MNG_Response> CreateBarcode(CreateBarcode_MNG_Request Request)
        {

            string url = "https://api.mngkargo.com.tr/mngapi/api/barcodecmdapi/createbarcode";



            CreateTokenResponse_MNG token = await CreateToken();
            CreateBarcode_MNG_Request request = new CreateBarcode_MNG_Request();
            request.ReferenceId = Request.ReferenceId;
            request.BillOfLandingId = Request.BillOfLandingId;
            request.IsCOD = Request.IsCOD;
            request.CodAmount = Request.CodAmount;
            request.PackagingType = Request.PackagingType;
            request.OrderPieceList = Request.OrderPieceList;
            string json = JsonConvert.SerializeObject(request);

            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Jwt.ToString());


                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode) //200 
                {

                    CreateBarcode_MNG_Response[] tokenResponse = JsonConvert.DeserializeObject<CreateBarcode_MNG_Response[]>(responseContent);
                    if (tokenResponse != null && tokenResponse.Length > 0)
                    {
                        //await ConvertPNG(tokenResponse[0].Barcodes[0].Value);
                        return tokenResponse[0];

                    }
                    else
                    {
                        throw new Exception($"Gelen Yanıt Yok:{responseContent}");
                    }

                }
                else
                {
                    throw new Exception($"Yanıt Başarısız:{responseContent}");
                }
            }



            throw new NotImplementedException();
        }
        //public async Task ConvertPNG(string zpl)
        //{

        //    var zplAsBytes = System.Text.Encoding.UTF8.GetBytes(zpl);
        //    var requestContent = new ByteArrayContent(zplAsBytes);

        //    requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

        //    using (var httpClient = new HttpClient())
        //    {
        //        var response = await httpClient.PostAsync("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/", requestContent);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            using (var ms = await response.Content.ReadAsStreamAsync())
        //            {
        //                using (var fs = new FileStream(@"C:\code\label.png", FileMode.Create, FileAccess.Write))
        //                {
        //                    ms.CopyTo(fs);
        //                    fs.Flush();
        //                }
        //            }

        //            Console.WriteLine("Etiket PNG olarak kaydedildi.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Bir hata oluştu: " + response.StatusCode);
        //        }
        //    }
        //}


        public async Task<CreateTokenResponse_MNG> CreateToken()
        {
            string url = "https://api.mngkargo.com.tr/mngapi/api/token";


            var request = new CreateToken_MNG_Request
            {
                CustomerNumber = userName,
                Password = password,
                IdentityType = 1
            };
            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });


            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                //Console.WriteLine(clientId);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    CreateTokenResponse_MNG tokenResponse = JsonConvert.DeserializeObject<CreateTokenResponse_MNG>(responseContent);
                    return tokenResponse;


                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
        }

        //async Task<bool> PrintBarcode(string zplCode)
        //{
        //    return ZplPrinterService.SendStringToPrinter(_configuriation["Printers:ZplPrinterName"], zplCode);
        //}

        public Task<bool> DeleteCargo()
        {
            throw new NotImplementedException();
        }
    }
}
