using Acr.UserDialogs;
using Android.App;
using Android.OS;
using PCLBluetooth.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Sample.PCLBluetooth.Android
{
    [Activity(Label = "SampleBlacksunBluetoothDroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FormsApplicationActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);
            new AndroidBluetoothClient();
            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

