using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class CommoditiesViewModel : BaseViewModel
    {
        public CommoditiesViewModel()
        {
            Title = "Commodoties";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}