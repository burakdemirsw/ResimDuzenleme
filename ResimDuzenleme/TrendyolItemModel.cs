using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme
{
    public class TrendyolItemModel
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalElements { get; set; }

        public int TotalPages { get; set; }
        public List<TrendyolContentModel> Content { get; set; }
    }
}
