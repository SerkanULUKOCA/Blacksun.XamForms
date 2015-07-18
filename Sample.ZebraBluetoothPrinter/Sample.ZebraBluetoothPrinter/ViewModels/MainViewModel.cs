using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Blacksun.Bluetooth;
using Blacksun.Mvvm;
using Blacksun.ZebraBluetoothPrinter;
using Sample.ZebraBluetoothPrinter.Core.Views;
using Xamarin.Forms;
using Command = Blacksun.Mvvm.Command;

namespace Sample.ZebraBluetoothPrinter.Core.ViewModels
{
    public class MainViewModel : ViewModel
    {

        private string ToPrint = "";

        private readonly IZebraBluetoothClient _zebraBluetoothClient;
        private readonly IBluetoothClient _bluetoothClient;

        public MainViewModel()
        {
            try
            {
                _bluetoothClient = DependencyService.Get<IBluetoothClient>();
                _zebraBluetoothClient = DependencyService.Get<IZebraBluetoothClient>();
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

                        using (UserDialogs.Instance.Loading("Checking Bluetooth availability"))
                        {
                            var checkBluetoothResult = await _bluetoothClient.IsBluetoothOn();

                            if (!checkBluetoothResult)
                            {
                                await UserDialogs.Instance.AlertAsync("Bluetooth is off, please turn it on", "Error");
                                return;
                            }
                        }

                        

                        IBluetoothDevice printer = null;

                        using (UserDialogs.Instance.Loading("Looking for printer"))
                        {
                            printer = await _zebraBluetoothClient.FindPrinter();
                        }

                        

                        if (printer == null)
                        {
                            await UserDialogs.Instance.AlertAsync("No printer found", "Not found");
                        }
                        else
                        {
                            /*
                            var assembly = typeof(MainView).GetTypeInfo().Assembly;
                            var resourceName = "Sample.ZebraBluetoothPrinter.Core.PrintFormat.txt";

                            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string result = reader.ReadToEnd();
                                ToPrint = result;
                            }*/

                            ToPrint = Environment.NewLine+Environment.NewLine+"I am a test"+Environment.NewLine+Environment.NewLine;

                            using (UserDialogs.Instance.Loading("Connecting"))
                            {
                                await printer.Connect();
                            }

                            

                            if (printer.IsConnected)
                            {
                                using (UserDialogs.Instance.Loading("Printing"))
                                {
                                    await Task.Delay(2000);
                                    await _zebraBluetoothClient.Print(ToPrint);
                                    await printer.Disconnect();
                                }
                            }
                            else
                            {
                                await UserDialogs.Instance.AlertAsync("No se pudo conectar con el dispositivo " + printer.Name + "", "Error");
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
