using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksun.XamServices.Sockets
{
    public interface ISocketManager
    {
        Task<string> SendTCPMessage(string host, int port, string message);
    }
}
