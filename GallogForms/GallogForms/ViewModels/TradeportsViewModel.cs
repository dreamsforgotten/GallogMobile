using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradeportsViewModel : BaseViewModel
    {
        public TradeportsViewModel()
        {
            Title = "Tradeports";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/tradeports/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}