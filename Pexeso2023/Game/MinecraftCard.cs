using System;
using PexesoTv.Common;

namespace PexesoTv.Game
{
    public class MinecraftCard : IGameCard
    {
        public MinecraftCard()
        {
        }

        string name = "img";

        public int Count()
        {
            return CartUtils.CartCount;
        }


        private Color _cartColor = Colors.SeaGreen;
        public Color CartColor()
        {
            return _cartColor;
        }

        public string Get(int id)
        {
            return name + (id + 1) + ".jpg";
        }

        public string GetBackImage()
        {
            return null;
        }
    }
}
