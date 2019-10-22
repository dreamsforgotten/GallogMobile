using GallogForms.Models;
using GallogForms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class HangarPage : ContentPage
    {
        public HangarPage()
        {

            InitializeComponent();
            BindingContext = new AddShipViewModel();
            //var _container = BindingContext as AddShipViewModel;
            //myHangarList.ItemsSource = _container.Items.Where(i => i.IsVisible == true);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddShipPage());
        }
    }
}