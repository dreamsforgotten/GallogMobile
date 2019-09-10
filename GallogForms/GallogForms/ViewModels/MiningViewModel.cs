using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class MiningViewModel : BaseViewModel
    {
        public MiningViewModel()
        {
            Title = "Mining";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/mining/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}