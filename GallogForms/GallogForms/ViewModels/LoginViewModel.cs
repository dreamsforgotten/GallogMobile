﻿using System;
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
using System.Threading.Tasks;
using System.Diagnostics;

namespace GallogForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private GallogClient _gallogClient;
        private string Username;
        private string Password;
        
        public Command LoginCommand { get; set; }
        public LoginViewModel()
        {
            Title = "Login";
            
            _gallogClient = new GallogClient();
            LoginCommand = new Command(async () => await ExecuteLoginCommand(), () => !IsBusy);



        }

        async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                LoginCommand.ChangeCanExecute();
                {

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    
    }
}
