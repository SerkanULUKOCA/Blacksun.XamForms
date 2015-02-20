using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamServices.Bluetooth
{
    public interface IBluetoothDevice
    {
        string Name { get; set; }

        string Address { get; set; }

        BluetoothDeviceType Type { get; set; }

        void Connect();

        void Write(string message);

    }
}
