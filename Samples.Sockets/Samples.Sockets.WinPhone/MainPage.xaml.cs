using Acr.XamForms.UserDialogs.WindowsPhone;
using Blacksun.XamServices.Sockets.WinPhone;
using Microsoft.Phone.Controls;
using Xamarin.Forms;


namespace Samples.Sockets.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            new WindowsPhone8SocketManager();
            new UserDialogService();
            Content = Samples.Sockets.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
