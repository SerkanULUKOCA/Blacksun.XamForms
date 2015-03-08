using Blacksun.XamForms.Resources;
using Blacksun.XamForms.Sample.Core.Views;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.Core
{
    public class App : Application
    {
        public App()
        {
            AppColors.WindowsPhoneTheme = WindowsPhoneTheme.LightTheme;
            AppColors.AndroidTheme = AndroidTheme.HoloLightTheme;
            AppColors.SetAccent("#FF31B6E7");
            MainPage = new DemoView();
        }
    }
}
