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
using SampleBlacksunBluetoothWP80.Resources;

namespace SampleBlacksunBluetoothWP80
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new SampleBlacksunBluetooth.App());
        }

    }
}