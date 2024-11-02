using CommuteApp.Core.Interfaces.Vehicles;
using CommuteApp.Core.Models.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Trains
{
    public class Train : IVehicle
    {
        public string ID { get; } = string.Empty;
        public string VehicleType { get; set; } = "Train";
        public DateTime? DepartureTime { get; set; }
        public required Station Destination { get; set; }
        public int DelayInMinutes { get; set; } = 0;
    }
}
