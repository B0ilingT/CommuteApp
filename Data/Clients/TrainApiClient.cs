using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using System.Collections.Generic;
using CommuteApp.Data.Interfaces;
using CommuteApp.Core.Models.Stations;
using CommuteApp.Core.Models.Train;

namespace CommuteApp.Data.Clients
{
    public class TrainApiClient : ITrainApiClient
    {
        private readonly HttpClient _httpClient;

        public TrainApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Train>> GetTrainsAsync()
        {
            var response = await _httpClient.GetAsync("trains");
            response.EnsureSuccessStatusCode();
            var bikes = await response.Content.ReadFromJsonAsync<List<Train>>();
            return bikes ?? new List<Train>();
        }

        public async Task<List<TrainStation>> GetTrainStationsAsync()
        {
            var response = await _httpClient.GetAsync("stations");
            response.EnsureSuccessStatusCode();
            var bikeStations = await response.Content.ReadFromJsonAsync<List<TrainStation>>();
            return bikeStations ?? new List<TrainStation>();
        }
    }
}
