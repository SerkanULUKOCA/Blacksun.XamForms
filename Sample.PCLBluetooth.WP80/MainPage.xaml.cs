using PCLBluetooth.WinPhone80;

namespace Sample.PCLBluetooth.BluetoothWP80
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            global::Xamarin.Forms.Forms.Init();
            PCLBluetoothClient.Init();
            LoadApplication(new PCLBluetooth.App());
        }

    }
}