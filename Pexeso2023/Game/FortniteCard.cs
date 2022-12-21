using PexesoTv.Common;

namespace PexesoTv.Game
{
    class FortniteCard : IGameCard
    {
        string name = "fortnite";

        public FortniteCard()
        {
        }

        private Color _cartColor = Colors.MediumPurple;
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
