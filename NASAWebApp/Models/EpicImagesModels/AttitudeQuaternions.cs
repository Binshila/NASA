using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EpicImagesModels
{
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

}
