using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EpicImagesModels
{
    public class CentroidCoordinates
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }
}
