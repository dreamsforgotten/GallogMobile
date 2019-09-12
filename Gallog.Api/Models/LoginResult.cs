using Gallog.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallog.Api.Models
{
    [ApiPath("login")]
    public class LoginResult : ApiQueryable
    {
        public string response { get; set; }
        public string jwt { get; set; }
    }

}
