
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

        public Task<List<IBluetoothDevice>> GetPairedDevices()
        {
            var tcs = new TaskCompletionSource<List<IBluetoothDevice>>();


            return tcs.Task;
        }

        private string _uuid;
        public string UUID
        {
            get { return _uuid; }
            set { _uuid = value; }
        }
    }
}
