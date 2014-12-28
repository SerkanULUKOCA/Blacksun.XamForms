using Blacksun.XamForms.Sample.Core.Views;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.Core
{
    public class App
    {
        public static Page GetMainPage()
        {
            AppColors.WindowsPhoneTheme = WindowsPhoneTheme.LightTheme;
            AppColors.AndroidTheme = AndroidTheme.HoloLightTheme;
            return new MainView();
        }
    }
}
