using CommuteApp.Core.Interfaces.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Bikes
{
    public class Bike : IVehicle
    {
        public String ID { get; set; } = String.Empty;
        public string VehicleType { get; set; } = "Bike";
        public DateTime? LastServicedDate { get; set; }

        public string StationId { get; set; }
    }
}
