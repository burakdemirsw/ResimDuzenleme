namespace ResimDuzenleme.Services.Models.MNG.Request
{
    public class CreateToken_MNG_Request
    {
        public string CustomerNumber { get; set; }
        public string Password { get; set; }
        public int IdentityType { get; set; }

    }
}
