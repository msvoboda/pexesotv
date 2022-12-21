using System;
using PexesoTv.Common;
using Xamarin.Forms;

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


        private Color _cartColor = Color.SeaGreen;
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
