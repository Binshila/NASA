
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace NASAWebApp.Models.NEO
{
    public class NeoResponse
    {
        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, List<NearEarthObject>>? NearEarthObjects { get; set; }
    }
}
