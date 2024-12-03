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




