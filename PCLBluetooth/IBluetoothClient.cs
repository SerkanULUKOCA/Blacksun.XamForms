using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCLBluetooth
{
    public interface IBluetoothClient
    {

        Task<bool> IsBluetoothOn();

        Task<List<IBluetoothDevice>> GetPairedDevices();
        /*
        void StartDiscovery();

        void EndDiscovery();

        event EventHandler DeviceDiscoveryStarted;

        event EventHandler DeviceDiscoverEnded;
        
        event EventHandler<DeviceFoundEventArgs> DeviceDiscovered;
        */
        Task<List<IBluetoothDevice>> FindDevicesWithIdentifier(string identifier);

    }
}
