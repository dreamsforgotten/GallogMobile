using Gallog.Api.Attributes;
using Gallog.Api.Interfaces;
using Gallog.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallog.Api
{
    public class TestClient : IGallogClient
    {
        internal readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("https://api.gallog.co/api/") };
        /// <summary>
        /// JSON Web Token to use with the client
        /// </summary>
        public string Jwt { get; set; }
        public TestClient()
        {

        }

        /// <summary>
        /// Initializes the client with a known JSON Web Token
        /// </summary>
        /// <param name="jwt"></param>
        public TestClient(string jwt)
        {
            Jwt = jwt;
        }

        private StringContent JwtContent
        {
            get {
                return new StringContent(JsonConvert.SerializeObject(new
                {
                    jwt = Jwt              
                }), Encoding.UTF8, "application/json");
            }
        }


        /// <summary>
        /// Logs into the system.  If successful, stores the JSON Web Token in the client (in memory only)
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var body = new { email, password };
            var response =  await PostAsync<LoginResult>(body, "login");
            Jwt = response.jwt;
            return response;
        }

        /// <summary>
        /// Gets a specific item based on the model passed to it. Must be a class that implements ApiQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Name / slug of the item you want</param>
        /// <returns></returns>
        public async Task<T> GetItemAsync<T>(string name) where T : ApiQueryable
        {
            return await PostAsync<T>($"{GetPath<T>()}/{name}");
        }

        /// <summary>
        /// Gets items from the api.  Must be a class that implements ApiQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetItemsAsync<T>() where T : ApiQueryable
        {
            return await PostAsync<T>($"{GetPath<T>()}");
        }

        internal string GetPath<T>()
        {
            if (typeof(T).GetCustomAttributes(
                typeof(ApiPathAttribute), true
            ).FirstOrDefault() is ApiPathAttribute at)
            {
                return at.Path;
            }
            return null;
        }

        public async Task<T> PostAsync<T>(string path) where T : ApiQueryable
        {
            var response = await Client.PostAsync(path, JwtContent);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<T> PostAsync<T>(object body, string path) where T : ApiQueryable
        {
            var response = await Client.PostAsync(path,
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
