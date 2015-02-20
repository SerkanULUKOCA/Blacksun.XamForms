using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blacksun.XamForms.Controls;
using Blacksun.XamServices.Bluetooth;
using BlacksunForms;
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

            var appointmentsListView = new ListView();
            appointmentsListView.VerticalOptions = LayoutOptions.FillAndExpand;
            appointmentsListView.ItemTapped += (o, t) =>
            {
                var item = t.Item as IBluetoothDevice;
                ViewModel.ConnectDevice(item);
                item.Write("Hello world");
                appointmentsListView.SelectedItem = null;
            };
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, "Address");
            appointmentsListView.ItemTemplate = cell;
            appointmentsListView.SetBinding(ListView.ItemsSourceProperty, "Devices", BindingMode.TwoWay);

            Content = new DataForm()
            {
                Children =
                {
                    new DataFormGroup()
                    {
                        Header = "Bluetooth test",
                        Children =
                        {
                            new DataFormContentField{Label = "Availability",Content = new DataFormButton(){Text ="Check",Command = ViewModel.CheckBluetoothAvailableCommand}},
                            new DataFormButton(){Text = "Get paired devices",Command = ViewModel.GetPairedDevicesCommand},
                            appointmentsListView,
                        }
                    }
                }
            };

        }

        

        

    }
}
