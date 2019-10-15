using GallogForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Gallog.Api;
using Xamarin.Forms.Xaml;
using Gallog.Api.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Gallogforms.ViewModels;
using System.ComponentModel;
using System.Diagnostics;

namespace GallogForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddShipPage : ContentPage
    {


        public AddShipPage()
        {
            InitializeComponent();
            BindingContext = new AddShipViewModel();
        }

        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HangarPage());
        }

    }
}