using Gallog.Api.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallog.Api.Models
{
    [ApiPath("login")]
    public class LoginResult
    {
        public string message { get; set; }
        public string response { get; set; }
        public string jwt { get; set; }
    }

}
