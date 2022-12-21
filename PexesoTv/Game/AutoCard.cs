using System;
using System.Collections.Generic;
using PexesoTv.Common;
using Xamarin.Forms;

namespace PexesoTv.Game
{
    public class AutoCard : IGameCard
    {

        string name = "car";

        public AutoCard()
        {
        }

        private Color _cartColor = Color.CornflowerBlue;
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
