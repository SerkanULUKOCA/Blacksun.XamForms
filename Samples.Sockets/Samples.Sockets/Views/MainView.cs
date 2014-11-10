using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksunForms;
using BlacksunForms.CustomControls;
using BlacksunForms.Layouts;
using BlacksunForms.Resources;
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

            FormLayout content = null;

            Content = content = ViewHelper.GetForm(new List<GroupLayout>
            {
                ViewHelper.GetFormGroup("Web Socket test", new List<View>
                {
                    ViewHelper.GetTextProperty("Host", "Host"),
                    ViewHelper.GetTextProperty("Port", "Port",new PropertyConfig{Keyboard = Keyboard.Numeric}),
                    ViewHelper.GetButton("Open",ViewModel.OpenCommand),
                    ViewHelper.GetTextProperty("Message", "Message"),
                    ViewHelper.GetButton("Send message",ViewModel.SendMessageCommand),
                })
            });

            //SPECIFIC CONFIGURATIONS
            var group = content.Groups.First();

            //SET BINDINGS FOR SHOWOPEN
            var host = ((PropertyLayout)group.Fields[0]);
            host.SetBinding(IsVisibleProperty, "ShowOpen");
            var port = ((PropertyLayout)group.Fields[1]);
            port.SetBinding(IsVisibleProperty, "ShowOpen");
            var openButton = ((Button)group.Fields[2]);
            openButton.SetBinding(IsVisibleProperty, "ShowOpen");

            //SET BINDINGS FOR SHOWMESSAGE
            var message = ((PropertyLayout)group.Fields[3]);
            message.SetBinding(IsVisibleProperty, "ShowMessage");
            var buttonMessage = ((Button)group.Fields[4]);
            buttonMessage.SetBinding(IsVisibleProperty, "ShowMessage");

        }

    }
}
