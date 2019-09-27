using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GallogForms
{
    class SliderDemo : ContentPage
    {
        private double StepValue;
        private Slider SliderUec;

        public SliderDemo()
        {
            StepValue = 100.0;

            Label UecCount = new Label
            {
                Text = "Total Uec",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label display = new Label
            {
                Text = "(uninitalized)",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            SliderUec = new Slider
            {
                Maximum = 1000000.0, 
                Minimum = 100.0,
                Value = 100.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            SliderUec.ValueChanged += OnSliderValueChanged;

            Content = new StackLayout
            {
                Children = { SliderUec },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / StepValue);
            SliderUec.Value = newStep * StepValue;
        }
    }
}
