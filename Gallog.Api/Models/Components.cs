using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("components")]



    public class Components : ApiQueryable
    {
        public string message { get; set; }
        public Ship ship { get; set; }
    }
}

    