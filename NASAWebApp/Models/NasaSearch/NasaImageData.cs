using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NasaSearch
{
    public class NasaImageData
    {
        [JsonPropertyName("center")]
        public string Center { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("photographer")]
        public string Photographer { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("nasa_id")]
        public string NasaId { get; set; }

        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }

        [JsonPropertyName("date_created")]
        public string DateCreated { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }


}
