using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Gallog.Api;
using Gallog.Api.Models;

using GallogForms.Models;
using GallogForms.Services;
using Gallog.Api.Services;

namespace GallogForms.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> _values = new Dictionary<String, object>();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public T GetProperty<T>([CallerMemberName] string propertyName = "")
        {
            EnsureElement<T>(propertyName);
            return (T)_values[propertyName];
        }

        public void SetProperty<T>(object value, [CallerMemberName] string propertyName = "")
        {
            EnsureElement<T>(propertyName);
            if (_values[propertyName] == value)
            {
                return;
            }
            _values[propertyName] = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EnsureElement<T>(string propertyName)
        {
            if (!_values.ContainsKey(propertyName))
            {
                _values.Add(propertyName, default(T));
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
