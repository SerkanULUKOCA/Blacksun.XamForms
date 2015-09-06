namespace BlacksunBluetooth.Models
{
    public class DeviceFoundEventArgs : System.EventArgs
    {
        public IPairableBluetoothDevice Device { get; set; }

    }
}
