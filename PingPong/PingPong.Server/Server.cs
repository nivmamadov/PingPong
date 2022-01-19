using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace PingPong.Server
{
    public class Server
    {
        private Socket _listeningSocket;
        private IPHostEntry _ipHostEntry;
        private IPEndPoint _ipEndpoint;
        private IPAddress _ipAddress;

        private int _port;

        public Server(int port)
        {
            _port = port;

            _ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddress = _ipHostEntry.AddressList[0];
            _ipEndpoint = new IPEndPoint(_ipAddress, _port);
            _listeningSocket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            InitialBinding();
        }

        public void InitialBinding()
        {
            _listeningSocket.Bind(_ipEndpoint);
            _listeningSocket.Listen();
        }
    }
}
