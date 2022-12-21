using System;
using System.Collections.ObjectModel;
using System.Diagnostics;


using PexesoTv.Models;
using PexesoTv.Views;

namespace PexesoTv.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "PEXESO";
            Player1 = new Player("Hrač 1");
            Player2 = new Player("Hráč 2");
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "Nová hra", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
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


        Item _selectedGame;
        public Item SelectedGame
        {
            get { return _selectedGame; }
            set { _selectedGame = value; }
        }

        public Command SelectedChangedCommand
        {
            get
            {
                return new Command(async (sender) =>
                {
                    var navigationParameter = new Dictionary<string, object>
                        {
                            { "game", new GameViewModel(_selectedGame, Player1, Player2) }
                        };

                    await Shell.Current.GoToAsync(nameof(GamePage), navigationParameter);
                    //Navigation.PushAsync(new GamePage(new GameViewModel(SelectedGame, Player1, Player2)));
                });
            }
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}