using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        public StoresViewModel()
        {
            Title = "Stores";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/stores/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}