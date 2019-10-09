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
        List<string> Hangars = new List<string>();
        public HangarPage()
        {

            InitializeComponent();
            BindingContext = new HangarViewModel();
            ListViewFilter();

        }
        public void ListViewFilter()
        {
            var _container = BindingContext as AddShipViewModel;
            myHangarList.BeginRefresh();
            var _container2 = BindingContext as AddShipViewModel;
            var Items = _container2.chosenShip;
            myHangarList.ItemsSource = _container.Items.Where(i => i.name.ToLower().Contains(Items.ToString()));
            myHangarList.EndRefresh();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new AddShipPage());
            }
    }
}