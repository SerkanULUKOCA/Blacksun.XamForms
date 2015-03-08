using Xamarin.Forms;

namespace Blacksun.XamForms.Resources
{
    public static class AppLayouts
    {

        public static Thickness FormLayoutPadding
        {
            get { return new Thickness(Device.OnPlatform(30, 30, 30)); }
        }

        public static Thickness FormGroupLayoutPadding
        {
            get { return new Thickness(Device.OnPlatform(0, 0, 0)); }
        }

        public static double FormGroupsSpacing
        {
            get { return Device.OnPlatform(20, 20, 40); }
        }

        public static double FormGroupLabelSpacing
        {
            get { return Device.OnPlatform(10, 10, 10); }
        }

        public static double FormPropertiesSpacing
        {
            get { return Device.OnPlatform(10, 10, 20); }
        }

        public static double LabelPropertySpacing
        {
            get { return Device.OnPlatform(0, 0, 0); }
        }

    }
}
