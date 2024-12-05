using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NasaSearch
{
    public class NasaImageLink
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("rel")]
        public string Rel { get; set; }

        [JsonPropertyName("render")]
        public string Render { get; set; }
    }

}
