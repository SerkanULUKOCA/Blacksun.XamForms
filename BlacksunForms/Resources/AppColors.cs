using Xamarin.Forms;

namespace Blacksun.XamForms.Resources
{


    public enum WindowsPhoneTheme
    {
        LightTheme,
        DarkTheme
    }

    public enum AndroidTheme
    {
        HoloLightTheme,
        HoloDarkTheme
    }

    public static class AppColors
    {
        


        //Light
        private const string White = "#FFFFFFFF";
        private static string AccentColor = "#FF2C3E50";
        private const string DarkGray = "#FF1F1F1F";
        private const string LightGray = "#FF797779";

        private static WindowsPhoneTheme _windowsPhoneTheme = WindowsPhoneTheme.DarkTheme;
        public static WindowsPhoneTheme WindowsPhoneTheme
        {
            get { return _windowsPhoneTheme; }
            set { _windowsPhoneTheme = value; }
        }

        private static AndroidTheme _androidTheme = AndroidTheme.HoloDarkTheme;
        public static AndroidTheme AndroidTheme
        {
            get { return _androidTheme; }
            set { _androidTheme = value; }
        }

        public static void SetAccent(string colorHex)
        {
            AccentColor = colorHex;
        }


        //APPLICATION COLORS
        public static Color Accent
        {
            get { return Color.FromHex(AccentColor); }
        }

        public static Color PageBackground
        {
            get { return Color.FromHex(White); }
        }

        public static Color SlideMenuBackground
        {
            get { return Color.FromHex(AccentColor); }
        }

        public static Color GroupColor
        {
            get
            {
                return Device.OnPlatform(Color.FromHex(AccentColor), Color.FromHex(White), Color.FromHex(White));
            }
        }


        public static Color FormGroupColor
        {
            get
            {

                var windowsPhoneColor = WindowsPhoneTheme == WindowsPhoneTheme.DarkTheme
                    ? Color.FromHex(White)
                    : Color.FromHex(DarkGray);

                var androidColor = AndroidTheme == AndroidTheme.HoloDarkTheme
                    ? Color.FromHex(White)
                    : Color.FromHex(DarkGray);

                return Device.OnPlatform(Color.FromHex(DarkGray), androidColor, windowsPhoneColor);
            }
        }

        public static Color FormLabelColor
        {
            get
            {

                var windowsPhoneColor = WindowsPhoneTheme == WindowsPhoneTheme.DarkTheme
                    ? Color.FromHex(White)
                    : Color.FromHex(DarkGray);

                var androidColor = AndroidTheme == AndroidTheme.HoloDarkTheme
                    ? Color.FromHex(White)
                    : Color.FromHex(DarkGray);

                return Device.OnPlatform(Color.FromHex(DarkGray), androidColor, windowsPhoneColor);
            }
        }

        public static Color FormReadOnlyColor
        {
            get
            {

                var windowsPhoneColor = WindowsPhoneTheme == WindowsPhoneTheme.DarkTheme
                    ? Color.FromHex(LightGray)
                    : Color.FromHex(LightGray);

                var androidColor = AndroidTheme == AndroidTheme.HoloDarkTheme
                    ? Color.FromHex(LightGray)
                    : Color.FromHex(LightGray);

                return Device.OnPlatform(Color.FromHex(DarkGray), androidColor, windowsPhoneColor);
            }
        }

        public static Color SubTitleColor
        {
            get
            {
                return Device.OnPlatform(Color.FromHex(LightGray), Color.FromHex(LightGray), Color.FromHex(LightGray));
            }
        }

    }
}
