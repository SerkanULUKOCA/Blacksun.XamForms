using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blacksun.XamServices.Bluetooth;

namespace Blacksun.ZebraBluetoothPrinter
{
    public interface IZebraBluetoothClient
    {

        Task<IBluetoothDevice> FindPrinter();

        Task Print(string str);

        Task Print(byte[] bytes);

    }
}
