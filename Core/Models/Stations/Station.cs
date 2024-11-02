using CommuteApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Stations
{
    public class Station : IStation
    {
        public Guid ID { get; } = Guid.NewGuid();
        public string StationType { get; set; } = "Station";
        public string StationName { get; set; } = "Station";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
