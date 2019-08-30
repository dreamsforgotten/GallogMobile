using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Android.App;
using Newtonsoft.Json;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gallog
{
    [Activity(Label = "LogonActivity")]
    public class LogonActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            async void PostRequest(string URL)
            {
                var formContent = new FormUrlEncodedContent(new[]
                    {
                new KeyValuePair<string, string>("somekey", "1"),
            });

                var myHttpClient = new findbyid
                    var response = await myHttpClient.PostAsync(URL, formContent);

                var json = await response.Content.ReadAsStringAsync();
                EventHandler result = JsonConvert.DeserializeObject<EventHandler>(json);
            }
        }
    }
}