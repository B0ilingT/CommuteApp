using CommuteApp.Core.Interfaces.Stations;
using CommuteApp.Core.Models;
using CommuteApp.Core.Models.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Factories
{
    public class StationFactory : IStationFactory
    {
        public IStation CreateStation(string type)
        {
            switch (type)
            {
                case "Bike":
                    return new BikeStation();
                case "Train":
                    return new TrainStation();
                default:
                    throw new ArgumentException("Unknown station type", nameof(type));
            }
        }
    }
}
