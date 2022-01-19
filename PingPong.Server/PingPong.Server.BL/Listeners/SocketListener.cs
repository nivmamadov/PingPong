using PingPong.Server.BL.Listeners.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Listeners
{
    public class SocketListener : IListener
    {
        private Socket _listeningSocket;
        private IPEndPoint _ipEndPoint;
        public SocketListener(Socket socket, IPEndPoint ipEndPoint)
        {
            _listeningSocket = socket;
            _ipEndPoint = ipEndPoint;
        }

        public void Bind()
        {
            _listeningSocket.Bind(_ipEndPoint);
        }

        public void Listen()
        {
            _listeningSocket.Listen();
        }
    }
}
