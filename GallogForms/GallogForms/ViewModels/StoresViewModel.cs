using Gallog.Api;
using Gallog.Api.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<TradeportCatalog> Items { get; set; }
        public Command RefreshItemsCommand { get; set; }
        public StoresViewModel()
        {
            Title = "Stores";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/stores/")));
        }

        public ICommand OpenWebCommand { get; }
        
    }
}