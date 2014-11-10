using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.ViewModels;
using Blacksun.XamServices.Sockets;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Samples.Sockets.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly IUserDialogService _dialogService;
        private readonly IWebSocketManager _webSocketManager;
        public MainViewModel()
        {
            try
            {
                _webSocketManager = DependencyService.Get<IWebSocketManager>();
                _dialogService = DependencyService.Get<IUserDialogService>();
                
            }
            catch (Exception ex)
            {

            }

        }


        private string _host = "localhost.com";
        public string Host
        {
            get { return _host; }
            set { _host = value; OnPropertyChanged(); }
        }

        private int _port = 8124;
        public int Port
        {
            get { return _port; }
            set { _port = value; OnPropertyChanged(); }
        }

        private string _message = "";
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        private bool _showOpen = true;
        public bool ShowOpen
        {
            get { return _showOpen; }
            set { _showOpen = value; OnPropertyChanged(); }
        }

        private bool _showMessage = false;
        public bool ShowMessage
        {
            get { return _showMessage; }
            set { _showMessage = value; OnPropertyChanged(); }
        }

        public ICommand OpenCommand
        {
            get
            {
                return new Command(async () =>
                {
                    using (_dialogService.Loading("Opening..."))
                    {
                        try
                        {
                            await _webSocketManager.Open(Host, Port);
                            ShowOpen = false;
                            ShowMessage = true;
                        }
                        catch (Exception ex)
                        {
                            _dialogService.Alert("Couldt connect...");
                        }
                        
                    }

                });
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    using (_dialogService.Loading("Sending..."))
                    {
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        _webSocketManager.Send(Message);
                    }

                });
            }
        }


    }
}
