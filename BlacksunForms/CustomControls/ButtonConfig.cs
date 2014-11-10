using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.CustomControls
{
    public class ButtonConfig
    {

        public ButtonConfig()
        {
            TextColor = Color.White;
            BackgroundColor = AppColors.Accent;
        }

        public Color TextColor { get; set; }

        public Color BackgroundColor { get; set; }

    }
}
