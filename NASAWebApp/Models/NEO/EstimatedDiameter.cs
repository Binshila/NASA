
using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NEO
{
    public class EstimatedDiameter
    {
        [JsonPropertyName("kilometers")]
        public DiameterUnit Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public DiameterUnit Meters { get; set; }

        [JsonPropertyName("miles")]
        public DiameterUnit Miles { get; set; }

        [JsonPropertyName("feet")]
        public DiameterUnit Feet { get; set; }
    }
}
