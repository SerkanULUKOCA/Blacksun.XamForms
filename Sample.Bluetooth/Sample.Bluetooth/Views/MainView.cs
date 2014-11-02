using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms;
using BlacksunForms.Resources;
using Sample.Bluetooth.ViewModels;
using Xamarin.Forms;

namespace Sample.Bluetooth.Views
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
                ViewHelper.GetFormGroup("Bluetooth test", new List<View>
                {
                    ViewHelper.GetLabelForContent("Availability",ViewHelper.GetButton("Check",Color.White,AppColors.Accent,ViewModel.CheckBluetoothAvailableCommand))
                })
            });
        }

    }
}
