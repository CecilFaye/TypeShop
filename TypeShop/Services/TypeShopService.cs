using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.Model;
using TypeShop.ServiceClients;

namespace TypeShop.Services
{
    public class TypeShopService : ITypeShopService
    {
        
        private ITypeShopServiceClient typeShopServiceClient;

        public TypeShopService()
        {
            typeShopServiceClient = new TypeShopServiceClient();
        }
        public TypeShopService(ITypeShopServiceClient typeShopServiceClient)
        {
            this.typeShopServiceClient = typeShopServiceClient;
        }
        public async Task<ObservableCollection<GroceryItem>> GetProductAsync()
        {
            return await typeShopServiceClient.GetProductAsync();
        }
        public async Task<bool> AddItemToCartAsync(GroceryItem groceryItem)
        {
            return await typeShopServiceClient.AddItemToCartAsync(groceryItem);
        }

        public async Task<ObservableCollection<GroceryCart>> GetCartAsync()
        {
            return await typeShopServiceClient.GetCartAsync();
        }

        public async Task<PriceBreakdown> CalculatePriceAsync(ObservableCollection<GroceryCart> groceryCart)
        {
            return await typeShopServiceClient.CalculatePriceAsync(groceryCart);
        }

        public async Task<bool> RemoveItemToCartAsync(GroceryCart item)
        {
            return await typeShopServiceClient.RemoveItemToCartAsync(item);
        }

        public async Task<bool> ClearCartAsync()
        {
            return await typeShopServiceClient.ClearCartAsync();
        }
    }
}
