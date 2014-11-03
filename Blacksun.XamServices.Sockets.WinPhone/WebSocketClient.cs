using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace Blacksun.XamServices.Sockets.WinPhone
{
    public class WebSocketClient
    {

        private WebSocket _webSocket = null;

        public Task ConnectAsync(string hostName, int portNumber)
        {

            var tcs = new TaskCompletionSource<string>();

            

            _webSocket = new WebSocket("ws://" + hostName + ":" + portNumber + "/");

            _webSocket.Opened += (o, t) =>
            {
                tcs.TrySetResult("");
            };

            _webSocket.Open();

            return tcs.Task;
        }

        public Task SendAsync(string message)
        {

            var tcs = new TaskCompletionSource<string>();

            if (_webSocket != null)
            {
                _webSocket.Send(message);
                tcs.TrySetResult("");
            }

            return tcs.Task;
        }


    }
}
