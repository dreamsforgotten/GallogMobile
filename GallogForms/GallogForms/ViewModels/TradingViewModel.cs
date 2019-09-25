using Gallog.Api;
using Gallog.Api.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradingViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<TradeRoutes> Items { get; set; }
        public TradingViewModel()
        {
            Items = new ObservableCollection<TradeRoutes>();

            Title = "Trading";
        }
        
    }
}