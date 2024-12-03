
using System.Text.Json.Serialization;

namespace NASAWebApp.Models.DONKI
{
    public class CME
    {
        [JsonPropertyName("activityID")]
        public string ActivityID { get; set; }

        [JsonPropertyName("catalog")]
        public string Catalog { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        [JsonPropertyName("instruments")]
        public List<Instrument> Instruments { get; set; }

        [JsonPropertyName("sourceLocation")]
        public string SourceLocation { get; set; }

        [JsonPropertyName("activeRegionNum")]
        public int? ActiveRegionNum { get; set; }

        [JsonPropertyName("note")]
        public string Note { get; set; }

        [JsonPropertyName("submissionTime")]
        public string SubmissionTime { get; set; }

        [JsonPropertyName("versionId")]
        public int VersionId { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("cmeAnalyses")]
        public List<CMEAnalysis> CMEAnalyses { get; set; }

        [JsonPropertyName("linkedEvents")]
        public object LinkedEvents { get; set; }
    }
}




namespace NASAWebApp.Models.DONKI
{
    public class Instrument
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}



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


namespace NASAWebApp.Models.DONKI
{
    public class Enlil
    {
        [JsonPropertyName("modelCompletionTime")]
        public string ModelCompletionTime { get; set; }

        [JsonPropertyName("au")]
        public double Au { get; set; }

        [JsonPropertyName("estimatedShockArrivalTime")]
        public object EstimatedShockArrivalTime { get; set; }

        [JsonPropertyName("estimatedDuration")]
        public object EstimatedDuration { get; set; }

        [JsonPropertyName("rmin_re")]
        public object RminRe { get; set; }

        [JsonPropertyName("kp_18")]
        public object Kp18 { get; set; }

        [JsonPropertyName("kp_90")]
        public object Kp90 { get; set; }

        [JsonPropertyName("kp_135")]
        public object Kp135 { get; set; }

        [JsonPropertyName("kp_180")]
        public object Kp180 { get; set; }

        [JsonPropertyName("isEarthGB")]
        public bool IsEarthGB { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("impactList")]
        public List<Impact> ImpactList { get; set; }

        [JsonPropertyName("cmeIDs")]
        public List<string> CmeIDs { get; set; }
    }
}

namespace NASAWebApp.Models.DONKI
{
    public class Impact
    {
        [JsonPropertyName("isGlancingBlow")]
        public bool IsGlancingBlow { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }
    }
}

