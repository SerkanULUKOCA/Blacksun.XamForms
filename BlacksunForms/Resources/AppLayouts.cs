using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlacksunForms.Resources
{
    public static class AppLayouts
    {

        public static int FormGroupsSpacing
        {
            get { return Device.OnPlatform(20, 20, 30); }
        }

        public static int FormGroupLabelSpacing
        {
            get { return Device.OnPlatform(10, 20, 20); }
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
