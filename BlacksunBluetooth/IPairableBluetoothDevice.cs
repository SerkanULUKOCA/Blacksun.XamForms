using System.Threading.Tasks;

namespace Blacksun.Bluetooth
{
    public interface IPairableBluetoothDevice
    {

        string Name { get; set; }

        string Address { get; set; }

        Task Pair();

    }
}
