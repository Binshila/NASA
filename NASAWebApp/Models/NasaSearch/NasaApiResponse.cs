using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NasaSearch
{
    public class NasaApiResponse
    {
        [JsonPropertyName("collection")]
        public NasaCollection Collection { get; set; }
    }

}
