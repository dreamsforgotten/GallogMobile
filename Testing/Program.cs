using System;
using System.IO;
using GallogForms;
using GallogForms.Services;
using GallogForms.Models;

namespace Testing
{
    class Program
    {
        private static string path = Path.Combine(Environment.CurrentDirectory, "jwt.txt");
        static void Main(string[] args)
        {
            var jwt = "";
            if (!File.Exists(path))
            {
                //login 
                Console.Write("Email: ");
                var email = Console.ReadLine();
                Console.Write("\nPassword: ");
                var pass = Console.ReadLine();
                Console.Clear();
                var login = ApiFetcher.LoginAsync(email, pass).Result;
                if (login.message.Contains("Success"))
                {
                    using (var sw = new StreamWriter(path))
                    {
                        sw.Write(login.jwt);
                    }

                    jwt = login.jwt;
                }
                else
                {
                    Environment.Exit(1);
                }
            }
            else
            {
                //get the jwt
                using (var sr = new StreamReader(path))
                {
                    jwt = sr.ReadToEnd();
                }
            }
            Console.WriteLine(jwt);
            Console.WriteLine("JWT LOADED");
            var ships = ApiFetcher.GetShipsAsync(jwt).Result;
            Console.WriteLine($"Found {ships.ships.Length} ships.");

            Console.Read();
        }
    }
}
