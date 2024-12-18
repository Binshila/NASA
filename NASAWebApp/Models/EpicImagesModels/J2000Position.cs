﻿using System.Text.Json.Serialization;

namespace NASAWebApp.Models.EpicImagesModels
{
    public class J2000Position
    {
        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }

        [JsonPropertyName("z")]
        public double Z { get; set; }
    }
}
