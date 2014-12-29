using Xamarin.Forms;

namespace Blacksun.XamForms.Resources
{
    public static class AppLayouts
    {



        public static int FormGroupsSpacing
        {
            get { return Device.OnPlatform(20, 20, 40); }
        }

        public static int FormGroupLabelSpacing
        {
            get { return Device.OnPlatform(10, 10, 10); }
        }

        public static int FormPropertiesSpacing
        {
            get { return Device.OnPlatform(10, 10, 20); }
        }

        public static int LabelPropertySpacing
        {
            get { return Device.OnPlatform(0, 0, 0); }
        }

    }
}
