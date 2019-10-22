using System;
using System.Globalization;
using Xamarin.Forms;

namespace GallogForms
{
    class NullableIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
                return null;
            var rv = int.Parse(value.ToString());
            return rv;
        }
    }
}
