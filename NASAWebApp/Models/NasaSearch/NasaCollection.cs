using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NasaSearch
{
    public class NasaCollection
    {
        [JsonPropertyName("items")]
        public List<NasaItem> Items { get; set; }
    }

}
