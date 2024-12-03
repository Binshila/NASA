namespace NASAWebApp.Models.EpicImagesModels
{
    using System.Text.Json.Serialization;

    public class CentroidCoordinates
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }

    public class J2000Position
    {
        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }

        [JsonPropertyName("z")]
        public double Z { get; set; }
    }

    public class AttitudeQuaternions
    {
        [JsonPropertyName("q0")]
        public double Q0 { get; set; }

        [JsonPropertyName("q1")]
        public double Q1 { get; set; }

        [JsonPropertyName("q2")]
        public double Q2 { get; set; }

        [JsonPropertyName("q3")]
        public double Q3 { get; set; }
    }

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
