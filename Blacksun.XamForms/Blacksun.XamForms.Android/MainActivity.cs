using System;
using Acr.XamForms.UserDialogs.Droid;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Blacksun.XamForms.Sample.Core;
using Xamarin.Forms.Platform.Android;

namespace Blacksun.XamForms.Droid
{
    [Activity(Label = "Blacksun.XamForms", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            new UserDialogService();
            SetPage(App.GetMainPage());
        }
    }
}

