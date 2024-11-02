using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Interfaces
{
    public interface IVehicle
    {
        Guid ID { get; }
        string VehicleType { get; }
    }
}