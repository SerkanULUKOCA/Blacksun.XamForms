using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Blacksun.Bluetooth.Winphone;
using Blacksun.ZebraBluetoothPrinter.Winphone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Sample.ZebraBluetoothPrinter.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
            new Acr.XamForms.UserDialogs.WindowsPhone.UserDialogService();
            new WP8BluetoothClient();
            new WP8ZebraBluetoothClient();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new Sample.ZebraBluetoothPrinter.App());
        }
    }
}
