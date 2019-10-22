using GallogForms.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GallogForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddShipPage : ContentPage
    {


        public AddShipPage()
        {
            InitializeComponent();
            BindingContext = new AddShipViewModel();
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HangarPage());
        }
    }
}