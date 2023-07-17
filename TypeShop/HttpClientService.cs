using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeShop
{
    public partial class HttpClientService
    {
        public HttpClient GetPlatfromSpecificHttpClient()
        {
            var httpMesageHandler = PlatfromSpecificHttpMessageHandler;
            return new HttpClient(httpMesageHandler);
        }
        public  HttpMessageHandler PlatfromSpecificHttpMessageHandler { get; }
    }
}
