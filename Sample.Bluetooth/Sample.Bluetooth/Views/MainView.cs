using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Blacksun.Bluetooth;
using Blacksun.XamForms.Controls;
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
            appointmentsListView.ItemTapped += async (o, t) =>
            {
                var item = t.Item as IBluetoothDevice;
                try
                {

                    using (UserDialogs.Instance.Loading("Searching for "+item.Name+"..."))  
                        await item.Connect();

                    using (UserDialogs.Instance.Loading("Saying hi ..."))  
                        await item.Write("Hello world");

                    using (UserDialogs.Instance.Loading("Releasing device ..."))  
                        await item.Disconnect();

                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.AlertAsync(ex.Message);
                }
                
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
