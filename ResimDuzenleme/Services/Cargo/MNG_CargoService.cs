

using Newtonsoft.Json;
using ResimDuzenleme.Services.Models.MNG.Request;
using ResimDuzenleme.Services.Models.MNG.Response;
using ResimDuzenleme.Services.Models.MNG;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ResimDuzenleme.Services.Models.Entities;
using Nancy.Json;
using System.Linq;
using ResimDuzenleme.Services.Database;
using ResimDuzenleme.Services.Helpers;

namespace ResimDuzenleme.Services.Cargo
{
    public class MNG_CargoService
    {
        //700453564
        //Asr2023.
        string UserName = "798480508";
        string Password = "Vpolarstar3.";
        string ClientId = "9d9d9e37fccc18f1f9e4d0bf9f4af29c";
        string ClientSecret = "f491873cb2d37b39bf5ad3341fd0d410";
        
        public async Task<CreateCargo_RM<CreatePackage_MNG_RR>> CreateCargo(CreatePackage_MNG_RM request)
        {

            try
            {
                string url = "https://api.mngkargo.com.tr/mngapi/api/standardcmdapi/createOrder";
                string clientId = ClientId;
                string clientSecret = ClientSecret;


                CreateTokenResponse_MNG token = await CreateToken();
                if (token == null)
                {
                    CreateCargo_RM<CreatePackage_MNG_RR> cargoResponse = new CreateCargo_RM<CreatePackage_MNG_RR>();
                    cargoResponse.Status = false;
                    cargoResponse.ErrMsg = "Token Null";
                    return cargoResponse;
                }

                string json = JsonConvert.SerializeObject(request.OrderRequest, new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                });

                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                    client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Jwt.ToString());

                    //Console.WriteLine(token.Jwt);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseContent = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        CreatePackage_MNG_Response[] tokenResponse = JsonConvert.DeserializeObject<CreatePackage_MNG_Response[]>(responseContent);
                        if (tokenResponse != null && tokenResponse.Length > 0)
                        {

                            for (int i = 1; i <= request.BarcodeRequest.OrderPieceList.Count; i++)
                            {
                                CargoBarcode _cargoBarcode = new CargoBarcode();
                                _cargoBarcode.BarcodeSequence = i;
                                _cargoBarcode.CargoFirmId = request.CargoFirmId;
                                _cargoBarcode.OrderRequest = new JavaScriptSerializer().Serialize(request.OrderRequest);

                                _cargoBarcode.OrderResponse = new JavaScriptSerializer().Serialize(tokenResponse[0]);
                                //_cargoBarcode.BarcodeResponse = new JavaScriptSerializer().Serialize(tokenResponse);
                                _cargoBarcode.OrderNo = request.OrderRequest.Order.BillOfLandingId;
                                //_cargoBarcode.BarcodeZplCode = tokenResponse[0].Barcodes[0].Value;
                                //_cargoBarcode.ShipmentId = tokenResponse[0].ShipmentId;
                                _cargoBarcode.ReferenceId = request.OrderRequest.Order.ReferenceId;
                                _cargoBarcode.CreatedDate = DateTime.Now;
                                _cargoBarcode.Customer = request.OrderRequest.Recipient.FullName;
                                _cargoBarcode.BarcodeRequest = new JavaScriptSerializer().Serialize(request.BarcodeRequest);
                                _cargoBarcode.Desi = request.BarcodeRequest.OrderPieceList.First().Desi;
                                _cargoBarcode.Kg = request.BarcodeRequest.OrderPieceList.First().Desi;
                                _cargoBarcode.PackagingType = request.BarcodeRequest.PackagingType;

                                using (var context = new Context())
                                {
                                    var repository = new DbContextRepository<CargoBarcode>(context);
                                     repository.Add(_cargoBarcode);

                                }
   
                            }
                            CreatePackage_MNG_RR _response = new CreatePackage_MNG_RR();
                            _response.Response = tokenResponse[0];
                            _response.Request = request.OrderRequest;

                            CreateCargo_RM<CreatePackage_MNG_RR> cargoResponse = new CreateCargo_RM<CreatePackage_MNG_RR>();
                            cargoResponse.CargoResponse = _response;
                            cargoResponse.Status = true;
                            return cargoResponse;
                        }
                        else
                        {
                            CreateCargo_RM<CreatePackage_MNG_RR> cargoResponse = new CreateCargo_RM<CreatePackage_MNG_RR>();
                            cargoResponse.Status = false;
                            cargoResponse.ErrMsg = responseContent;
                            return cargoResponse;
                        }

                    }
                    else
                    {
                        CreateCargo_RM<CreatePackage_MNG_RR> cargoResponse = new CreateCargo_RM<CreatePackage_MNG_RR>();
                        cargoResponse.Status = false;
                        cargoResponse.ErrMsg = responseContent;
                        return cargoResponse;
                    }
                }

            }
            catch (Exception ex)
            {
                CreateCargo_RM<CreatePackage_MNG_RR> cargoResponse = new CreateCargo_RM<CreatePackage_MNG_RR>();
                cargoResponse.Status = false;
                cargoResponse.ErrMsg = ex.Message;
                return cargoResponse;
            }

        }
        public async Task<BulkDeleteShipment_RM> DeleteShippedCargo(DeletePackage_MNG_Request request)
        {

            string url = "https://api.mngkargo.com.tr/mngapi/api/barcodecmdapi/cancelshipment";
            string clientId = ClientId;
            string clientSecret = ClientSecret;


            CreateTokenResponse_MNG token = await CreateToken();
            if (token == null)
            {
                throw new Exception("Token Null");
            }

            string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });

            //Console.WriteLine(json);
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Jwt.ToString());

                //Console.WriteLine(token.Jwt);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    using (var context = new Context())
                    {
                        var repository = new DbContextRepository<CargoBarcode>(context);
                    
                        List<CargoBarcode> cargoBarcodes = repository._dbSet.Where(c => c.ReferenceId == request.ReferenceId).ToList();

                        foreach (var cargoBarcode in cargoBarcodes)
                        {
                            repository.Delete(cargoBarcode);

                        }
                        BulkDeleteShipment_RM bulkDeleteShipment_RM = new BulkDeleteShipment_RM();
                        bulkDeleteShipment_RM.ReferenceId = JsonConvert.SerializeObject(cargoBarcodes.Select(p => p.ReferenceId).ToList());
                        bulkDeleteShipment_RM.Status = true;
                        return bulkDeleteShipment_RM;

                    }

                }
                else
                {
                    using (var context = new Context())
                    {
                        var repository = new DbContextRepository<CargoBarcode>(context);
                      
                        List<CargoBarcode> cargoBarcodes = repository._dbSet.Where(c => c.ReferenceId == request.ReferenceId).ToList();

                        foreach (var cargoBarcode in cargoBarcodes)
                        {

                            repository.Delete(cargoBarcode);

                        }
                        BulkDeleteShipment_RM bulkDeleteShipment_RM = new BulkDeleteShipment_RM();
                        bulkDeleteShipment_RM.ReferenceId = JsonConvert.SerializeObject(cargoBarcodes.Select(p => p.ReferenceId).ToList());
                        bulkDeleteShipment_RM.Status = true;
                        return bulkDeleteShipment_RM;


                    }
              
                }
            }

        }

     
        public async Task<CreateBarcode_MNG_Response> CreateBarcode(string referenceId)
        {
            using (var context = new Context())
            {
                var repository = new DbContextRepository<CargoBarcode>(context);
          
                List<CargoBarcode> cargoBarcodes =  repository._dbSet.Where(cb => cb.ReferenceId == referenceId).ToList();
            List<string> barcodePaths = new List<string>();
            foreach (var cargoBarcode in cargoBarcodes)
            {
                if (cargoBarcode.BarcodeZplCode == null)
                {
                    continue;
                }
                if (cargoBarcode.BarcodeZplCode != null)
                {
                    if (cargoBarcode.CargoFirmId == 1)
                    {

                        string path = await GeneralService.ConvertZplToPng(cargoBarcode.BarcodeZplCode);
                        barcodePaths.Add(path);
                        continue;

                    }
                    else
                    {

                        //BarcodeResult result = await _arasCargoService.GetBarcode(referenceId);
                        string path = await GeneralService.ConvertZplToPng(cargoBarcode.BarcodeZplCode);
                        barcodePaths.Add(path);
                        continue;

                    }

                }

            }

            if (cargoBarcodes.Any(b => b.BarcodeZplCode != null))
            {
                return new CreateBarcode_MNG_Response() { BarcodePaths = barcodePaths };
            }
            if (cargoBarcodes.First().CargoFirmId == 1)
            {

                CreateBarcode_MNG_Request Request = JsonConvert.DeserializeObject<CreateBarcode_MNG_Request>(cargoBarcodes.First().BarcodeRequest);


                string url = "https://api.mngkargo.com.tr/mngapi/api/barcodecmdapi/createbarcode";
                string clientId = ClientId;
                string clientSecret = ClientSecret;


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


                    if (response.IsSuccessStatusCode)
                    {

                        CreateBarcode_MNG_Response[] tokenResponse = JsonConvert.DeserializeObject<CreateBarcode_MNG_Response[]>(responseContent);
                        if (tokenResponse != null && tokenResponse.Length > 0)
                        {
                            try
                            {
                                var index = 0;
                                foreach (var barcode in tokenResponse)
                                {
                                    List<CargoBarcode> __cargoBarcodes = repository._dbSet.Where(cb => cb.ReferenceId == Request.ReferenceId && cb.BarcodeZplCode == null).ToList();
                                    foreach (var _cargoBarcode in __cargoBarcodes)
                                    {
                                        _cargoBarcode.BarcodeZplCode = barcode.Barcodes[0].Value;
                                        _cargoBarcode.ShipmentId = barcode.ShipmentId;
                                        _cargoBarcode.BarcodeResponse = new JavaScriptSerializer().Serialize(tokenResponse);
                                         repository.Update(_cargoBarcode);
                                        break;
                                    }
                                    index++;

                                }
                           

                                List<CargoBarcode> _cargoBarcodes = repository._dbSet.Where(cb => cb.ReferenceId == Request.ReferenceId && cb.BarcodeZplCode != null).ToList();

                                foreach (var _cargoBarcode in _cargoBarcodes)
                                {
                                    string path = await  GeneralService.ConvertZplToPng(_cargoBarcode.BarcodeZplCode);
                                    barcodePaths.Add(path);
                                }

                                tokenResponse[0].BarcodePaths = barcodePaths;
                                return tokenResponse[0];

                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.Message + ex.InnerException);
                            }
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

            }
            else
            {
                return new CreateBarcode_MNG_Response();
            }
            throw new Exception($"KOD ERROR");
            }

        }
        public async Task ConvertPNG(string zpl)
        {

            var zplAsBytes = System.Text.Encoding.UTF8.GetBytes(zpl);
            var requestContent = new ByteArrayContent(zplAsBytes);

            requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    using (var ms = await response.Content.ReadAsStreamAsync())
                    {
                        using (var fs = new FileStream(@"C:\code\label.png", FileMode.Create, FileAccess.Write))
                        {
                            ms.CopyTo(fs);
                            fs.Flush();
                        }
                    }

                    //Console.WriteLine("Etiket PNG olarak kaydedildi.");
                }
                else
                {
                    //Console.WriteLine("Bir hata oluştu: " + response.StatusCode);
                }
            }
        }
        public async Task<CreateTokenResponse_MNG> CreateToken( )
        {
            string url = "https://api.mngkargo.com.tr/mngapi/api/token";
            string clientId = ClientId;
            string clientSecret = ClientSecret;

            var request = new CreateToken_MNG_Request
            {
                CustomerNumber = UserName,
                Password = Password,
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
                    var _reponse = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine($"Error: {_reponse}");
                    return null;
                }
            }
        }
        async Task<bool> PrintBarcode(string zplCode)
        {
            return ZplPrinterService.SendStringToPrinter("KARGOYAZICISI", zplCode);
        }
        public Bitmap Base64ToBitmap(string base64string)
        {


            // Convert Base64 string to byte array
            byte[] imageBytes = Convert.FromBase64String(base64string);

            // Create a memory stream from the byte array
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                // Create Bitmap from memory stream
                Bitmap bitmap = new Bitmap(ms);

                // Now you have your bitmap, you can use it as needed
                // For example, you can save it to a file
                return bitmap;
            }
        }
        public async Task<bool> PrintSingleBarcode(string zplCode)
        {

            await GeneralService.ConvertAndPrintBarcode(zplCode);
            return true;
        }
        public async Task<GetPackageStatus_MNG_Response> GetPackageStatus(string ShipmentId)
        {
            string url = $"https://api.mngkargo.com.tr/mngapi/api/standardqueryapi/getshipmentstatus/{ShipmentId}";
            string clientId = ClientId;
            string clientSecret = ClientSecret;


            CreateTokenResponse_MNG token = await CreateToken();
            if (token == null)
            {
                throw new Exception("Token Null");
            }

            //string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            //{
            //    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            //});

            //Console.WriteLine(json);
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("X-IBM-Client-Id", clientId.Trim());
                client.DefaultRequestHeaders.Add("X-IBM-Client-Secret", clientSecret.ToString());
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Jwt.ToString());

                //Console.WriteLine(token.Jwt);


                HttpResponseMessage response = await client.GetAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();


                if (response.IsSuccessStatusCode)
                {
                    GetPackageStatus_MNG_Response[] tokenResponse = JsonConvert.DeserializeObject<GetPackageStatus_MNG_Response[]>(responseContent);

                    return tokenResponse[0];


                }
                else
                {
                    return null;
                }
            }



        }
    }
}
