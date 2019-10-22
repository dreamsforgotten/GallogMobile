using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using GallogForms.Models;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Splash, new NavigationPage(new SplashPage()));
            System.Threading.Thread.Sleep(1000);
            MenuPages.Add((int)MenuItemType.Home, new NavigationPage(new HomePage()));
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Login:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                    case (int)MenuItemType.Hangar:
                        MenuPages.Add(id, new NavigationPage(new HangarPage()));
                        break;
                    case (int)MenuItemType.MyOrg:
                        MenuPages.Add(id, new NavigationPage(new MyOrgPage()));
                        break;
                    case (int)MenuItemType.Missions:
                        MenuPages.Add(id, new NavigationPage(new MissionsPage()));
                        break;
                    case (int)MenuItemType.Trade:
                        MenuPages.Add(id, new NavigationPage(new TradingPage()));
                        break;
                    case (int)MenuItemType.TradePorts:
                        MenuPages.Add(id, new NavigationPage(new TradeportsPage()));
                        break;
                    case (int)MenuItemType.Commodities:
                        MenuPages.Add(id, new NavigationPage(new CommoditiesPage()));
                        break;

                    case (int)MenuItemType.Mining:
                        MenuPages.Add(id, new NavigationPage(new MiningPage()));
                        break;
                    case (int)MenuItemType.Search:
                        MenuPages.Add(id, new NavigationPage(new SearchPage()));
                        break;

                    case (int)MenuItemType.Ships:
                        MenuPages.Add(id, new NavigationPage(new ShipsPage()));
                        break;
                    case (int)MenuItemType.Stores:
                        MenuPages.Add(id, new NavigationPage(new StoresPage()));
                        break;
                    case (int)MenuItemType.Components:
                        MenuPages.Add(id, new NavigationPage(new ComponentsPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                //if (Device.RuntimePlatform == Device.Android)
                //    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}