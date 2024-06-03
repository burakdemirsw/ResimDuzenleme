using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ResimDuzenleme.Services.Cargo;
using ResimDuzenleme.Services.Database;
using ResimDuzenleme.Services.Models.Entities;
using ResimDuzenleme.Services.Models.MNG;
using ResimDuzenleme.Services.Models.MNG.Cargo;
using ResimDuzenleme.Services.Models.MNG.Order;
using ResimDuzenleme.Services.Models.MNG.Request;
using ResimDuzenleme.Services.Models.MNG.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResimDuzenleme.Services.Forms
{
    public partial class MNG_CargoForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly Context _context;
        private readonly DbContextRepository<CargoBarcode> _repository;

        public MNG_CargoForm(Context context, DbContextRepository<CargoBarcode> repository)
        {
            _repository = repository;
            _context = context;
            InitializeComponent();
        }

        CreatePackage_MNG_RM mainCargo = new CreatePackage_MNG_RM(); 
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var orderNumber = textBox1.Text.Trim();
            var query = $"exec [ZTMSG_CreateCargoBarcode] 1,'{orderNumber}'";
            Models.Entities.ZTMSG_CreateCargoBarcode _cargo = _context.ZTMSG_CreateCargoBarcode.FromSqlRaw(query).AsEnumerable().FirstOrDefault();
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
                CargoFirmId = _cargo.CargoFirmId
            };
            mainCargo = new CreatePackage_MNG_RM(); 
            mainCargo = createPackage_MNG_RM;   

            richTextBox1.Text = JsonConvert.SerializeObject(createPackage_MNG_RM, Formatting.Indented);
        }

        private async  void simpleButton2_Click(object sender, EventArgs e)
        {
            MNG_CargoService mNG_CargoService = new MNG_CargoService(); 
            var response = await mNG_CargoService.CreateToken();
            MessageBox.Show(System.Text.Json.JsonSerializer.Serialize(response),"Token Yanıtı");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void simpleButton4_Click(object sender, EventArgs e)
        {
            MNG_CargoService mNG_CargoService = new MNG_CargoService();
            var response =await  mNG_CargoService.CreateCargo(mainCargo);
            this.richTextBox2.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        private async void  simpleButton5_Click(object sender, EventArgs e)
        {
            MNG_CargoService mNG_CargoService = new MNG_CargoService();
            var response = await mNG_CargoService.CreateBarcode(textBox2.Text);
            this.richTextBox3.Text = JsonConvert.SerializeObject(response, Formatting.Indented);
        }

        private async void simpleButton6_Click(object sender, EventArgs e)
        {
            MNG_CargoService mNG_CargoService = new MNG_CargoService();

            try
            {
                string referenceIdsInput = textBox3.Text;
                string shipmentIdsInput = textBox4.Text;

                if (string.IsNullOrWhiteSpace(referenceIdsInput) || string.IsNullOrWhiteSpace(shipmentIdsInput))
                {
                    MessageBox.Show("Reference IDs or Shipment IDs cannot be empty.");
                    return; 
                }

                List<string> referenceIdList = new List<string>(referenceIdsInput.Split(','));
                List<string> shipmentIdList = new List<string>(shipmentIdsInput.Split(','));

                if (referenceIdList.Count != shipmentIdList.Count)
                {
                    MessageBox.Show("Number of reference IDs does not match number of shipment IDs.");
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

    }
}