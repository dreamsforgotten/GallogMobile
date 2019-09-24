using Gallog.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallog.Api.Models
{
    [ApiPath("ships")]
    public class ShipList : ApiQueryable
    {
        public ShipCatalog[] ships { get; set; }
    }
    public class ShipCatalog
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public int rsi_id { get; set; }
        public string img { get; set; }
        public string mfr { get; set; }
        public string flyable { get; set; }
        public string scu { get; set; }
        public string value { get; set; }
    }


}
