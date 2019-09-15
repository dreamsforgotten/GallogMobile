using System;
using System.Windows.Input;
using System.Net.Http;
using Gallog.Api.Models;
using Gallog.Api;

using Xamarin.Forms;
using Refit;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace GallogForms.ViewModels
{
    public class ShipsViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<ShipCatalog> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ShipsViewModel()
        {
            Title = "Ships";
            _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo2MywidXNlcm5hbWUiOiJEcmVhbXNmb3Jnb3R0ZW4iLCJoYW5kbGUiOiJkcmVhbXNmb3Jnb3R0ZW4iLCJlbWFpbCI6Im1pZGRsZXBpbGxlckBnbWFpbC5jb20ifX0.GdETzflTrrdQ3OQg_pcIMpBCO7JTPenLizr_JfrUq1g");
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
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