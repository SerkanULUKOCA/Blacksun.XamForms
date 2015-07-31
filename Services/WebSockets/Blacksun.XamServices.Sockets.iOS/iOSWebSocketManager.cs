using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Blacksun.XamServices.Sockets.iOS;
using WebSocket4Net;

[assembly: Xamarin.Forms.Dependency(typeof(iOSWebSocketManager))]
namespace Blacksun.XamServices.Sockets.iOS
{
    public class iOSWebSocketManager : IWebSocketManager
    {

        private WebSocket _webSocket = null;

        public event EventHandler Closed;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public event EventHandler Opened;

        public Task Open(string host, int port)
        {
            var tcs = new TaskCompletionSource<string>();
            Timer timer = new Timer((e) =>
            {
                tcs.TrySetException(new TimeoutException());
            }, null, 3000, Timeout.Infinite);


            _webSocket = new WebSocket("ws://" + host + ":" + port + "/");

            _webSocket.Opened += (o, t) =>
            {
                OnOpened(t);
                tcs.TrySetResult("success");
            };
            _webSocket.Closed += (o, t) => OnClosed(t);
            _webSocket.DataReceived += (o, t) =>
            {
                var args = new DataReceivedEventArgs();
                args.Data = t.Data;
                OnDataReceived(args);
            };
            _webSocket.Error += (o, t) =>
            {
                tcs.TrySetException(t.Exception);
            };


            _webSocket.Open();

            return tcs.Task;
        }

        protected virtual void OnOpened(EventArgs e)
        {
            if (Opened != null)
            {
                Opened(this, e);
            }
        }

        public void Send(string message)
        {
            if (_webSocket != null)
            {
                _webSocket.Send(message);
            }
        }

        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                DataReceived(this, e);
            }
        }

        protected virtual void OnClosed(EventArgs e)
        {
            if (Closed != null)
            {
                Closed(this, e);
            }
        }

        public void Close()
        {
            if (_webSocket != null)
            {
                _webSocket.Close();
            }
        }
    }
}
