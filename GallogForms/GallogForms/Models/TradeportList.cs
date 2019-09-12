﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GallogForms.Models
{

    public class TradeportList
    {
        public string message { get; set; }
        public TradeportCatalog[] tradeports { get; set; }
    }

    public class TradeportCatalog
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string slug { get; set; }
        public string sysname { get; set; }
        public string objname { get; set; }
        public int objectId { get; set; }
        public string objicon { get; set; }
    }

}
