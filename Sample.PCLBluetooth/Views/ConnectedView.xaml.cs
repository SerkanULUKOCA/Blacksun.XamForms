using System;
using Acr.UserDialogs;
using PCLBluetooth;
using Xamarin.Forms;

namespace Sample.PCLBluetooth.Views
{
    public partial class ConnectedView : ContentPage
    {

        private IBluetoothDevice _device;

        public ConnectedView(IBluetoothDevice device)
        {
            InitializeComponent();
            _device = device;
            txtName.Text = _device.Name;
        }

        private async void ButtonWrite_OnClicked(object sender, EventArgs e)
        {
            try
            {
                await _device.Write(txtMessage.Text);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message);
            }
            
        }

        private async void DisconnectButtonClick(object sender, EventArgs e)
        {
            try
            {
                await _device.Disconnect();
                 Navigation.PopToRootAsync(true);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert("Couldnt disconnect!");
            }
            
        }

        protected override void OnDisappearing()
        {
            _device.Disconnect();
            base.OnDisappearing();
        }
    }
}
