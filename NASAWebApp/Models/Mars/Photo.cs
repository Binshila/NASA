using System.Text.Json.Serialization;

namespace NASAWebApp.Models.Mars
{
    public class Photo
    {
        public int Id { get; set; }
        public int Sol { get; set; }
        public Camera Camera { get; set; }
        [JsonPropertyName("img_src")]
        public string ImgSrc { get; set; }
        [JsonPropertyName("earth_date")]
        public string EarthDate { get; set; }
        public Rover Rover { get; set; }
    }
}
