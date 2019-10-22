using System;
using Gallog.Api.Models;
using Gallog.Api;

namespace Testing
{
    class Program
    {
        static void Main()
        {
            var c = new GallogClient("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOlwvXC9hcGkuZ2FsbG9nLmNvIiwiYXVkIjoiaHR0cDpcL1wvYXBpLmdhbGxvZy5jbyIsImlhdCI6MTM1Njk5OTUyNCwibmJmIjoxMzU3MDAwMDAwLCJkYXRhIjp7ImlkIjoiNjMiLCJ1c2VybmFtZSI6IkRyZWFtc2ZvcmdvdHRlbiIsImhhbmRsZSI6ImRyZWFtc2ZvcmdvdHRlbiIsImVtYWlsIjoibWlkZGxlcGlsbGVyQGdtYWlsLmNvbSJ9fQ.B7xcwG8Bn18UGT3xE-7Er3N-kY7vMViCE5u1EY-a4j8");

            var result = c.GetItemAsync<ShipResponse>("idris").Result;

            Console.WriteLine(result.ship.image);
            Console.Read();
         
        }
    }
}
