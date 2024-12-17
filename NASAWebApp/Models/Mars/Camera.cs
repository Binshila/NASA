using System.Text.Json.Serialization;

namespace NASAWebApp.Models.Mars
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("rover_id")]
        public int RoverId { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}
