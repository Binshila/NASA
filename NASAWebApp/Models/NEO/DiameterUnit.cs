
using System.Text.Json.Serialization;

namespace NASAWebApp.Models.NEO
{
    public class DiameterUnit
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }
}
