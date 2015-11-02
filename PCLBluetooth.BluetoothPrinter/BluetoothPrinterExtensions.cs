using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCLBluetooth.BluetoothPrinter
{
    public static class BluetoothPrinterExtensions
    {

        public static async Task<List<PCLBluetooth.BluetoothPrinter.BluetoothPrinter>> FindPrinters(this IBluetoothClient client)
        {

            const string generalPrinterIdentifier = "00001101-0000-1000-8000-00805f9b34fb";

            var printers = (await client.FindDevicesWithIdentifier(generalPrinterIdentifier)).Select(x=>new PCLBluetooth.BluetoothPrinter.BluetoothPrinter(x)).ToList();

            return printers;
        }
    }
}
