using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Blacksun.Bluetooth.WinPhone81;

[assembly: Xamarin.Forms.Dependency(typeof(WP81BluetoothClient))]
namespace Blacksun.Bluetooth.WinPhone81
{
    public class WP81BluetoothClient : IBluetoothClient
    {

        private StreamSocket Socket;

        public WP81BluetoothClient()
        {
            Socket = new StreamSocket(); 
        }

        


        public async Task<bool> IsBluetoothOn()
        {

            var tcs = new TaskCompletionSource<bool>();


           
            try
            {

                Windows.Networking.Proximity.PeerFinder.Start();

                var peers = await Windows.Networking.Proximity.PeerFinder.FindAllPeersAsync();
                return  true; //boolean variable
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    return false;
                }

            }          


            return false;


        }

        public async Task<List<IBluetoothDevice>> GetPairedDevices()
        {
            
            var devices = new List<IBluetoothDevice>();

            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";

            var pairedDevices = (await PeerFinder.FindAllPeersAsync()).ToList();

            if (pairedDevices.Count > 0)
            {
                foreach (var paireddevice in pairedDevices)
                {

                    var device = new WP81BluetoothDevice() { Name = paireddevice.DisplayName, Address = paireddevice.HostName.CanonicalName };
                   
                    device.BluetoothDevice = paireddevice;

                    var id = paireddevice.GetPropertyValue<string>("Id");

                    if (!String.IsNullOrEmpty(id))
                    {
                        var guid = Guid.Parse(id);
                        device.UniqueIdentifiers.Add(guid);
                    }


                    devices.Add(device);
                }
            } 


            return devices;
        }

        public async Task<IBluetoothDevice> FindDeviceByIdentifier(string identifier)
        {
            PeerFinder.AlternateIdentities["Bluetooth:SDP"] = identifier;

            var pairedDevices = await PeerFinder.FindAllPeersAsync();

            if (pairedDevices.Count == 0)
            {
                Debug.WriteLine("No paired devices were found.");
            }
            else
            {

                var paireddevice = pairedDevices.First();

                var device = new WP81BluetoothDevice() { Name = paireddevice.DisplayName, Address = paireddevice.HostName.CanonicalName };

                device.BluetoothDevice = paireddevice;
                var id = paireddevice.GetPropertyValue<string>("Id");

                if (!String.IsNullOrEmpty(id))
                {
                    var guid = Guid.Parse(id);
                    device.UniqueIdentifiers.Add(guid);
                }
                return device;
            }

            return null;
        }

        private string _uuid;
        public string UUID
        {
            get { return _uuid; }
            set { _uuid = value; }
        }
    }
}
