using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.XamForms.UserDialogs;
using Acr.XamForms.ViewModels;
using Blacksun.XamServices.Sockets;
using Newtonsoft.Json;
using Samples.Sockets.Models;
using Xamarin.Forms;

namespace Samples.Sockets.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly IUserDialogService _dialogService;
        private readonly ISocketManager _socketManager;
        public MainViewModel()
        {
            try
            {
                _socketManager = DependencyService.Get<ISocketManager>();
                _dialogService = DependencyService.Get<IUserDialogService>();
                
            }
            catch (Exception ex)
            {

            }

        }


        private string _host = "dma-source.com";
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

        public ICommand TurnOnCommand
        {
            get
            {
                return new Command(async () =>
                {

                    var message = JsonConvert.SerializeObject(new CustomMessage());
                    try
                    {
                        var result = await _socketManager.SendTCPMessage(Host, Port, message);
                    }
                    catch (Exception ex)
                    {
                        
                    }

                });
            }
        }

        public ICommand TurnOffCommand
        {
            get
            {
                return new Command(async () =>
                {

                    var message = JsonConvert.SerializeObject(new CustomMessage(){R= "0"});
                    try
                    {
                        var result = await _socketManager.SendTCPMessage(Host, Port, message);
                    }
                    catch (Exception ex)
                    {

                    }

                });
            }
        }


    }
}
