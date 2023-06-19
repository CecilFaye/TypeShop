using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TypeShop.Model;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace TypeShop.ViewModel
{
    public class MainPageViewModel : BasePageViewModel
    {
        private ObservableCollection<Product> _products;
        private ObservableCollection<Product> _cart;
        private Product _selectedProduct;
        private double _subtotalPrice;
        private double _vatPrice;
        private double _totalPrice;


        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public ObservableCollection<Product> CartProducts
        {
            get => _cart;
            set => SetProperty(ref _cart, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set {
                if (SetProperty(ref _selectedProduct, value))
                {
                    UpdateCanRemove();
                }
            }
        }

        public double TotalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }

        public double VatPrice
        {
            get => _vatPrice;
            set => SetProperty(ref _vatPrice, value);
        }

        public double SubTotalPrice
        {
            get => _subtotalPrice;
            set
            {
                if (SetProperty(ref _subtotalPrice, value))
                {
                    UpdateVatPrice();
                }
            }
        }

        private bool _canRemove;
        public bool CanRemove
        {
            get => _canRemove;
            set => SetProperty(ref _canRemove, value);
        }

        public ICommand AddToCartCommand { get; }
        public ICommand RemoveToCartCommand { get; }

        public MainPageViewModel()
        {
            Products = new ObservableCollection<Product>()
            {
                new Product { Name = "Monsgeek M1", ImageUrl = "kb_m1.png", Description = "Aluminum Keyboard Kit", Price = 5690 },
                new Product { Name = "Akko Top75", ImageUrl = "kb_top75.png", Description = "Top Mount Barebone Kit", Price = 6735 },
                new Product { Name = "Keychron Q1", ImageUrl = "kb_keychronq1.png", Description = "Custom Mech with Knob", Price = 8690 },
                new Product { Name = "Keychron Q2", ImageUrl = "kb_keychronq2.png", Description = "65% layout, full metal", Price = 8190 },
                new Product { Name = "GMMK Pro", ImageUrl = "kb_gmmkpro.png", Description = "Glorious keyboard Kit", Price = 8095 },
                new Product { Name = "GMMK2", ImageUrl = "kb_gmmk2.png", Description = "Glorious keyboard Kit", Price = 3595 }
            };

            CartProducts = new ObservableCollection<Product>();
            RemoveToCartCommand = new Command<Product>(RemoveToCart);
            AddToCartCommand = new Command<Product>(AddToCart);
        }


        private void AddToCart(Product product)
        {
            if (product != null)
            {
                CartProducts.Add(product);
                UpdateCanRemove();
                SubTotalPrice += product.Price;
            }
        }

        private void RemoveToCart(Product product)
        {
            if (product != null && CartProducts.Contains(product)) 
            {
                CartProducts.Remove(product);
                UpdateCanRemove();
                SubTotalPrice -= product.Price;
            }
        }

        private void UpdateVatPrice()
        {
            VatPrice = SubTotalPrice * 0.12;
            TotalPrice = SubTotalPrice + VatPrice;
        }

        private void UpdateCanRemove()
        {
            CanRemove = CartProducts.Contains(SelectedProduct);
        }

    }
}
