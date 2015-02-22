using System;
using System.Threading.Tasks;
using Blacksun.XamServices.Bluetooth;
using Blacksun.XamServices.Bluetooth.Android;
using Blacksun.ZebraBluetoothPrinter.Android;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidZebraBluetoothClient))]
namespace Blacksun.ZebraBluetoothPrinter.Android
{
    public class AndroidZebraBluetoothClient : IZebraBluetoothClient
    {

        private string GeneralSerialIdentifier = "00001101-0000-1000-8000-00805f9b34fb";

        private IBluetoothDevice _device;

        public async Task<IBluetoothDevice> FindPrinter()
        {
            var bluetoothClient = new AndroidBluetoothClient();
            var devices = await bluetoothClient.GetPairedDevices();

            foreach (var device in devices)
            {
                if (device.ContainsUniqueIdentifier(GeneralSerialIdentifier))
                {
                    device.SetUniqueIdentifier(GeneralSerialIdentifier);
                    _device = device;
                    return device;
                }

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