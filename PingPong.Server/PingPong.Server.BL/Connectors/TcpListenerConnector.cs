using PingPong.Server.BL.Communicators;
using PingPong.Server.BL.Communicators.Abstractions;
using PingPong.Server.BL.Connectors.Abstractions;
using PingPong.Server.BL.Listeners;
using PingPong.Server.BL.Listeners.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.BL.Connectors
{
    public class TcpListenerConnector : IConnector
    {
        private TcpListener _server;
        private IPAddress _ipAddress;
        public TcpListenerConnector(string hostname, int port)
        {
            _ipAddress = IPAddress.Parse(hostname);
            _server = new TcpListener(_ipAddress, port);
        }
        public void Connect()
        {
            GetConnectionListener().Listen();
        }

        public ICommunicator GetConnectionCommunicator()
        {
            return new TcpListenerCommunicator(_server);
        }

        public IListener GetConnectionListener()
        {
            return new TcpListenerListener(_server);
        }

        public void TerminateConnection()
        {
            _server.Stop();
        }
    }
}
