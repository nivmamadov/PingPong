using PingPong.Server.BL.Listeners.Abstractions;
using System.Net;
using System.Net.Sockets;

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
