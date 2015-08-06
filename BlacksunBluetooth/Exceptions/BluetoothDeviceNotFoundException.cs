using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksunBluetooth.Exceptions
{
    public class BluetoothDeviceNotFoundException : Exception
    {

        public BluetoothDeviceNotFoundException(string messsage): base(messsage)
        {
            
        }

    }
}
