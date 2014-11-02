
using System;
using System.Windows.Input;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.ViewModels;
using Xamarin.Forms;
using Blacksun.XamServices.Bluetooth;

namespace Sample.Bluetooth.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly IUserDialogService _dialogService;
        private readonly IBluetoothManager _bluetoothManager;

        public MainViewModel()
        {
            try
            {
                _bluetoothManager = DependencyService.Get<IBluetoothManager>();
                _dialogService = DependencyService.Get<IUserDialogService>();
            }
            catch (Exception ex)
            {
                
            }
            
        }




        public ICommand CheckBluetoothAvailableCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await _bluetoothManager.IsBluetoothOn();

                    if (result)
                    {
                        await _dialogService.AlertAsync("Bluetooth is on", "Sucess");
                    }
                    else
                    {
                        await _dialogService.AlertAsync("Bluetooth is off, please turn it on", "Sucess");
                    }

                });
            }
        } 

    }
}
