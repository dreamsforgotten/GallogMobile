using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Gallog.Api.Models;
using Gallog.Api.Interfaces;
using Gallog.Api.Attributes;
using System.Net.Http;
using System.Collections.ObjectModel;
using Gallog.Api;
using Xamarin.Forms;

namespace GallogForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        public ObservableCollection<LoginResult> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public LoginViewModel()
        {
            Title = "Login";
            Items = new ObservableCollection<LoginResult>();
            _gallogClient = new GallogClient();


        }

    }
}

