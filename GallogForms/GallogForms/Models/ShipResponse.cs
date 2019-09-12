using System;
using System.Collections.Generic;
using System.Text;

namespace GallogForms.Models
{

    public class ShipResponse
    {
        public string message { get; set; }
        public Ship ship { get; set; }
    }

    public class Ship
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string image { get; set; }
        public string value { get; set; }
        public int scu { get; set; }
        public Shipmatrix shipmatrix { get; set; }
    }

    public class Shipmatrix
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
