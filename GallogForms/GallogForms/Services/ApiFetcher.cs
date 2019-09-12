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

        public static async Task<IEnumerable<Entry>> GetApiList()
        {
            using (var w = new HttpClient())
            {                   
              //  w.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));
              //  w.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", serverKey);

                w.BaseAddress = new Uri("https://api.publicapis.org/");
                if (!string.IsNullOrEmpty(Token))
                {
                    w.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                }

                return JsonConvert.DeserializeObject<ApiList>(await w.GetStringAsync("entries")).entries;
            }
        }

    }
}
