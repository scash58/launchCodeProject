using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Interfaces
{
    public interface IVehicle
    {
        string _ID { get; }
        string Year { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string ModelNum{ get; set; }
        string SerialNum { get; set; }

        string GetDescription();
        void PrintDescription();
        bool GetUserInput();

    }
}
