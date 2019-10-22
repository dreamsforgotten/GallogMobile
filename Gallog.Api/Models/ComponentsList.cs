using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{
    [ApiPath("components")]
    public class ComponentsList : ApiQueryable
    {
        public Componenttype[] componentTypes { get; set; }
    

        public class Componenttype
        {
            public string id { get; set; }
            public string categoryId { get; set; }
            public string name { get; set; }
            public string uri { get; set; }
            public string icon { get; set; }
            public string type { get; set; }
        }

    }
}

