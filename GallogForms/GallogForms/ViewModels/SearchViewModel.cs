using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        public SearchViewModel()
        {
            Title = "Search";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/search/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}