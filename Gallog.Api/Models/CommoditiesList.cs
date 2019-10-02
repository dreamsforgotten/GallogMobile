using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("commodities")]

    public class CommoditiesList : ApiQueryable
    {
        public Commodity[] commodities { get; set; }
    }

    public class Commodity1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string slug { get; set; }
        public int typeId { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
    }
}
