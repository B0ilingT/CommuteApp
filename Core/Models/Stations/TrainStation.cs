using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Stations
{
    public class TrainStation : Station
    {
        public List<Train> Trains { get; set; }
        public TrainStation()
        {
            Trains = new List<Train>();
        }
    }
}
