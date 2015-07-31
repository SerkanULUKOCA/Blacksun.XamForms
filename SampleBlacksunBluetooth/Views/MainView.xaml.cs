using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using BlacksunBluetooth;
using Xamarin.Forms;

namespace SampleBlacksunBluetooth.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as IBluetoothDevice;
            try
            {

                using (UserDialogs.Instance.Loading("Searching for " + item.Name + "..."))
                    await item.Connect();

                var nl = Environment.NewLine;

                using (UserDialogs.Instance.Loading("Saying hi ..."))
                    await item.Write(nl + nl + nl + nl + nl + "Hello world" + nl + nl + nl + nl + nl);

                using (UserDialogs.Instance.Loading("Releasing device ..."))
                    await item.Disconnect();

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.AlertAsync(ex.Message);
            }

            (sender as ListView).SelectedItem = null;
        }
    }
}
