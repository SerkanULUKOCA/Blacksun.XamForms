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
            if (String.IsNullOrEmpty(txtPort.Text))
            {
                txtPort.Text = "1";
            }

            try
            {
                await Device.Connect(Convert.ToInt32(txtPort.Text));
                DoDeviceConnected(Device);
                
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message);

            }

        }

        public event EventHandler<BluetoothDeviceConnectedEventArgs> DeviceConnected;

        private void DoDeviceConnected(IBluetoothDevice device)
        {
            if (DeviceConnected != null)
            {
                DeviceConnected(this,new BluetoothDeviceConnectedEventArgs(device) );
            }
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
