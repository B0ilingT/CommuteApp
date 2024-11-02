using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Data.DTOs
{
    public class BikeDto
    {
        public string? BikeId { get; set; }
        public string? StationId { get; set; }
        public string? VehicleTypeId { get; set; }
        public bool? IsReserved { get; set; }
        public bool? IsDisabled { get; set; }
        public int? CurrentRange { get; set; }
    }
}
