using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Stations
{
    public class BikeStation : Station
    {
        public BikeStation()
        {
            StationType = "Bike Station";
        }
        public int NumberOfBikes { get; set; }
        public int NumberOfElectricBikes { get; set; }
    }
}
