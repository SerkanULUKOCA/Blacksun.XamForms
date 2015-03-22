using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.Bluetooth
{
    public class BluetoothDeviceNotFoundException : Exception
    {
        public BluetoothDeviceNotFoundException()
        {
            
        }

        public BluetoothDeviceNotFoundException(string message) : base(message)
        {
            
        }

    }

}
