using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Blacksun.XamServices.Sockets.WinPhone;
using SuperSocket.ClientEngine;
using WebSocket4Net;

[assembly: Xamarin.Forms.Dependency(typeof(WindowsPhone8SocketManager))]
namespace Blacksun.XamServices.Sockets.WinPhone
{
    public class WindowsPhone8SocketManager : ISocketManager
    {

        private Socket _socket;

        public async Task<string> SendTCPMessage(string host,int port, string message)
        {

            var tcs = new TaskCompletionSource<string>();

            var client = new WebSocketClient();
            await client.ConnectAsync(host,port);
            await client.SendAsync(message);



            /*
            HostName serverHost = new HostName(host);
            StreamSocket clientSocket = new Windows.Networking.Sockets.StreamSocket();

            // Try to connect to the remote host
            await clientSocket.ConnectAsync(serverHost, "http");
            */
            
            /*
            // Make sure we can perform this action with valid data
            if (ValidateRemoteHost(host) && ValidateInput(message))
            {
                // Instantiate the SocketClient
                SocketClient client = new SocketClient();

                // Attempt to connect to the echo server
                //Console.WriteLine(String.Format("Connecting to server '{0}' over port {1} (echo) ...", host, port), true);
                var result = await client.ConnectAsync(host, port);
                //Console.WriteLine(result, false);

                // Attempt to send our message to be echoed to the echo server
                //Console.WriteLine(String.Format("Sending '{0}' to server ...", message));
                result =  await client.SendAsync(message);
                //Console.WriteLine(result, false);

                // ReceiveAsync a response from the echo server
                //Console.WriteLine("Requesting ReceiveAsync ...", true);
                result = await client.ReceiveAsync();
                //Console.WriteLine(result, false);

                // Close the socket connection explicitly
                client.Close();

                return result;

            }
            */
            return null;

        }

        private bool ValidateInput(string input)
        {
            // txtInput must contain some text
            if (String.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Message is empty");
            }

            return true;
        }

        /// <summary>
        /// Validates the txtRemoteHost TextBox
        /// </summary>
        /// <returns>True if the txtRemoteHost contains valid data,
        /// otherwise False
        /// </returns>
        private bool ValidateRemoteHost(string host)
        {
            // The txtRemoteHost must contain some text
            if (String.IsNullOrWhiteSpace(host))
            {
                throw new Exception("Empty host name");
                return false;
            }

            return true;
        }


    }
}
