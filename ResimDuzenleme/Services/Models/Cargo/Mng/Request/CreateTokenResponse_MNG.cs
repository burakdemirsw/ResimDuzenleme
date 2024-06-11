namespace ResimDuzenleme.Services.Models.MNG.Request
{
    public class CreateTokenResponse_MNG
    {
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
        public string JwtExpireDate { get; set; }
        public string RefreshTokenExpireDate { get; set; }
    }
}
