using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class MyOrgViewModel : BaseViewModel
    {
        public MyOrgViewModel()
        {
            Title = "MyOrg";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/org/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}