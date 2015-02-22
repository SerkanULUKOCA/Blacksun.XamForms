using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamServices.Bluetooth
{
    public interface IBluetoothDevice
    {

        List<Guid> UniqueIdentifiers { get; }

        string Name { get; set; }

        string Address { get; set; }

        bool IsConnected { get; set; }

        BluetoothDeviceType Type { get; set; }

        bool ContainsUniqueIdentifier(string uniqueIdentifier);

        void SetUniqueIdentifier(string uniqueIdentifier);

        bool ContainsUniqueIdentifier(Guid uniqueIdentifier);

        void SetUniqueIdentifier(Guid uniqueIdentifier);

        void Connect();

        void Disconnect();

        Task Write(string message);

        Task Write(byte[] bytes);

    }
}
