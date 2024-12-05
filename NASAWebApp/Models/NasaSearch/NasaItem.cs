using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NasaSearch
{
    public class NasaItem
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("data")]
        public List<NasaImageData> Data { get; set; }

        [JsonPropertyName("links")]
        public List<NasaImageLink> Links { get; set; }
    }

}
