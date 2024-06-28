using ResimDuzenleme.Services.Models.Entities;
using ResimDuzenleme.Services.Models.MNG;
using ResimDuzenleme.Services.Models.MNG.Request;
using ResimDuzenleme.Services.Models.MNG.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services.Cargo.Abstractions
{
    public interface IMNG_CargoService
    {
        List<CargoBarcode> GetPrintableCargos(bool status);
        Task<CreateCargo_RM<CreatePackage_MNG_RR>> CreateCargo(
           CreatePackage_MNG_RM request
       );
        Task<BulkDeleteShipment_RM> DeleteShippedCargo(
            DeletePackage_MNG_Request request
        );
        Task<List<CreateBarcode_MNG_Response>> CreateBarcode(string referenceId);
        
        Task ConvertPNG(string zpl);
        Task<CreateTokenResponse_MNG> CreateToken( );
        Task<bool> PrintBarcode(string zplCode);
        Bitmap Base64ToBitmap(string base64string);
        Task<bool> PrintSingleBarcode(string zplCode);
        Task<GetPackageStatus_MNG_Response> GetPackageStatus(string ShipmentId);

    }
}
