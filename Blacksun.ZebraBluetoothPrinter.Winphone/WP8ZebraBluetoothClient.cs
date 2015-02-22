using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Blacksun.Bluetooth;
using Blacksun.Bluetooth.Winphone;
using Blacksun.ZebraBluetoothPrinter.Winphone;
using Sample.Bluetooth;
using Xamarin.Forms;

[assembly: Dependency(typeof(WP8ZebraBluetoothClient))]
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

                _device = device;

                return device;
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
