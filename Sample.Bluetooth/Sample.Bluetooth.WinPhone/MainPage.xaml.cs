using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Acr.XamForms.UserDialogs.WindowsPhone;
using Blacksun.XamServices.Bluetooth.Winphone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;


namespace Sample.Bluetooth.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            new WindowsPhone8BluetoothManager();
            new UserDialogService();
            Content = Sample.Bluetooth.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
