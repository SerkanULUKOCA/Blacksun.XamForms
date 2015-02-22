using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Acr.UserDialogs;
using Blacksun.Bluetooth.Winphone;
using Blacksun.ZebraBluetoothPrinter.Winphone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Sample.ZebraBluetoothPrinter.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
            UserDialogs.Init();
            new Acr.XamForms.UserDialogs.WindowsPhone.UserDialogService();
            new WP8BluetoothClient();
            new WP8ZebraBluetoothClient();
            Xamarin.Forms.Forms.Init();
            LoadApplication(new Sample.ZebraBluetoothPrinter.App());
        }
    }
}
