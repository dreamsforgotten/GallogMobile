using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GallogForms.Models
{
    public class Ships 
    {
        public ShipListView[] shipsview { get; set; }
    }


    public class ShipListView : INotifyPropertyChanged
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
        public string role { get; set; }
        private bool _selectedItem { get; set; }
        public bool SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool _isVisible { get; set; }
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

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

}


