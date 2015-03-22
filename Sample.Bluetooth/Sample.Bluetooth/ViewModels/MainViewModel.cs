
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Acr.UserDialogs;
using Blacksun.Bluetooth;
using Blacksun.Mvvm;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace Sample.Bluetooth.ViewModels
{
    public class MainViewModel : ViewModel
    {

        private readonly IBluetoothClient _bluetoothClient;

        public MainViewModel()
        {
            try
            {
                _bluetoothClient = DependencyService.Get<IBluetoothClient>();
            }
            catch (Exception ex)
            {
                
            }
            
        }

        private ObservableCollection<IBluetoothDevice> _devices = new ObservableCollection<IBluetoothDevice>();
        public ObservableCollection<IBluetoothDevice> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }


        public ICommand CheckBluetoothAvailableCommand
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {
                        var result = await _bluetoothClient.IsBluetoothOn();

                        if (result)
                        {
                            await UserDialogs.Instance.AlertAsync("Bluetooth is on", "Sucess");
                        }
                        else
                        {
                            await UserDialogs.Instance.AlertAsync("Bluetooth is off, please turn it on", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }

                    

                });
            }
        }

        public ICommand GetPairedDevicesCommand
        {
            get
            {
                return new Command(async() =>
                {


                    try
                    {
                        var devices = await _bluetoothClient.GetPairedDevices();

                        Devices.Clear();

                        foreach (var device in devices)
                        {
                            Devices.Add(device);
                        }
                    }
                    catch (Exception ex)
                    {
                        UserDialogs.Instance.AlertAsync(ex.Message, "Error");
                    }

                    

                });
            }
        }

        public void ConnectDevice(IBluetoothDevice bluetoothDevice)
        {
            bluetoothDevice.Connect();
        }


    }
}
