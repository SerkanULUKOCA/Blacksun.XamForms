using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.XamForms.UserDialogs;
using Blacksun.Bluetooth;
using Blacksun.Mvvm;
using Blacksun.ZebraBluetoothPrinter;
using Sample.ZebraBluetoothPrinter.Views;
using Xamarin.Forms;
using Command = Blacksun.Mvvm.Command;

namespace Sample.ZebraBluetoothPrinter.ViewModels
{
    public class MainViewModel : ViewModel
    {

        private string ToPrint = "Z";

        private readonly IUserDialogService _dialogService;
        private readonly IZebraBluetoothClient _zebraBluetoothClient;
        private readonly IBluetoothClient _bluetoothClient;

        public MainViewModel()
        {
            try
            {
                _bluetoothClient = DependencyService.Get<IBluetoothClient>();
                _zebraBluetoothClient = DependencyService.Get<IZebraBluetoothClient>();
                _dialogService = DependencyService.Get<IUserDialogService>();
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


        public ICommand PrintCommand
        {
            get
            {
                return new Command(async () =>
                {

                    try
                    {

                        var checkBluetoothResult = await _bluetoothClient.IsBluetoothOn();

                        if (!checkBluetoothResult)
                        {
                            await _dialogService.AlertAsync("Bluetooth is off, please turn it on", "Error");
                            return;
                        }

                        var printer = await _zebraBluetoothClient.FindPrinter();

                        if (printer == null)
                        {
                            await _dialogService.AlertAsync("No printer found", "Not found");
                        }
                        else
                        {

                            var assembly = typeof(MainView).GetTypeInfo().Assembly;
                            var resourceName = "Sample.ZebraBluetoothPrinter.PrintFormat.txt";

                            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string result = reader.ReadToEnd();
                                ToPrint = result;
                            }

                            

                            printer.Connect();

                            if (printer.IsConnected)
                            {
                                using (var dialog = _dialogService.Loading("Prinitng"))
                                {
                                    await Task.Delay(2000);
                                    await _zebraBluetoothClient.Print(ToPrint);
                                }
                            }
                            else
                            {
                                await _dialogService.AlertAsync("No se pudo conectar con el dispositivo "+printer.Name + "", "Error");
                            }

                            

                            
                        }

                    }
                    catch (Exception ex)
                    {
                        
                    }

                    

                });
            }
        }



    }
}
