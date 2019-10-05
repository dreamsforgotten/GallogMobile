using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GallogForms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Picker = Xamarin.Forms .Picker;
[assembly: ExportRenderer(typeof(Picker), typeof(GallogForms.Droid.Renderers.CustomPickerRenderer))]
namespace GallogForms.Droid.Renderers
{
    [Obsolete]
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.rounded_corners);
                Control.Gravity = GravityFlags.CenterVertical;
                Control.SetPadding(10, 0, 0, 0);
            }
        }
    }
}
