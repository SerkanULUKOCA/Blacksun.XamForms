using Blacksun.XamForms.Resources;
using Xamarin.Forms;

namespace Blacksun.XamForms.Controls
{
    public class DataFormButton : Button
    {

        public DataFormButton()
        {
            TextColor = Color.White;
            BackgroundColor = AppColors.Accent;
        }
        /*
        public DataFormButton(string content, ICommand command, ButtonConfig config = null)
        {
            if (config == null)
            {
                config = new ButtonConfig();
            }

            Text = content;
            TextColor = config.TextColor;
            BackgroundColor = config.BackgroundColor;
            if (command != null)
            {
                Command = command;
            }
        }
        */

    }
}
