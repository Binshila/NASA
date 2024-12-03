namespace NASAWebApp.Models.NasaSearch
{
    using System.Text.Json.Serialization;

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

    public class NasaImageLink
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("rel")]
        public string Rel { get; set; }

        [JsonPropertyName("render")]
        public string Render { get; set; }
    }

    public class NasaItem
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("data")]
        public List<NasaImageData> Data { get; set; }

        [JsonPropertyName("links")]
        public List<NasaImageLink> Links { get; set; }
    }

    public class NasaCollection
    {
        [JsonPropertyName("items")]
        public List<NasaItem> Items { get; set; }
    }

    public class NasaApiResponse
    {
        [JsonPropertyName("collection")]
        public NasaCollection Collection { get; set; }
    }

}
