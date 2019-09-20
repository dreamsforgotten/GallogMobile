﻿using System;
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
        public FlexLayout flexlayout;

        public Command RefreshItemsCommand { get; set; }
        public string full_URL;
        public ShipsViewModel()
        {
            Title = "Ships";
            Items = new ObservableCollection<ShipCatalog>();
            _gallogClient = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo1NywidXNlcm5hbWUiOiJQYXJhIiwiaGFuZGxlIjoiUGFyYSIsImVtYWlsIjoicGFyYWJvbGE5NDlAZ21haWwuY29tIn19.bRpI9hVy-Spky5pbZhJCkyN-MT9RA6ap_yD9ezRxCxo");
            RefreshItemsCommand = new Command(async() => await ExecuteRefreshItemsCommand(), () => !IsBusy);
            flexlayout = new FlexLayout();
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
                        item.img = "were're fucked here";
                    }
                    else
                    {
                        full_URL = "https://gallog.co/img/ships/" + item.img;
                        item.img = full_URL;
                    }
                    if (item.flyable == "1")
                    {
                        item.flyable = "Flyable";
                    }
                    else
                    {
                        item.flyable = "Not Flyable";
                    }
                    if (item.value == "0.00")
                    {
                        item.value = "Price Tag Says Broke";
                    }
                    if (item.value == "")
                    {
                        item.value = "Price Tag Says Broke";
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
                        item.img = "were're fucked here";
                    }
                    else
                    {
                        full_URL = "https://gallog.co/img/ships/" + item.img;
                        item.img = full_URL;
                    }
                    Items.Add(item);
                /*    Image image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(item.img))
                    };
                    flexlayout.Children.Add(image);*/
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