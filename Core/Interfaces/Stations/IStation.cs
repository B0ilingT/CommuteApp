using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Interfaces.Stations
{
    public interface IStation
    {
        string ID { get; set; }
        string StationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
