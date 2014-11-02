using Acr.XamForms.UserDialogs.WindowsPhone;
using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            new UserDialogService();
            Content = Blacksun.XamForms.Sample.Core.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
