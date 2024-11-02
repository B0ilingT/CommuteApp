using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommuteApp.Core.Interfaces
{
    public interface IStation
    {
        Guid ID { get; }
        string StationType { get; }
    }
}
