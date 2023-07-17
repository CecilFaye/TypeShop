using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.Model;

namespace TypeShop.Services
{
    public interface ITypeShopService 
    {
        Task<ObservableCollection<GroceryItem>> GetProductAsync();
        Task<bool> AddItemToCartAsync(GroceryItem item);
        Task<ObservableCollection<GroceryCart>> GetCartAsync();
        Task<PriceBreakdown> CalculatePriceAsync(ObservableCollection<GroceryCart> groceryCart);
        Task<bool> RemoveItemToCartAsync(GroceryCart item);
        Task<bool> ClearCartAsync();

    }
}
