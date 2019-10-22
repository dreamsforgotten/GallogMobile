using GallogForms.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace GallogForms.Views
{
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