using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Acr.UserDialogs;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Sample.ZebraBluetoothPrinter.WinPhone.Resources;
using Xamarin.Forms;

namespace Sample.ZebraBluetoothPrinter.WinPhone
{
    public partial class MainPage 
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.SupportedOrientations = SupportedPageOrientation.Portrait;
            Forms.Init();
            LoadApplication(new Core.App());
        }

    }
}