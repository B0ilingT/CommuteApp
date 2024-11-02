using CommuteApp.Core.Interfaces.Vehicles;
using CommuteApp.Core.Models;
using CommuteApp.Core.Models.Bikes;
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
                    return new ElectricBike {CurrentRange = 10000 };
                case "PedalBike":
                    return new PedalBike();
                default:
                    throw new ArgumentException("Unknown vehicle type", nameof(type));
            }
        }
    }
}
