using System.Text.Json.Serialization;

namespace NASAWebApp.Models.DONKI
{
    public class Impact
    {
        [JsonPropertyName("isGlancingBlow")]
        public bool IsGlancingBlow { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }
    }
}
