using Gallog.Api;
using Gallog.Api.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradingViewModel : BaseViewModel
    {
        public ObservableCollection<TradeportCatalog> Ports { get; set; }
        public ObservableCollection<ShipCatalog> Items { get; set; }
        private TradeportCatalog _selectedPort { get; set; }
        private ShipCatalog _selectedShip { get; set; }
        private TradeRoutes _tradeRoutes { get; set; }
        public Command PostRouteData { get; set; }

        private GallogClient _gallogClient;


        // public string shipUri;
        // public string portUri;
        // public string _ship;
        public int _scu;
        int uec = int.MinValue;
        public int UEC
        {
            get => uec;
            set
            {
                if (uec == value)
                    return;

                uec = value;
                OnPropertyChanged(nameof(UEC));

            }
        }

        string entrytxt = string.Empty;
        public string EntryTxt
        {
            get => entrytxt;
            set
            {
                if (entrytxt == value)
                    return;

                entrytxt = value;
                OnPropertyChanged(nameof(EntryTxt));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        public ShipCatalog SelectedShip
        {
            get { return _selectedShip; }
            set
            {
                if (_selectedShip != value)
                {
                    _selectedShip = value;
                    //   _selectedShip.uri = shipUri;
                    OnPropertyChanged();

                }
            }
        }

        public TradeportCatalog SelectedPort
        {
            get { return _selectedPort; }
            set
            {
                if (_selectedPort != value)
                {
                    _selectedPort = value;
                    //   _selectedPort.uri = portUri;
                    OnPropertyChanged();
                }
            }
        }

        public TradeRoutes TradeRoutes
        {
            get { return _tradeRoutes; }
            set
            {
                if (_tradeRoutes != value)
                {
                    _tradeRoutes = value;
                    {
                        OnPropertyChanged();
                    }
                }
            }
        }

        public string DisplayName => $"{EntryTxt} UEC";

        public TradingViewModel()
        {
            Title = "Trading";
            Ports = new ObservableCollection<TradeportCatalog>();
            Items = new ObservableCollection<ShipCatalog>();
            _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo1NywidXNlcm5hbWUiOiJQYXJhIiwiaGFuZGxlIjoiUGFyYSIsImVtYWlsIjoicGFyYWJvbGE5NDlAZ21haWwuY29tIn19.bRpI9hVy-Spky5pbZhJCkyN-MT9RA6ap_yD9ezRxCxo");
         //   PostRouteData = new Command(async () => await ExecutePostRouteData(), () => !IsBusy);
            LoadItems();
        }

        //async Task ExecutePostRouteData()
        //{
        //        var routes = await _gallogClient.RoutesAsync(shipUri, uec);
        //  //  _ship = routes.ship;
        //    _scu = routes.scu;            
        //}

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