using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Java.Util;
using Debug = System.Diagnostics.Debug;
using Exception = System.Exception;

namespace BlacksunBluetoothAndroid
{
    public class ConnectThread : Thread
    {

        public BluetoothSocket mmSocket;
        private BluetoothDevice Device;
        private BluetoothAdapter mBluetoothAdapter;
        private int Port;
 
        public ConnectThread(BluetoothDevice device,int port) {
            // Use a temporary object that is later assigned to mmSocket,
            // because mmSocket is final
            BluetoothSocket tmp = null;
            Device = device;
            Port = port;
            mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (mBluetoothAdapter == null)
            {
                // Device does not support Bluetooth
                throw new System.Exception("No bluetooth device found");
            }

            //mBluetoothAdapter.CancelDiscovery();
            /*
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

                foreach (var uuid in parcelUuids)
                {
                    Debug.WriteLine(uuid.ToString());
                }

                if (parcelUuid == null)
                {
                    Debug.WriteLine("no UUIDS found");
                }
                else
                {

                    var uuID = parcelUuid.Uuid;

                    uuID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");

                    Debug.WriteLine("Found "+uuID);

                    // Get a BluetoothSocket to connect with the given BluetoothDevice
                    try
                    {
                        //mmSocket = (BluetoothSocket)method.Invoke(device, new object[] { port });
                        mmSocket = device.CreateInsecureRfcommSocketToServiceRecord(uuID);
                        //method = device.GetType().GetMethod("createRfcommSocket");

                        //IntPtr createRfcommSocket = JNIEnv.GetMethodID(device.Class.Handle, "createRfcommSocket", "(I)Landroid/bluetooth/BluetoothSocket;");
                        //IntPtr _socket = JNIEnv.CallObjectMethod(device.Handle, createRfcommSocket, new JValue(port));
                        //tmp = Java.Lang.Object.GetObject<BluetoothSocket>(_socket, JniHandleOwnership.TransferLocalRef);

                        // MY_UUID is the app's UUID string, also used by the server code
                        //tmp = device.CreateRfcommSocketToServiceRecord(uuID);
                    }
                    catch (IOException e)
                    {

                    }
                    //mmSocket = tmp;
                }

                
            }*/

            
        }

        public override void Run()
        {
            // Cancel discovery because it will slow down the connection
            //mBluetoothAdapter.CancelDiscovery();

            try
            {

                ProbeConnection();
                // Connect the device through the socket. This will block
                // until it succeeds or throws an exception
                
                //mmSocket.Connect();
                
                // Do work to manage the connection (in a separate thread)
                
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

        private void ProbeConnection()
        {
            ParcelUuid[] parcelUuids;
            parcelUuids = Device.GetUuids();
            bool isConnected = false;

            if (parcelUuids == null)
            {
                throw new System.Exception("No Unique Identifiers found");
            }
            else
            {

                Debug.WriteLine("Connecting...");
                foreach (var parcelUuid in parcelUuids)
                {
                    mBluetoothAdapter.CancelDiscovery();
                    //METHOD A

                    try
                    {
                        var method = Device.GetType().GetMethod("createRfcommSocket");
                        mmSocket = (BluetoothSocket) method.Invoke(Device, new object[] {Port});
                        mmSocket.Connect();
                        Debug.WriteLine("Connected...");
                        isConnected = true;
                        DoDeviceConnected();
                        break;
                    }
                    catch (Exception)
                    {
                        
                    }

                    //METHOD B

                    try
                    {
                        var method = Device.GetType().GetMethod("createInsecureRfcommSocket");
                        mmSocket = (BluetoothSocket)method.Invoke(Device, new object[] { Port });
                        mmSocket.Connect();
                        Debug.WriteLine("Connected...");
                        isConnected = true;
                        DoDeviceConnected();
                        break;
                    }
                    catch (Exception)
                    {
                       
                    }

                }

                if (!isConnected)
                {
                    //METHOD C

                    try
                    {
                        IntPtr createRfcommSocket = JNIEnv.GetMethodID(Device.Class.Handle, "createRfcommSocket", "(I)Landroid/bluetooth/BluetoothSocket;");
                        // JNIEnv.GetMethodID(device.Class.Handle, "createRfcommSocket", "(I)Landroid/bluetooth/BluetoothSocket;");
                        IntPtr _socket = JNIEnv.CallObjectMethod(Device.Handle, createRfcommSocket, new Android.Runtime.JValue(Port));
                        mmSocket = Java.Lang.Object.GetObject<BluetoothSocket>(_socket, JniHandleOwnership.TransferLocalRef);
                        /*
                        mmSocket =
                            mBluetoothAdapter.GetRemoteDevice(Device.Address)
                                .CreateRfcommSocketToServiceRecord(
                                    UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));
                        */
                        mmSocket.Connect();
                        DoDeviceConnected();
                    }
                    catch (IOException connectException)
                    {

                        Debug.WriteLine("IO Error: " + connectException.Message);
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
                }

            }
        }

        public event EventHandler DeviceConnected;

        private void DoDeviceConnected()
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