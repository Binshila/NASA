using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EpicImagesModels
{
    public class Coords
    {
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
    }

}
