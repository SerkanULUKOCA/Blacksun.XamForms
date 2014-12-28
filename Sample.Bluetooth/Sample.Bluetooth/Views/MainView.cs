using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms;
using BlacksunForms.Controls;
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
            Content = new DataForm()
            {
                Children =
                {
                    new DataFormGroup()
                    {
                        Header = "Bluetooth test",
                        Children =
                        {
                            new DataFormContentField{Label = "Availability",Content = new DataFormButton(){Text ="Check",Command = ViewModel.CheckBluetoothAvailableCommand}}
                        }
                    }
                }
            };

        }

    }
}
