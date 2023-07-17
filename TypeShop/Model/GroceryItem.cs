using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.DTOs;

namespace TypeShop.Model
{
    public class GroceryItem
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public TypeShopDTO ToDTO()
        {
            var dto = new TypeShopDTO()
            {
                ItemId = ItemId,
                ItemName = ItemName,
                ImageUrl = ImageUrl,
                Price = Price,
            };

            return dto;
        }

        public GroceryCart ToCart()
        {
            var cart = new GroceryCart()
            {
                ItemId = ItemId,
                ItemName = ItemName,
                ImageUrl = ImageUrl,
                Price = Price
            };

            return cart;
        }
    }
}
