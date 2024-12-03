using System.Text.Json.Serialization;

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


}
