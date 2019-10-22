using System;
using Gallog.Api.Models;
using Gallog.Api;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GallogForms.ViewModels
{
    //   private GallogClient _gallogClient;
    //   public ObservableCollection<ShipCatalog> Items { get; set; }

    //   public Command RefreshItemsCommand { get; set; }
    public class StoresViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<TradeportCatalog> Items { get; set; }
        public Command RefreshItemsCommand { get; set; }
        public StoresViewModel()
        {
            Title = "Stores";
        //    Items = new ObservableCollection<ShipCatalog>();
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
          //      var items = await _gallogClient.GetItemsAsync<StoreList>();

           //     foreach (var item in items.ships.ToList())
                {                    
           //         Items.Add(item);
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
            RefreshItemsCommand.ChangeCanExecute();

            try
            {
                Items.Clear();
          //      var items = await _gallogClient.GetItemsAsync<StoreList>();
         //       foreach (var item in items.ships.ToList())
                {                    
         //           Items.Add(item);                  
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