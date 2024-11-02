using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Bikes
{
    public class ElectricBike : Bike
    {
        public int CurrentRange { get; set; }

        public ElectricBike()
        {
            VehicleType = "Electric Bike";
            CurrentRange = 100;
        }
    }
}
