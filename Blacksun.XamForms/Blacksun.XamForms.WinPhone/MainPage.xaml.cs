using Acr.UserDialogs;
using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace Blacksun.XamForms.Sample.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.SupportedOrientations = SupportedPageOrientation.Portrait;
            Forms.Init();
            UserDialogs.Init();
            LoadApplication(new Core.App());
        }
    }
}
