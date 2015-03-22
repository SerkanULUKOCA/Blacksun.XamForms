using Acr.UserDialogs;
using Blacksun.Bluetooth.Winphone;
using Xamarin.Forms;

namespace Sample.Bluetooth.WinPhone
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            new WP8BluetoothClient();
            UserDialogs.Init();
            LoadApplication(new Bluetooth.App());
        }
    }
}
