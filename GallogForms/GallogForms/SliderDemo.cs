using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GallogForms
{
    class SliderDemo : ContentPage
    {
        private double StepValue;
        private Slider SliderMain;

        public SliderDemo()
        {
            StepValue = 100.0;

            SliderMain = new Slider
            {
                Maximum = 100000000000.0f,
                Minimum = 1000.0f,
                Value = 0.0f,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            SliderMain.ValueChanged += OnSliderValueChanged;

            Content = new StackLayout
            {
                Children = { SliderMain },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);
            SliderMain.Value = newStep * StepValue;
        }
    }
}
