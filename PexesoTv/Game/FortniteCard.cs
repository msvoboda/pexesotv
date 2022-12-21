using PexesoTv.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PexesoTv.Game
{
    class FortniteCard : IGameCard
    {
        string name = "fortnite";

        public FortniteCard()
        {
        }

        private Color _cartColor = Color.MediumPurple;
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
