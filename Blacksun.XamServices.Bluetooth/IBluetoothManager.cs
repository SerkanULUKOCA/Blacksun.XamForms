using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamServices.Bluetooth
{
    public interface IBluetoothManager
    {

        Task<bool> IsBluetoothOn();

        Task<uint> SendCommand(string command);

    }
}
