using Gallog.Api;
using Gallog.Api.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradingViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<ShipCatalog> Items { get; set; }
        public ObservableCollection<TradeportCatalog> Ports { get; set; }
        public Array TempArray;
        public string shipUri;
        public int uec = 5000;

        private ShipCatalog _selectedShip { get; set; }
        public ShipCatalog SelectedShip
        {
            get { return _selectedShip; }
            set
            {
                if (_selectedShip != value)
                {
                    _selectedShip = value;
                    _selectedShip.uri = shipUri;

                }
            }
        }

        public Command PostRouteData { get; set; }



        public TradingViewModel()
        {
            Title = "Trading";
            Ports = new ObservableCollection<TradeportCatalog>();
            Items = new ObservableCollection<ShipCatalog>();
            _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo1NywidXNlcm5hbWUiOiJQYXJhIiwiaGFuZGxlIjoiUGFyYSIsImVtYWlsIjoicGFyYWJvbGE5NDlAZ21haWwuY29tIn19.bRpI9hVy-Spky5pbZhJCkyN-MT9RA6ap_yD9ezRxCxo");
          //  PostRouteData = new Command(async () => await ExecutePostRouteData(), () => !IsBusy);

            LoadItems();
        }

        private async void ExecutePostRouteData()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                var routes = await _gallogClient.RoutesAsync(shipUri, uec);
               // foreach (var route in routes.)



            }
            catch
            {

            }
        }
        private async void LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;  
            try
            {
                Items.Clear();
                var items = await _gallogClient.GetItemsAsync<ShipList>();
                var ports = await _gallogClient.GetItemsAsync<TradeportList>();
                foreach (var item in items.ships.ToList())
                {                
                   Items.Add(item);
                }
                foreach (var port in ports.tradeports.ToList())
                    {
                    Ports.Add(port);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                
            }
        }      

    }
}