using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using System.Collections.Generic;
using CommuteApp.Data.Interfaces;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;
using CommuteApp.Data.DTOs;

namespace CommuteApp.Data.Clients
{
    public class BikeApiClient : IBikeApiClient
    {
        private readonly HttpClient _httpClient;

        public BikeApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Bike>> GetBikesAsync()
        {
            var response = await _httpClient.GetAsync("Greater_Manchester/free_bike_status.json");
            response.EnsureSuccessStatusCode();
            var bikes = await response.Content.ReadFromJsonAsync<BikeApiResponseDto>();
            return MapBikes(bikes.Data.Bikes);
        }

        private List<Bike> MapBikes(List<BikeDto>? bikes)
        {
            List<Bike> parsedBikes = new List<Bike>();
            if (bikes == null)
            {
                return parsedBikes;
            }
            foreach (var bike in bikes)
            {
                parsedBikes.Add(MapBikeInformation(bike));
            }
            return parsedBikes;
        }

        private Bike MapBikeInformation(BikeDto bikeInformation)
        {
            if (bikeInformation.CurrentRange == null || bikeInformation.VehicleTypeId == "beryl_bike")
            {
                var bike = new PedalBike { ID = bikeInformation.BikeId, StationId = bikeInformation.StationId, Latitude = bikeInformation.Lat, Longitude = bikeInformation.Lon};
                return bike;
            } else
            {
                var bike = new ElectricBike
                {
                    ID = bikeInformation.BikeId,
                    StationId = bikeInformation.StationId,
                    CurrentRange = bikeInformation.CurrentRange.Value,
                    Latitude = bikeInformation.Lat,
                    Longitude = bikeInformation.Lon
                };

                return bike;
            }
        }

        public async Task<List<BikeStation>> GetBikeStationsAsync()
        {
            var stationInfoResponse = await _httpClient.GetAsync("Greater_Manchester/station_information.json");
            stationInfoResponse.EnsureSuccessStatusCode();
            var bikeStationResponse = await stationInfoResponse.Content.ReadFromJsonAsync<BikeStationApiResponseDto>();
            return MapBikeStations(bikeStationResponse.Data.Stations);
        }

        private List<BikeStation> MapBikeStations(List<BikeStationInformationDto>? bikeStationsInformation)
        {
            List<BikeStation> parsedStations = new List<BikeStation>();
            if (bikeStationsInformation == null)
            {
                return parsedStations;
            }
            foreach (var bikeStation in bikeStationsInformation)
            {
                parsedStations.Add(MapBikeStationInformation(bikeStation));
            }
            return parsedStations;
        }

        private BikeStation MapBikeStationInformation(BikeStationInformationDto bikeStation)
        {
            var station = new BikeStation
            {
                ID = bikeStation.StationId,
                Name = bikeStation.Name,
                Latitude = bikeStation.Lat,
                Longitude = bikeStation.Lon
            };

            return station;
        }
    }
}
