using Acr.UserDialogs;
using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace Sample.ZebraBluetoothPrinter.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            Forms.Init();
            UserDialogs.Init();
            //new WP8BluetoothClient();
            //new WP8ZebraBluetoothClient();
            LoadApplication(new ZebraBluetoothPrinter.App());
        }
    }
}
