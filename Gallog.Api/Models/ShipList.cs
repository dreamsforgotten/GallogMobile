using Gallog.Api.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gallog.Api.Models
{
    [ApiPath("ships")]
    public class ShipList : ApiQueryable
    {
        public ShipCatalog[] ships { get; set; }
    }
    public class ShipCatalog : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public int rsi_id { get; set; }
        public string img { get; set; }
        public string mfr { get; set; }
        public string flyable { get; set; }
        public string scu { get; set; }
        public string value { get; set; }
        public string bgcolor { get; set; }
        public string color { get; set; }
        public bool _isVisible { get; set; }
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    OnPropertyChanged();
                }
            }
        }
    }


}
