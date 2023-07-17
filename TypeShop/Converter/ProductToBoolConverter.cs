using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeShop.Model;
using TypeShop.ViewModel;

namespace TypeShop.Converter
{
    public class ProductToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<GroceryCart> cartProducts && parameter is GroceryItem product)
            {
                return cartProducts.Any(p => p.ItemId == product.ItemId);
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}