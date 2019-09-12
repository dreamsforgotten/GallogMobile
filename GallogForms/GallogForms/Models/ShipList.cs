﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GallogForms.Models
{

    public class ShipList
    {
        public string message { get; set; }
        public Ship[] ships { get; set; }
    }

    public class Ship
    {
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string rsi_id { get; set; }
        public string img { get; set; }
        public string mfr { get; set; }
        public string flyable { get; set; }
        public string scu { get; set; }
        public string value { get; set; }
    }

}