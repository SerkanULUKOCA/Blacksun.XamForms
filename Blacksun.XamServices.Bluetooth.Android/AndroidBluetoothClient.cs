using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Bluetooth;
using Android.Content.Res;
using Android.Views;
using Blacksun.XamServices.Bluetooth.Android;
using Java.Util;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidBluetoothClient))]
namespace Blacksun.XamServices.Bluetooth.Android
{
    public class AndroidBluetoothClient : IBluetoothClient
    {

        private BluetoothAdapter btAdapter;

        public AndroidBluetoothClient()
        {
            btAdapter = BluetoothAdapter.DefaultAdapter;
        }

        public async Task<bool> IsBluetoothOn()
        {
            var bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (bluetoothAdapter == null)
            {
                // Device does not support Bluetooth
                throw new Exception("Device does not support Bluetooth");
            }
            else
            {
                return bluetoothAdapter.IsEnabled;
            }
        }

        public async Task<List<IBluetoothDevice>> GetPairedDevices()
        {

            var devices = new List<IBluetoothDevice>();

            // Get a set of currently paired devices 
 			var pairedDevices = btAdapter.BondedDevices; 
 			 
 			// If there are paired devices, add each one to the ArrayAdapter 
 			if (pairedDevices.Count > 0) 
            { 
 				foreach (var paireddevice in pairedDevices)
 				{

 				    var device = new AndroidBluetoothDevice() {Name = paireddevice.Name, Address = paireddevice.Address};
 				    device.BluetoothDevice = paireddevice;
                    
 				    switch (paireddevice.Type)
 				    {
                        case global::Android.Bluetooth.BluetoothDeviceType.Classic:
 				            device.Type = BluetoothDeviceType.Classic;
                            break;
                        case global::Android.Bluetooth.BluetoothDeviceType.Dual:
                            device.Type = BluetoothDeviceType.Dual;
                            break;
                        case global::Android.Bluetooth.BluetoothDeviceType.Le:
                            device.Type = BluetoothDeviceType.Le;
                            break;
                        case global::Android.Bluetooth.BluetoothDeviceType.Unknown:
                            device.Type = BluetoothDeviceType.Unknown;
                            break;
 				    }

                    devices.Add(device);
 				} 
 			} 



            return devices;
        }

        
    }
}