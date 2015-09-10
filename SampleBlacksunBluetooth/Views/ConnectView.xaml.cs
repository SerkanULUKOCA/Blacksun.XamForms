using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using BlacksunBluetooth;
using Xamarin.Forms;

namespace SampleBlacksunBluetooth.Views
{
    public partial class ConnectView : ContentPage
    {

        public IBluetoothDevice Device;

        public ConnectView()
        {
            InitializeComponent();
        }

        public void Init(IBluetoothDevice device)
        {
            Device = device;
            txtName.Text = Device.Name;
            txtAddress.Text = Device.Address;
            var ui = Device.UniqueIdentifiers.FirstOrDefault();
            if (ui != null)
                txtUniqueIdentifier.Text = ui.ToString();



        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtMessage.Text))
            {
                UserDialogs.Instance.Alert("Message is empty");
                return;
            }

            /*
            if (String.IsNullOrEmpty(txtPort.Text))
            {
                txtPort.Text = "1";
            }
            */
            try
            {

                using (var dialog = UserDialogs.Instance.Loading(""))
                {
                    dialog.Title = "Connecting";
                    await Device.Connect(Convert.ToInt32(1));
                    dialog.Title = "Writing";
                    await Device.Write(txtMessage.Text);
                    dialog.Title = "Disconnecting";
                    await Device.Disconnect();
                    await Task.Delay(500);
                }

                
                
            }
            catch (Exception ex)
            {
                try
                {
                    Device.Disconnect();
                }
                catch (Exception)
                {
                    
                }
                UserDialogs.Instance.Alert(ex.Message);

            }

        }

        private void ButtonDiscover_OnClicked(object sender, EventArgs e)
        {
            
        }
    }

    public class BluetoothDeviceConnectedEventArgs : EventArgs
    {

        public BluetoothDeviceConnectedEventArgs(IBluetoothDevice device)
        {
            Device = device;
        }


        public IBluetoothDevice Device { get; set; }
        
    }

}
