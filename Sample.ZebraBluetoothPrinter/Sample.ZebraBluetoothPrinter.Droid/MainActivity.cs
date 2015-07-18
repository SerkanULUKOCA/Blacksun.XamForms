using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Blacksun.Bluetooth.Android;
using Blacksun.ZebraBluetoothPrinter.Android;
using Sample.ZebraBluetoothPrinter.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Sample.ZebraBluetoothPrinter.Droid
{
    [Activity(Label = "Sample.ZebraBluetoothPrinter", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);
            new AndroidBluetoothClient();
            new AndroidZebraBluetoothClient();
            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

