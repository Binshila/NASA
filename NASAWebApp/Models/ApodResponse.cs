using System.Text.Json.Serialization;

namespace NASAWebApp.Models
{
    public class ApodResponse
    {
        public string Date { get; set; }
        public string Explanation { get; set; }
        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }

        [JsonPropertyName("service_version")]
        public string ServiceVersion { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
