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
            
            var ship = ApiFetcher.GetShipAsync("idris").Result;
            Console.WriteLine($"{ship.name}");

            Console.Read();
        }
    }
}
