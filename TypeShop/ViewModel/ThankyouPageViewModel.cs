using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.ServiceClients;

namespace TypeShop.ViewModel
{
    public class ThankyouPageViewModel : BasePageViewModel
    {

        private readonly TypeShopServiceClient typeShopService;
        public ThankyouPageViewModel()
        {
            typeShopService = new TypeShopServiceClient();
        }

        public async void ClearCart()
        {
           await typeShopService.ClearCartAsync();
        }
    }
}
