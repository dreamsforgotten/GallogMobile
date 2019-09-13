using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("resources")]
    class Resources : ApiQueryable
    {
        public object[] resources { get; set; }
    }

}
