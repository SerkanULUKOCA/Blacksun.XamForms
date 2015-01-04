using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blacksun.XamForms.Resources;
using Sample.Bluetooth.Views;
using Xamarin.Forms;

namespace Sample.Bluetooth
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
