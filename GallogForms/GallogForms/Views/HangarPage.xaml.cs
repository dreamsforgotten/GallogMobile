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
            BindingContext = new HangarViewModel();
        }
        void Populate_myHangarList(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as ShipsViewModel;
            myHangarList.BeginRefresh();

            //if (String.IsNullOrWhiteSpace(e.ToString()))
            //    myHangarList.ItemsSource = _container.Items;
            //else
            //myHangarList.ItemsSource = _container.Items.Where(i => i.name.ToLower().Contains(e.ToString()));
            myHangarList.ItemsSource = _container.Items;

            myHangarList.EndRefresh();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new AddShipPage());
            }
    }
}