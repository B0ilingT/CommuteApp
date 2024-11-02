using CommuteApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Bikes
{
    public class Bike : IVehicle
    {
        public Guid ID { get; } = Guid.NewGuid();
        public string VehicleType { get; set; } = "Bike";
        public DateTime? LastServicedDate { get; set; }
    }
}
