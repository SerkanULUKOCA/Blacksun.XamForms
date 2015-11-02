using System.Linq;
using System.Threading.Tasks;
using Android.Bluetooth;
using Debug = System.Diagnostics.Debug;

namespace PCLBluetooth.Android
{
    sealed class AndroidBluetoothPairableDevice : IPairableBluetoothDevice
    {

        public BluetoothDevice BluetoothDevice { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public async Task Pair()
        {

            var methods = BluetoothDevice.GetType().GetMethods().ToList();

            foreach (var methodInfo in methods)
            {
                Debug.WriteLine(methodInfo.Name);
            }

            var method = BluetoothDevice.GetType().GetMethod("CreateBond");

            method.Invoke(BluetoothDevice, null);




        }
    }
}