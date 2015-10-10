using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Interfaces;

namespace VehicleInventory
{
    [Serializable]
    public sealed class Vehicle: VehicleBase, IVehicle
    {
        public Vehicle()
        {
            
        }

    }
}
