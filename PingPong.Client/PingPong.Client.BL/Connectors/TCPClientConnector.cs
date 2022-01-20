using PingPong.Client.BL.Communicators;
using PingPong.Client.BL.Communicators.Abstractions;
using PingPong.Client.BL.Connectors.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Client.BL.Connectors
{
    public class TCPClientConnector : IConnector
    {
        TcpClient _tcpClient;
        private string _hostname;
        private int _port;
        private TCPClientCommunicator _clientCommunicator;
        public TCPClientConnector(string hostname, int port)
        {
            _hostname = hostname;
            _port = port;
        }
        public void Connect()
        {
            _tcpClient = new TcpClient(_hostname, _port);
            _clientCommunicator = new TCPClientCommunicator(_tcpClient);
        }

        public ICommunicator GetConnectionCommunicator()
        {
            return _clientCommunicator;
        }

        public void TerminateConnection()
        {
            _clientCommunicator.ClientStream.Close();
            _tcpClient.Close();
        }
    }
}
