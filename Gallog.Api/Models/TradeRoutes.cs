using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("trade/routes")]

    public class TradeRoutes : ApiQueryable
    {
        public Commodity[] commodities { get; set; }
    }

    public class Commodity : ApiQueryable
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public string tradeport { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }
        public string uri { get; set; }
        public string timestamp { get; set; }
        public string tradeport_source { get; set; }
        public int tid_source { get; set; }
        public int margin { get; set; }
        public double profit { get; set; }
        public int units { get; set; }
        public double total { get; set; }
        public string code { get; set; }
    }



}

