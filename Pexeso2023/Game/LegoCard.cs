using System;
using PexesoTv.Common;

namespace PexesoTv.Game
{
    public class LegoCard : IGameCard
    {
        public LegoCard()
        {
        }


        string name = "lego";


        private Color _cartColor = Colors.MistyRose;
        public Color CartColor()
        {
            return _cartColor;
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
            return null;
        }
    }
}
