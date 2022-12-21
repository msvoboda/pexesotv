using System;
using PexesoTv.Game;

namespace PexesoTv.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public IGameCard Cart { get; set; }
        public string Description { get; set; }
    }
}