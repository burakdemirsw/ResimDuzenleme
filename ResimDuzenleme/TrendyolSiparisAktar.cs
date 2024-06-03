using Newtonsoft.Json;
using ResimDuzenleme.TrendyolRoot;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class TrendyolSiparisAktar : Form
    {
        public TrendyolSiparisAktar( )
        {
            InitializeComponent();
        }

        private async void btnSiparisCek_Click(object sender, EventArgs e)
        {
            await GetTrendyolOrderModels();
        }
        private long GetTimestampMillis(DateTime dateTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime - epoch).TotalMilliseconds;
        }
        private HttpClient TrendyolClient( )
        {
            HttpClient client = new HttpClient();

            string authorizationHeader = Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{Properties.Settings.Default.txtApiKey}:{Properties.Settings.Default.txtApiSecret}")
            );
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authorizationHeader);

            // HTTP isteği oluştur ve ayarla

            client.DefaultRequestHeaders.Add(
                "User-Agent",
                $"{Properties.Settings.Default.TxtSatici}-SelfIntegration"
            );

            return client;
        }
        public async Task<List<TrendyolOrderModel>> GetTrendyolOrderModels( )
        {
            // Trendyol API isteği için gereken bilgiler
            string apiUrl = $"https://api.trendyol.com/sapigw/suppliers/{Properties.Settings.Default.TxtSatici}/orders";

            // Başlangıç tarihini al
            DateTime startDateSelected = dateTimePicker1.Value;

            // Bitiş tarihini al
            DateTime endDateSelected = dateTimePicker2.Value;

            // Başlangıç tarihinden max 7 gün fazla olmamasını sağla
            if ((endDateSelected - startDateSelected).TotalDays > 7)
            {
                MessageBox.Show("Başlangıç tarihinden en fazla 7 gün sonrasına kadar seçim yapabilirsiniz.");
                // Varsa hatalı tarih seçimini düzeltmek için gerekli adımları burada yapabilirsiniz.
                return null;
            }

            // Unix zaman damgasını hesaplamak için gerekli metot
            long GetTimestampMillis(DateTime dateTime)
            {
                return (long)(dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            }

            // Başlangıç ve bitiş tarihlerini ayarla
            long startDate = GetTimestampMillis(startDateSelected);
            long endDate = GetTimestampMillis(endDateSelected.AddDays(1)); // Belirtilen tarihe kadar olan siparişleri almak için, son günü de dahil etmek için 1 gün ekleyin.

            // API isteğini oluştur
            string requestUrl = $"{apiUrl}?status=Picking&Shipped&Created&startDate={startDate}&endDate={endDate}&orderByField=PackageLastModifiedDate&orderByDirection=DESC&size=200";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            HttpClient client = TrendyolClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();


                var responseObj = JsonConvert.DeserializeObject<dynamic>(responseBody);

                List<Root2> root2List = new List<Root2>();

                foreach (var order in responseObj.content)
                {
                    Root2 root2 = new Root2();

                    root2.shipmentAddress = new ShipmentAddress();
                    root2.shipmentAddress.id = order.shipmentAddress.id;
                    root2.shipmentAddress.firstName = order.shipmentAddress.firstName;
                    root2.shipmentAddress.lastName = order.shipmentAddress.lastName;
                    root2.shipmentAddress.company = order.shipmentAddress.company;
                    root2.shipmentAddress.address1 = order.shipmentAddress.address1;
                    root2.shipmentAddress.address2 = order.shipmentAddress.address2;
                    root2.shipmentAddress.city = order.shipmentAddress.city;
                    root2.shipmentAddress.cityCode = order.shipmentAddress.cityCode;
                    root2.shipmentAddress.district = order.shipmentAddress.district;
                    root2.shipmentAddress.districtId = order.shipmentAddress.districtId;
                    root2.shipmentAddress.postalCode = order.shipmentAddress.postalCode;
                    root2.shipmentAddress.countryCode = order.shipmentAddress.countryCode;
                    root2.shipmentAddress.neighborhoodId = order.shipmentAddress.neighborhoodId;
                    root2.shipmentAddress.neighborhood = order.shipmentAddress.neighborhood;
                    root2.shipmentAddress.phone = order.shipmentAddress.phone;
                    root2.shipmentAddress.fullAddress = order.shipmentAddress.fullAddress;
                    root2.shipmentAddress.fullName = order.shipmentAddress.fullName;

                    root2.orderNumber = order.orderNumber;
                    root2.grossAmount = order.grossAmount;
                    root2.totalDiscount = order.totalDiscount;
                    root2.totalTyDiscount = order.totalTyDiscount;
                    root2.taxNumber = order.taxNumber;

                    root2.invoiceAddress = new InvoiceAddress();
                    root2.invoiceAddress.id = order.invoiceAddress.id;
                    root2.invoiceAddress.firstName = order.invoiceAddress.firstName;
                    root2.invoiceAddress.lastName = order.invoiceAddress.lastName;
                    root2.invoiceAddress.company = order.invoiceAddress.company;
                    root2.invoiceAddress.address1 = order.invoiceAddress.address1;
                    root2.invoiceAddress.address2 = order.invoiceAddress.address2;
                    root2.invoiceAddress.city = order.invoiceAddress.city;
                    root2.invoiceAddress.cityCode = order.invoiceAddress.cityCode;
                    root2.invoiceAddress.district = order.invoiceAddress.district;
                    root2.invoiceAddress.districtId = order.invoiceAddress.districtId;
                    root2.invoiceAddress.postalCode = order.invoiceAddress.postalCode;
                    root2.invoiceAddress.countryCode = order.invoiceAddress.countryCode;
                    root2.invoiceAddress.neighborhoodId = order.invoiceAddress.neighborhoodId;
                    root2.invoiceAddress.neighborhood = order.invoiceAddress.neighborhood;
                    root2.invoiceAddress.phone = order.invoiceAddress.phone;
                    root2.invoiceAddress.fullAddress = order.invoiceAddress.fullAddress;
                    root2.invoiceAddress.fullName = order.invoiceAddress.fullName;

                    root2.customerFirstName = order.customerFirstName;
                    root2.customerEmail = order.customerEmail;
                    root2.customerId = order.customerId;
                    root2.customerLastName = order.customerLastName;
                    root2.id = order.id;
                    root2.cargoTrackingNumber = order.cargoTrackingNumber;
                    root2.cargoProviderName = order.cargoProviderName;

                    root2.lines = new List<Line>();
                    foreach (var line in order.lines)
                    {
                        Line newLine = new Line();

                        newLine.quantity = line.quantity;
                        newLine.salesCampaignId = line.salesCampaignId;
                        newLine.productSize = line.productSize;
                        newLine.merchantSku = line.merchantSku;
                        newLine.productName = line.productName;
                        newLine.productCode = line.productCode;
                        newLine.merchantId = line.merchantId;
                        newLine.amount = line.amount;
                        newLine.discount = line.discount;
                        newLine.tyDiscount = line.tyDiscount;
                        newLine.discountDetails = null;
                        newLine.currencyCode = line.currencyCode;
                        newLine.productColor = line.productColor;
                        newLine.id = line.id;
                        newLine.sku = line.sku;
                        newLine.vatBaseAmount = line.vatBaseAmount;
                        newLine.barcode = line.barcode;
                        newLine.orderLineItemStatusName = line.orderLineItemStatusName;
                        newLine.price = line.price;
                        newLine.fastDeliveryOptions = null;

                        root2.lines.Add(newLine);
                    }

                    root2.orderDate = order.orderDate;
                    root2.tcIdentityNumber = order.tcIdentityNumber;
                    root2.currencyCode = order.currencyCode;

                    root2.packageHistories = new List<PackageHistory>();
                    foreach (var history in order.packageHistories)
                    {
                        PackageHistory newHistory = new PackageHistory();
                        newHistory.createdDate = history.createdDate;
                        newHistory.status = history.status;

                        root2.packageHistories.Add(newHistory);
                    }

                    root2.shipmentPackageStatus = order.shipmentPackageStatus;
                    root2.status = order.status;
                    root2.deliveryType = order.deliveryType;
                    root2.timeSlotId = order.timeSlotId;
                    root2.scheduledDeliveryStoreId = order.scheduledDeliveryStoreId;
                    root2.estimatedDeliveryStartDate = order.estimatedDeliveryStartDate;
                    root2.estimatedDeliveryEndDate = order.estimatedDeliveryEndDate;
                    root2.totalPrice = order.totalPrice;
                    root2.deliveryAddressType = order.deliveryAddressType;
                    root2.agreedDeliveryDate = order.agreedDeliveryDate;
                    root2.fastDelivery = order.fastDelivery;
                    root2.originShipmentDate = order.originShipmentDate;
                    root2.lastModifiedDate = order.lastModifiedDate;
                    root2.commercial = order.commercial;
                    root2.fastDeliveryType = order.fastDeliveryType;
                    root2.deliveredByService = order.deliveredByService;
                    root2.agreedDeliveryDateExtendible = order.agreedDeliveryDateExtendible;
                    root2.extendedAgreedDeliveryDate = order.extendedAgreedDeliveryDate;
                    root2.agreedDeliveryExtensionEndDate = order.agreedDeliveryExtensionEndDate;
                    root2.agreedDeliveryExtensionStartDate = order.agreedDeliveryExtensionStartDate;
                    root2.warehouseId = order.warehouseId;
                    root2.groupDeal = order.groupDeal;
                    root2.invoiceLink = order.invoiceLink;
                    root2.micro = order.micro;
                    root2.Address5 = root2.shipmentAddress.address1;

                    root2List.Add(root2);
                }
                root2List.RemoveAll(o => o.invoiceLink != null);
                // bakim bi

                dataGridView1.DataSource = root2List;

                return null;
            }
            else
            {
                return null;
            }

        }

        private void TrendyolSiparisAktar_Load(object sender, EventArgs e)
        {

        }
    }
    public class TrendyolOrderModel
    {

        public string Id { get; set; }
        public string CargoTrackingNumber { get; set; }

    }
}
