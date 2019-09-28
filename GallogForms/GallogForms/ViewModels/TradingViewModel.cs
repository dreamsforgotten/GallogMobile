using Gallog.Api;
using Gallog.Api.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradingViewModel : BaseViewModel
    {
        public ObservableCollection<TradeportCatalog> Ports { get; set; }
        public ObservableCollection<ShipCatalog> Items { get; set; }
        private TradeportCatalog _selectedStartPort { get; set; }
        private TradeportCatalog _selectedEndPort { get; set; }
        private ShipCatalog _selectedShip { get; set; }
        private TradeRoutes _tradeRoutes { get; set; }
        public Command PostRouteData { get; set; }

        private GallogClient _gallogClient;
        string shipuri = string.Empty;
        public string shipUri
        {
            get => shipuri;
            set
            {
                if (shipuri == value)
                    return;

                shipuri = value;
                OnPropertyChanged(nameof(shipUri));
            }
        }

        string starturi = string.Empty;
        public string startUri
        {
            get => starturi;
            set
            {
                if (starturi == value)
                    return;

                starturi = value;
                OnPropertyChanged(nameof(startUri));
            }
        }
        string enduri = string.Empty;
        public string endUri
                {
            get => enduri;
            set
            {
                if (enduri == value)
                    return;

                enduri = value;
                OnPropertyChanged(nameof(endUri));
            }
        }

        public int _scu;

        public int UEC = 0;

        public int uec
        {
            get => GetProperty<int>();
            set => SetProperty<int>(value);
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
                uec = Int32.Parse(value);
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
                    shipUri = _selectedShip.uri;
                    OnPropertyChanged(nameof(SelectedShip));

                }
            }
        }

        public TradeportCatalog SelectedStartPort
        {
            get { return _selectedStartPort; }
            set
            {
                if (_selectedStartPort != value)
                {
                    _selectedStartPort = value;
                    startUri = _selectedStartPort.uri; 
                    OnPropertyChanged(nameof(SelectedStartPort));
                }
            }
        }

        public TradeportCatalog SelectedEndPort
        {
            get { return _selectedEndPort; }
            set
            {
                if (_selectedEndPort != value)
                {
                    _selectedEndPort = value;
                    endUri = _selectedEndPort.uri;
                    OnPropertyChanged(nameof(SelectedEndPort));
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
                        OnPropertyChanged(nameof(TradeRoutes));
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