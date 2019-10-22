namespace Gallog.Api.Models
{
    public interface IShipCatalog
    {
        string flyable { get; set; }
        int id { get; set; }
        string img { get; set; }
        string mfr { get; set; }
        string name { get; set; }
        string scu { get; set; }
        string uri { get; set; }
        string value { get; set; }
    }
}