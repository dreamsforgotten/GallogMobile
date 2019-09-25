using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("trade/routes")]

    public class TradeRoutes : ApiQueryable
    {
            public int scu { get; set; }
            public int uec { get; set; }
            public object[] commodities { get; set; }
            public object[] results { get; set; }
    }
}

