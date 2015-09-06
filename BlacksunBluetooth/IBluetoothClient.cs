using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunBluetooth.Models;

namespace BlacksunBluetooth
{
    public interface IBluetoothClient
    {

        Task<bool> IsBluetoothOn();

        Task<List<IBluetoothDevice>> GetPairedDevices();

        void StartDiscovery();

        void EndDiscovery();

        event EventHandler DeviceDiscoveryStarted;

        event EventHandler DeviceDiscoverEnded;

        event EventHandler<DeviceFoundEventArgs> DeviceDiscovered;

        Task<IBluetoothDevice> FindDeviceByIdentifier(string identifier);

    }
}
