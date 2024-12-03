using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EarthAssetModels
{
    public class Resource
    {
        [JsonPropertyName("dataset")]
        public string Dataset { get; set; }

        [JsonPropertyName("planet")]
        public string Planet { get; set; }
    }

}
