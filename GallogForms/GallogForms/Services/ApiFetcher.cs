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

        public class Post
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Body { get;set; }
        }

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
        private static async Task PostBasicAsync(object content)
        {
            using (var client = new HttpClient())
            var  Url = "https://api.gallog.com/ships/"
            using (var request = new HttpRequestMessage(HttpMethod.Post, Url))
            {
                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }
            }
        }
    }

        public static async Task<LoginResult> LoginAsync(string email, string password)
        {

        }

        public static async Task<ShipList> GetShipsAsync(string jwt)
        {

        }

    }
}
