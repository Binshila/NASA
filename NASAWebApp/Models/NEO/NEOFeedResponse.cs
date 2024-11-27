using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NEO
{
    public class NEOFeedResponse
    {
        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, List<NearEarthObject>> NearEarthObjects { get; set; }
    }
}
