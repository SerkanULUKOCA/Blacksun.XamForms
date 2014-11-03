using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Blacksun.XamServices.Sockets.Android;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSocketManager))]
namespace Blacksun.XamServices.Sockets.Android
{
    public class AndroidSocketManager : ISocketManager
    {

        public async Task<string> SendTCPMessage(string host, int port, string message)
        {

            var tcs = new TaskCompletionSource<string>();

            var client = new WebSocketClient();
            await client.ConnectAsync(host, port);
            await client.SendAsync(message);

            return null;

        }


    }
}