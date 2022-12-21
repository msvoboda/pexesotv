using System;
using System.Drawing;
using PexesoTv.ViewModels;
using Color = Microsoft.Maui.Graphics.Color;

namespace PexesoTv.Models
{
    public class Player : BaseViewModel
    {
        public Player(String name)
        {
            Name = name;
            Score = 0;

        }

        public string Name
        {
            get;
            set;
        }

        public double Score
        {
            get;
            set;
        }

        public string Text
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return Name + ": " + Score;
        }

        private Color _color = Colors.Black;
        public Color Color
        {
            get { return _color; }
            set 
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }

        }
    }
}
