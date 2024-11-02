using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommuteApp.Core.Interfaces.Vehicles;

namespace CommuteApp.Core.Interfaces.Stations
{
    public interface IStationFactory
    {
        IVehicle CreateVehicle(string type);
    }
}
