﻿using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EarthAssetModels
{
    public class Resource
    {
        [JsonPropertyName("dataset")]
        public string Dataset { get; set; }

        [JsonPropertyName("planet")]
        public string Planet { get; set; }
    }

    public class EarthAsset
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("resource")]
        public Resource Resource { get; set; }

        [JsonPropertyName("service_version")]
        public string ServiceVersion { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}