using Acr.XamForms.UserDialogs.Droid;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Blacksun.XamServices.Sockets.Android;
using Xamarin.Forms.Platform.Android;

namespace Samples.Sockets.Droid
{
    [Activity(Label = "Samples.Sockets", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            new AndroidWebSocketManager();
            new UserDialogService();
            SetPage(App.GetMainPage());
        }
    }
}

