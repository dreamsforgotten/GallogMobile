using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class CurvedCornersPicker : Picker
    {
        public static readonly BindableProperty CurvedCornerRadiusProperty =
                BindableProperty.Create(
                    nameof(CurvedCornerRadius),
                    typeof(double),
                    typeof(CurvedCornersPicker),
                    12.0);
        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CurvedBackgroundColorProperty =
            BindableProperty.Create(
                nameof(CurvedCornerRadius),
                typeof(Color),
                typeof(CurvedCornersPicker),
                Color.Default);

        public Color CurvedBackGroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }
    }
}
