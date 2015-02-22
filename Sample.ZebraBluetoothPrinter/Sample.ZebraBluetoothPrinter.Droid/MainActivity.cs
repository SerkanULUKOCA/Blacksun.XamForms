using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Blacksun.XamServices.Bluetooth.Android;
using Blacksun.ZebraBluetoothPrinter.Android;

namespace Sample.ZebraBluetoothPrinter.Droid
{
    [Activity(Label = "Sample.ZebraBluetoothPrinter", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Acr.UserDialogs.UserDialogs.Init(this);
            new AndroidBluetoothClient();
            new AndroidZebraBluetoothClient();
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

