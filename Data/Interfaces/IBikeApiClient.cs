using System.Collections.Generic;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using CommuteApp.Core.Models.Bikes;

namespace CommuteApp.Data.Interfaces
{
    public interface IBikeApiClient
    {
        Task<List<Bike>> GetBikesAsync();
    }
}
