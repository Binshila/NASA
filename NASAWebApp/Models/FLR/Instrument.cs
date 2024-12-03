using System.Text.Json.Serialization;

namespace NASAWebApp.Models.FLR
{
    public class Instrument
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}
