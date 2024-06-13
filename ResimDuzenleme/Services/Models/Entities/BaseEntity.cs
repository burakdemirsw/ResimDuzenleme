using System;

namespace ResimDuzenleme.Services.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }

}
