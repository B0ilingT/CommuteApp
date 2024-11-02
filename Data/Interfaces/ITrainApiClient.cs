using System.Collections.Generic;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using CommuteApp.Core.Models.Bikes;

namespace CommuteApp.Data.Interfaces
{
    public interface ITrainApiClient
    {
        Task<List<Train>> GetTrainsAsync();
    }
}
