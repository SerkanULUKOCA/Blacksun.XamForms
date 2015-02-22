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

        private IBluetoothDevice _device;

        public async Task<IBluetoothDevice> FindPrinter()
        {
            var bluetoothClient = new AndroidBluetoothClient();
            var devices = await bluetoothClient.GetPairedDevices();

            foreach (var device in devices)
            {
                if (device.UniqueIdentifier.ToString() == "00001101-0000-1000-8000-00805f9b34fb")
                {
                    _device = device;
                    _device.Connect();
                    return device;
                }
            }

            return null;

        }

        public void Print(string str)
        {
            _device.Write(str);
        }

        public void Print(byte[] bytes)
        {
            _device.Write(bytes);
        }
    }
}