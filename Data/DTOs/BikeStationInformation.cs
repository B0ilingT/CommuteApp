using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommuteApp.Data.DTOs
{
    public class BikeStationApiResponseDto
    {
        [JsonPropertyName("last_updated")]
        public long LastUpdated { get; set; }

        [JsonPropertyName("ttl")]
        public int Ttl { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public BikeStationDataDto Data { get; set; } = new BikeStationDataDto();
    }

    public class BikeStationDataDto
    {
        [JsonPropertyName("stations")]
        public List<BikeStationInformationDto> Stations { get; set; } = new List<BikeStationInformationDto>();
    }

    public class BikeStationInformationDto
    {
        [JsonPropertyName("station_id")]
        public string StationId { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("rental_uris")]
        public RentalUris RentalUris { get; set; } = new RentalUris();
    }

    public class RentalUris
    {
        [JsonPropertyName("android")]
        public string Android { get; set; } = string.Empty;

        [JsonPropertyName("ios")]
        public string IOS { get; set; } = string.Empty;
    }

}
