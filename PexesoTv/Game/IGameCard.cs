using System;
using Xamarin.Forms;

namespace PexesoTv.Game
{
    public interface IGameCard
    {
        string Get(int id);
        int Count();
        Color CartColor();

        String GetBackImage();
    }
}
