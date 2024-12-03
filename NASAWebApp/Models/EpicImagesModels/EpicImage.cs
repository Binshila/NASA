using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EpicImagesModels
{
    public class EpicImage
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("centroid_coordinates")]
        public CentroidCoordinates CentroidCoordinates { get; set; }

        [JsonPropertyName("dscovr_j2000_position")]
        public J2000Position DscovrJ2000Position { get; set; }

        [JsonPropertyName("lunar_j2000_position")]
        public J2000Position LunarJ2000Position { get; set; }

        [JsonPropertyName("sun_j2000_position")]
        public J2000Position SunJ2000Position { get; set; }

        [JsonPropertyName("attitude_quaternions")]
        public AttitudeQuaternions AttitudeQuaternions { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("coords")]
        public Coords Coords { get; set; }
    }

}

