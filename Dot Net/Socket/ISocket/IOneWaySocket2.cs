using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;


namespace ISocket
{
    public interface IOneWaySocket2
    {
         string Name { get; set; }
         string InputIP { get; set; }
         string InputPort { get; set; }

         string OutIP { get; set; }
         string OutPort { get; set; }
         bool ListenState { get; set; }
         bool ConnectState { get; set; }
         Socket Local { get; set; }
         Socket Remote { get; set; }
         string Message { get; set; }
         Dictionary<string, Socket> pool { get; set; }
         event EventHandler OnMessageReceived;
         event EventHandler OnStopped;
         event EventHandler OnConnected;
         void Listen();
         void Stop();
         void Send(string msg);
         void ReceiveFormServer();
         void ReceiveFormClient(Socket s);
         void Connect();
    }
}
