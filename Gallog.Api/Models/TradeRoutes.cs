using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Gallog.Api.Attributes;
using Xamarin.Forms;

namespace Gallog.Api.Models
{
    [ApiPath("trade/routes")]

    public class TradeRoutes : ApiQueryable
    {
        public string ship { get; set; }
        public int scu { get; set; }
        public int uec { get; set; }
        public object[] commodities { get; set; }
        public object[] results { get; set; }
    }
}

