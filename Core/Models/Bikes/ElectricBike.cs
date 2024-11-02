using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Bikes
{
    public class ElectricBike : Bike
    {
        public ElectricBike()
        {
            VehicleType = "Electric Bike";
        }

        public int BatteryLevel { get; set; }
    }
}
