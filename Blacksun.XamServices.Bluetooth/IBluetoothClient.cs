using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blacksun.Bluetooth
{
    public interface IBluetoothClient
    {

        Task<bool> IsBluetoothOn();

        Task<List<IBluetoothDevice>> GetPairedDevices();

    }
}
