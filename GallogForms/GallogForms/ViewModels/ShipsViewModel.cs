using System;
using System.Windows.Input;
using System.Net.Http;
using Gallog.Api.Models;
using Gallog.Api;

using Xamarin.Forms;
using Refit;

namespace GallogForms.ViewModels
{
    public class ShipsViewModel : BaseViewModel
    {
        private GallogClient GallogClient;

        public ShipsViewModel()
        {
            Title = "Ships";
            var client = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjo2MywidXNlcm5hbWUiOiJEcmVhbXNmb3Jnb3R0ZW4iLCJoYW5kbGUiOiJkcmVhbXNmb3Jnb3R0ZW4iLCJlbWFpbCI6Im1pZGRsZXBpbGxlckBnbWFpbC5jb20ifX0.GdETzflTrrdQ3OQg_pcIMpBCO7JTPenLizr_JfrUq1g");
            var ShipResults = client.GetItemAsync<ShipList>().Result;
            ListView.ListView1 = ShipResults;
        }



    }

}