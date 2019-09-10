using GallogForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home", Image="home.png"},
                new HomeMenuItem {Id = MenuItemType.Hangar, Title="Hangar", Image="flight_takeoff_b.png"},
                new HomeMenuItem {Id = MenuItemType.MyOrg, Title="My Org", Image="account_b.png"},
                new HomeMenuItem {Id = MenuItemType.Missions, Title="Missions", Image="missions.png"},
                new HomeMenuItem {Id = MenuItemType.Trade, Title="Trading", Image="trading.png"},
                new HomeMenuItem {Id = MenuItemType.TradePorts, Title="Tradeports", Image="tradeports.png"},
                new HomeMenuItem {Id = MenuItemType.Commodities, Title="Commodoties", Image="commadaties.png"},
                new HomeMenuItem {Id = MenuItemType.Commodities, Title="mining", Image="mining.png"},

                new HomeMenuItem {Id = MenuItemType.Search, Title="Search", Image="search.png"},
                new HomeMenuItem {Id = MenuItemType.Ships, Title="Ships", Image="ships.png"},
                new HomeMenuItem {Id = MenuItemType.Components, Title="Components", Image="components.png"},
                new HomeMenuItem {Id = MenuItemType.Stores, Title="Stores", Image="store_w.png"}

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}