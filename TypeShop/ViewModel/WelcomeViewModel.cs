using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TypeShop.ViewModel
{
    public class WelcomeViewModel : MainPageViewModel
    {
        private string _appLogo;
        private string _appTitle;

        public string AppLogo
        {
            get => _appLogo;
            set => SetProperty(ref _appLogo, value);
        }

        public string AppTitle
        {
            get => _appTitle;
            set => SetProperty(ref _appTitle, value);
        }


        public WelcomeViewModel()
        {
            _appLogo = "mauistore.png";
            _appTitle = "Maui Store";
        }


    }
}
