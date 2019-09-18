using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("commodities")]

    public class Commodities : ApiQueryable
    {
            public Commodity[] commodities { get; set; }
        }

        public class Commodity
        {
            public int id { get; set; }
            public string name { get; set; }
            public string uri { get; set; }
            public string slug { get; set; }
            public int typeId { get; set; }
            public string type { get; set; }
            public string icon { get; set; }
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

