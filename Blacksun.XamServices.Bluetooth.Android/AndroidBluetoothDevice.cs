using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using Java.Util;
using IOException = Java.IO.IOException;

namespace Blacksun.Bluetooth.Android
{
    public class AndroidBluetoothDevice : IBluetoothDevice
    {

        private static UUID MY_UUID = UUID.FromString("fa87c0d0-afac-11de-8a39-0800200c9a66");
        private BluetoothSocket Socket = null;
        private Guid CurrentUniqueIdentifier { get; set; }

        private readonly List<Guid> _uniqueIdentifiers = new List<Guid>(); 
        public List<Guid> UniqueIdentifiers
        {
            get { return _uniqueIdentifiers; }
        }

        public string Name { get; set; }
        public string Address { get; set; }

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        public BluetoothDeviceType Type { get; set; }
        public BluetoothDevice BluetoothDevice { get; set; }
        private Stream outStream = null;
        private Stream inStream = null;
        public void SetUniqueIdentifier(Guid uniqueIdentifier)
        {
            CurrentUniqueIdentifier = uniqueIdentifier;
        }

        public async Task Connect()
        {
            var bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            if (CurrentUniqueIdentifier == Guid.Empty)
            {
                var uuids = BluetoothDevice.GetUuids().ToList().FirstOrDefault();

                if (uuids != null)
                {
                    var stringUUID = MY_UUID.ToString();
                    CurrentUniqueIdentifier = Guid.Parse(stringUUID);
                }

                

            }

            MY_UUID = UUID.FromString(CurrentUniqueIdentifier.ToString());

            try
            {
                Socket = BluetoothDevice.CreateRfcommSocketToServiceRecord(MY_UUID);
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
                var device = Socket.RemoteDevice;
                Socket.Connect();
                IsConnected = true;
                inStream = Socket.InputStream;
                outStream = Socket.OutputStream;
            }
            catch (Exception e)
            {
                IsConnected = false;
                try
                {
                    Socket.Close();
                }
                catch (Exception e2)
                {
                    
                }
            }

        }

        public async Task Disconnect()
        {
            try
            {
                if (inStream != null)
                {
                    try { inStream.Close(); }
                    catch (Exception e) { }
                    inStream = null;
                }

                if (outStream != null)
                {
                    try { outStream.Close(); }
                    catch (Exception e) { }
                    outStream = null;
                }

                if (Socket != null)
                {
                    try { Socket.Close(); }
                    catch (Exception e) { }
                    Socket = null;
                }

                await Task.Delay(2000);


            }
            catch (Exception ex)
            {
                
            }
        }


        public async Task Write(string message)
        {
            await Write(Encoding.UTF8.GetBytes(message));
        }

        public async Task Write(byte[] bytes)
        {
            try
            {
                outStream = Socket.OutputStream;
            }
            catch (IOException ex)
            {

            }

            var msgBuffer = bytes;
            try
            {
                outStream.Write(msgBuffer, 0, msgBuffer.Length);
            }
            catch (IOException ex)
            {

            }
        }


        public bool ContainsUniqueIdentifier(string uniqueIdentifier)
        {
            return ContainsUniqueIdentifier(Guid.Parse(uniqueIdentifier));
        }

        public void SetUniqueIdentifier(string uniqueIdentifier)
        {
            SetUniqueIdentifier(Guid.Parse(uniqueIdentifier));
        }

        public bool ContainsUniqueIdentifier(Guid uniqueIdentifier)
        {
            var uuids = BluetoothDevice.GetUuids().ToList();

            foreach (var uuid in uuids)
            {
                var stringUUID = uuid.ToString();
                if (stringUUID == uniqueIdentifier.ToString())
                {
                    return true;
                }
            }


            return false;
        }
    }



}