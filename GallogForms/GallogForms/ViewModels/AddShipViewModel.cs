using Gallog.Api;
using Gallog.Api.Models;
using Gallogforms.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace GallogForms.ViewModels
{
    public class AddShipViewModel : BaseViewModel
    {
        public ObservableCollection<ShipCatalog> Items { get; set; }
        public List<string> chosenShip = new List<string>();

        private GallogClient _gallogClient; 



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
