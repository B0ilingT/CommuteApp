using System.Collections.Generic;
using System.Threading.Tasks;
using CommuteApp.Core.Models;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;
using CommuteApp.Core.Models.Trains;

namespace CommuteApp.Data.Interfaces
{
    public interface ITrainApiClient
    {
        Task<List<TrainStation>> GetTrainStationsAsync();
        Task<List<Train>> GetTrainsAsync();
    }
}
