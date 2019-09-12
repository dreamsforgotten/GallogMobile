using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("tradeports")]
    public class Tradeport
    {
        public string message { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string uri { get; set; }
        public Commodities commodities { get; set; }
    }

    public class Commodities
    {
        public Commodity _19 { get; set; }
        public Commodity _20 { get; set; }
        public Commodity _21 { get; set; }
        public Commodity _23 { get; set; }
        public Commodity _17 { get; set; }
        public Commodity _3 { get; set; }
        public Commodity _18 { get; set; }
        public Commodity _4 { get; set; }
        public Commodity _5 { get; set; }
        public Commodity _6 { get; set; }
        public Commodity _7 { get; set; }
        public Commodity _8 { get; set; }
        public Commodity _9 { get; set; }
        public Commodity _24 { get; set; }
        public Commodity _10 { get; set; }
        public Commodity _11 { get; set; }
        public Commodity _12 { get; set; }
        public Commodity _13 { get; set; }
        public Commodity _14 { get; set; }
        public Commodity _15 { get; set; }
        public Commodity _16 { get; set; }
        public Commodity _1 { get; set; }
        public Commodity _2 { get; set; }
    }

    public class Commodity
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _20
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _21
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public float sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _23
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public float sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _17
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _3
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public float sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _18
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _4
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _5
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _6
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _7
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _8
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _9
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _24
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _10
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _11
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public float sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _12
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public float sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _13
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _14
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _15
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _16
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public float sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _1
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public float buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

    public class _2
    {
        public int id { get; set; }
        public int tid { get; set; }
        public string name { get; set; }
        public int buy { get; set; }
        public int sell { get; set; }
        public string timestamp { get; set; }
    }

}
