using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class TradingViewModel : BaseViewModel
    {
        public TradingViewModel()
        {
            Title = "Trading";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/trading/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}