using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using System.Collections.Generic;
using CommuteApp.Data.Interfaces;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;

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
            var response = await _httpClient.GetAsync("bikes");
            response.EnsureSuccessStatusCode();
            var bikes = await response.Content.ReadFromJsonAsync<List<Bike>>();
            return bikes ?? new List<Bike>();
        }

        public async Task<List<BikeStation>> GetBikeStationsAsync()
        {
            var response = await _httpClient.GetAsync("stations");
            response.EnsureSuccessStatusCode();
            var bikeStations = await response.Content.ReadFromJsonAsync<List<BikeStation>>();
            return bikeStations ?? new List<BikeStation>();
        }
    }
}
