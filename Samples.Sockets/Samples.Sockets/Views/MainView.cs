using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms;
using BlacksunForms.Resources;
using Samples.Sockets.ViewModels;
using Xamarin.Forms;

namespace Samples.Sockets.Views
{
    public class MainView : ContentPage
    {

        public MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainView()
        {

            BindingContext = new MainViewModel();

            Content = ViewHelper.GetForm(new List<View>
            {
                ViewHelper.GetFormGroup("Socket test", new List<View>
                {
                    ViewHelper.GetTextProperty("Host", "Host"),
                    ViewHelper.GetTextProperty("Port", "Port"),
                    ViewHelper.GetButton("On",Color.White,AppColors.Accent,ViewModel.TurnOnCommand),
                    ViewHelper.GetButton("Off",Color.White,AppColors.Accent,ViewModel.TurnOffCommand)
                })
            });
        }

    }
}
