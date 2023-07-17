using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TypeShop.Constants;
using TypeShop.DTOs;
using TypeShop.Model;

namespace TypeShop.ServiceClients
{
    public class TypeShopServiceClient : ITypeShopServiceClient
    {
        private HttpClient client;
        private JsonSerializerOptions serializerOptions;

        private string typeShopRoute = DeviceInfo.Platform == DevicePlatform.Android
          ? $"{TypeShopAPIConsts.TypeShopAPIURLDroid}Homework"
          : $"{TypeShopAPIConsts.TypeShopAPIURL}Homework";

        private string cartRoute = DeviceInfo.Platform == DevicePlatform.Android
        ? $"{TypeShopAPIConsts.TypeShopAPIURLDroid}GroceryCart"
        : $"{TypeShopAPIConsts.TypeShopAPIURL}GroceryCart";

        private string calculateRoute = DeviceInfo.Platform == DevicePlatform.Android
            ? $"{TypeShopAPIConsts.TypeShopAPIURLDroid}CalculatePrice/CalculateTotalPrice"
            : $"{TypeShopAPIConsts.TypeShopAPIURL}CalculatePrice/CalculateTotalPrice";

        public ObservableCollection<GroceryItem> Product { get; private set; }
        public ObservableCollection<GroceryCart> Cart { get; private set; }

        public TypeShopServiceClient()
        {
            client = new HttpClient();

            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<ObservableCollection<GroceryItem>> GetProductAsync()
        {
            Product = new ObservableCollection<GroceryItem>();

            Uri uri = new Uri(string.Format(typeShopRoute, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var productDTOs = JsonSerializer.Deserialize<ObservableCollection<TypeShopDTO>>(content, serializerOptions);

                    if (productDTOs?.Any() ?? false)
                    {
                        Product = new ObservableCollection<GroceryItem>(productDTOs.Select(x => x.ToModel()));
                    }
                }
                else
                {
                    Debug.WriteLine($"Response status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Product;
        }

        public async Task<bool> AddItemToCartAsync(GroceryItem groceryItem)
        {
            Uri uri = new Uri(string.Format(cartRoute+"/AddToCart", string.Empty));

            string json = JsonSerializer.Serialize(groceryItem.ToDTO(), serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<ObservableCollection<GroceryCart>> GetCartAsync()
        {
            Cart = new ObservableCollection<GroceryCart>();

            Uri uri = new Uri(string.Format(cartRoute, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var productDTOs = JsonSerializer.Deserialize<ObservableCollection<TypeShopDTO>>(content, serializerOptions);

                    if (productDTOs?.Any() ?? false)
                    {
                        Cart = new ObservableCollection<GroceryCart>(productDTOs.Select(x => x.ToCart()));
                    }
                }
                else
                {
                    Debug.WriteLine($"Response status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Cart;
        }

        public async Task<PriceBreakdown> CalculatePriceAsync(ObservableCollection<GroceryCart> groceryCart)
        {
            Uri uri = new Uri(string.Format(calculateRoute, string.Empty));
            List<GroceryCart> cartList = groceryCart.ToList();
            string json = JsonSerializer.Serialize(cartList, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
               
            string responseContent = await response.Content.ReadAsStringAsync();
            PriceBreakdown priceBreakdown = JsonSerializer.Deserialize<PriceBreakdown>(responseContent, serializerOptions);
            return priceBreakdown;
        }
        public async Task<bool> RemoveItemToCartAsync(GroceryCart item)
        {
            Uri uri = new Uri(string.Format(cartRoute + "/DeleteItemToCart", string.Empty));

            string json = JsonSerializer.Serialize(item, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = uri,
                Content = content
            };

            var response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ClearCartAsync()
        {
            Uri uri = new Uri(string.Format(cartRoute + "/ClearCart", string.Empty));
            var response = await client.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }

    }
}
