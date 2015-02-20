using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamServices.Bluetooth
{
    public interface IBluetoothClient
    {

        Task<bool> IsBluetoothOn();

        Task<List<IBluetoothDevice>> GetPairedDevices();

    }
}
