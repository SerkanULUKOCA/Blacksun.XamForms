using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BlacksunBluetooth.Exceptions;
using Java.IO;
using Java.Lang;
using Debug = System.Diagnostics.Debug;

namespace BlacksunBluetoothAndroid
{
    public class ConnectThread : Thread
    {

        public BluetoothSocket mmSocket;
        private BluetoothDevice mmDevice;
        private BluetoothAdapter mBluetoothAdapter;
 
        public ConnectThread(BluetoothDevice device,int port) {
            // Use a temporary object that is later assigned to mmSocket,
            // because mmSocket is final
            BluetoothSocket tmp = null;
            mmDevice = device;

            mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (mBluetoothAdapter == null)
            {
                // Device does not support Bluetooth
            }

            mBluetoothAdapter.CancelDiscovery();

            Debug.WriteLine("Getting UUIDS");

            ParcelUuid[] parcelUuids;
            parcelUuids = device.GetUuids();

            if (parcelUuids == null)
            {
                Debug.WriteLine("UUIDS null");
            }
            else
            {
                var parcelUuid = parcelUuids.FirstOrDefault();

                if (parcelUuid == null)
                {
                    Debug.WriteLine("no UUIDS found");
                }
                else
                {

                    var uuID = parcelUuid.Uuid;

                    Debug.WriteLine("Found "+uuID);

                    // Get a BluetoothSocket to connect with the given BluetoothDevice
                    try
                    {

                        IntPtr createRfcommSocket = JNIEnv.GetMethodID(device.Class.Handle, "createRfcommSocket", "(I)Landroid/bluetooth/BluetoothSocket;");
                        IntPtr _socket = JNIEnv.CallObjectMethod(device.Handle, createRfcommSocket, new JValue(port));
                        tmp = Java.Lang.Object.GetObject<BluetoothSocket>(_socket, JniHandleOwnership.TransferLocalRef);

                        // MY_UUID is the app's UUID string, also used by the server code
                        //tmp = device.CreateRfcommSocketToServiceRecord(uuID);
                    }
                    catch (IOException e)
                    {

                    }
                    mmSocket = tmp;
                }

                
            }

            
        }

        public override void Run()
        {
            // Cancel discovery because it will slow down the connection
            //mBluetoothAdapter.CancelDiscovery();

            try
            {
                // Connect the device through the socket. This will block
                // until it succeeds or throws an exception
                Debug.WriteLine("Connecting...");
                mmSocket.Connect();
                Debug.WriteLine("Connected...");
                // Do work to manage the connection (in a separate thread)
                DoConnectionStateChanged();
            }
            catch (IOException connectException)
            {

                Debug.WriteLine("IO Error: "+ connectException.Message);
                // Unable to connect; close the socket and get out
                try
                {
                    mmSocket.Close();
                }
                catch (IOException closeException)
                {
                    Debug.WriteLine("Error: " + closeException.Message);
                }
                throw new BluetoothDeviceNotFoundException(connectException.Message);
                return;
            }

            

            //base.Run();

        }

        public event EventHandler DeviceConnected;

        private void DoConnectionStateChanged()
        {
            if (DeviceConnected != null)
            {
                DeviceConnected(this, new EventArgs());
            }
        }
 
        /** Will cancel an in-progress connection, and close the socket */
        public void Cancel() {
            try {
                mmSocket.Close();
            } catch (IOException e) { }
        }


    }
}