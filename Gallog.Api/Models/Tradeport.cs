using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("tradeports")]
    public class Tradeports : ApiQueryable
    {
        public Tradeport[] tradeports { get; set; }         

    }  

    public class Tradeport
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

