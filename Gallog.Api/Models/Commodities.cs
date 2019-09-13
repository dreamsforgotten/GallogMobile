using System;
using System.Collections.Generic;
using System.Text;
using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("commodoties")]
    class Commodoties : ApiQueryable
    {
        public object[] commodity { get; set; }
    }

}
