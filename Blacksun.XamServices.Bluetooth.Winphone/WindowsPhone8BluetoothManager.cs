
using System.ComponentModel;
using System.Diagnostics;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Blacksun.XamServices.Bluetooth;
using System;
using System.Threading.Tasks;
using Blacksun.XamServices.Bluetooth.Winphone;

[assembly: Xamarin.Forms.Dependency(typeof(WindowsPhone8BluetoothManager))]
namespace Blacksun.XamServices.Bluetooth.Winphone
{
    public class WindowsPhone8BluetoothManager : IBluetoothManager
    {

        public WindowsPhone8BluetoothManager() { }

        /// <summary>
        /// Socket used to communicate with Arduino.
        /// </summary>
        private StreamSocket socket;

        /// <summary>
        /// DataWriter used to send commands easily.
        /// </summary>
        private DataWriter dataWriter;

        /// <summary>
        /// DataReader used to receive messages easily.
        /// </summary>
        private DataReader dataReader;

        /// <summary>
        /// Thread used to keep reading data from socket.
        /// </summary>
        private BackgroundWorker dataReadWorker;

        /// <summary>
        /// Delegate used by event handler.
        /// </summary>
        /// <param name="message">The message received.</param>
        public delegate void MessageReceivedHandler(string message);

        /// <summary>
        /// Event fired when a new message is received from Arduino.
        /// </summary>
        public event MessageReceivedHandler MessageReceived;

        public void Inititalize()
        {
            socket = new StreamSocket();
            dataReadWorker = new BackgroundWorker();
            dataReadWorker.WorkerSupportsCancellation = true;
            dataReadWorker.DoWork += new DoWorkEventHandler(ReceiveMessages);
        }

        public async Task<bool> IsBluetoothOn()
        {
            //Windows.Networking.Proximity.PeerFinder.Start();

            // Search for all paired devices
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = "";
            try
            {
                var peers = await Windows.Networking.Proximity.PeerFinder.FindAllPeersAsync();
                return true; //boolean variable
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x8007048F)
                {
                    return false;
                }

            }

            return false;
        }

        private async void ReceiveMessages(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    // Read first byte (length of the subsequent message, 255 or less). 
                    uint sizeFieldCount = await dataReader.LoadAsync(1);
                    if (sizeFieldCount != 1)
                    {
                        // The underlying socket was closed before we were able to read the whole data. 
                        return;
                    }

                    // Read the message. 
                    uint messageLength = dataReader.ReadByte();
                    uint actualMessageLength = await dataReader.LoadAsync(messageLength);
                    if (messageLength != actualMessageLength)
                    {
                        // The underlying socket was closed before we were able to read the whole data. 
                        return;
                    }
                    // Read the message and process it.
                    string message = dataReader.ReadString(actualMessageLength);
                    MessageReceived(message);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void Terminate()
        {
            if (socket != null)
            {
                socket.Dispose();
            }
            if (dataReadWorker != null)
            {
                dataReadWorker.CancelAsync();
            }
        }

        public async Task<uint> SendCommand(string command)
        {
            uint sentCommandSize = 0;
            if (dataWriter != null)
            {
                uint commandSize = dataWriter.MeasureString(command);
                dataWriter.WriteByte((byte)commandSize);
                sentCommandSize = dataWriter.WriteString(command);
                await dataWriter.StoreAsync();
            }
            return sentCommandSize;
            
        }
    }
}
