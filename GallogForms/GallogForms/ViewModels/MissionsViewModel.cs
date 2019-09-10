using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class MissionsViewModel : BaseViewModel
    {
        public MissionsViewModel()
        {
            Title = "Missions";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://www.gallog.co/org/missions/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}