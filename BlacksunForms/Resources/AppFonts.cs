using Xamarin.Forms;

namespace Blacksun.XamForms.Resources
{
    public static class AppFonts
    {
        public static Font FormGroupFont
        {

            get { return Device.OnPlatform(Font.SystemFontOfSize(25), Font.SystemFontOfSize(30), Font.SystemFontOfSize(50)); }
            
        }

        public static Font FormLabelFont
        {

            get { return Device.OnPlatform(Font.SystemFontOfSize(15), Font.SystemFontOfSize(20), Font.SystemFontOfSize(30)); }

        }

        public static Font FormReadOnlyFont
        {

            get { return Device.OnPlatform(Font.SystemFontOfSize(15), Font.SystemFontOfSize(15), Font.SystemFontOfSize(30)); }

        }


        public static Font ListItemSubTitleFont()
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    return Font.SystemFontOfSize(NamedSize.Micro);
                    break;
                case TargetPlatform.WinPhone:
                    return Font.SystemFontOfSize(NamedSize.Medium);
                    break;
                case TargetPlatform.Android:
                    return Font.SystemFontOfSize(NamedSize.Micro);
                    break;
                default:
                    return Font.SystemFontOfSize(NamedSize.Micro);
                    break;
            }
        }

        public static Font ListItemTitleFont()
        {
            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    return Font.SystemFontOfSize(NamedSize.Medium);
                    break;
                case TargetPlatform.WinPhone:
                    return Font.SystemFontOfSize(NamedSize.Large);
                    break;
                case TargetPlatform.Android:
                    return Font.SystemFontOfSize(NamedSize.Medium);
                    break;
                default:
                    return Font.SystemFontOfSize(NamedSize.Medium);
                    break;
            }
        }


    }
}
