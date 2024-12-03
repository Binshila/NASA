using System.Text.Json.Serialization;

namespace NASAWebApp.Models.DONKI
{
    public class CMEAnalysis
    {
        [JsonPropertyName("isMostAccurate")]
        public bool IsMostAccurate { get; set; }

        [JsonPropertyName("time21_5")]
        public string Time21_5 { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("halfAngle")]
        public double HalfAngle { get; set; }

        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("featureCode")]
        public string FeatureCode { get; set; }

        [JsonPropertyName("imageType")]
        public string ImageType { get; set; }

        [JsonPropertyName("measurementTechnique")]
        public string MeasurementTechnique { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("levelOfData")]
        public int LevelOfData { get; set; }

        [JsonPropertyName("tilt")]
        public object Tilt { get; set; }

        [JsonPropertyName("minorHalfWidth")]
        public object MinorHalfWidth { get; set; }

        [JsonPropertyName("speedMeasuredAtHeight")]
        public object SpeedMeasuredAtHeight { get; set; }

        [JsonPropertyName("submissionTime")]
        public string SubmissionTime { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("enlilList")]
        public List<Enlil> EnlilList { get; set; }
    }
}


