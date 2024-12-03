namespace NASAWebApp.Models.FLR
{
    using System.Text.Json.Serialization;
    using System.Collections.Generic;

    public class Instrument
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }

    public class LinkedEvent
    {
        [JsonPropertyName("activityID")]
        public string ActivityID { get; set; }
    }

    public class SolarFlare
    {
        [JsonPropertyName("flrID")]
        public string FlrID { get; set; }

        [JsonPropertyName("catalog")]
        public string Catalog { get; set; }

        [JsonPropertyName("instruments")]
        public List<Instrument> Instruments { get; set; }

        [JsonPropertyName("beginTime")]
        public string BeginTime { get; set; }

        [JsonPropertyName("peakTime")]
        public string PeakTime { get; set; }

        [JsonPropertyName("endTime")]
        public string EndTime { get; set; }

        [JsonPropertyName("classType")]
        public string ClassType { get; set; }

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

        [JsonPropertyName("linkedEvents")]
        public List<LinkedEvent> LinkedEvents { get; set; }
    }

}
