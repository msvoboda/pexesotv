using System;
using System.Threading.Tasks;
using PexesoTv.Common;
using PexesoTv.Components;
using PexesoTv.Game;
using PexesoTv.Models;

namespace PexesoTv.ViewModels
{

    public delegate void OnSelectEvent(CartViewModel cart);

    public class GameViewModel : BaseViewModel
    {
        CartView[] grid;
        CartViewModel[] cart;
        CartViewModel selectCart = null;
        IGameCard imageCard;

        bool[] winKarta = new bool[CartUtils.CartCount/2];
        private int[] karty = new int[CartUtils.CartCount]; // pro losovani
        private int[] index = new int[CartUtils.CartCount/2];// pro losovani
        private ImageSource[] images = new ImageSource[CartUtils.CartCount/2];
        private Player _currentPlayer;
        private int _openCount = 0;

        public Item Item { get; set; }
        public GameViewModel(Item item = null, Player pl1=null, Player pl2=null)
        {
            Title = item?.Text;
            Item = item;
            imageCard = item.Cart;
            Player1 = pl1;
            Player2 = pl2;
            CurrentPlayer = Player1;
        }

        public Player Player1
        {
            get;
            set;
        }

        public Player Player2
        {
            get;
            set;
        }

        public Player Winner
        {
            get;
            set;
        }

        public Player CurrentPlayer
        {
            get { return _currentPlayer;  }
            set
            {
                if (_currentPlayer != null)
                {
                    _currentPlayer.Color = Colors.Black;
                }
                _currentPlayer = value;
                _currentPlayer.Color = Colors.Red;
                OnPropertyChanged(nameof(Player1));
                OnPropertyChanged(nameof(Player2));
            }
        }


        public void setGrid(CartView[] set, CartViewModel[] card)
        {
            grid = set;
            cart = card;
        }

        public void nactiKarty(string cards, bool losovani = true)
        {
            if (losovani)
            {
                Losovani();
            }
            else
            {
                for (int i = 0; i < CartUtils.CartCount; i++)
                {
                    grid[i].Image.Source = images[karty[i]];
                }
            }
        }

        private Random rand = new Random();
        public void Losovani()
        {
            for (int i = 0; i < CartUtils.CartCount; i++)
            {
                karty[i] = 0;
            }

            for (int j = 0; j < CartUtils.CartCount/2; j++)
            {
                index[j] = 0;
            }

            for (int i = 0; i < CartUtils.CartCount; i++)
            {
                karty[i] = losovani();
                cart[i].Karta = karty[i].ToString();
                cart[i].KartaId = karty[i];
                cart[i].CartColor = imageCard.CartColor();
                cart[i].Image = imageCard.Get(karty[i]);
                Console.WriteLine(i.ToString() + "," + karty[i]);

            }
        }

        private int losovani()
        {
            int losovane;

            losovane = rand.Next(CartUtils.CartCount/2);
            if (index[losovane] < 2)
                index[losovane]++;
            else
                losovane = losovani();

            return losovane;
        }

        CartViewModel show1 = null;
        CartViewModel show2 = null;
        public void SelectCard(CartViewModel cart)
        {
            if (winKarta[cart.KartaId] == true)
                return;

            if (show1 == null)
            {
                show1 = cart;
            }
            else if (show2 == null && show1 != cart)
            {
                show2 = cart;
            }
            else
            {
                return;
            }

            cart.ShowCart();

            if (show1 != null && show2 != null)
            {
                if (show1.KartaId == show2.KartaId)
                {
                    winKarta[show1.KartaId] = true;
                    _openCount++;
                    if (_openCount >= CartUtils.CartCount/2)
                    {
                        GameWin();
                    }

                    CurrentPlayer.Score++;
                    show1 = null;
                    show2 = null;
                    //CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
                    OnPropertyChanged(nameof(Player1));
                    OnPropertyChanged(nameof(Player2));
                }
                else
                {
                    Task t = new Task(() =>
                    {
                        System.Threading.Thread.Sleep(1500);
                        show1.HideCart();
                        show2.HideCart();
                        show1 = null;
                        show2 = null;
                        CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
                        //OnPropertyChanged(nameof(CurrentPlayer));
                    });
                    t.Start();
                }
            }

        }

        bool _winGame = false;
        private void GameWin()
        {
            Winner = Player1.Score > Player2.Score ? Player1 : Player2;
            if (Player1.Score == Player2.Score)
            {
                Winner = null;
            }
            _winGame = true;
        }


        public bool isWin
        {
            get 
            {
                return _winGame;
            }
        }


        int selectIndex = 0;

        [Obsolete]
        public void KeyPad(KeyPad key)
        {
            if (selectCart == null)
            {
                selectCart = cart[selectIndex];
                selectCart.IsSelected = true;
            }
            else
            {
                selectCart.IsSelected = false;
                if (key == Common.KeyPad.RIGHT)
                {
                    selectIndex++;
                    if (selectIndex >= CartUtils.CartCount)
                        selectIndex = 0;

                    selectCart = cart[selectIndex];

                }
                else if (key == Common.KeyPad.LEFT)
                {
                    selectIndex--;
                    if (selectIndex < 0)
                        selectIndex = CartUtils.CartCount-1;
                    selectCart = cart[selectIndex];
                }
                else if (key == Common.KeyPad.UP)
                {                 
                    if (selectIndex - CartUtils.Columns >= 0)
                        selectIndex -= CartUtils.Columns;
                    selectCart = cart[selectIndex];
                }
                else if (key == Common.KeyPad.DOWN)
                {
                    if (selectIndex + CartUtils.Columns <= CartUtils.CartCount)
                        selectIndex += CartUtils.Columns;

                    selectCart = cart[selectIndex];
                }
                else if (key == Common.KeyPad.ENTER)
                {
                    Device.BeginInvokeOnMainThread(() => 
                    {
                        try
                        {
                            SelectCard(selectCart);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    });                 
                    return;
                }

                selectCart.IsSelected = true;
            }

        }
    }
}

