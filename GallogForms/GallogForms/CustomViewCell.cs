using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GallogForms
{
    class CustomViewCell : ViewCell
    {
            public static readonly BindableProperty 
            SelectedItemBackgroundColorProperty = BindableProperty.Create("SelectedItemBackgroundColor", typeof(Color), typeof(CustomViewCell), default);  
        public Color SelectedItemBackgroundColor
         {
                get
                {
                    return (Color)GetValue(SelectedItemBackgroundColorProperty);
                }
                set
                {
                    SetValue(SelectedItemBackgroundColorProperty, value);
                }
         }
        
    }
}

