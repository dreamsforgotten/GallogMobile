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
    public class MissionsViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<TradeportCatalog> Items { get; set; }
        public Command RefreshItemsCommand { get; set; }
        public MissionsViewModel()
        {
            Title = "Missions";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/stores/")));
        }

        public ICommand OpenWebCommand { get; }

    }
}