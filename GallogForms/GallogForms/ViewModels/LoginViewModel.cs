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
using System.Threading.Tasks;
using System.Diagnostics;

namespace GallogForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string _userName = string.Empty;
        public string Username
        {
            get => _userName;
            set
            {
                if (_userName == value)
                    return;
                _userName = value;
                username = _userName;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        string _passWord = string.Empty;
        public string Password
        {
            get => _passWord;
            set
            {
                if (_passWord == value)
                    return;

                _passWord = value;
                password = _passWord;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(DisplayPassword));
            }
        }
        string _jwt = string.Empty;
        public string jwt
        {
            get => _jwt;
            set
            {
                if (_jwt == value)
                    return;

                _jwt = value;
                OnPropertyChanged(nameof(jwt));
                OnPropertyChanged(nameof(DisplayJwt));
            }
        }

        string _username = string.Empty;
        public string username
        {
            get => _username;
            set
            {
                if (_username == value)
                    return;

                _username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        string _password = string.Empty;
        public string password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;

                _password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        string _response = string.Empty;
        public string Response
        {
            get => _response;
            set
            {
                if (_response == value)
                    return;

                _response = value;
                OnPropertyChanged(nameof(Response));
            }
        }

        public string DisplayJwt => $" SuperSecret JWT is: {jwt}";
        public string DisplayName => $" Your username is: {Username}";
        public string DisplayPassword => $" Your Password is: {Password}";
        public string DisplayResponse => $" Server says {Response}";
        public Command LoginCommand { get; set; }

        private GallogClient _gallogClient;



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
                    var responses = await _gallogClient.LoginAsync(username, password);
                    jwt = responses.jwt;
                    Response = responses.message;                   
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
                LoginCommand.ChangeCanExecute();

            }
        }
    }
}

