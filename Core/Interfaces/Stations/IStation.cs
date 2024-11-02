using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Interfaces.Stations
{
    public interface IStation
    {
        Guid ID { get; }
        string StationType { get; }
        string StationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
