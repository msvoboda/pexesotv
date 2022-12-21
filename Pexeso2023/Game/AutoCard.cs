using System;
using System.Collections.Generic;
using PexesoTv.Common;

namespace PexesoTv.Game
{
    public class AutoCard : IGameCard
    {

        string name = "car";

        public AutoCard()
        {
        }

        private Color _cartColor = Colors.CornflowerBlue;
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
            return name + (id+1) + ".jpg";
        }

        public string GetBackImage()
        {
            return null;
        }
    }
}
