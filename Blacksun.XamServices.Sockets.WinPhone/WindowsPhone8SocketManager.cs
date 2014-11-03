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

        public async Task<string> SendTCPMessage(string host,int port, string message)
        {

            var tcs = new TaskCompletionSource<string>();

            var client = new WebSocketClient();
            await client.ConnectAsync(host,port);
            await client.SendAsync(message);

            return null;

        }
       

    }
}
