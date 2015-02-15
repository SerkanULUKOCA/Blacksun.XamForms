using Blacksun.XamForms.Resources;
using Blacksun.XamForms.Sample.Core.Views;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.Core
{
    public class App
    {
        public static Page GetMainPage()
        {
            AppColors.WindowsPhoneTheme = WindowsPhoneTheme.LightTheme;
            AppColors.AndroidTheme = AndroidTheme.HoloLightTheme;
            AppColors.SetAccent("#FF31B6E7");
            return new MainView();
        }
    }
}
