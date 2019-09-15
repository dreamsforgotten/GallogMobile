using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gallog.Api.Models;

namespace Gallog.Api.Services
{
    public class ShipDataStore : IShipDataStore<ShipCatalog>
    {
        List<ShipCatalog> items;

        public ShipDataStore()
        {
            items = new List<ShipCatalog>();
            var shipItems = new List<ShipCatalog>
            {
                new ShipCatalog { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new ShipCatalog { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new ShipCatalog { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new ShipCatalog { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new ShipCatalog { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new ShipCatalog { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };

            foreach (var item in shipItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(ShipCatalog item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((ShipCatalog arg) => arg.id == ShipCatalog.id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ShipCatalog arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<ShipCatalog>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
