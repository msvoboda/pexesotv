using PexesoTv.Models;
using System;
using System.Collections.Generic;

namespace PexesoTv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.SelectGame, Title="Vyber hru" },
                new HomeMenuItem {Id = MenuItemType.About, Title="O hře" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                //await RootPage.NavigateFromMenu(id);
            };
        }
    }
}