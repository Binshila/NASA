﻿using System.Text.Json.Serialization;

namespace NASAWebApp.Models
{

    public class Links
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("prev")]
        public string Prev { get; set; }

        [JsonPropertyName("self")]
        public string Self { get; set; }
    }

    public class Diameter
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonPropertyName("kilometers")]
        public Diameter Kilometers { get; set; }

        [JsonPropertyName("meters")]
        public Diameter Meters { get; set; }

        [JsonPropertyName("miles")]
        public Diameter Miles { get; set; }

        [JsonPropertyName("feet")]
        public Diameter Feet { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonPropertyName("kilometers_per_second")]
        public string KilometersPerSecond { get; set; }

        [JsonPropertyName("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }

        [JsonPropertyName("miles_per_hour")]
        public string MilesPerHour { get; set; }
    }

    public class MissDistance
    {
        [JsonPropertyName("astronomical")]
        public string Astronomical { get; set; }

        [JsonPropertyName("lunar")]
        public string Lunar { get; set; }

        [JsonPropertyName("kilometers")]
        public string Kilometers { get; set; }

        [JsonPropertyName("miles")]
        public string Miles { get; set; }
    }

    public class CloseApproachData
    {
        [JsonPropertyName("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonPropertyName("close_approach_date_full")]
        public string CloseApproachDateFull { get; set; }

        [JsonPropertyName("epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonPropertyName("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }

        [JsonPropertyName("miss_distance")]
        public MissDistance MissDistance { get; set; }

        [JsonPropertyName("orbiting_body")]
        public string OrbitingBody { get; set; }
    }

    public class NearEarthObject
    {
        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("neo_reference_id")]
        public string NeoReferenceId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nasa_jpl_url")]
        public string NasaJplUrl { get; set; }

        [JsonPropertyName("absolute_magnitude_h")]
        public double AbsoluteMagnitudeH { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }

        [JsonPropertyName("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonPropertyName("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        [JsonPropertyName("is_sentry_object")]
        public bool IsSentryObject { get; set; }
    }

    public class NEOFeedResponse
    {
        [JsonPropertyName("links")]
        public Links Links { get; set; }

        [JsonPropertyName("element_count")]
        public int ElementCount { get; set; }

        [JsonPropertyName("near_earth_objects")]
        public Dictionary<string, List<NearEarthObject>> NearEarthObjects { get; set; }
    }
}
