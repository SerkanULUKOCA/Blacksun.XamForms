using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Blacksun.Bluetooth;
using Blacksun.ZebraBluetoothPrinter;
using GalaSoft.MvvmLight;
using Sample.ZebraBluetoothPrinter.Core.Views;
using Xamarin.Forms;

namespace Sample.ZebraBluetoothPrinter.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private string ToPrint = "";
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
                RaisePropertyChanged();
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

                        

                        BluetoothPrinter printer = null;

                        using (UserDialogs.Instance.Loading("Looking for printer"))
                        {
                            printer = await _bluetoothClient.FindPrinter();
                        }

                        

                        if (printer == null)
                        {
                            await UserDialogs.Instance.AlertAsync("No printer found", "Not found");
                        }
                        else
                        {

                            var nl = Environment.NewLine;

                            ToPrint = nl+ nl + nl + nl + nl + nl + nl + "I am a printer" + nl + nl + nl + nl + nl + nl + nl+
                            "My name is "+printer.Name+ nl + nl + nl + nl + nl + nl ;

                            using (UserDialogs.Instance.Loading("Connecting"))
                            {
                                await printer.Connect();
                            }

                            

                            if (printer.IsConnected)
                            {
                                using (UserDialogs.Instance.Loading("Printing"))
                                {
                                    await Task.Delay(2000);
                                    await printer.Print(ToPrint);
                                    await printer.Disconnect();
                                    await Task.Delay(2000);
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
