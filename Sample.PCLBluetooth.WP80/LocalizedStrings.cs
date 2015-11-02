using Sample.PCLBluetooth.BluetoothWP80.Resources;

namespace Sample.PCLBluetooth.BluetoothWP80
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }
    }
}