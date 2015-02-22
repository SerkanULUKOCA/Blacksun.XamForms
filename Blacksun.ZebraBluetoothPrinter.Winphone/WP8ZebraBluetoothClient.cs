using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Blacksun.Bluetooth;
using Blacksun.Bluetooth.Winphone;
using Sample.Bluetooth;

namespace Blacksun.ZebraBluetoothPrinter.Winphone
{
    public class WP8ZebraBluetoothClient : IZebraBluetoothClient
    {

        private string GeneralSerialIdentifier = "00001101-0000-1000-8000-00805f9b34fb";

        private IBluetoothDevice _device;

        public async Task<IBluetoothDevice> FindPrinter()
        {

            PeerFinder.AlternateIdentities["Bluetooth:SDP"] = GeneralSerialIdentifier;

            var pairedDevices = await PeerFinder.FindAllPeersAsync();

            if (pairedDevices.Count == 0)
            {
                Debug.WriteLine("No paired devices were found.");
            }
            else
            {

                var paireddevice = pairedDevices.First();

                var device = new WP8BluetoothDevice() { Name = paireddevice.DisplayName, Address = paireddevice.HostName.CanonicalName };

                device.BluetoothDevice = paireddevice;
                var id = paireddevice.GetPropertyValue<string>("Id");

                if (!String.IsNullOrEmpty(id))
                {
                    var guid = Guid.Parse(id);
                    device.UniqueIdentifiers.Add(guid);
                }

                
                // Select a paired device. In this example, just pick the first one.
                PeerInformation selectedDevice = pairedDevices[0];
                // Attempt a connection
                StreamSocket socket = new StreamSocket();
                // Make sure ID_CAP_NETWORKING is enabled in your WMAppManifest.xml, or the next 
                // line will throw an Access Denied exception.
                // In this example, the second parameter of the call to ConnectAsync() is the RFCOMM port number, and can range 
                // in value from 1 to 30.
                await socket.ConnectAsync(selectedDevice.HostName, "1");
            }

            return null;
        }

        public async Task Print(string str)
        {
            await _device.Write(str);
            _device.Disconnect();
        }

        public async Task Print(byte[] bytes)
        {
            await _device.Write(bytes);
            _device.Disconnect();
        }
    }
}
