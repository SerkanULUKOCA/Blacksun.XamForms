using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunBluetooth;

namespace BlacksunBluetoothPrinter
{
    public static class BluetoothPrinterExtensions
    {

        public static async Task<List<BluetoothPrinter>> FindPrinters(this IBluetoothClient client)
        {
            const string generalPrinterIdentifier = "00001101-0000-1000-8000-00805f9b34fb";



            var device = await client.FindDeviceByIdentifier(generalPrinterIdentifier);


            var printer = new BluetoothPrinter(device);

            return printer;
        }
    }
}
