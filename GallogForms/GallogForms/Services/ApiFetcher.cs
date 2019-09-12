using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GallogForms.Models;
using Newtonsoft.Json;

namespace GallogForms.Services
{
    public static class ApiFetcher
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("https://api.gallog.co/api/") };

        public static string Token
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(Token), "");
            set => Xamarin.Essentials.Preferences.Set(nameof(Token), value);
        }

        public static string RefreshToken
        {
            get => Xamarin.Essentials.Preferences.Get(nameof(RefreshToken), "");
            set => Xamarin.Essentials.Preferences.Set(nameof(RefreshToken), value);
        }

        private static StringContent Jwt = new StringContent(JsonConvert.SerializeObject(new
        {
            jwt =
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjoiNjMiLCJ1c2VybmFtZSI6IkRyZWFtc2ZvcmdvdHRlbiIsImhhbmRsZSI6ImRyZWFtc2ZvcmdvdHRlbiIsImVtYWlsIjoibWlkZGxlcGlsbGVyQGdtYWlsLmNvbSJ9fQ.B7xcwG8Bn18UGT3xE-7Er3N-kY7vMViCE5u1EY-a4j8"
        }), Encoding.UTF8, "application/json");

        /*   public static async Task PostBasicAsync(object content, )
           {
               using (var w = new HttpClient())
               {                   
                 //  w.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));
                 //  w.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", serverKey);

                   w.BaseAddress = new Uri("https://api.gallog.co/ships/");
                   string item = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjoiNjMiLCJ1c2VybmFtZSI6IkRyZWFtc2ZvcmdvdHRlbiIsImhhbmRsZSI6ImRyZWFtc2ZvcmdvdHRlbiIsImVtYWlsIjoibWlkZGxlcGlsbGVyQGdtYWlsLmNvbSJ9fQ.B7xcwG8Bn18UGT3xE-7Er3N-kY7vMViCE5u1EY-a4j8";

                   var json = new StringContent(JsonConvert.SerializeObject(item));
                   var content = new StringContent (json, Encoding.UTF8, "application/json");


                   return JsonConvert.DeserializeObject<ApiList>(await w.GetStringAsync("entries")).entries;
               }*/



        public static async Task<LoginResult> LoginAsync(string email, string password)
        {
            var body = new { email = email, password = password };
            return await PostAsync<LoginResult>(body, "login");
        }

        public static async Task<ShipList> GetShipsAsync()
        {
            return await PostAsync<ShipList>("ships");
        }

        public static async Task<Ship> GetShipAsync(string ship)
        {
            return (await PostAsync<ShipResponse>($"ships/{ship}")).ship;
        }

        public static async Task<ResourceList> GetResourcesAsync()
        {
            return await PostAsync<ResourceList>("resources");
        }

        public static async Task<Resource> GetResourceAsync(string resource)
        {
            return (await PostAsync<ResourceResponse>($"resources/{resource}")).resource;
        }

        public static async Task<TradeportList> GetTradeportsAsync()
        {
            return await PostAsync<TradeportList>("tradeports");
        }

        public static async Task<Tradeport> GetTradeportAsync(string port)
        {
            return await PostAsync<Tradeport>($"tradeports/{port}");
        }

        public static async Task<T> PostAsync<T>(string path) where T : class
        {
            var response = await Client.PostAsync(path, Jwt);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public static async Task<T> PostAsync<T>(object body, string path) where T : class
        {
            var response = await Client.PostAsync(path,
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

    }
}
