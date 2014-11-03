using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlacksunForms.Resources;
using Samples.Sockets.Views;
using Xamarin.Forms;

namespace Samples.Sockets
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
