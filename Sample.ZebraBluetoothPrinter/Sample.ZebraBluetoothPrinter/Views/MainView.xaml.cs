using Sample.ZebraBluetoothPrinter.ViewModels;
using Xamarin.Forms;

namespace Sample.ZebraBluetoothPrinter.Views
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
