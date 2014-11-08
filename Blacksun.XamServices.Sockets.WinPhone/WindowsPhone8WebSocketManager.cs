using System;
using System.Threading.Tasks;
using Blacksun.XamServices.Sockets.WinPhone;
using WebSocket4Net;

[assembly: Xamarin.Forms.Dependency(typeof(WindowsPhone8WebSocketManager))]
namespace Blacksun.XamServices.Sockets.WinPhone
{
    public class WindowsPhone8WebSocketManager : IWebSocketManager
    {

        private WebSocket _webSocket = null;

        public event EventHandler Closed;
        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public event EventHandler Opened;

        public Task Open(string host, int port)
        {
            var tcs = new TaskCompletionSource<string>();

            _webSocket = new WebSocket("ws://" + host + ":" + port + "/");

            _webSocket.Opened += (o, t) => OnOpened(t);
            _webSocket.Closed += (o, t) => OnClosed(t);
            _webSocket.Open();
            _webSocket.DataReceived += (o, t) =>
            {
                var args = new DataReceivedEventArgs();
                args.Data = t.Data;
                OnDataReceived(args);
            };
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
                Closed(this,e);
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
