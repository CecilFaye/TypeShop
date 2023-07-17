using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeShop.Model
{
    public class PriceBreakdown
    {
        public double BasePrice { get; set; }
        public double Tax { get; set; }
        public double TotalAmount { get; set; }
    }
}
