using CommuteApp.Core.Models.Bikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Models.Stations
{
    public class BikeStation : Station
    {
        public string Name { get; set; }
        public int NumberOfBikes { get; set; }
        public int NumberOfElectricBikes { get; set; }
        public List<Bike> Bikes { get; set; }
        public BikeStation()
        {
            Name = String.Empty;
            StationType = "Bike Station";
            Bikes = new List<Bike>();
        }
    }
}
