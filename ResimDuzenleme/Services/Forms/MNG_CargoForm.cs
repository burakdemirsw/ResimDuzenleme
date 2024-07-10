using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ResimDuzenleme.Services.Cargo;
using ResimDuzenleme.Services.Cargo.Reports.ReportModels;
using ResimDuzenleme.Services.Database;
using ResimDuzenleme.Services.Helpers;
using ResimDuzenleme.Services.Models.DTO_s;
using ResimDuzenleme.Services.Models.Entities;
using ResimDuzenleme.Services.Models.MNG;
using ResimDuzenleme.Services.Models.MNG.Cargo;
using ResimDuzenleme.Services.Models.MNG.Order;
using ResimDuzenleme.Services.Models.MNG.Request;
using ResimDuzenleme.Services.Models.MNG.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreatePackage_MNG_RR = ResimDuzenleme.Services.Models.MNG.Response.CreatePackage_MNG_RR;
using Formatting = Newtonsoft.Json.Formatting;

namespace ResimDuzenleme.Services.Forms
{
    public partial class MNG_CargoForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly Context _context;
        private readonly DbContextRepository<CargoBarcode> _repository;
        private readonly DbContextRepository<OrderDetail_DTO> _or;
        private readonly MNG_CargoService mNG_CargoService;

        public MNG_CargoForm(
            Context context,
            DbContextRepository<CargoBarcode> repository,
            MNG_CargoService mNG_CargoService
        )
        {
            _repository = repository;
            _context = context;
            this.mNG_CargoService = mNG_CargoService;
            InitializeComponent();
        }

        Timer timer = new Timer();

        public async void Service()
        {
            // Timer'ı her 1 dakikada bir tetikle (1 dakika = 60000 milisaniye)
            timer.Interval = 60000;
            timer.Tick += Timer_Tick;
            // Timer'ı başlat
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            simpleButton1_Click(sender, e);
        }

        CreatePackage_MNG_RM mainCargo = new CreatePackage_MNG_RM();

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var orderNumber = textBox1.Text.Trim();
            var query = $"exec [ZTMSG_CreateCargoBarcode] 1,'{orderNumber}'";
            Models.Entities.ZTMSG_CreateCargoBarcode _cargo = _context.ZTMSG_CreateCargoBarcode
                .FromSqlRaw(query)
                .AsEnumerable()
                .FirstOrDefault();
            CreatePackage_MNG_RM createPackage_MNG_RM = new CreatePackage_MNG_RM
            {
                OrderRequest = new CreatePackage_MNG_Request
                {
                    Order = JsonConvert.DeserializeObject<Order_MNG>(_cargo.Order),
                    OrderPieceList = JsonConvert.DeserializeObject<List<OrderPieceList_MNG>>(
                        _cargo.OrderPieceList
                    ),
                    Recipient = JsonConvert.DeserializeObject<Recipient_MNG>(_cargo.Recepient)
                },
                BarcodeRequest = JsonConvert.DeserializeObject<CreateBarcode_MNG_Request>(
                    _cargo.BarcodeRequest
                ),
                BarcodeBase64 = _cargo.BarcodeBase64,
                CargoFirmId = _cargo.CargoFirmId,
                Marketplace = _cargo.Marketplace,
                SalesUrl = _cargo.SalesUrl,
                FirstItem = _cargo.FirstItem,
                OrderStatus = _cargo.OrderStatus
            };
            mainCargo = new CreatePackage_MNG_RM();
            mainCargo = createPackage_MNG_RM;

            richTextBox1.Text = JsonConvert.SerializeObject(
                createPackage_MNG_RM,
                Formatting.Indented
            );
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            var response = await mNG_CargoService.CreateToken();
            MessageBox.Show(System.Text.Json.JsonSerializer.Serialize(response), "Token Yanıtı");
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private async void simpleButton4_Click(object sender, EventArgs e)
        {
            var response = await mNG_CargoService.CreateCargo(mainCargo);
            this.richTextBox2.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        private async void simpleButton5_Click(object sender, EventArgs e)
        {
            var response = await mNG_CargoService.CreateBarcode(textBox2.Text);
            this.richTextBox3.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        private async void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {
                string referenceIdsInput = textBox3.Text;
                string shipmentIdsInput = textBox4.Text;

                if (
                    string.IsNullOrWhiteSpace(referenceIdsInput)
                    || string.IsNullOrWhiteSpace(shipmentIdsInput)
                )
                {
                    MessageBox.Show("Reference IDs or Shipment IDs cannot be empty.");
                    return;
                }

                List<string> referenceIdList = new List<string>(referenceIdsInput.Split(','));
                List<string> shipmentIdList = new List<string>(shipmentIdsInput.Split(','));

                if (referenceIdList.Count != shipmentIdList.Count)
                {
                    MessageBox.Show(
                        "Number of reference IDs does not match number of shipment IDs."
                    );
                    return;
                }

                for (int i = 0; i < referenceIdList.Count; i++)
                {
                    DeletePackage_MNG_Request bulkDeleteShipment_RM = new DeletePackage_MNG_Request
                    {
                        ReferenceId = referenceIdList[i],
                        ShipmentId = shipmentIdList[i]
                    };

                    await mNG_CargoService.DeleteShippedCargo(bulkDeleteShipment_RM);
                }

                MessageBox.Show("Deletion completed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        List<OrderDetail_DTO> selectedOrders = new List<OrderDetail_DTO>();

        private async void simpleButton1_Click(object sender, EventArgs e)
        {

            //SİPARİŞ LİSTESİNİ GETİR *****************************
            this.progressBar1.Visible = true;
            this.progressBar1.Value = 10;
            List<OrderDetail_DTO> orderDetail_DTOs = await _context.OrderDetail_DTO
                .FromSqlRaw("exec [ZTMSG_CreateCargoList]")
                .ToListAsync();

            if(orderDetail_DTOs.Count == 0)
            {
                this.progressBar1.Value = 100;
                this.progressBar1.Visible = false;
                return;
            }

            List<string> orderNumbers = orderDetail_DTOs.Select(x => x.OrderNumber).ToList();
            var orderListQuery = "";

            foreach (var item in orderNumbers)
            {
                orderListQuery += item + ",";
            }
            selectedOrders = orderDetail_DTOs;

            //SİPARİŞ İSTEKLERİNİ GETİR *****************************

            var query = $"exec [ZTMSG_CreateCargoBarcode] 1,'{orderListQuery}'";
            List<Models.Entities.ZTMSG_CreateCargoBarcode> _cargos =
                await _context.ZTMSG_CreateCargoBarcode.FromSqlRaw(query).ToListAsync();
            List<CreatePackage_MNG_RM> createPackage_MNG_RMs = new List<CreatePackage_MNG_RM>();

            foreach (var _cargo in _cargos)
            {
               
                CreatePackage_MNG_RM createPackage_MNG_RM = new CreatePackage_MNG_RM
                {
                    OrderRequest = new CreatePackage_MNG_Request
                    {
                        Order = JsonConvert.DeserializeObject<Order_MNG>(_cargo.Order),
                        OrderPieceList = JsonConvert.DeserializeObject<List<OrderPieceList_MNG>>(
                            _cargo.OrderPieceList
                        ),
                        Recipient = JsonConvert.DeserializeObject<Recipient_MNG>(_cargo.Recepient)
                    },
                    BarcodeRequest = JsonConvert.DeserializeObject<CreateBarcode_MNG_Request>(
                        _cargo.BarcodeRequest
                    ),
                    BarcodeBase64 = _cargo.BarcodeBase64,
                    CargoFirmId = _cargo.CargoFirmId,
                    Marketplace = _cargo.Marketplace,
                    SalesUrl = _cargo.SalesUrl,
                    FirstItem = _cargo.FirstItem,
                    OrderStatus = _cargo.OrderStatus,
                    Country = _cargo.Country,
                    OrderDate = _cargo.OrderDate
                };

                createPackage_MNG_RMs.Add(createPackage_MNG_RM);
            }
   
            //SİPARİŞ OLUŞTUR *****************************

            //DialogResult dialogResult = MessageBox.Show("Seçili siparişleri MNG Kargo'ya göndermek istediğinize emin misiniz","Onay",MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.No)
            //{
            //    MessageBox.Show("İşlem iptal edildi.");
            //    return;
            //}

            List<CreateCargo_RM<CreatePackage_MNG_RR>> createPackage_MNG_RRs =
                new List<CreateCargo_RM<CreatePackage_MNG_RR>>();
            var count = 1;  
            foreach (var order in createPackage_MNG_RMs) // Note: What is the type of createPackage_MNG_RMs? It's not shown.
            {
                this.progressBar1.Value = count * 100 / createPackage_MNG_RMs.Count;
                var random = GeneralService.GenerateRandomNumber();
                order.OrderRequest.Order.ReferenceId = random;
                order.BarcodeRequest.ReferenceId = random;
              
                CreateCargo_RM<CreatePackage_MNG_RR> response = await mNG_CargoService.CreateCargo(
                    order
                );
                response.OrderNumber = order.OrderRequest.Order.BillOfLandingId;

                createPackage_MNG_RRs.Add(response);
                count++;
            }
            //LOGLARI TABLOYA BAS *****************************


            this.progressBar1.Visible = false;  
            gridControl2.DataSource = createPackage_MNG_RRs;
            gridControl1.DataSource = createPackage_MNG_RMs;

            this.xtraTabControl1.SelectedTabPageIndex = 2;
            //MessageBox.Show("İşlem tamamlandı.");
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            // Assuming gridControl1's main view is a GridView
            GridView view = gridControl1.MainView as GridView;

            if (view != null)
            {
                // Get the count of selected rows
                int selectedCount = view.SelectedRowsCount;

                // Display the count of selected rows
                MessageBox.Show(selectedCount + " Adet Kayıt Seçildi");
            }
            else
            {
                MessageBox.Show("Grid görünümü uygun değil.");
            }
        }

        public async Task DeleteSelectedBarcodes()
        {
            GridView view = gridControl3.MainView as GridView;

            List<CargoBarcode> barcodes = new List<CargoBarcode>();
            if (view != null)
            {
                int selectedCount = view.SelectedRowsCount;

                if (selectedCount > 0)
                {
                    int[] selectedRows = view.GetSelectedRows(); // Get indices of selected rows

                    foreach (int rowIndex in selectedRows)
                    {
                        if (view.IsDataRow(rowIndex)) // Check if the row is a data row and not a group or filter row
                        {
                            // Create a new instance of CargoBarcode
                            CargoBarcode barcode = new CargoBarcode();

                            // Assuming the view is correctly bound to a data model that can be cast to your model
                            var row = view.GetRow(rowIndex) as CargoBarcode; // Replace YourDataRowType with the actual type bound to the grid

                            if (row != null)
                            {
                                // Assign row data to the CargoBarcode instance
                                barcode.CargoFirmId = row.CargoFirmId;
                                barcode.OrderRequest = row.OrderRequest;
                                barcode.OrderResponse = row.OrderResponse;
                                barcode.BarcodeResponse = row.BarcodeResponse;
                                barcode.OrderNo = row.OrderNo;
                                barcode.ReferenceId = row.ReferenceId;
                                barcode.BarcodeZplCode = row.BarcodeZplCode;
                                barcode.ShipmentId = row.ShipmentId;
                                barcode.Customer = row.Customer;
                                barcode.BarcodeRequest = row.BarcodeRequest;
                                barcode.Desi = row.Desi;
                                barcode.Kg = row.Kg;
                                barcode.PackagingType = row.PackagingType;
                                barcode.BarcodeSequence = row.BarcodeSequence;
                            }

                            barcodes.Add(barcode); // Add the populated instance to the list
                        }
                    }

                    //MessageBox.Show(selectedCount + " Adet Kayıt Seçildi ve işlendi.");
                }
                else
                {
                    MessageBox.Show("Seçili kayıt yok.", "Hata");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Grid görünümü uygun değil.", "Hata");
                return;
            }
            barcodes = barcodes.Where(b => b.BarcodeResponse != null).ToList();
            List<BulkDeleteShipment_RM> responses = new List<BulkDeleteShipment_RM>();

            for (int i = 0; i < barcodes.Count; i++)
            {
                DeletePackage_MNG_Request bulkDeleteShipment_RM = new DeletePackage_MNG_Request
                {
                    ReferenceId = barcodes[i].ReferenceId,
                    ShipmentId = barcodes[i].ShipmentId
                };

                BulkDeleteShipment_RM response = await mNG_CargoService.DeleteShippedCargo(
                    bulkDeleteShipment_RM
                );
                responses.Add(response);
            }
            await GetPrintableCargos(true);
            MessageBox.Show(
                $"İşlem Tamamlandı ({barcodes.Count}/{responses.Where(r => r.Status == true).ToList().Count} Adet Kargo Başarılı Şekilde Silindi)",
                "Hata"
            );
        }

        private async void simpleButton8_Click(object sender, EventArgs e)
        {
            this.progressBar1.Visible = true;
            this.progressBar1.Value = 10;
            var Context = new Context();
            GridView view = gridControl3.MainView as GridView;

            List<CargoBarcode> barcodes = new List<CargoBarcode>();
            if (view != null)
            {
                int selectedCount = view.SelectedRowsCount;

                if (selectedCount > 0)
                {
                    int[] selectedRows = view.GetSelectedRows(); // Get indices of selected rows

                    foreach (int rowIndex in selectedRows)
                    {
                        if (view.IsDataRow(rowIndex)) // Check if the row is a data row and not a group or filter row
                        {
                            // Create a new instance of CargoBarcode
                            CargoBarcode barcode = new CargoBarcode();

                            // Assuming the view is correctly bound to a data model that can be cast to your model
                            var row = view.GetRow(rowIndex) as CargoBarcode; // Replace YourDataRowType with the actual type bound to the grid

                            if (row != null)
                            {
                                // Assign row data to the CargoBarcode instance
                                barcode.CargoFirmId = row.CargoFirmId;
                                barcode.OrderRequest = row.OrderRequest;
                                barcode.OrderResponse = row.OrderResponse;
                                barcode.BarcodeResponse = row.BarcodeResponse;
                                barcode.OrderNo = row.OrderNo;
                                barcode.ReferenceId = row.ReferenceId;
                                barcode.BarcodeZplCode = row.BarcodeZplCode;
                                barcode.ShipmentId = row.ShipmentId;
                                barcode.Customer = row.Customer;
                                barcode.BarcodeRequest = row.BarcodeRequest;
                                barcode.Desi = row.Desi;
                                barcode.Kg = row.Kg;
                                barcode.PackagingType = row.PackagingType;
                                barcode.BarcodeSequence = row.BarcodeSequence;
                            }

                            barcodes.Add(barcode); // Add the populated instance to the list
                        }
                    }

                    //MessageBox.Show(selectedCount + " Adet Kayıt Seçildi ve işlendi.");
                }
                else
                {
                    MessageBox.Show("Seçili kayıt yok.", "Hata");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Grid görünümü uygun değil.", "Hata");
                return;
            }

            //MNG KARGO BARKODU OLUŞTURMA İSTEĞİ ATILIR *****************************
            List<string> referenceIds = barcodes.Select(b => b.ReferenceId).ToList();

            List<CreateBarcode_MNG_Response> responses = new List<CreateBarcode_MNG_Response>();

            DialogResult dialogResult = MessageBox.Show(
                $"Seçili barkodları yazdırmak istediğinize emin misiniz? ({referenceIds.Count} Adet)",
                "Onay",
                MessageBoxButtons.YesNo
            );

            if (dialogResult == DialogResult.No)
            {
                this.progressBar1.Visible = false;

                return;

            }
            foreach (var referenceId in referenceIds)
            {
                try
                {
                    var _response = await this.mNG_CargoService.CreateBarcode(referenceId);
                    if (_response != null)
                    {
                        responses.AddRange(_response);
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    continue;
                  
                }
              
            }

            List<string> referenceIdList = responses.Select(r => r.ReferenceId).Distinct().ToList();
            List<CargoBarcode_ZPL> cargoBarcode_ZPLs = new List<CargoBarcode_ZPL>();

            int barcodeCount = 0;
            var count = 1;  
            foreach (var referenceId in referenceIdList)
            {
                this.progressBar1.Value = count * 100 / referenceIdList.Count;


                try
                {
                    List<Barcode_MNG> mng_barcodes = new List<Barcode_MNG>();
                    responses.ForEach(r =>
                    {
                        if (r.ReferenceId == referenceId)
                        {
                            mng_barcodes.Add(r.Barcodes.First());
                        }
                    });
                    barcodeCount += mng_barcodes.Count;
                    CargoBarcode cargo =await Context.ZTMSG_CargoBarcodes.FirstOrDefaultAsync(
                        c => c.ReferenceId == referenceId
                    );
                    CreateBarcode_MNG_Request barcode =
                        JsonConvert.DeserializeObject<CreateBarcode_MNG_Request>(
                            cargo.BarcodeRequest
                        );

                    foreach (var item in mng_barcodes)
                    {
                        CreatePackage_MNG_Request order =
                            JsonConvert.DeserializeObject<CreatePackage_MNG_Request>(
                                cargo.OrderRequest
                            );

                        CargoBarcode_ZPL cargoBarcode_ZPL = new CargoBarcode_ZPL();
                        cargoBarcode_ZPL.CargoCompany = "MNG KARGO";
                        cargoBarcode_ZPL.SupplierName = "ASSUR";
                        cargoBarcode_ZPL.ReceiverName = order.Recipient.FullName.ToUpper();
                        cargoBarcode_ZPL.Address = order.Recipient.Address.ToUpper();
                        cargoBarcode_ZPL.Desi = barcode.OrderPieceList[
                            item.PieceNumber - 1
                        ].Desi.ToString();
                        cargoBarcode_ZPL.Kg = barcode.OrderPieceList[
                            item.PieceNumber - 1
                        ].Kg.ToString();
                        cargoBarcode_ZPL.ShipmentType = order.Order.PaymentType == 1 ? "GO" : "AO";
                        cargoBarcode_ZPL.Amount =
                            order.Order.IsCOD == 0 ? "0" : order.Order.CodAmount.ToString();
                        cargoBarcode_ZPL.PaymentType = order.Order.IsCOD == 1 ? "KÖ" : "ONL";
                        cargoBarcode_ZPL.OrderNo = order.Order.Barcode;
                        cargoBarcode_ZPL.OrderNo = cargo.CreatedDate?.ToString("yyyy-MM-dd");
                        cargoBarcode_ZPL.Description = barcode.OrderPieceList.First().Content;
                        cargoBarcode_ZPL.CargoBarcode = item.Barcode;
                        cargoBarcode_ZPL.Marketplace = cargo.Marketplace;
                        cargoBarcode_ZPL.SalesUrl = cargo.SalesUrl;
                        cargoBarcode_ZPLs.Add(cargoBarcode_ZPL);
                    }
                }
                catch
                {
                    count++;
                    continue;
                }
                count++;
            }

            XtraReport report = XtraReport.FromFile("C:\\code\\CargoBarcode_ZPL.repx", true);
            report.DataSource = cargoBarcode_ZPLs;

            if (report != null)
            {
                string pdfFilePath = $"C:\\code\\{Guid.NewGuid()}" + ".pdf";
                await report.ExportToPdfAsync(pdfFilePath);

                PdfViewerForm pdfViewerForm = new PdfViewerForm(pdfFilePath);

                this.progressBar1.Visible = false;
                MessageBox.Show($"Barkodlar Yazdırıldı ({barcodeCount} Adet).", "Bilgi");
                pdfViewerForm.ShowDialog();
            }

            await GetPrintableCargos(false);
        }

        private async void simpleButton9_Click(object sender, EventArgs e)
        {
            await GetPrintableCargos(false);
        }

        public async Task GetPrintableCargos(bool status)
        {
            if (dateTimeOffsetEdit1.DateTimeOffset == null)
            {
                MessageBox.Show("Lütfen Tarih Giriniz");
                return;
            }

            var Context = new Context();
            if (!status)
            {
               
                // yazdırılmayanlar
                List<CargoBarcode> cargoBarcodes = await Context.ZTMSG_CargoBarcodes
                    .Where(c => c.ReferenceId != null && c.BarcodeResponse == null && c.OrderDate >=
                    dateTimeOffsetEdit1.DateTimeOffset && c.OrderDate <=
                    dateTimeOffsetEdit2.DateTimeOffset)
                    .OrderByDescending(p => p.FirstItem)
                    .OrderByDescending(p => p.SalesUrl)
                    .ToListAsync();

                if(cargoBarcodes.Count > 0)
                {
                    gridControl3.DataSource = cargoBarcodes;

                    // GridControl'ün ilgili sütun formatını ayarlayalım
                    GridView view = gridControl3.MainView as GridView;
                    if (view != null)
                    {
                        view.Columns["CreatedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        view.Columns["CreatedDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                        view.Columns["OrderDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        view.Columns["OrderDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                    }

                }
                else
                {
                    MessageBox.Show("Veri Yok");
                }


            }
            else
            {
                List<CargoBarcode> cargoBarcodes = await Context.ZTMSG_CargoBarcodes
                    .Where(c => c.ReferenceId != null && c.BarcodeResponse != null && c.OrderDate >=
                    dateTimeOffsetEdit1.DateTimeOffset && c.OrderDate <=
                    dateTimeOffsetEdit2.DateTimeOffset)
                    .OrderByDescending(p => p.FirstItem)
                    .OrderByDescending(p => p.SalesUrl)
                    .ToListAsync();


                if (cargoBarcodes.Count > 0)
                {
                    gridControl3.DataSource = cargoBarcodes;
                    GridView view = gridControl3.MainView as GridView;
                    if (view != null)
                    {
                        view.Columns["CreatedDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        view.Columns["CreatedDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                        view.Columns["OrderDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        view.Columns["OrderDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
                    }

                }
                else
                {
                    MessageBox.Show("Veri Yok");
                }


              
            }
            this.xtraTabControl1.SelectedTabPageIndex = 1;
        }

        private async  void simpleButton14_Click(object sender, EventArgs e)
        {
            await GetPrintableCargos(true);
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            DeleteSelectedBarcodes();
        }

        bool serviceStatus = false;

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            serviceStatus = !serviceStatus;

            if (serviceStatus)
            {
                Service();
                simpleButton16.Appearance.BackColor = Color.Green;
                MessageBox.Show("Servis Başlatıldı.");
            }
            else
            {
                timer.Stop();
                simpleButton16.Appearance.BackColor = Color.Red;
                MessageBox.Show("Servis Durduruldu.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaticVariables.DebugMode = !StaticVariables.DebugMode; 
            MessageBox.Show("Debug Modu: " + StaticVariables.DebugMode);    
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StaticVariables.DebugMode = true;
            DebugForm debugForm = new DebugForm(StaticVariables.errors);
            debugForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new Exception("Hata oluştu.");
        }
    }
}
