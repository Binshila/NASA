
using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NEO
{
    public class NeoLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
