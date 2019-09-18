using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("missions")]

    public class Missions : ApiQueryable
    {
            public Mission[] missions { get; set; }
        

        public class Mission
        {
            public int id { get; set; }
            public string name { get; set; }
            public int orgId { get; set; }
            public string orgSpectrumId { get; set; }
            public string timeStart { get; set; }
            public object timeEnd { get; set; }
        }



    }
}

