using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services.Models.Cargo.DTO_s
{
    public class MNG_CompanyInfo
    {
        public Guid ID { get; set; } // Using Guid as the data type for ID because it's a uniqueidentifier in SQL
        public string CustomerCode { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Password { get; set; }
        public string MusteriKoduGonder { get; set; }
        public string BarkodCikti { get; set; }
    }
}
