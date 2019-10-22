using Gallog.Api;
using Gallog.Api.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradeportsViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<TradeportCatalog> Items { get; set; }
        public Command RefreshItemsCommand { get; set; }
        public TradeportsViewModel()
        {
            Title = "Tradeports";
            Items = new ObservableCollection<TradeportCatalog>();
            _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo1NywidXNlcm5hbWUiOiJQYXJhIiwiaGFuZGxlIjoiUGFyYSIsImVtYWlsIjoicGFyYWJvbGE5NDlAZ21haWwuY29tIn19.bRpI9hVy-Spky5pbZhJCkyN-MT9RA6ap_yD9ezRxCxo");
            RefreshItemsCommand = new Command(async () => await ExecuteRefreshItemsCommand(), () => !IsBusy);
            LoadItems();
        }

        private async void LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RefreshItemsCommand.ChangeCanExecute();
                Items.Clear();
                var items = await _gallogClient.GetItemsAsync<TradeportList>();
                foreach (var item in items.tradeports.ToList())
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
                RefreshItemsCommand.ChangeCanExecute();
            }
        }
        async Task ExecuteRefreshItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RefreshItemsCommand.ChangeCanExecute();
                Items.Clear();
                var items = await _gallogClient.GetItemsAsync<TradeportList>();
                foreach (var item in items.tradeports.ToList())
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
                RefreshItemsCommand.ChangeCanExecute();
            }
        }

    }

}