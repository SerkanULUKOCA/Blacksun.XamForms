using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlacksunForms.CustomControls;
using BlacksunForms.Resources;
using Xamarin.Forms;

namespace BlacksunForms.Controls
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
