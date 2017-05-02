using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;


namespace ISocket
{
    public interface IOneWaySocket
    {
         string Name { get; set; }
         string InputIP { get; set; }
         string InputPort { get; set; }

         string OutIP { get; set; }
         string OutPort { get; set; }
         bool ListenState { get; set; }
         bool ConnectState { get; set; }
         Socket Remote { get; set; }
         Socket Local { get; set; }
         string Message { get; set; }

         event EventHandler OnMessageReceived;
         event EventHandler OnStopped;

        //SocketAsyncEventArgs RemoteEventArg = new SocketAsyncEventArgs();
        //SocketAsyncEventArgs LocalEventArg  =new SocketAsyncEventArgs();

        //public IOneWaySocket()
        //{
            //RemoteEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(RemoteEventArg_Completed);
            //RemoteEventArg.UserToken = new AsyncUserToken();

            //LocalEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(LocalEventArg_Completed);
            //LocalEventArg.UserToken = new AsyncUserToken();
        //}

        //void LocalEventArg_Completed(object sender, SocketAsyncEventArgs e)
        //{
        //    switch (e.LastOperation)
        //    {
        //        case SocketAsyncOperation.Receive:
        //            //ProcessReceive(e);
        //            break;
        //        case SocketAsyncOperation.Send:
        //            //ProcessSend(e);
        //            break;
        //        default:
        //            throw new ArgumentException("The last operation completed on the socket was not a receive or send");
        //    }
        //}

        //void RemoteEventArg_Completed(object sender, SocketAsyncEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

          void Listen();
          void Stop();
          void Send(string msg);
          void Receive();
          void Connect();
    }
}
