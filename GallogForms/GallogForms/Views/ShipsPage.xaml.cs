using Gallog.Api.Models;
using GallogForms.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GallogForms.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ShipsPage : ContentPage
    {
        public ShipsPage()
        {
            InitializeComponent();
            BindingContext = new ShipsViewModel();
        }
    }
}