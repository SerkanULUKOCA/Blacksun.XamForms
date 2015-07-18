using Sample.ZebraBluetoothPrinter.Core.ViewModels;
using Xamarin.Forms;

namespace Sample.ZebraBluetoothPrinter.Core.Views
{
    public partial class MainView : ContentPage
    {

        public MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainView()
        {
            InitializeComponent();
        }
    }
}
