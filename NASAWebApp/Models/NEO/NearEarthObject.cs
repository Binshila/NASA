
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace NASAWebApp.Models.NEO
{
    public class NearEarthObject
    {
        [JsonPropertyName("links")]
        public NeoLinks Links { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        [JsonPropertyName("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }
}
