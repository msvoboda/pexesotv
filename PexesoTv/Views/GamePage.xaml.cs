using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PexesoTv.Common;
using PexesoTv.Components;
using PexesoTv.Models;
using PexesoTv.ViewModels;
using Xamarin.Forms;

namespace PexesoTv.Views
{
    public partial class GamePage : ContentPage
    {
        private Image m_deck = null;
        private CartView[] grid = new CartView[CartUtils.CartCount];
        private CartViewModel[] card = new CartViewModel[CartUtils.CartCount];
        GameViewModel _gameViewModel;

        public GamePage(GameViewModel gameViewModel)
        {
            InitializeComponent();
            _gameViewModel = gameViewModel;
            BindingContext = gameViewModel;

            MessagingCenter.Subscribe<KeyModelEvent>(this, "KeyDown", this.KeyDown);

            // A 
            grid[0] = pictureCartA1;
            grid[1] = pictureCartA2;
            grid[2] = pictureCartA3;
            grid[3] = pictureCartA4;
            grid[4] = pictureCartA5;
            grid[5] = pictureCartA6;
            grid[6] = pictureCartA7;
            // B 
            grid[7] = pictureCartB1;
            grid[8] = pictureCartB2;
            grid[9] = pictureCartB3;
            grid[10] = pictureCartB4;
            grid[11] = pictureCartB5;
            grid[12] = pictureCartB6;
            grid[13] = pictureCartB7;
            // C
            grid[14] = pictureCartC1;
            grid[15] = pictureCartC2;
            grid[16] = pictureCartC3;
            grid[17] = pictureCartC4;
            grid[18] = pictureCartC5;
            grid[19] = pictureCartC6;
            grid[20] = pictureCartC7;
            // D
            grid[21] = pictureCartD1;
            grid[22] = pictureCartD2;
            grid[23] = pictureCartD3;
            grid[24] = pictureCartD4;
            grid[25] = pictureCartD5;
            grid[26] = pictureCartD6;
            grid[27] = pictureCartD7;
            // E
            grid[28] = pictureCartE1;
            grid[29] = pictureCartE2;
            grid[30] = pictureCartE3;
            grid[31] = pictureCartE4;
            grid[32] = pictureCartE5;
            grid[33] = pictureCartE6;
            grid[34] = pictureCartE7;

            // F
            grid[35] = pictureCartF1;
            grid[36] = pictureCartF2;
            grid[37] = pictureCartF3;
            grid[38] = pictureCartF4;
            grid[39] = pictureCartF5;
            grid[40] = pictureCartF6;
            grid[41] = pictureCartF7;

            int idx = 0;
            foreach (CartView gr in grid)
            {
                card[idx] = new CartViewModel();
                gr.setViewModel(card[idx++]);
                gr.onSelect += new OnSelectEvent(this.OnSelect);
            }

            gameViewModel.setGrid(grid, card);
            gameViewModel.nactiKarty("", true);
        }

        void OnSelect(CartViewModel cart)
        {
            _gameViewModel.SelectCard(cart);
            if (_gameViewModel.isWin)
            {
                string vitez = "";
                if (_gameViewModel.Winner != null)
                {
                    vitez = "Vítězí: " + _gameViewModel.Winner.Text;
                }
                else
                {
                    vitez = "Remíza";
                }

                DisplayAlert("Konec hry", vitez, "Ok");
                this.Navigation.PopAsync();
            }
        }

        void KeyDown(KeyModelEvent key)
        {
            try
            {
                _gameViewModel.KeyPad(key.KeyPad);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        bool endGame = false;
        protected override bool OnBackButtonPressed()
        {
            Task<bool> action = DisplayAlert("Konec hry", "Chcete ukončit hru?", "Ano", "Ne");
            action.ContinueWith(task =>
             {
                 if (task.Result == true)
                 {
                     endGame = true;
                 }
             });

            return false;
        }
    }
}
