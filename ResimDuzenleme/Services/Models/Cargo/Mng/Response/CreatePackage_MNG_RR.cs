namespace ResimDuzenleme.Services.Models.MNG.Response
{
    public class CreatePackage_MNG_RR
    {

        public CreatePackage_MNG_Response Response { get; set; }
        public Request.CreatePackage_MNG_Request Request { get; set; }

    }

    public interface ICreateCargoResponse
    {
        string OrderNumber { get; set; }
        int CargoFirmId { get; set; }
        bool Status { get; set; }
        string ErrMsg { get; set; }
    }

    public class CreateCargo_RM<T> : ICreateCargoResponse
    {
        public string OrderNumber { get; set; }
        public int CargoFirmId { get; set; }
        public bool Status { get; set; }
        public string ErrMsg { get; set; }
        public T CargoResponse { get; set; }
    }

}
