
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Blacksun.XamServices.Bluetooth;
using System;
using System.Threading.Tasks;
using Blacksun.XamServices.Bluetooth.Winphone;

[assembly: Xamarin.Forms.Dependency(typeof(WindowsPhone8BluetoothClient))]
namespace Blacksun.XamServices.Bluetooth.Winphone
{
    public class WindowsPhone8BluetoothClient : IBluetoothClient
    {


        public Task<bool> IsBluetoothOn()
        {

            var tcs = new TaskCompletionSource<bool>();


            return tcs.Task;


        }

        public Task<List<BluetoothDevice>> GetPairedDevices()
        {
            var tcs = new TaskCompletionSource<List<BluetoothDevice>>();


            return tcs.Task;
        }
    }
}
