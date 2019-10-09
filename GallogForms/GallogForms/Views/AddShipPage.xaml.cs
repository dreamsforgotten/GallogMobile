using GallogForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Gallog.Api;
using Xamarin.Forms.Xaml;
using Gallog.Api.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Gallogforms.ViewModels;

namespace GallogForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddShipPage : ContentPage
    {
        public ObservableCollection<ShipCatalog> ships { get; set; }
        public AddShipPage()
        {
            InitializeComponent();
            BindingContext = new AddShipViewModel();
        }

        void ListViewFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as AddShipViewModel;
            SuggestedShipView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                SuggestedShipView.ItemsSource = _container.Items;
            else
                SuggestedShipView.ItemsSource = _container.Items.Where(i => i.name.ToLower().Contains(e.NewTextValue));

            SuggestedShipView.EndRefresh();
        }

        private void SuggestedShipView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ship = e.Item as string;
            var _container = BindingContext as AddShipViewModel;
            _container.chosenShip.Add(ship);
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HangarPage());
        }        
    }
}