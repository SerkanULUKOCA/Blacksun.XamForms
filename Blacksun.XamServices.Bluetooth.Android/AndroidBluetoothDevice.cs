using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using IOException = Java.IO.IOException;

namespace Blacksun.XamServices.Bluetooth.Android
{
    public class AndroidBluetoothDevice : IBluetoothDevice
    {

        private static UUID MY_UUID = UUID.FromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
        private BluetoothSocket btSocket = null;

        public string Name { get; set; }
        public string Address { get; set; }
        public BluetoothDeviceType Type { get; set; }
        public BluetoothDevice BluetoothDevice { get; set; }
        private Stream outStream = null;
        public void Connect()
        {
            var bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            ParcelUuid[] uuids = BluetoothDevice.GetUuids();
            for (int j = 0; j < uuids.Length; j++)
            {

                var uuidString = uuids[j].Uuid.ToString();
                if (uuidString == "00001101-0000-1000-8000-00805f9b34fb")
                {
                    MY_UUID = uuids[j].Uuid;
                }
                
            }

            try
            {
                btSocket = BluetoothDevice.CreateRfcommSocketToServiceRecord(MY_UUID);
            }
            catch (Exception ex)
            {
                
            }

            bluetoothAdapter.CancelDiscovery();

            // Blocking connect, for a simple client nothing else can
            // happen until a successful connection is made, so we
            // don't care if it blocks.
            try
            {
                var device = btSocket.RemoteDevice;
                btSocket.Connect();
                outStream = btSocket.OutputStream;
            }
            catch (Exception e)
            {
                try
                {
                    btSocket.Close();
                }
                catch (Exception e2)
                {
                    
                }
            }



        }


        public void Write(string message)
        {
            try
            {
                outStream = btSocket.OutputStream;
            }
            catch (IOException ex)
            {
                
            }

            var msgBuffer = Encoding.UTF8.GetBytes(message);
            try
            {
                outStream.Write(msgBuffer,0,msgBuffer.Length);
            }
            catch (IOException ex)
            {
                
            }
        }
    }
}