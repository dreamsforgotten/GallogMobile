using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("login")]
    public class LoginResult : ApiQueryable
    {
        public string response { get; set; }
        public string jwt { get; set; }
    }

}
