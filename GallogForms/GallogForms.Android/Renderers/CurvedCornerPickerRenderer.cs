using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GallogForms.Droid.Renderers;
using GallogForms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CurvedCornersPicker), typeof(CurvedCornersPickerRenderer))]
namespace GallogForms.Droid.Renderers
{
    [Obsolete]
    public class CurvedCornersPickerRenderer : PickerRenderer
        {
            private GradientDrawable _gradientBackground;

            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                base.OnElementChanged(e);

                var view = (CurvedCornersPicker)Element;
                if (view == null) return;

                Paint(view);
            }

            private void Paint(CurvedCornersPicker view)
            {
                // creating gradient drawable for the curved background
                _gradientBackground = new GradientDrawable();
                _gradientBackground.SetShape(ShapeType.Rectangle);
                _gradientBackground.SetColor(view.CurvedBackGroundColor.ToAndroid());

                // Thickness of the stroke line
                _gradientBackground.SetStroke(4, view.CurvedBackGroundColor.ToAndroid());

                // Radius for the curves
                _gradientBackground.SetCornerRadius(
                    DpToPixels(this.Context,
                    Convert.ToSingle(view.CurvedCornerRadius)));

                // set the background of the label
                Control.SetBackground(_gradientBackground);
            }

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);

                // re-paint if these properties change at runtime
                if (e.PropertyName == CurvedCornersPicker.BackgroundColorProperty.PropertyName ||
                    e.PropertyName == CurvedCornersPicker.CurvedCornerRadiusProperty.PropertyName)
                {
                    if (Element != null)
                    {
                        Paint((CurvedCornersPicker)Element);
                    }
                }
            }

            /// <summary>
            /// Device Independent Pixels to Actual Pixles conversion
            /// </summary>
            /// <param name="context"></param>
            /// <param name="valueInDp"></param>
            /// <returns></returns>
            public static float DpToPixels(Context context, float valueInDp)
            {
                DisplayMetrics metrics = context.Resources.DisplayMetrics;
                return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
            }
        }
    }