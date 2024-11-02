using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommuteApp.Data.DTOs
{
    public class BikeApiResponseDto
    {
        [JsonPropertyName("last_updated")]
        public long LastUpdated { get; set; }

        [JsonPropertyName("ttl")]
        public int Ttl { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public BikeDataDto Data { get; set; } = new BikeDataDto();
    }

    public class BikeDataDto
    {
        [JsonPropertyName("bikes")]
        public List<BikeDto> Bikes { get; set; } = new List<BikeDto>();
    }
    public class BikeDto
    {
        [JsonPropertyName("bike_id")]
        public string? BikeId { get; set; }

        [JsonPropertyName("station_id")]
        public string? StationId { get; set; }

        [JsonPropertyName("vehicle_type_id")]
        public string? VehicleTypeId { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("is_reserved")]
        public bool? IsReserved { get; set; }

        [JsonPropertyName("is_disabled")]
        public bool? IsDisabled { get; set; }

        [JsonPropertyName("current_range_meters")]
        public int? CurrentRange { get; set; }
    }
}
