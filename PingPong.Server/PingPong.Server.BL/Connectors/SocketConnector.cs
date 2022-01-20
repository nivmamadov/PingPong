using PingPong.Server.BL.Communicators;
using PingPong.Server.BL.Communicators.Abstractions;
using PingPong.Server.BL.Connectors.Abstractions;
using PingPong.Server.BL.Listeners;
using PingPong.Server.BL.Listeners.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace PingPong.Server.BL.Connectors
{
    public class SocketConnector : IConnector
    {
        private Socket _listeningSocket;
        private IPHostEntry _ipHostEntry;
        private IPEndPoint _ipEndpoint;
        private IPAddress _ipAddress;
        public SocketCommunicator SocketCommunicator { get; set; }
        public SocketListener SocketListener { get; set; }

        private int _port;

        public SocketConnector(int port)
        {
            _port = port;

            _ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            _ipAddress = _ipHostEntry.AddressList[0];
            _ipEndpoint = new IPEndPoint(_ipAddress, _port);
        }

        public void Connect()
        {
            _listeningSocket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            SocketCommunicator = new SocketCommunicator(_listeningSocket);
            SocketListener = new SocketListener(_listeningSocket, _ipEndpoint);
        }

        public void TerminateConnection()
        {
            _listeningSocket.Close();
            _listeningSocket.Shutdown(SocketShutdown.Both);
        }

        public IListener GetConnectionListener()
        {
            return SocketListener;
        }

        public ICommunicator GetConnectionCommunicator()
        {
            return SocketCommunicator;
        }
    }
}
