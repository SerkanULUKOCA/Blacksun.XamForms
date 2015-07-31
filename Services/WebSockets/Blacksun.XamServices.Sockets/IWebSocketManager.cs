using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamServices.Sockets
{
    public interface IWebSocketManager
    {

        event EventHandler Closed;
        event EventHandler<DataReceivedEventArgs> DataReceived;
        event EventHandler Opened;

        Task Open(string host, int port);
        void Send(string message);
        void Close();

    }
}
