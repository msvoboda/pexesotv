using System;
using System.Collections.Generic;
using PexesoTv.ViewModels;
using Xamarin.Forms;

namespace PexesoTv.Components
{
    public partial class CartView : ContentView
    {

        TapGestureRecognizer tapGesture;
        CartViewModel _vm;

        public CartView()
        {
            InitializeComponent();
            tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += ChangeColor;
            pictureCart.GestureRecognizers.Add(tapGesture);
        }

        public void setViewModel(CartViewModel vm)
        {
            BindingContext = vm;
            _vm = vm;
        }

        private void ChangeColor(object sender, EventArgs args)
        {
            //pictureCart.IsVisible = false;
            if (onSelect!=null)
            {
                onSelect(_vm);
            }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public event OnSelectEvent onSelect;
    }
}
