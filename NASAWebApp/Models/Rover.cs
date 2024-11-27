using System.Text.Json.Serialization;

namespace NASAWebApp.Models
{
    public class Rover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("landing_date")]
        public string LandingDate { get; set; }
        [JsonPropertyName("launch_date")]
        public string LaunchDate { get; set; }
        public string Status { get; set; }
        [JsonPropertyName("max_sol")]
        public int MaxSol { get; set; }
        [JsonPropertyName("max_date")]
        public string MaxDate { get; set; }
        [JsonPropertyName("total_photos")]
        public int TotalPhotos { get; set; }
        public List<Camera> Cameras { get; set; }
    }
}
