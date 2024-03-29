﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace GallogForms.Views
{
    public class ShipImageConverter<T> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"https://gallog.co/img/ships/{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Replace("https://gallog.co/img/ships/", "");
        }
    }
}
