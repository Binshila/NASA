
using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NEO
{
    public class Links
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("prev")]
        public string Prev { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
