using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GallogForms.Models;
using Newtonsoft.Json;

namespace GallogForms.Services
{
    public static class ApiFetcher
    {
        public static async Task<IEnumerable<Entry>> GetApiList()
        {
            using (var w = new HttpClient())
            {
                w.BaseAddress = new Uri("https://api.publicapis.org/");
                return JsonConvert.DeserializeObject<ApiList>(await w.GetStringAsync("entries")).entries;
            }
        }

    }
}
