using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blacksun.XamForms.Controls;
using BlacksunForms;
using BlacksunForms.Layouts;
using Samples.Sockets.ViewModels;
using Xamarin.Forms;

namespace Samples.Sockets.Views
{
    public class MainView : ContentPage
    {

        public MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainView()
        {

            BindingContext = new MainViewModel();

            DataForm content = null;

            Content = content = new DataForm
            {
                Children =
                {
                    new DataFormGroup()
                    {
                        Header = "Web Socket Test",
                        Children =
                        {
                            new DataFormDataField(){Label = "Host",DataMemberBindingPath = "Host"},
                            new DataFormDataField(){Label = "Port",DataMemberBindingPath = "Port",Keyboard = Keyboard.Numeric},
                            new DataFormButton(){Text = "Host",Command = ViewModel.OpenCommand},
                            new DataFormDataField(){Label = "Message",DataMemberBindingPath = "Message"},
                            new DataFormButton(){Text = "Send message",Command = ViewModel.SendMessageCommand},
                        }
                    }
                }
            };

            //SPECIFIC CONFIGURATIONS
            var group = content.Children.First() as DataFormGroup;

            //SET BINDINGS FOR SHOWOPEN
            var host = ((DataFormDataField)group.Children[0]);
            host.SetBinding(IsVisibleProperty, "ShowOpen");
            var port = ((DataFormDataField)group.Children[1]);
            port.SetBinding(IsVisibleProperty, "ShowOpen");
            var openButton = ((DataFormButton)group.Children[2]);
            openButton.SetBinding(IsVisibleProperty, "ShowOpen");

            //SET BINDINGS FOR SHOWMESSAGE
            var message = ((DataFormDataField)group.Children[3]);
            message.SetBinding(IsVisibleProperty, "ShowMessage");
            var buttonMessage = ((DataFormButton)group.Children[4]);
            buttonMessage.SetBinding(IsVisibleProperty, "ShowMessage");

        }

    }
}
