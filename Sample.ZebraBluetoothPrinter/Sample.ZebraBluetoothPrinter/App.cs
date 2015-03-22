using Blacksun.XamForms.Resources;
using Sample.ZebraBluetoothPrinter.Views;
using Xamarin.Forms;

namespace Sample.ZebraBluetoothPrinter
{
    public class App : Application
    {
        public App()
        {
            AppColors.WindowsPhoneTheme = WindowsPhoneTheme.LightTheme;
            AppColors.AndroidTheme = AndroidTheme.HoloLightTheme;
            AppColors.SetAccent("#FF31B6E7");
            MainPage = new MainView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
