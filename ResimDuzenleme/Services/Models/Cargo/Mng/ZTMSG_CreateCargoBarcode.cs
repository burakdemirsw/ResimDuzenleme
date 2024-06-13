namespace ResimDuzenleme.Services.Models.MNG
{
    public class ZTMSG_CreateCargoBarcode
    {
        public string Order { get; set; }
        public string Recepient { get; set; }
        public string BarcodeRequest { get; set; }
        public string OrderPieceList { get; set; }
        public string BarcodeBase64 { get; set; }
        public int CargoFirmId { get; set; }


    }

    public class ZTMSG_CreateCargoBarcode_CM
    {
        public string OrderNumber { get; set; }
        public int CargoFirmId { get; set; }

    }
    public class ZTMSG_CreateCargoBarcode_RM<T> : ZTMSG_CreateCargoBarcode_CM
    {
        public bool Status { get; set; }
        public T Response { get; set; }

    }
}
