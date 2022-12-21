using PexesoTv.Common;
using System;

namespace PexesoTv.Game
{
    public class StarWarsCard : IGameCard
    {
        string name = "starwars";

        public Color CartColor()
        {
            return Colors.Black;
        }

        public int Count()
        {
            return CartUtils.CartCount;
        }

        public string Get(int id)
        {
            return name + (id + 1) + ".jpg";
        }

        public string GetBackImage()
        {
            return "backwars.png";
        }
    }
}
