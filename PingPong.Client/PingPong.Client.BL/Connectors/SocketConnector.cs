using PingPong.Client.BL.Communicators.Abstractions;
using PingPong.Client.BL.Connectors.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL.Connectors
{
    public class SocketConnector:IConnector
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
            throw new NotImplementedException();
        }

        public void TerminateConnection()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }
    }
}
