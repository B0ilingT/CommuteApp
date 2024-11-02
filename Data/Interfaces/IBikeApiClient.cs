using System.Collections.Generic;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;

namespace CommuteApp.Data.Interfaces
{
    public interface IBikeApiClient
    {
        Task<List<BikeStation>> GetBikeStationsAsync();
        Task<List<Bike>> GetBikesAsync();
    }
}
