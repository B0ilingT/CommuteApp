using CommuteApp.Core.Interfaces;
using CommuteApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type)
        {
            switch (type)
            {
                case "ElectricBike":
                    return new ElectricBike {BatteryLevel = 100 };
                case "PedalBike":
                    return new PedalBike();
                default:
                    throw new ArgumentException("Unknown vehicle type", nameof(type));
            }
        }
    }
}
