using PexesoTv.Common;
using PexesoTv.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso2023.Game
{
    public class WednesdayCard : IGameCard
    {

        string name = "w";
        public Color CartColor()
        {
            return Colors.DarkGray;
        }

        public int Count()
        {
            return CartUtils.CartCount;
        }

        public string Get(int id)
        {
            return name + (id + 1) + ".png";
        }

        public string GetBackImage()
        {
            return null;
        }
    }
}
