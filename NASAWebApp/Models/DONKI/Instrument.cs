using System.Text.Json.Serialization;

namespace NASAWebApp.Models.DONKI
{
    public class Instrument
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}
