using System;


namespace PexesoTv.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private string image = "car.jpg";
        public String Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        private Color _cartColor= Colors.CornflowerBlue;
        public Color CartColor
        {
            get { return _cartColor; }
            set
            {
                _cartColor = value;
                OnPropertyChanged(nameof(CartColor));
            }
        }

        bool _isVisible = true;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public void ShowCart()
        {
            _cartColor = Colors.Transparent;
            IsVisible = false;
        }

        public void HideCart()
        {
            _cartColor = Colors.CornflowerBlue;
            IsVisible = true;
        }

        private string karta = ".";
        public string Karta
        {
            get { return karta; }
            set
            { 
                karta = value;
                OnPropertyChanged(nameof(Karta));
            }
        }

        public int KartaId
        {
            get;
            set;
        }

        bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

    }
}

