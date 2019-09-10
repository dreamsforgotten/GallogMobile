using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class ShipsViewModel : BaseViewModel
    {
        public ShipsViewModel()
        {
            Title = "Ships";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/ships/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}