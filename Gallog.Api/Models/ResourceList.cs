using Gallog.Api.Attributes;

namespace Gallog.Api.Models
{

    [ApiPath("resources")]
    public class ResourceList : ApiQueryable
    {
        public Resource[] resources { get; set; }
    }

    [ApiPath("resources")]
    public class ResourceResponse : ApiQueryable
    {
        public Resource resource { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string stub { get; set; }
        public int typeId { get; set; }
        public string type { get; set; }
        public float sell { get; set; }
        public string icon { get; set; }
    }

}
