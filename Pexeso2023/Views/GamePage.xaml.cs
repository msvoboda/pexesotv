using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PexesoTv.Common;
using PexesoTv.Components;
using PexesoTv.Models;
using PexesoTv.ViewModels;
namespace PexesoTv.Views
{
    [QueryProperty(nameof(GameViewModel), "game")]
    public partial class GamePage : ContentPage, IQueryAttributable
    {
        private Image m_deck = null;
        private CartView[] grid = new CartView[CartUtils.CartCount];
        private CartViewModel[] card = new CartViewModel[CartUtils.CartCount];
        GameViewModel _gameViewModel;

        public GamePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<KeyModelEvent>(this, "KeyDown", this.KeyDown);

            // A 
            grid[0] = pictureCartA1;
            grid[1] = pictureCartA2;
            grid[2] = pictureCartA3;
            grid[3] = pictureCartA4;
            grid[4] = pictureCartA5;
            grid[5] = pictureCartA6;
            // B 
            grid[6] = pictureCartB1;
            grid[7] = pictureCartB2;
            grid[8] = pictureCartB3;
            grid[9] = pictureCartB4;
            grid[10] = pictureCartB5;
            grid[11] = pictureCartB6;
            // C
            grid[12] = pictureCartC1;
            grid[13] = pictureCartC2;
            grid[14] = pictureCartC3;
            grid[15] = pictureCartC4;
            grid[16] = pictureCartC5;
            grid[17] = pictureCartC6;
            // D
            grid[18] = pictureCartD1;
            grid[19] = pictureCartD2;
            grid[20] = pictureCartD3;
            grid[21] = pictureCartD4;
            grid[22] = pictureCartD5;
            grid[23] = pictureCartD6;
            // E
            grid[24] = pictureCartE1;
            grid[25] = pictureCartE2;
            grid[26] = pictureCartE3;
            grid[27] = pictureCartE4;
            grid[28] = pictureCartE5;
            grid[29] = pictureCartE6;   

            // F
            grid[30] = pictureCartF1;
            grid[31] = pictureCartF2;
            grid[32] = pictureCartF3;
            grid[33] = pictureCartF4;
            grid[34] = pictureCartF5;
            grid[35] = pictureCartF6;

            int idx = 0;
            foreach (CartView gr in grid)
            {
                card[idx] = new CartViewModel();
                gr.setViewModel(card[idx++]);
                gr.onSelect += new OnSelectEvent(this.OnSelect);
            }

        }

        public void setGameContext(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            BindingContext = gameViewModel;
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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            setGameContext((GameViewModel)query["game"]);
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            this.InvalidateMeasure();
        }
    }
}
