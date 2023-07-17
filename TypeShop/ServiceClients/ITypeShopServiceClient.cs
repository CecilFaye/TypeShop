using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.Model;

namespace TypeShop.ServiceClients
{
    public interface ITypeShopServiceClient
    {
        Task<ObservableCollection<GroceryItem>> GetProductAsync();
        Task<bool> AddItemToCartAsync(GroceryItem groceryItem);
        Task<ObservableCollection<GroceryCart>> GetCartAsync();
        Task<PriceBreakdown> CalculatePriceAsync(ObservableCollection<GroceryCart> groceryCart);
        Task<bool> RemoveItemToCartAsync(GroceryCart item);
        Task<bool> ClearCartAsync();
    }
}
