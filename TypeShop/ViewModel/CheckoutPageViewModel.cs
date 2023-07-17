using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.Model;
using TypeShop.ServiceClients;

namespace TypeShop.ViewModel
{
    public class CheckoutPageViewModel : BasePageViewModel
    {
        private ObservableCollection<GroceryCart> _cart;
        private TypeShopServiceClient typeShopService;
        private PriceBreakdown _priceBreakdown;

        public ObservableCollection<GroceryCart> Cart
        {
            get => _cart;
            set => SetProperty(ref _cart, value, nameof(Cart));
        }

        public CheckoutPageViewModel()
        {

            typeShopService = new TypeShopServiceClient();
            Cart = new ObservableCollection<GroceryCart>();
            Prices = new PriceBreakdown();
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await GetCartItems();
            await CalculateTotalPrice();
        }

        public PriceBreakdown Prices
        {
            get => _priceBreakdown;
            set => SetProperty(ref _priceBreakdown, value);
        }

        public async Task GetCartItems()
        {
            var productList = await typeShopService.GetCartAsync();
            Cart = productList;
        }

        public async Task CalculateTotalPrice()
        {
            Prices = await typeShopService.CalculatePriceAsync(Cart);
        }

    }
}
