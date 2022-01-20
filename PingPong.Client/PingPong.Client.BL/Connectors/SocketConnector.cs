using PingPong.Client.BL.Communicators;
using PingPong.Client.BL.Communicators.Abstractions;
using PingPong.Client.BL.Connectors.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace PingPong.Client.BL.Connectors
{
    public class SocketConnector : IConnector
    {
        private IPHostEntry _ipHostEntry;
        private IPAddress _ipAddress;
        private IPEndPoint _ipEndPoint;
        private Socket _clientSocket;

        public SocketConnector(string hostname, int port)
        {
            _ipHostEntry = Dns.GetHostEntry(hostname);
            _ipAddress = _ipHostEntry.AddressList[0];
            _ipEndPoint = new IPEndPoint(_ipAddress, port);

            _clientSocket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            _clientSocket.Connect(_ipEndPoint);
        }

        public ICommunicator GetConnectionCommunicator()
        {
            return new SocketCommunicator(_clientSocket);
        }

        public void TerminateConnection()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }
    }
}
