﻿namespace ResimDuzenleme.Services.Models.MNG
{
    public class BulkDeleteShipment_CM
    {
        public int CargoFirmId { get; set; }
        public string ReferenceId { get; set; }
    }
    public class BulkDeleteShipment_RM : BulkDeleteShipment_CM
    {
        public bool Status { get; set; }
        public string ErrMessage { get; set; }
    }
}
