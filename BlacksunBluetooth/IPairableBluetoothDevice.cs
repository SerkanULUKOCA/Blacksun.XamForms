using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksunBluetooth
{
    public interface IPairableBluetoothDevice
    {

        string Name { get; set; }

        string Address { get; set; }

        Task Pair();

    }
}
