using Gallog.Api.Attributes;
using Newtonsoft.Json;
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
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        public string rsi_id { get; set; }
        public string img { get; set; }
        public string mfr { get; set; }
        public string flyable { get; set; }
        public string scu { get; set; }
        public string value { get; set; }
    }

}
