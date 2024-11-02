using CommuteApp.Core.Interfaces;
using CommuteApp.Core.Models;
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
                    //return new ElectricBike { BatteryLevel = 100 };
                case "Train":
                    //return new PedalBike();
                default:
                    throw new ArgumentException("Unknown station type", nameof(type));
            }
        }
    }
}
