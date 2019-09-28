using System;
using System.Collections.Generic;
using System.Text;

namespace GallogForms.Models
{
    public enum MenuItemType
    {
        Home,
        Login,
        Hangar,
        MyOrg,
        Missions,
        Trade,
        TradePorts,
        Commodities,
        Mining,
        Search,
        Ships,
        Components,
        Stores,
        Splash
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string Image { get; set; }
    }
}
