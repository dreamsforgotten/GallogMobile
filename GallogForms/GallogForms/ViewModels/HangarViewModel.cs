using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Gallog.Api.Models;
using Gallog.Api.Interfaces;
using Gallog.Api.Attributes;
using System.Net.Http;
using Xamarin.Forms;
using GallogForms.Views;
using System.Collections.ObjectModel;
using Gallog.Api;
using System.Linq;
using System.Diagnostics;

namespace GallogForms.ViewModels
{
    public class HangarViewModel : BaseViewModel
    {
        public ObservableCollection<ShipCatalog> Hangars { get; set; }
        private GallogClient _gallogClient;


        public HangarViewModel()
        {
            Title = "Hangar";
            Hangars = new ObservableCollection<ShipCatalog>();
            LoadItems();
        }



        private async void LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Hangars.Clear();
                var items = await _gallogClient.GetItemsAsync<ShipList>();
                foreach (var item in items.ships.ToList())
                {
                    Hangars.Add(item);
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

