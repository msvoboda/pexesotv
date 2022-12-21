using System;
using PexesoTv.Common;

namespace PexesoTv.Game
{
    public class MarioCard : IGameCard
    {
        public MarioCard()
        {
        }

        string name = "mar";

        public int Count()
        {
            return CartUtils.CartCount;
        }


        private Color _cartColor = Colors.IndianRed;
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
