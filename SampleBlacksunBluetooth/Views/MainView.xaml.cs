using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Blacksun.Bluetooth;
using BlacksunBluetooth;
using Xamarin.Forms;

namespace SampleBlacksunBluetooth.Views
{
    public partial class MainView
    {

        private IBluetoothClient _bluetoothClient;

        public MainView()
        {
            InitializeComponent();

            _bluetoothClient = DependencyService.Get<IBluetoothClient>();
            _bluetoothClient.DeviceDiscoveryStarted += (o, t) =>
            {
                
            };
            _bluetoothClient.DeviceDiscovered += (o, t) =>
            {
                var query = DiscoveredDevices.FirstOrDefault(x => x.Name == t.Device.Name && x.Address == t.Device.Address);

                if (query == null)
                {
                    DiscoveredDevices.Add(t.Device);
                }

            };
            _bluetoothClient.DeviceDiscoverEnded += (o, t) =>
            {
                
            };
            listViewPaired.ItemsSource = PairedDevices;
            listViewDiscovered.ItemsSource = DiscoveredDevices;
        }

        private readonly ObservableCollection<IBluetoothDevice> _pairedDevices = new ObservableCollection<IBluetoothDevice>();
        public ObservableCollection<IBluetoothDevice> PairedDevices
        {
            get { return _pairedDevices; }

        }

        private readonly ObservableCollection<IPairableBluetoothDevice> _discoveredDevices = new ObservableCollection<IPairableBluetoothDevice>();
        public ObservableCollection<IPairableBluetoothDevice> DiscoveredDevices
        {
            get { return _discoveredDevices; }

        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as IBluetoothDevice;

            var view = new ConnectView();
            view.Init(item);
            /*
            view.DeviceConnected += async (o, t) =>
            {
                var connectedView = new ConnectedView(t.Device);
                await Navigation.PopModalAsync();
                await Navigation.PushModalAsync(connectedView);
            };
            */
            await Navigation.PushModalAsync(view);

            (sender as ListView).SelectedItem = null;


        }

        private async void ButtonDiscover_OnClicked(object sender, EventArgs e)
        {

            DiscoveredDevices.Clear();

            using (UserDialogs.Instance.Loading("Searching for devices"))
            {
                await SearchDevices();
            }
            
            
        }

        public async Task SearchDevices()
        {
            _bluetoothClient.StartDiscovery();
            await Task.Delay(TimeSpan.FromMilliseconds(10000));
            _bluetoothClient.EndDiscovery();
        }

        private async void ButtonGetPaired_OnClicked(object sender, EventArgs e)
        {
            try
            {

                PairedDevices.Clear();

                using (UserDialogs.Instance.Loading("Getting paired devices"))
                {
                    _bluetoothClient.EndDiscovery();
                    var devices = await _bluetoothClient.GetPairedDevices();

                    foreach (var device in devices)
                    {
                        PairedDevices.Add(device);
                    }
                }

                
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.AlertAsync(ex.Message, "Error");
            }
        }

        private void OnPairMenuItem_Clicked(object sender, EventArgs e)
        {

            var device = listViewDiscovered.SelectedItem as IPairableBluetoothDevice;

            var query = PairedDevices.FirstOrDefault(x => x.Name == device.Name && x.Address == device.Address);

            if (query == null)
            {
                try
                {
                    device.Pair();
                }
                catch (Exception ex)
                {
                    
                }
                
            }
            else
            {
                UserDialogs.Instance.AlertAsync("Device already paired");
            }

        }
    }
}
