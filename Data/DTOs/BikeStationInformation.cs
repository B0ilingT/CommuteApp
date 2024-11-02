using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Data.DTOs
{
    public class BikeStationInformationDto
    {
        public string? StationId { get; set; }
        public string? Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Capacity { get; set; }
        public RentalUris? RentalUris { get; set; }
    }

    public class RentalUris
    {
        public string? Android { get; set; }
        public string? IOS { get; set; }
    }
}
