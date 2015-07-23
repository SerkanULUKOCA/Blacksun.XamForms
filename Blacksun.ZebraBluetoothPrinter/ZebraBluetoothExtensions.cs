using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blacksun.Bluetooth;

namespace Blacksun.ZebraBluetoothPrinter
{
    public static class ZebraBluetoothExtensions
    {

        public static async Task<IBluetoothDevice> FindPrinter(this IBluetoothClient client)
        {
            const string generalPrinterIdentifier = "00001101-0000-1000-8000-00805f9b34fb";

            var printer = await client.FindDeviceByIdentifier(generalPrinterIdentifier);

            return printer;
        }
    }
}
