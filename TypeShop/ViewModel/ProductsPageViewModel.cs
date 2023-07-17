using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TypeShop.Model;
using TypeShop.ServiceClients;
using TypeShop.Services;

namespace TypeShop.ViewModel
{
    public class ProductsPageViewModel : BasePageViewModel
    {
        private ObservableCollection<GroceryItem> _products;
        private ObservableCollection<GroceryCart> _cart;
        private TypeShopServiceClient typeShopService;
        private GroceryItem _selectedProduct;
        public ICommand AddToCartCommand { get; }
        public ICommand RemoveToCartCommand { get; }

        private bool _isInCart;
        public bool IsInCart
        {
            get => _isInCart;
            set => SetProperty(ref _isInCart, value);
        }

        public ObservableCollection<GroceryItem> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ObservableCollection<GroceryCart> CartProducts
        {
            get => _cart;
            set => SetProperty(ref _cart, value, nameof(CartProducts));
        }

        public GroceryItem SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (SetProperty(ref _selectedProduct, value))
                {
                    UpdateCanRemove();
                }
            }
        }

        private bool _canRemove;
        public bool CanRemove
        {
            get => _canRemove;
            set => SetProperty(ref _canRemove, value);
        }

      

        public ProductsPageViewModel()
        {
            typeShopService = new TypeShopServiceClient();
            Products = new ObservableCollection<GroceryItem>();
            CartProducts = new ObservableCollection<GroceryCart>();
            RemoveToCartCommand = new Command<GroceryItem>(RemoveToCart);
            AddToCartCommand = new Command<GroceryItem>(AddToCart);
            GetProduct();
        }

        public async void GetProduct()
        {
            var productList = await typeShopService.GetProductAsync();
            Products = productList;
        }

        private void UpdateCanRemove()
        {
            if (SelectedProduct != null)
            {
                IsInCart = CartProducts.Any(cartItem => cartItem.ItemId == SelectedProduct.ItemId);
                CanRemove = CartProducts.Any(cartItem => cartItem.ItemId == SelectedProduct.ItemId);
            }
        }

        private async void AddToCart(GroceryItem product)
        {
            if (product != null)
            {
                var result = await typeShopService.AddItemToCartAsync(product);
                if (result)
                {
                    CartProducts.Add(product.ToCart());
                    await Application.Current.MainPage.DisplayAlert("Item Added", "The item has been added to the cart.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong, try again later.", "OK");
                }
                UpdateCanRemove();

                Debug.WriteLine($"Number of cart products: {CartProducts.Count}");
            }
        }

        private async void RemoveToCart(GroceryItem product)
        {
            if (product != null)
            {
                var result = await typeShopService.RemoveItemToCartAsync(product.ToCart());
                if (result)
                {
                    CartProducts.Remove(product.ToCart());
                    await Application.Current.MainPage.DisplayAlert("Item Removed", "The item has been removed to the cart.", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong, try again later.", "OK");
                }
                UpdateCanRemove();
            }

        }

    }
}
