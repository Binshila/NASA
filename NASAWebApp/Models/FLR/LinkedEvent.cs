using System.Text.Json.Serialization;

namespace NASAWebApp.Models.FLR
{
    public class LinkedEvent
    {
        [JsonPropertyName("activityID")]
        public string ActivityID { get; set; }
    }

}
