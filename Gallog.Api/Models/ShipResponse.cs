using System.ComponentModel;
using System.Runtime.CompilerServices;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("ships")]
    public class ShipResponse : ApiQueryable
    {
        public Ship ship { get; set; }
    }

    public class Ship : INotifyPropertyChanged
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
        public string image { get; set; }
        public string value { get; set; }
        public int scu { get; set; }
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
        public shipmatrix shipmatrix { get; set; }
    }

    public class shipmatrix
    {
        public string length { get; set; }
        public string beam { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public int cargo { get; set; }
        public string focus { get; set; }
        public string type { get; set; }
        public string mass { get; set; }
        public string min_crew { get; set; }
        public string max_crew { get; set; }
        public string scm_speed { get; set; }
        public string afterburner_speed { get; set; }
        public string pitch_max { get; set; }
        public string yaw_max { get; set; }
        public string roll_max { get; set; }
        public string xaxis_acceleration { get; set; }
        public string yaxis_acceleration { get; set; }
        public string zaxis_acceleration { get; set; }
    }

}
