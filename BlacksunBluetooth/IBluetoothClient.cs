using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blacksun.Bluetooth.Models;
using BlacksunBluetooth;

namespace Blacksun.Bluetooth
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
