using System.Threading.Tasks;

namespace PCLBluetooth.BluetoothPrinter
{
    public class BluetoothPrinter
    {
        private IBluetoothDevice _device;

        public BluetoothPrinter(IBluetoothDevice device)
        {
            _device = device;
        }

        public async Task Connect()
        {
            await _device.Connect();
        }

        public bool IsConnected
        {
            get { return _device.IsConnected; }
        }

        public async Task Print(string text)
        {
            await _device.Write(text);
        }

        public async Task Disconnect()
        {
            await _device.Disconnect();
        }

        public string Name
        {
            get { return _device.Name; }
        }

    }
}
