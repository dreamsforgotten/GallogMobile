using System;
using Gallog.Api.Models;
using Gallog.Api;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace GallogForms.ViewModels
{
    public class ShipsViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<ShipCatalog> Items { get; set; }


        private ShipCatalog _selectedShip { get; set; }
        public ShipCatalog SelectedShip
        {
            get { return _selectedShip; }
            set
            {
                if (_selectedShip != value)
                {
                    _selectedShip = value;
                    ExpandOrCollapseSelectedItem();
                }
            }
        }

        private void ExpandOrCollapseSelectedItem()
        {
            Items.Where(t => t.id == SelectedShip.id).FirstOrDefault().IsVisible =
                !SelectedShip.IsVisible;
        }
        public Command RefreshItemsCommand { get; set; }

        public string full_URL;
        public string tempColor;
        public ShipsViewModel()
        {
            Title = "Ships";
            Items = new ObservableCollection<ShipCatalog>();
         //   ExtItems = new ObservableCollection<shipmatrix>();

           _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo1NywidXNlcm5hbWUiOiJQYXJhIiwiaGFuZGxlIjoiUGFyYSIsImVtYWlsIjoicGFyYWJvbGE5NDlAZ21haWwuY29tIn19.bRpI9hVy-Spky5pbZhJCkyN-MT9RA6ap_yD9ezRxCxo");
            RefreshItemsCommand = new Command(async () => await ExecuteRefreshItemsCommand(), () => !IsBusy);

            LoadItems();
        }
        private async void LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            RefreshItemsCommand.ChangeCanExecute();

            try
            {
                Items.Clear();
                var items = await _gallogClient.GetItemsAsync<ShipList>();
                    foreach (var item in items.ships.ToList())
                    {
                    if (item.img == "")
                    {
                        item.img = "ph.png";
                    }
                    else
                    {
                        full_URL = "https://gallog.co/img/ships/" + item.img;
                        item.img = full_URL;
                    }
                    if (item.flyable == "1")
                    {
                        item.flyable = "Yes";
                        item.color = "#7bf964";
                        
                    }
                    else
                    {
                        item.flyable = "No";
                        item.color = "#dc494e";
                    }
                    if (item.value == "0.00")
                    {
                        item.value = "Price Says Broke";
                    }
                    if (item.value == "")
                    {
                        item.value = "Price Null";
                    }

                    Items.Add(item);
                    }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                RefreshItemsCommand.ChangeCanExecute();

            }
        }

        //public async void LoadExtendedItems()
        //{
        //    if (IsBusy)
        //        return;

        //    IsBusy = true;
        //    try
        //    {
        //        ExtItems.Clear();
        //        var items = await _gallogClient.GetItemAsync<ShipResponse>(SelectedShip.name);
        //        foreach (var item in items.ship.ToList())
        //        {                   
        //            ExtItems.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        async Task ExecuteRefreshItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            RefreshItemsCommand.ChangeCanExecute();

            try
            {
                Items.Clear();
                var items = await _gallogClient.GetItemsAsync<ShipList>();

                foreach (var item in items.ships.ToList())
                {
                    if (item.img == "")
                    {
                        item.img = "ph.png";
                    }
                    else
                    {
                        full_URL = "https://gallog.co/img/ships/" + item.img;
                        item.img = full_URL;
                    }
                    if (item.flyable == "1")
                    {
                        item.flyable = "Yes";
                        item.color = "#7bf964";

                    }
                    else
                    {
                        item.flyable = "No";
                        item.color = "#dc494e";
                    }
                    if (item.value == "0.00")
                    {
                        item.value = "Price Says Broke";
                    }
                    if (item.value == "")
                    {
                        item.value = "Price Null";
                    }

                    Items.Add(item);

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                RefreshItemsCommand.ChangeCanExecute();

            }
        }
                     
    }
}