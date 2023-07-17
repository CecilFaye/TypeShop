using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeShop.Model
{
    public class GroceryCart
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}
