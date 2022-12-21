using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PexesoTv.Game;
using PexesoTv.Models;

namespace PexesoTv.Services
{
    public class GamesDataStore : IDataStore<Item>
    {
        List<Item> items;

        public GamesDataStore()
        {
            items = new List<Item>();
            var games = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Image = "car.png", Text = "Auta", Cart = new AutoCard(),Description="Pexeso s auty." },
                new Item { Id = Guid.NewGuid().ToString(), Image = "fortnite.png", Text = "Fortnite", Cart = new FortniteCard(), Description="Pexeso ze světa Fortnite" },
                new Item { Id = Guid.NewGuid().ToString(), Image = "starwars.png", Text = "Starwars", Cart = new StarWarsCard(), Description="Pexeso ze světa Star wars" },
                new Item { Id = Guid.NewGuid().ToString(), Image = "minecraft.png", Text = "Minecraft", Cart = new MinecraftCard(), Description="Pexeso ze světa minecraftu." },
                new Item { Id = Guid.NewGuid().ToString(), Image = "mario.png", Text = "Mario", Cart = new MarioCard(), Description="Pexeso mario." },
                new Item { Id = Guid.NewGuid().ToString(), Image = "lego.png", Text = "Lego", Cart = new LegoCard(), Description="Pexeso z lego světa" },
            };

            foreach (var item in games)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
