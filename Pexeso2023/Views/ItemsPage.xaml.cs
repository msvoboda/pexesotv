using PexesoTv.Models;
using PexesoTv.Views;
using PexesoTv.ViewModels;

namespace PexesoTv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            MessagingCenter.Subscribe<KeyModelEvent>(this, "KeyDown", this.KeyDown);
        }


        async void KeyDown(KeyModelEvent key)
        {
            /*
            if (key.DisplayLabel == "1")
            {
                await Navigation.PushAsync(new GamePage(new GameViewModel(viewModel.Items[0], viewModel.Player1, viewModel.Player2)));
            }
            else if (key.DisplayLabel == "2")
            {
                await Navigation.PushAsync(new GamePage(new GameViewModel(viewModel.Items[1], viewModel.Player1, viewModel.Player2)));
            }
            else if (key.DisplayLabel == "3")
            {
                await Navigation.PushAsync(new GamePage(new GameViewModel(viewModel.Items[2], viewModel.Player1, viewModel.Player2)));
            }
            else if (key.DisplayLabel == "4")
            {
                await Navigation.PushAsync(new GamePage(new GameViewModel(viewModel.Items[3], viewModel.Player1, viewModel.Player2)));
            }*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}