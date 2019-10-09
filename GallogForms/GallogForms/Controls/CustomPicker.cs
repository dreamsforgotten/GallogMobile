﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Picker = Xamarin.Forms.Picker;

namespace GallogForms.Controls
{
    public class CustomPicker : Picker
        {
            public static readonly BindableProperty ImageProperty =
                BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomPicker), string.Empty);

            public string Image
            {
                get { return (string)GetValue(ImageProperty); }
                set { SetValue(ImageProperty, value); }
            }
        }
    }