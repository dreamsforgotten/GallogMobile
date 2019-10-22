using Gallog.Api;
using Gallog.Api.Models;
using Gallogforms.ViewModels;
using GallogForms.Interfaces;
using GallogForms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class AddShipViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<ShipCatalog> Items { get; set; }
        public IEnumerable<Ships> MyHangarListData { get; set; }
        private ShipCatalog _selectedItem { get; set; }

        public GallogClient _gallogClient;
        public List<IShipCatalog> SC = new List<IShipCatalog>();

        public string full_URL;

        public ShipCatalog SelectedItem {
                get { return _selectedItem; }
                set
                {
                    if (_selectedItem != value)
                    {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                    ExecuteSelectedItems();
                    }
                }
        }

        public void ExecuteSelectedItems()
        {
            Items.Where(t => t.id == SelectedItem.id).FirstOrDefault().IsVisible =
                 !SelectedItem.IsVisible;
        }




        public AddShipViewModel()
        {   
            Title = "Add To Fleet";
            Items = new ObservableCollection<ShipCatalog>();
            _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo1NywidXNlcm5hbWUiOiJQYXJhIiwiaGFuZGxlIjoiUGFyYSIsImVtYWlsIjoicGFyYWJvbGE5NDlAZ21haWwuY29tIn19.bRpI9hVy-Spky5pbZhJCkyN-MT9RA6ap_yD9ezRxCxo");
            LoadItems();
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
                        item.color = "Black";
                        item.bgcolor = "#7bf964";

                    }
                    else
                    {
                        item.flyable = "No";
                        item.color = "White";
                        item.bgcolor = "#dc494e";
                    }
                    if (item.value == "0.00")
                    {
                        item.value = "Price Says Broke";
                    }
                    if (item.value == null)
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

            }
        }
    }
}
