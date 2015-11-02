using System.Threading.Tasks;

namespace PCLBluetooth
{
    public interface IPairableBluetoothDevice
    {

        string Name { get; set; }

        string Address { get; set; }

        Task Pair();

    }
}
