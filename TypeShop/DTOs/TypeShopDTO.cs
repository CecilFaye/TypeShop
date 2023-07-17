using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.Model;

namespace TypeShop.DTOs
{
    public class TypeShopDTO
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }

        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public GroceryItem ToModel()
        {
            var model = new GroceryItem()
            {
                ItemId = ItemId,
                ItemName = ItemName,
                ImageUrl = ImageUrl,
                Price = Price,
            };

            return model;
        }

        public GroceryCart ToCart()
        {
            var model = new GroceryCart()
            {
                ItemId = ItemId,
                ItemName = ItemName,
                ImageUrl = ImageUrl,
                Price = Price
            };
            return model;
        }
    }
}
